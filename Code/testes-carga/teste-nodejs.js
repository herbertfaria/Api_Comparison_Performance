import http from 'k6/http';
import { sleep, check, fail } from 'k6';
import { Trend, Rate } from 'k6/metrics';

export let GetDuration = new Trend('get_customer_duration');
export let Getfail = new Trend('get_customer_fail_rate');
export let Getsuccess = new Trend('get_customer_success_rate');
export let GetReqs = new Trend('get_customer_rerqs');

export default () => {
    let request = http.get('http://localhost:3000/pessoa');

    GetDuration.add(request.timings.duration);
    GetReqs.add(1)
    Getfail.add(request.status == 0 || request.status > 399)
    Getsuccess.add(request.status < 399);

    let durationMsg = 'Max Duration ${10000/1000}s'
    if (!check(request, {
        'max duration': (r) => r.timings.duration < 10000
    })) {
        fail(durationMsg);
    }
    sleep(1);
}