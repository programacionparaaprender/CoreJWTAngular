### FBTarjetas 3.1
dotnet new angular -o FBTarjeta -f netcoreapp3.1

### FBTarjetas 6.0
dotnet new angular -o FBTarjeta6 -f net6.0

### FBTarjetas66 6.0 para angular
dotnet new angular -o FBTarjeta66 -f net6.0

### FBTarjetas7 7.0 para angular
dotnet new angular -o FBTarjeta7 -f net7.0


dotnet new sln
dotnet sln add .\FBTarjeta\FBTarjeta.csproj
dotnet sln add .\Common\Common.csproj
dotnet sln add .\Models\Models.csproj
dotnet sln add FBTarjeta7/FBTarjeta7.csproj

ng add @angular/cdk @angular/http


### documentaci�n de swagger
https://docs.microsoft.com/es-es/aspnet/core/tutorials/getting-started-with-swashbuckle?view=aspnetcore-3.1&tabs=visual-studio

### visualizar swagger
https://localhost:44372/swagger/index.html
https://localhost:44372/swagger/v1/swagger.json


## trabajar tokens
https://www.c-sharpcorner.com/article/implement-jwt-in-asp-net-core-3-1/



https://www.udemy.com/course/aprende-haciendo-crea-tu-api-en-net-core-y-tu-app-en-ionic-4/learn/lecture/14567318#overview
https://gitlab.com/tom07/noticiasapi/
https://docs.microsoft.com/es-es/ef/core/querying/raw-sql

dotnet add package System.Data.SqlClient



CREATE DATABASE Noticias
GO
USE Noticias
GO

create table Nombres(
    NombreID int primary key identity(1,1),
    Nombre varchar(120),
	edad int
);

Create Table Noticia(
	NoticiaID int primary key identity(1,1),
	Titulo varchar(120),
	Descripcion varchar(200),
	Contenido varchar(max),
	Fecha Datetime,
	AutorID int
)
GO
Create Table Autor(
	AutorID int primary key identity(1,1),
	Nombre Varchar(100),
	Apellido Varchar(100)
)
go
insert into 
dbo.Autor(Nombre,Apellido)
values
('Luis','Correa')

insert into 
dbo.Noticia(Titulo,Descripcion,Contenido,Fecha,AutorID)
values
('Curso ionic 1','Descrripción','información de contenido',getdate(),1)

insert into 
dbo.Noticia(Titulo,Descripcion,Contenido,Fecha,AutorID)
values
('Curso ionic 2','Descrripción','información de contenido',getdate(),1)

insert into 
dbo.Noticia(Titulo,Descripcion,Contenido,Fecha,AutorID)
values
('Curso ionic 3','Descrripción','información de contenido',getdate(),1)

go

create procedure spSinValoresDesdeProcedimiento
@Edad int,
@Nombre varchar(100)
as
begin
update Nombres set edad = @edad where nombre like '%' +@Nombre+ '%';
end

go

create procedure spValoresDesdeProcedimiento
@edad int,
@nombre varchar(100)
as
begin
select NombreID, Nombre from Nombres where edad = @edad 
and  Nombre like '%' +@nombre+'%';
end


https://codepen.io/arsinak/pen/eFDGw/

>- Install-Package Microsoft.EntityFrameworkCore
>- Install-Package Microsoft.EntityFrameworkCore.SqlServer
>- Install-Package Microsoft.EntityFrameworkCore.Tools -Version 3.1.6

PM> add-migration v.6.0.0
PM> add-migration v.7.0.0
PM> add-migration v.8.0.0
PM> update-database



https://aka.ms/dotnet-core-applaunch?framework=Microsoft.NETCore.App&framework_version=3.1.32&arch=x64&rid=win10-x64

https://www.connectionstrings.com/sqlconnection/




### autentication
>- https://jasonwatmore.com/post/2021/12/14/net-6-jwt-authentication-tutorial-with-example-api

### Migrar core 5 a 6
>- https://learn.microsoft.com/en-us/aspnet/core/migration/50-to-60-samples?view=aspnetcore-7.0


### vue error
>- https://stackoverflow.com/questions/70346829/eslint-vue-multiword-components
>- https://stackoverflow.com/questions/70083042/eslint-parsing-error-unexpected-token
>- npm i @typescript-eslint/eslint-plugin

