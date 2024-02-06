-- Inserções para a tabela Contacts
INSERT INTO Contact (AddressNumber, Email, TelephoneNumber, Street, City, Neighborhood, State, CEP, TelephoneType) 
VALUES (123, 'contato@email.com', '123456789', 'Rua Principal', 'Cidade Principal', 'Bairro Principal', 'Estado Principal', '12345678', '1'),
       (456, 'outro_contato@email.com', '987654321', 'Rua Secundária', 'Cidade Secundária', 'Bairro Secundário', 'Estado Secundário', '87654321', '2'),
       (789, 'mais_um_contato@email.com', '456123789', 'Rua Terciária', 'Cidade Terciária', 'Bairro Terciário', 'Estado Terciário', '45678912', '1');

-- Inserções para a tabela Dealer
INSERT INTO Dealers (ContactFK, CNPJ, Name) 
VALUES (1, '12345678901234', 'Revenda A'),
       (2, '98765432109876', 'Revenda B'),
       (3, '56789012345678', 'Revenda C');

-- Inserções para a tabela Employee
INSERT INTO Employees (DealerFK, ContactFK, BaseSalary, Commission, CPF, Name, Employees) 
VALUES (1, 1, 2000.00, 1.0, '12345678901', 'Funcionário A', '1'),
       (2, 2, 2200.00, 1.0, '23456789012', 'Funcionário B', '2'),
       (3, 3, 2500.00, 0.1, '34567890123', 'Funcionário C', '3');

-- Inserções para a tabela Customer
INSERT INTO Customers (ContactFK, DealerFK, Name, CPF) 
VALUES (1, 1, 'Cliente A', '111.111.111-11'),
       (2, 2, 'Cliente B', '222.222.222-22'),
       (3, 3, 'Cliente C', '333.333.333-33');

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
