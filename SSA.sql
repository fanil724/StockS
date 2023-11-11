CREATE DATABASE Stock


CREATE TABLE Product(
	id int primary key identity(1,1),
	ProdName varchar(20) not null,
	SupplierID int not null foreign key references Supplier(id),
	TypeID int not null foreign key references Typess(id),
	Quantity int not null,
	Cost money not null,
	DiliveryDate date not null
)

CREATE TABLE Typess(
	id int primary key identity(1,1),
	ProductType varchar(20) not null
)

CREATE TABLE Supplier(
	id int primary key identity(1,1),
	City varchar(20) not null,
	Phone bigint not null
) 



INSERT INTO Typess VALUES('Cereals'),('spare parts'),('office'),('electrical'),('liquid')

INSERT INTO Supplier VALUES('Kazan',8945123456),('Moscow',8789456123),('Tokio',897869454),('Rim',4897654357687)

INSERT INTO Product VALUES('Nasos',4,9,569,102.23,'2023-08-21')


SELECT pc.id, pc.ProdName, s.City, t.ProductType,pc.Quantity, pc.Cost, pc.DiliveryDate
FROM Product pc join Typess t on t.id=pc.TypeID join Supplier s on s.id=pc.SupplierID
WHERE pc.DiliveryDate>(GETDATE()-11)


SELECT pc.id, pc.ProdName, s.City, t.ProductType,pc.Quantity, pc.Cost, pc.DiliveryDate
FROM Product pc join Typess t on t.id=pc.TypeID join Supplier s on s.id=pc.SupplierID
WHERE s.City like (
SELECT s.City FROM Supplier s
join Product p on p.SupplierID=s.id
GROUP BY s.City
HAVING SUM(p.Quantity) =(SELECT MIN(t.QUN) FROM
(SELECT SUM(p.Quantity) as QUN FROM Supplier s
join Product p on p.SupplierID=s.id
GROUP BY City) t)
)

