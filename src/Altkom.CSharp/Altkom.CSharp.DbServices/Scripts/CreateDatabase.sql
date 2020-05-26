create table dbo.Products
(
	[ProductId] int primary key identity(1,1),
	[Name] nvarchar(100) not null,
	[UnitPrice] decimal not null,
	[Color] nvarchar(50) null,
	[Weight] float not null
)

insert into dbo.Products
	values
		('Maseczka', 9.99, 'black', 100),
		('Plyn dezynfekujacy', 59.99, 'transparent', 1000),
		('Przylbica', 19.99, 'white', 20)

select * from dbo.Products
