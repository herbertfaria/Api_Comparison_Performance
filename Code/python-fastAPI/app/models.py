from sqlalchemy import Boolean, Column, ForeignKey, Integer, String
from sqlalchemy.orm import relationship

from database import Base

class Pessoa(Base):
    __tablename__ = "pessoa"

    idade = Column(Integer)
    nome = Column(String)
    cpf = Column(String, primary_key=True)