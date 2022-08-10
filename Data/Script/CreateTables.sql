/*
create table restaurantes (
	idRestaurante INT NOT NULL AUTO_INCREMENT,
    nomeRestaurante varchar(100) not null,
    c int not null,
    primary key (idRestaurante)
);
create table usuarios (
	idUsuario INT NOT NULL AUTO_INCREMENT,
    nomeUsuario varchar(100) not null,
    codigoUsuario int not null,
    primary key (idUsuario)
);
create table votos (
	idVoto INT NOT NULL AUTO_INCREMENT,
    idUsuario varchar(100) not null,
    idRestaurante int not null,
    horaVoto varchar(20) not null,
    primary key (idVoto)
);
*/