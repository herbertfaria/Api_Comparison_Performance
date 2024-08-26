import { Body, Controller, Get, Param, Post } from '@nestjs/common';
import { PessoaService } from './pessoa.service';
import { PessoaDto } from './pessoa.dto';

@Controller('pessoa')
export class PessoaController {    
    constructor(private readonly pessoaService: PessoaService) {        
    }

    @Get()
   async getPessoas(){
      return await this.pessoaService.getPessoas();
    }
   
    @Get(":cpf")
    async getPessoa(@Param("cpf") cpf: string) {
      return this.pessoaService.getPessoaByCpf(cpf);
    }
   
    @Post()
    async addPessoa(@Body() pessoa: PessoaDto) {
      return this.pessoaService.createPessoa(pessoa);
    }
   
}
