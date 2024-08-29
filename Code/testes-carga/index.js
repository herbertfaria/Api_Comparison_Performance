import testenetjs from "/home/herbert/Documentos/net-nodes/Code/testes-carga/teste-net.js";
import testeNodejs from "/home/herbert/Documentos/net-nodes/Code/testes-carga/teste-nodejs.js";
import { group, sleep } from 'k6';

export const options = {
    vus: 10,
    iterations: 1,
    duration: '30s',
};

export default () => {
    group('.Net teste', () => {
        testenetjs();
    })
    sleep(1)
}