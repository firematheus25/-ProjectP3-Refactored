create table Funcionarios
(
	FuncionariosId int identity NOT NULL,
	TipoFuncionario int,
	Nome varchar(100) NOT NULL,
	MetodoPagamento int NOT NULL,
	Cep varchar(8),
	Rua varchar(70),
	Complemento varchar(100),
	Numero varchar(5),
	Cidade varchar(70),
	Uf varchar(2),
	Bairro varchar(50),
	TipoPagamento int,
	Banco varchar(100),
	Conta varchar(8),
	Agencia varchar(4),
	Operacao varchar(3),
	Tipo varchar(30),
	AgendaId int

	Primary Key(FuncionariosId),
	Constraint fk_AgendaId foreign key (AgendaId) references AgendaPagamentos(AgendaId),
	
);


create table Comissionados
(
	ComissionadoId int identity,
	FuncionariosId int,
	Salario float,
	TaxaComissao float,

	primary key(ComissionadoId),
	Constraint fk__Comi_FuncionariosId foreign key (FuncionariosId) references Funcionarios(FuncionariosId) on delete cascade
		
);

create table Horistas
(
	HoristaId int identity,
	FuncionariosId int,
	ValorHora float,

	primary key(HoristaId),
	Constraint fk_Hor_FuncionariosId foreign key (FuncionariosId) references Funcionarios(FuncionariosId) on delete cascade

);

create table Assalariados
(
	AssalariadoId int identity,
	FuncionariosId int,
	Salario float,

	primary key(AssalariadoId),
	Constraint fk_Assa_FuncionariosId foreign key (FuncionariosId) references Funcionarios(FuncionariosId) on delete cascade

);

create table Vendas
(
	VendasId int identity,
	FuncionariosId int,
	DtVenda date,
	ValorVenda float,
	Porcentagem float,
	Comissao float,

	primary key(VendasId),
	Constraint FK_vend_FuncionariosId foreign key (funcionariosId) references Funcionarios(FuncionariosId) on delete cascade

);
create table RegistroPontos
(
	RegistroPontoId int identity,
	FuncionariosId int,
	Nome varchar(50),
	DtPonto date,
	Entrada varchar(8),
	Saida varchar(8),
	Horas varchar(8),

	Primary Key(RegistroPontoId),
	Constraint FK_RP_FuncionariosId foreign key (funcionariosId) references Funcionarios(FuncionariosId) on delete cascade
);

create table Folhas
(
	FolhasId int identity,
	FuncionariosId int,
	DtPagamento date,
	Salario float,
	MetodoPagamento int,

	Primary Key(FolhasId),
	Constraint FK_FL_FuncionariosId foreign key (funcionariosId) references Funcionarios(FuncionariosId) on delete cascade
	
);

create table Sindicatos
(
	SindicatosId int identity,
	Nome varchar(50),

	Primary Key(SindicatosId)
);

create table FuncionarioSindical
(
	FuncionarioSindicalId int identity,
	FuncionariosId int,
	SindicatosId int,
	TaxaSindical float,

	primary key (FuncionarioSindicalId),
	Constraint FK__FuncionariosId foreign key (funcionariosId) references Funcionarios(FuncionariosId) on delete cascade, 
	Constraint FK__Sindicatos foreign key (SindicatosId) references Sindicatos(SindicatosId),
);

create table TaxaServico
(
	TaxaServicoId int identity,
	FuncionarioSindicalId int,
	Competencia date,
	TaxaServico float,

	primary key(TaxaservicoId, FuncionarioSindicalId),
	Constraint FK_FuncionariosSindicalId foreign key (FuncionarioSindicalId) references FuncionarioSindical(FuncionarioSindicalId) on delete cascade

);


create table AgendaPagamentos
(
	AgendaId Int identity,
	Tipo varchar(30),
	Dia varchar(30),
	DiaSemana varchar(30),
	Agenda varchar(30)

	primary key (AgendaId)
);



create or alter view FuncionariosVw AS
select F.*,A.AssalariadoId, A.Salario,C.ComissionadoId, C.Salario AS SalarioComissao, c.TaxaComissao, H.HoristaId, H.ValorHora, R.RegistroPontoId, V.VendasId, AP.Tipo as TipoAgenda, AP.Agenda, AP.Dia, AP.DiaSemana, FS.FuncionarioSindicalId, FS.SindicatosId, FS.TaxaSindical from Funcionarios F
Left Join Assalariados A ON (F.FuncionariosId = A.FuncionariosId)
Left Join Comissionados C ON (F.FuncionariosId = C.FuncionariosId)
Left Join Horistas H ON (F.FuncionariosId = H.FuncionariosId)
Left Join RegistroPontos R ON (F.FuncionariosId = R.FuncionariosId)
Left Join Vendas V ON (F.FuncionariosId = V.FuncionariosId)
Left Join AgendaPagamentos AP ON (F.AgendaId = AP.AgendaId)
Left Join FuncionarioSindical FS ON (F.FuncionariosId = FS.FuncionariosId)


create or alter view FuncionariosVw AS
select F.*,A.AssalariadoId, A.Salario,C.ComissionadoId, C.Salario AS SalarioComissao, c.TaxaComissao, H.HoristaId, H.ValorHora, AP.Tipo as TipoAgenda, AP.Agenda, AP.Dia, AP.DiaSemana, FS.FuncionarioSindicalId, FS.SindicatosId, FS.TaxaSindical from Funcionarios F
Left Join Assalariados A ON (F.FuncionariosId = A.FuncionariosId)
Left Join Comissionados C ON (F.FuncionariosId = C.FuncionariosId)
Left Join Horistas H ON (F.FuncionariosId = H.FuncionariosId)
Left Join AgendaPagamentos AP ON (F.AgendaId = AP.AgendaId)
Left Join FuncionarioSindical FS ON (F.FuncionariosId = FS.FuncionariosId)