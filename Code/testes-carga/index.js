import testenetjs from "/home/herbert/Documentos/net-nodes/Code/testes-carga/teste-net.js";
import testeNodejs from "/home/herbert/Documentos/net-nodes/Code/testes-carga/teste-nodejs.js";
import { group, sleep } from 'k6';

// export default () => {
//     group('Nodejs teste', () => {
//         testeNodejs();
//     })
//     sleep(1)
// }
export default () => {
    group('.Net teste', () => {
        testenetjs();
    })
    sleep(1)
}