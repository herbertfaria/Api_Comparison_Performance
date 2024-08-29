import os
import uvicorn
import crud,models,schemas
from fastapi import FastAPI, Depends, HTTPException
from sqlalchemy.orm import Session

from database import SessionLocal, engine

models.Base.metadata.create_all(bind=engine)

app = FastAPI()

#Dependency
def get_db():
    db = SessionLocal()
    try : 
        yield db
    finally:
        db.close()


@app.post("/api/pessoa", response_model=schemas.Pessoa)
def create(pessoa: schemas.Pessoa, db: Session = Depends(get_db)):
    pessoaDb = crud.get_pessoa_by_cpf(db, cpf=pessoa.cpf)
    if pessoaDb:
        raise HTTPException(status_code=400, detail="Pessoa já existe")
    return crud.create_pessoa(db, pessoa=pessoa)

@app.get("/api/pessoa", response_model=list[schemas.Pessoa])
def get_pessoas(skip:int=0, limit:int=0, db:Session=Depends(get_db)):
    pessoas = crud.get_pessoas(db,skip=skip,limit=limit)
    return pessoas


@app.get("/api/pessoa/{cpf}/",response_model=schemas.Pessoa)
def get_user(cpf:str, db:Session=Depends(get_db)):
    pessoa = crud.get_pessoa_by_cpf(db, cpf = cpf )
    if pessoa is None:
        raise HTTPException(status_code=404, detail="User not found")
    return pessoa


if __name__ == "__main__":
    uvicorn.run(app, host='0.0.0.0', port=int(os.environ.get('PORT', 8080)))