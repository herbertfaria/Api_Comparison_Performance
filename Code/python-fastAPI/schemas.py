
from pydantic import BaseModel

class PessoaBase(BaseModel):
    cpf : str
    nome: str
    idade: int

class PessoaCreate(PessoaBase):
    pass


class Pessoa(PessoaBase):
    class Config:
        orm_mode = True