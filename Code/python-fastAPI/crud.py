from sqlalchemy.orm import Session

import models,schemas

def get_pessoa_by_cpf(db: Session, cpf: str):
    return db.query(models.Pessoa).filter(models.Pessoa.cpf == cpf).first()


def get_pessoas(db: Session, skip:int=0, limit:int=100):
    return db.query(models.Pessoa).offset(skip).limit(limit).all()

def create_pessoa(db: Session, pessoa:schemas.PessoaCreate):
    db_pessoa = models.Pessoa(cpf=pessoa.cpf,
                            idade=pessoa.idade,
                          nome=pessoa.nome)
    db.add(db_pessoa)
    db.commit()
    db.refresh(db_pessoa)
    return db_pessoa