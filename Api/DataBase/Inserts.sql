USE VolvoFinalProject;

INSERT INTO Contact (AddressNumber, Email, TelephoneNumber, Street, City, Neighborhood, State, CEP, TelephoneType) 
VALUES 
(123, 'joao@example.com', '1234567890', 'Rua A', 'São Paulo', 'Centro', 'SP', '01234567', 1),
(456, 'maria@example.com', '9876543210', 'Rua B', 'Rio de Janeiro', 'Copacabana', 'RJ', '21098765', 2),
(789, 'carlos@example.com', '4561237890', 'Avenida C', 'Belo Horizonte', 'Savassi', 'MG', '30123456', 1),
(1011, 'ana@example.com', '3216549870', 'Rua D', 'Brasília', 'Asa Sul', 'DF', '70312345', 3),
(1314, 'pedro@example.com', '1597532468', 'Avenida E', 'Salvador', 'Barra', 'BA', '40123456', 2),
(1617, 'lucia@example.com', '8529637410', 'Rua F', 'Fortaleza', 'Meireles', 'CE', '60123456', 1),
(1819, 'jose@example.com', '3698521470', 'Avenida G', 'Recife', 'Boa Viagem', 'PE', '51123456', 3),
(2021, 'ana.maria@example.com', '1472583690', 'Rua H', 'Porto Alegre', 'Moinhos de Vento', 'RS', '90123456', 2),
(2223, 'ricardo@example.com', '2583691470', 'Avenida I', 'Curitiba', 'Batel', 'PR', '80123456', 1),
(2425, 'patricia@example.com', '3691472580', 'Rua J', 'Manaus', 'Adrianópolis', 'AM', '69050000', 3),
(2627, 'felipe@example.com', '4567891230', 'Avenida K', 'Natal', 'Ponta Negra', 'RN', '59090000', 2),
(2829, 'camila@example.com', '6549873210', 'Rua L', 'Florianópolis', 'Centro', 'SC', '88015000', 1),
(3031, 'bruno@example.com', '9876543210', 'Avenida M', 'Goiânia', 'Setor Marista', 'GO', '74190000', 3),
(3233, 'marina@example.com', '9876541230', 'Rua N', 'Campo Grande', 'Centro', 'MS', '79002000', 2),
(3435, 'rafael@example.com', '3216549870', 'Avenida O', 'João Pessoa', 'Bessa', 'PB', '58035000', 1),
(3637, 'gabriela@example.com', '9632587410', 'Rua P', 'Vitória', 'Praia do Canto', 'ES', '29055000', 3),
(3839, 'fernando@example.com', '8529637410', 'Avenida Q', 'Aracaju', 'Atalaia', 'SE', '49038000', 2),
(4041, 'andre@example.com', '7418529630', 'Rua R', 'Cuiabá', 'Centro Sul', 'MT', '78005000', 1),
(4243, 'patricia@example.com', '1478523690', 'Avenida S', 'Teresina', 'Jóquei', 'PI', '64049000', 3),
(4445, 'marcio@example.com', '3698521470', 'Rua T', 'Boa Vista', 'Centro', 'RR', '69301000', 2);

INSERT INTO Dealers (ContactFK, CNPJ, Name) 
VALUES 
(1, '12345678000101', 'Dicave'),
(2, '98765432000102', 'Lapônia'),
(3, '45612378000103', 'Nórdica'),
(4, '32165498000104', 'Gotemburgo'),
(5, '15975324000105', 'Auto Sueco São Paulo'),
(6, '85296374000106', 'Dipesul'),
(7, '36985214000107', 'Suécia'),
(8, '14725836000108', 'Tracbel NO'),
(9, '25836914000109', 'Treviso'),
(10, '36914725000110', 'Rivesa'),
(11, '45612378000111', 'Luvep'),
(12, '65498732000112', 'Auto Sueco Centro Oeste'),
(13, '98765432000113', 'Tracbel NE');

INSERT INTO Employees (DealerFK, ContactFK, Salary, BaseSalary, Commission, CPF, Name, Employees) 
VALUES 
(1, 1, 0, 3000.00, 1, '12345678901', 'João Silva', 1),
(2, 2, 0, 2800.00, 1, '23456789012', 'Maria Santos', 2),
(3, 3, 0, 3200.00, 0.1, '34567890123', 'Carlos Oliveira', 3),
(4, 4, 0, 2700.00, 1, '45678901234', 'Ana Souza', 1),
(5, 5, 0, 2900.00, 1, '56789012345', 'Pedro Rodrigues', 2),
(6, 6, 0, 3100.00, 0.1, '67890123456', 'Lucia Pereira', 3),
(7, 7, 0, 3000.00, 1, '78901234567', 'Jose Santos', 1),
(8, 8, 0, 2800.00, 1, '89012345678', 'Ana Maria Oliveira', 2),
(9, 9, 0, 3200.00, 0.1, '90123456789', 'Ricardo Almeida', 3),
(10, 10, 0, 2700.00, 1, '01234567890', 'Patricia Lima', 1),
(11, 11, 0, 2900.00, 1, '12345678901', 'Felipe Barbosa', 2),
(12, 12, 0, 3100.00, 0.1, '23456789012', 'Camila Souza', 3),
(13, 13, 0, 3000.00, 1, '34567890123', 'Bruno Oliveira', 1),
(1, 14, 0, 2800.00, 1, '45678901234', 'Marina Silva', 2),
(2, 15, 0, 3200.00, 0.1, '56789012345', 'Rafael Rodrigues', 3),
(3, 16, 0, 2700.00, 1, '67890123456', 'Gabriela Pereira', 1),
(4, 17, 0, 2900.00, 1, '78901234567', 'Fernando Santos', 2),
(5, 18, 0, 3100.00, 0.1, '89012345678', 'Andre Oliveira', 3),
(6, 19, 0, 3000.00, 1, '90123456789', 'Patricia Lima', 1),
(7, 20, 0, 3300.00, 1, '01234567890', 'Marcio Barbosa', 2);


