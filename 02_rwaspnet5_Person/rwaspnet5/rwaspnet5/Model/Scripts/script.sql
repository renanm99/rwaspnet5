create database rest_with_asp_net_udemy
go
use rest_with_asp_net_udemy
go

alter login sa ENABLE
go
alter login sa with PASSWORD = 'sa@localdbapp1'
go
CREATE TABLE person(
    id bigint not null identity,
    first_name varchar(80) not null,
    last_name varchar(80)not null,
    address varchar(100) not null,
    gender varchar(6) not null
    PRIMARY key(id)    
)
go
insert into dbo.person values('Renan','Machado','São Paulo','Male')