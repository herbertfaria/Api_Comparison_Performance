CREATE TABLE IF NOT EXISTS Pessoa (
    Idade INTEGER,
    Nome VARCHAR(80),
    CPF VARCHAR(11)
)

INSERT INTO Pessoa (Idade, Nome, CPF) VALUES (10,'Pessoa Jaca', '00000000001')
,(11,'Pessoa Jaca', '00000000002')
,(12,'Pessoa Jaca', '00000000003');

SELECT * FROM Pessoa