INSERT INTO Services (DealerFK, EmployeeFK, Value, Date, Situation) 
VALUES 
(1, 1, 1500.00, '05-01-2024 08:30:00', 2),
(2, 2, 1800.00, '06-01-2024 09:45:00', 2),
(3, 3, 2000.00, '07-01-2024 10:15:00', 2),
(4, 4, 1700.00, '08-01-2024 11:00:00', 2),
(5, 5, 1900.00, '09-01-2024 13:30:00', 2),
(6, 6, 1600.00, '10-01-2024 14:45:00', 2),
(7, 7, 2200.00, '11-01-2024 15:00:00', 2),
(8, 8, 2300.00, '12-01-2024 16:20:00', 2),
(9, 9, 2100.00, '13-01-2024 08:00:00', 2),
(10, 10, 1750.00, '14-01-2024 09:10:00', 2),
(11, 11, 1950.00, '15-01-2024 10:30:00', 2),
(12, 12, 1650.00, '16-01-2024 12:00:00', 2),
(13, 13, 1850.00, '17-01-2024 13:15:00', 2),
(1, 14, 2050.00, '18-01-2024 14:45:00', 2),
(2, 15, 1750.00, '19-01-2024 15:20:00', 2),
(3, 16, 1950.00, '20-01-2024 16:40:00', 2),
(4, 17, 1850.00, '21-01-2024 08:30:00', 2),
(5, 18, 2150.00, '22-01-2024 09:50:00', 2),
(6, 19, 2250.00, '23-01-2024 11:10:00', 2),
(7, 20, 2350.00, '24-01-2024 13:00:00', 2);

INSERT INTO CategoryServices (ServiceFK, ExecutionTime, Category) 
VALUES 
(1, 6, 3),
(2, 18, 7),
(3, 12, 1),
(4, 9, 9),
(5, 22, 4),
(6, 3, 6),
(7, 15, 8),
(8, 20, 2),
(9, 14, 5),
(10, 11, 11),
(11, 7, 1),
(12, 21, 10),
(13, 2, 2),
(14, 23, 3),
(15, 5, 7),
(16, 6, 4),
(17, 12, 9),
(18, 9, 6),
(19, 20, 8),
(20, 4, 1);

INSERT INTO Part (CategoryServiceFK, Quantity, Value, Availability, Name, Location) 
VALUES 
(1, 10, 50.00, 'In stock', 'Motor', 'Prateleira A1'),
(2, 15, 30.00, 'In stock', 'Transmissão', 'Prateleira B2'),
(3, 20, 25.00, 'In stock', 'Embreagem', 'Prateleira C3'),
(4, 12, 40.00, 'In stock', 'Freios', 'Prateleira D4'),
(5, 8, 60.00, 'In stock', 'Radiador', 'Prateleira E5'),
(6, 5, 70.00, 'In stock', 'Alternador', 'Prateleira F6'),
(7, 18, 35.00, 'In stock', 'Bateria', 'Prateleira G7'),
(8, 14, 45.00, 'In stock', 'Filtro de ar', 'Prateleira H8'),
(9, 22, 20.00, 'In stock', 'Velas de ignição', 'Prateleira I9'),
(10, 16, 55.00, 'In stock', 'Bomba de combustível', 'Prateleira J10'),
(11, 11, 65.00, 'In stock', 'Direção hidráulica', 'Prateleira K11'),
(12, 9, 75.00, 'In stock', 'Compressor de ar', 'Prateleira L12'),
(13, 23, 40.00, 'In stock', 'Válvulas', 'Prateleira M13'),
(14, 7, 80.00, 'In stock', 'Pistões', 'Prateleira N14'),
(15, 17, 35.00, 'In stock', 'Amortecedores', 'Prateleira O15'),
(16, 10, 50.00, 'In stock', 'Eixo traseiro', 'Prateleira P16'),
(17, 13, 30.00, 'In stock', 'Correia', 'Prateleira Q17'),
(18, 19, 25.00, 'In stock', 'Turbocompressor', 'Prateleira R18'),
(19, 25, 20.00, 'In stock', 'Radiador de óleo', 'Prateleira S19'),
(20, 18, 45.00, 'In stock', 'Junta do cabeçote', 'Prateleira T20');

