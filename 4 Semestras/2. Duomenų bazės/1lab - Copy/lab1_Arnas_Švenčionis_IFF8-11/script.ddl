--@(#) script.ddl

CREATE TABLE MIESTAS
(
	pavadinimas varchar (255) NOT NULL,
	salis varchar (255) NOT NULL,
	id_MIESTAS integer (11) NOT NULL,
	PRIMARY KEY(id_MIESTAS)
);

CREATE TABLE MOKINYS
(
	vardas varchar (255) NOT NULL,
	pavarde varchar (255) NOT NULL,
	gimimo_data date NOT NULL,
	asmens_kodas varchar (255) NOT NULL,
	telefonas varchar (255) NOT NULL,
	el_pastas varchar (255) NOT NULL,
	adresas varchar (255) NOT NULL,
	lytis varchar (255) NOT NULL,
	PRIMARY KEY(asmens_kodas)
);

CREATE TABLE KOMPANIJA
(
	pavadinimas varchar (255) NOT NULL,
	telefonas varchar (255) NOT NULL,
	el_pastas varchar (255) NOT NULL,
	id_KOMPANIJA integer (11) NOT NULL,
	fk_MIESTASid_MIESTAS integer (11) NOT NULL,
	PRIMARY KEY(id_KOMPANIJA),
	CONSTRAINT yra FOREIGN KEY(fk_MIESTASid_MIESTAS) REFERENCES MIESTAS (id_MIESTAS)
);

CREATE TABLE MOKYKLA
(
	pavadinimas varchar (255) NOT NULL,
	telefonas varchar (255) NOT NULL,
	adresas varchar (255) NOT NULL,
	el_pastas varchar (255) NOT NULL,
	tinklalapis varchar (255) NOT NULL,
	id_MOKYKLA integer (11) NOT NULL,
	fk_KOMPANIJAid_KOMPANIJA integer (11) NOT NULL,
	PRIMARY KEY(id_MOKYKLA),
	CONSTRAINT turi FOREIGN KEY(fk_KOMPANIJAid_KOMPANIJA) REFERENCES KOMPANIJA (id_KOMPANIJA)
);

CREATE TABLE MOKYTOJAS
(
	vardas varchar (255) NOT NULL,
	pavarde varchar (255) NOT NULL,
	amzius int (11) NOT NULL,
	lytis varchar (255) NOT NULL,
	asmens_kodas varchar (255) NOT NULL,
	specializacija char (7) NOT NULL,
	fk_MOKYKLAid_MOKYKLA integer (11) NOT NULL,
	PRIMARY KEY(asmens_kodas),
	CHECK(specializacija in ('rytu', 'vakaru', 'siaures', 'pietu')),
	CONSTRAINT idarbina FOREIGN KEY(fk_MOKYKLAid_MOKYKLA) REFERENCES MOKYKLA (id_MOKYKLA)
);

CREATE TABLE SUTARTIS
(
	nr int (11) NOT NULL,
	sutarties_data date NOT NULL,
	pradzios_data date NOT NULL,
	busena char (11) NOT NULL,
	fk_MOKYKLAid_MOKYKLA integer (11) NOT NULL,
	fk_MOKINYSasmens_kodas varchar (255) NOT NULL,
	PRIMARY KEY(nr),
	CHECK(busena in ('uzsakyta', 'patvirtinta', 'nutraukta', 'uzbaigta')),
	CONSTRAINT patvirtina FOREIGN KEY(fk_MOKYKLAid_MOKYKLA) REFERENCES MOKYKLA (id_MOKYKLA),
	CONSTRAINT pasiraso FOREIGN KEY(fk_MOKINYSasmens_kodas) REFERENCES MOKINYS (asmens_kodas)
);

CREATE TABLE KURSAS
(
	kalba varchar (255) NOT NULL,
	trukme_menesiais int (11) NOT NULL,
	kaina decimal (8,2) NOT NULL,
	mokiniu_skaicius int (11) NOT NULL,
	id int (11) NOT NULL,
	mokymosi_medziaga char (10) NOT NULL,
	lygis char (2) NOT NULL,
	savaites_diena char (14) NOT NULL,
	fk_MOKYTOJASasmens_kodas varchar (255) NOT NULL,
	CHECK(mokymosi_medziaga in ('internetas', 'paskaitos')),
	PRIMARY KEY(id),
	CHECK(lygis in ('A1', 'A2', 'B1', 'B2', 'C1', 'C2')),
	CHECK(savaites_diena in ('pirmadienis', 'antradienis', 'treciadienis', 'ketvirtadienis', 'penktadienis', 'sestadienis')),
	CONSTRAINT veda FOREIGN KEY(fk_MOKYTOJASasmens_kodas) REFERENCES MOKYTOJAS (asmens_kodas)
);

CREATE TABLE SASKAITA
(
	nr int (11) NOT NULL,
	data date NOT NULL,
	suma decimal (8,2) NOT NULL,
	fk_SUTARTISnr int (11) NOT NULL,
	PRIMARY KEY(nr),
	CONSTRAINT israso FOREIGN KEY(fk_SUTARTISnr) REFERENCES SUTARTIS (nr)
);

CREATE TABLE LANKOMAS_KURSAS
(
	max_mokiniu int (11) NOT NULL,
	kalba varchar (255) NOT NULL,
	lygis char (2) NOT NULL,
	id_LANKOMAS_KURSAS integer (11) NOT NULL,
	fk_SUTARTISnr int (11) NOT NULL,
	fk_KURSASid int (11) NOT NULL,
	CHECK(lygis in ('A1', 'A2', 'B1', 'B2', 'C1', 'C2')),
	PRIMARY KEY(id_LANKOMAS_KURSAS),
	CONSTRAINT ieina FOREIGN KEY(fk_SUTARTISnr) REFERENCES SUTARTIS (nr),
	CONSTRAINT lanko FOREIGN KEY(fk_KURSASid) REFERENCES KURSAS (id)
);

CREATE TABLE MOKEJIMAS
(
	data date NOT NULL,
	suma decimal (8,2) NOT NULL,
	mokejimo_tipas char (8) NOT NULL,
	id_MOKEJIMAS integer (11) NOT NULL,
	fk_MOKINYSasmens_kodas varchar (255) NOT NULL,
	fk_SASKAITAnr int (11) NOT NULL,
	CHECK(mokejimo_tipas in ('kortele', 'grynieji')),
	PRIMARY KEY(id_MOKEJIMAS),
	CONSTRAINT sumokejo FOREIGN KEY(fk_MOKINYSasmens_kodas) REFERENCES MOKINYS (asmens_kodas),
	CONSTRAINT apmoka FOREIGN KEY(fk_SASKAITAnr) REFERENCES SASKAITA (nr)
);
