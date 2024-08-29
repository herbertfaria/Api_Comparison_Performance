import { group, sleep, check, fail } from 'k6';
import http from 'k6/http';
import { Trend, Rate } from 'k6/metrics';

export const options = {
    vus: 10,
    duration: '30s',
};

const data = JSON.parse(open("./data.json"));
var count = 0;

export default () => {
    
    group('01. Create Pessoa - Net 8', () => {
        const payload = 
        {
            cpf: data[count].CPF,
            nome: data[count].Nome,
            idade: data[count].Idade
        }
        
        count++;
        const request = http.post("http://localhost:8080/pessoa", JSON.stringify(payload),{
            headers: { 'Content-Type': 'application/json' },
          });
        check(request, { 'Create Pessoa  status': (r) => r.status === 200 }); 
    });
}