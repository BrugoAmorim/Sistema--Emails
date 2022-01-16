show databases;

create database dbemails;
use dbemails;
show tables;

create table tb_email_recebido(
id_email_recebido int primary key auto_increment,
nm_titulo varchar(50) not null,
ds_conteudo varchar(400),
ds_email_remetente varchar(50) not null,
bl_lido boolean,
dt_envio datetime not null
);

create table tb_usuario(
id_usuario int primary key auto_increment,
ds_email varchar(50) not null,
ds_senha varchar(20) not null
);

create table tb_email_enviado(
id_email_enviado int primary key auto_increment,
nm_titulo varchar(50) not null,
ds_conteudo varchar(400), 
ds_email_destinatario varchar(50) not null,
dt_envio datetime not null,
ds_email_remetente varchar(50)
);

create table tb_email_usuario(
id_email_usuario int primary key auto_increment,
id_email_recebido int not null,
id_usuario int not null,

foreign key (id_email_recebido) references tb_email_recebido (id_email_recebido),
foreign key (id_usuario) references tb_usuario (id_usuario)
);

select * from tb_usuario;
select * from tb_email_enviado;
select * from tb_email_recebido;
select * from tb_email_usuario;

insert into tb_usuario(ds_email, ds_senha)
values ("hugo@gmail.com","12345678");

insert into tb_usuario(ds_email, ds_senha)
values ("vector2021@gmail.com","peixebolagato");

insert into tb_email_enviado(nm_titulo, ds_conteudo, ds_email_destinatario, dt_envio, ds_email_remetente)
values("testanto programa", "oi, como vai?", "vector2021@gmail.com", '2021-01-01', "hugo@gmail.com");

insert into tb_email_enviado(nm_titulo, ds_conteudo, ds_email_destinatario, dt_envio, ds_email_remetente)
values("testanto programa 2", "to indo bem", "hugo@gmail.com", '2021-01-01', "vector2021@gmail.com");

insert into tb_email_recebido(nm_titulo, ds_conteudo, ds_email_remetente, bl_lido, dt_envio)
values("testando programa", "oi, como vai?", "hugo@gmail.com", false, '2021-01-01');

insert into tb_email_recebido(nm_titulo, ds_conteudo, ds_email_remetente, bl_lido, dt_envio)
values("testando programa 2", "to indo bem", "vector2021@gmail.com", false, '2021-01-01');

insert into tb_email_usuario(id_email_recebido, id_usuario)
values(1,2);

insert into tb_email_usuario(id_email_recebido, id_usuario)
values(2,1);



