drop database LoginCore;

create database LoginCore;
use LoginCore;

create table Cliente
(
Id int auto_increment primary key,
Nome Varchar(50) not null,
Nascimento DateTime not null,
Sexo char(1),
CPF Varchar(11) not null,
Telefone Varchar(14) not null,
Email Varchar(50) not null,
Senha Varchar(8) not null,
Situacao char(1) not null
);

create table Colaborador
(
Id int auto_increment primary key,
Nome Varchar(50) not null,
CPF Varchar(11) not null,
Email Varchar(50) not null,
Senha Varchar(8) not null,
Tipo Varchar(8) not null,
Telefone Varchar(11) not null
);

insert into Cliente values (default, "Laura", "2008-10-03", "F", "12312312300", "11940407912", "lauraxavier@gmail.com", "12345678", "A");

select * from Cliente;
select * from Colaborador;

insert into Colaborador values(default, "Arthut", 45645645600, "arthur@gmail.com", "12345678", "G", "11988252332");