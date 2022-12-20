create database Task2

use Task2

Create table Employee(
	Id int primary key identity,
	Name nvarchar(60),
	Surname nvarchar(60),
	Salary int
)

INSERT INTO Employee(Name,Surname,Salary)
VALUES ('Izzet','Rehimov',5000),
	('Afer','Rehimov',3000),
	('Orxan','Ismayýlov',2500),
	('Qehraman','Aliosmanov',500),
	('Resul','Remixanov',3240),
	('Test','Testov',10000),
	('Ibrahim','Rehimli',1430),
	('Amil','Eliosmanov',1890)


	Select * from Employee Where Id=2
	INSERT INTO Employee VALUES ('Name','Suename',200)
	Select * from Employee Where Id=6