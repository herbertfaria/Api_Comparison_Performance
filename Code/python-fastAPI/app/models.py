from sqlalchemy import Boolean, Column, ForeignKey, Integer, String
from sqlalchemy.ext.declarative import declarative_base

Base = declarative_base()

class Pessoa(Base):
    __tablename__ = "pessoa"

    idade = Column(Integer)
    nome = Column(String)
    cpf = Column(String, primary_key=True)