create database Cinema

use Cinema

Create table Language(
	Id int primary key identity,
	Name nvarchar(50) not null
)


Create table MovieKategoriya(
	Id int primary key identity,
	Name nvarchar(50) not null
)

Create table Seans(
	Id int primary key identity,
	Name nvarchar(20) not null
)

Create table Qiymet(
	Id int primary key identity,
	Price float not null,
	SeansId int not null,
	FOREIGN KEY (SeansId) REFERENCES Seans(Id)
)


Create table Saat(
	Id int primary key identity,
	Time nvarchar(30) not null,
	SeansId int not null,
	FOREIGN KEY (SeansId) REFERENCES Seans(Id)
)

--Create table Saat2(
--	Id int primary key identity,
--	Time nvarchar(30) not null,
--	SeansId int not null,
--	FOREIGN KEY (SeansId) REFERENCES Seans(Id)
--)

Create table Zal(
	Id int primary key identity,
	Name nvarchar(30) not null,
)


Create table Movie(
	Id int primary key identity,
	Name nvarchar(200) not null,
	KategoriyaId int not null,
	SeansId int not null,
	SaatId int not null,
	DilId int not null,
	PriceId int not null,
	ZalId int not null,
	FOREIGN KEY (SaatId) REFERENCES Saat(Id),
	FOREIGN KEY (SeansId) REFERENCES Seans(Id),
	FOREIGN KEY (DilId) REFERENCES Language(Id),
	FOREIGN KEY (ZalId) REFERENCES Zal(Id),
	FOREIGN KEY (KategoriyaId) REFERENCES MovieKategoriya(Id),
	FOREIGN KEY (PriceId) REFERENCES Qiymet(Id),
)




SELECT Movie.Name 'Movie Name', Seans.Name 'Seans' ,Saat.Time 'Saat', Language.Name 'Dil',Qiymet.Price 'Qiymet', MovieKategoriya.Name 'Kategoriya',
Zal.Name 'Zal kodu' FROM
dbo.Movie INNER JOIN
dbo.Qiymet ON dbo.Movie.PriceId = dbo.Qiymet.Id INNER JOIN
dbo.Language ON dbo.Movie.DilId = dbo.Language.Id INNER JOIN
dbo.MovieKategoriya ON dbo.Movie.KategoriyaId = dbo.MovieKategoriya.Id INNER JOIN
dbo.Saat ON dbo.Movie.SaatId = dbo.Saat.Id INNER JOIN
dbo.Seans ON dbo.Movie.SeansId = dbo.Seans.Id AND dbo.Qiymet.SeansId = dbo.Seans.Id AND dbo.Saat.SeansId = dbo.Seans.Id INNER JOIN
dbo.Zal ON dbo.Movie.ZalId = dbo.Zal.Id