INSERT INTO Customers (ContactFK, DealerFK, Name, CPF) 
VALUES 
(1, 5, 'José da Silva', '12345678901'),
(2, 9, 'Maria Oliveira', '23456789012'),
(3, 2, 'Carlos Santos', '34567890123'),
(4, 11, 'Ana Pereira', '45678901234'),
(5, 7, 'João Souza', '56789012345'),
(6, 10, 'Luiza Almeida', '67890123456'),
(7, 3, 'Fernanda Lima', '78901234567'),
(8, 13, 'Ricardo Martins', '89012345678'),
(9, 6, 'Amanda Silva', '90123456789'),
(10, 8, 'Gabriel Oliveira', '01234567890'),
(11, 4, 'Isabela Costa', '12345678901'),
(12, 1, 'Daniel Rodrigues', '23456789012'),
(13, 12, 'Laura Nunes', '34567890123'),
(14, 3, 'Felipe Pereira', '45678901234'),
(15, 11, 'Juliana Santos', '56789012345'),
(16, 9, 'Mariana Almeida', '67890123456'),
(17, 5, 'Paulo Souza', '78901234567'),
(18, 10, 'Camila Lima', '89012345678'),
(19, 2, 'Eduardo Martins', '90123456789'),
(20, 7, 'Aline Silva', '01234567890');

INSERT INTO Vehicles (CustomerFK, ChassisNumber, Year, Value, Kilometrage, Model, Color, SystemVersion) 
VALUES 
(1, 123456, 2020, 150000.00, 50000.00, 'FH16', 'Blue', 'VOLVO FH16 D13A'),
(2, 234567, 2019, 140000.00, 55000.00, 'FH', 'Red', 'VOLVO FH D13K'),
(3, 345678, 2021, 160000.00, 60000.00, 'FM', 'Yellow', 'VOLVO FM D11K'),
(4, 456789, 2018, 130000.00, 45000.00, 'FH460', 'Green', 'VOLVO FH460 D13C'),
(5, 567890, 2020, 155000.00, 48000.00, 'FH500', 'White', 'VOLVO FH500 D13D'),
(6, 678901, 2019, 145000.00, 52000.00, 'FMX', 'Black', 'VOLVO FMX D11E'),
(7, 789012, 2021, 165000.00, 58000.00, 'FH520', 'Gray', 'VOLVO FH520 D13E'),
(8, 890123, 2018, 135000.00, 49000.00, 'FM370', 'Silver', 'VOLVO FM370 D11F'),
(9, 901234, 2020, 152000.00, 51000.00, 'FH540', 'Orange', 'VOLVO FH540 D13G'),
(10, 123012, 2019, 142000.00, 54000.00, 'FM460', 'Brown', 'VOLVO FM460 D11H'),
(11, 234123, 2021, 162000.00, 59000.00, 'FMX460', 'Beige', 'VOLVO FMX460 D13I'),
(12, 345234, 2018, 132000.00, 46000.00, 'FH480', 'Purple', 'VOLVO FH480 D13J'),
(13, 456345, 2020, 157000.00, 49000.00, 'FM370', 'Cyan', 'VOLVO FM370 D11K'),
(14, 567456, 2019, 147000.00, 53000.00, 'FMX370', 'Magenta', 'VOLVO FMX370 D11L'),
(15, 678567, 2021, 167000.00, 59000.00, 'FH500', 'Lime', 'VOLVO FH500 D13M'),
(16, 789678, 2018, 137000.00, 48000.00, 'FH540', 'Turquoise', 'VOLVO FH540 D13N'),
(17, 890789, 2020, 154000.00, 52000.00, 'FM460', 'Navy', 'VOLVO FM460 D11O'),
(18, 901890, 2019, 144000.00, 56000.00, 'FH460', 'Teal', 'VOLVO FH460 D13P'),
(19, 123901, 2021, 164000.00, 60000.00, 'FMX460', 'Maroon', 'VOLVO FMX460 D11Q'),
(20, 234012, 2018, 134000.00, 47000.00, 'FH500', 'Olive', 'VOLVO FH500 D13R');

INSERT INTO Bills (CustomerFK, ServiceFK, Amount) 
VALUES 
(1, 1, 0),
(2, 2, 0),
(3, 3, 0),
(4, 4, 0),
(5, 5, 0),
(6, 6, 0),
(7, 7, 0),
(8, 8, 0),
(9, 9, 0),
(10, 10, 0),
(11, 11, 0),
(12, 12, 0),
(13, 13, 0),
(14, 14, 0),
(15, 15, 0),
(16, 16, 0),
(17, 17, 0),
(18, 18, 0),
(19, 19, 0),
(20, 20, 0);

SELECT * FROM Bills;
SELECT * FROM CategoryServices;
SELECT * FROM Contact;
SELECT * FROM Customers;
SELECT * FROM Dealers;
SELECT * FROM Employees;
SELECT * FROM Part;
SELECT * FROM Services;
SELECT * FROM Vehicles;