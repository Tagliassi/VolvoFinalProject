-- Inserções para a tabela Contacts
INSERT INTO Contact (AddressNumber, Email, TelephoneNumber, Street, City, Neighborhood, State, CEP, TelephoneType) 
VALUES 
  (101, 'contato1@email.com', '111111111', 'Rua Contato 1', 'Cidade Contato 1', 'Bairro Contato 1', 'Estado Contato 1', '12345000', '1'),
  (102, 'contato2@email.com', '222222222', 'Rua Contato 2', 'Cidade Contato 2', 'Bairro Contato 2', 'Estado Contato 2', '22345000', '2'),
  (103, 'contato3@email.com', '333333333', 'Rua Contato 3', 'Cidade Contato 3', 'Bairro Contato 3', 'Estado Contato 3', '32345000', '1'),
  (104, 'contato4@email.com', '444444444', 'Rua Contato 4', 'Cidade Contato 4', 'Bairro Contato 4', 'Estado Contato 4', '42345000', '2'),
  (105, 'contato5@email.com', '555555555', 'Rua Contato 5', 'Cidade Contato 5', 'Bairro Contato 5', 'Estado Contato 5', '52345000', '1'),
  (106, 'contato6@email.com', '666666666', 'Rua Contato 6', 'Cidade Contato 6', 'Bairro Contato 6', 'Estado Contato 6', '62345000', '2'),
  (107, 'contato7@email.com', '777777777', 'Rua Contato 7', 'Cidade Contato 7', 'Bairro Contato 7', 'Estado Contato 7', '72345000', '1'),
  (108, 'contato8@email.com', '888888888', 'Rua Contato 8', 'Cidade Contato 8', 'Bairro Contato 8', 'Estado Contato 8', '82345000', '2'),
  (109, 'contato9@email.com', '999999999', 'Rua Contato 9', 'Cidade Contato 9', 'Bairro Contato 9', 'Estado Contato 9', '92345000', '1');

-- Inserções para a tabela Dealer
INSERT INTO Dealers (ContactFK, CNPJ, Name) 
VALUES (1, '12345678901234', 'Revenda A'),
       (3, '34567890123456', 'Revenda B'),
       (5, '56789012345678', 'Revenda C');

-- Inserções para a tabela Employee
INSERT INTO Employees (DealerFK, ContactFK, BaseSalary, Commission, CPF, Name, Employees) 
VALUES (1, 2, 2000.00, 1.0, '12345678901', 'Funcionário A', '1'),
       (2, 4, 2200.00, 1.0, '23456789012', 'Funcionário B', '2'),
       (3, 6, 2500.00, 0.1, '34567890123', 'Funcionário C', '3');

-- Inserções para a tabela Customer
INSERT INTO Customers (ContactFK, DealerFK, Name, CPF) 
VALUES (7, 1, 'Cliente A', '111.111.111-11'),
       (9, 2, 'Cliente B', '222.222.222-22'),
       (8, 3, 'Cliente C', '333.333.333-33');

-- Inserções para a tabela Vehicle
INSERT INTO Vehicles (CustomerFK, ChassisNumber, Year, Value, Kilometrage, Model, Color, SystemVersion) 
VALUES (1, 123456, 2020, 50000.00, 10000.00, 'Modelo A', 'Azul', 'Versão 1.0'),
       (2, 789012, 2021, 60000.00, 15000.00, 'Modelo B', 'Vermelho', 'Versão 1.1'),
       (3, 345678, 2019, 45000.00, 20000.00, 'Modelo C', 'Preto', 'Versão 1.2');

-- Inserções para a tabela Service
INSERT INTO Services (DealerFK, EmployeeFK, Value, Date, Situation) 
VALUES (1, 1, 100.00, '2023-01-01', '1'),
       (2, 2, 150.00, '2023-02-02', '1'),
       (3, 3, 200.00, '2023-03-03', '1');

-- Inserções para a tabela CategoryService
INSERT INTO CategoryServices (ServiceFK, ExecutionTime, Category) 
VALUES (1, 60, 1),
       (2, 90, 2),
       (3, 120, 3);

-- Inserções para a tabela Parts
INSERT INTO Part (CategoryServiceFK, Quantity, Value, Availabity, Name, Location) 
VALUES (1, 5, 50.00, 'Disponível', 'Peça A', 'Localização A'),
       (2, 3, 75.00, 'Disponível', 'Peça B', 'Localização B'),
       (3, 8, 30.00, 'Disponível', 'Peça C', 'Localização C');

-- Inserções para a tabela Bill
INSERT INTO Bills (CustomerFK, ServiceFK, Amount) 
VALUES (1, 1, 100.00),
       (2, 2, 150.00),
       (3, 3, 200.00);
