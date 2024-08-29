
from pydantic import BaseModel

class PessoaBase(BaseModel):    
    nome: str
    idade: int

class PessoaCreate(PessoaBase):
    pass


class Pessoa(PessoaBase):
    cpf : str
    class Config:
        orm_mode = True

