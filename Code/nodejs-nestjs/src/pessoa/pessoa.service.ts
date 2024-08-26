import { Injectable, OnModuleInit } from '@nestjs/common';
import { PrismaClient } from '@prisma/client';
import { PessoaDto } from './pessoa.dto';

@Injectable()
export class PessoaService extends PrismaClient implements OnModuleInit {
    async onModuleInit() {
        await this.$connect();
    }

    getPessoas() {
        return this.pessoa.findMany();
    }

    getPessoaByCpf(cpf: string) {
        return this.pessoa.findUnique({ where: { cpf: cpf } });
    }

    async createPessoa(pessoa: PessoaDto) {
        return this.pessoa.create({ data: {
            cpf: pessoa.cpf,
            idade: pessoa.idade,
            nome: pessoa.nome
        } });
    }
}
