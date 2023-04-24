-- Tworzenie tabel (komendy CREATE TABLE) i ich zale¿noœci (klucze, komendy ALTER TABLE)

-- Nie ma booleanów w tabeli Zamowienia: czy_oplacone oraz czy_zrealizowane bo wystarczy sprawdziæ czy daty s¹ null.

CREATE TABLE Kategoria (
	id INT NOT NULL,
	nazwa VARCHAR(255) NOT NULL
);

ALTER TABLE Kategoria ADD CONSTRAINT kategoria_pk PRIMARY KEY ( id );

CREATE TABLE Rola (
	id INT NOT NULL,
	nazwa_roli VARCHAR(255) NOT NULL
);

ALTER TABLE Rola ADD CONSTRAINT rola_pk PRIMARY KEY ( id );

CREATE TABLE Dostawa (
	id INT NOT NULL,
	sposob_dostawy VARCHAR(255) NOT NULL,
	cena FLOAT NOT NULL
);

ALTER TABLE Dostawa ADD CONSTRAINT dostawa_pk PRIMARY KEY ( id );

CREATE TABLE Uzytkownik (
	id INT NOT NULL,
	adres_email VARCHAR(255) NOT NULL,
	haslo VARCHAR(255) NOT NULL,
	adres_ulica VARCHAR(255),
	adres_kod_budynku INT NOT NULL,
	adres_kod_mieszkania INT,
	adres_miejscowosc VARCHAR(255) NOT NULL,
	adres_kod_pocztowy VARCHAR(255) NOT NULL,
	numer_telefonu INT NOT NULL,
	imie VARCHAR(255) NOT NULL,
	nazwisko VARCHAR(255) NOT NULL,
	czy_aktywny INT NOT NULL,
	id_roli INT NOT NULL
);

ALTER TABLE Uzytkownik ADD CONSTRAINT uzytkownik_pk PRIMARY KEY ( id );

ALTER TABLE Uzytkownik ADD CONSTRAINT uzytkownik_rola_fk FOREIGN KEY ( id_roli ) REFERENCES Rola ( id );

CREATE TABLE Zamowienie (
	id INT NOT NULL,
	cena_zamowienia FLOAT NOT NULL,
	koszt_wysylki FLOAT NOT NULL,
	data_zlozenia_zamowienia DATE NOT NULL,
	--czy_oplacone INT NOT NULL,
	data_przyjecia_zamowienia DATE,
	--czy_zrealizowano INT NOT NULL,
	data_zrealizowania_zamowienia DATE,
	id_uzytkownika INT NOT NULL,
	id_dostawy INT NOT NULL
);

ALTER TABLE Zamowienie ADD CONSTRAINT zamowienie_pk PRIMARY KEY ( id );

ALTER TABLE Zamowienie ADD CONSTRAINT zamowienie_uzytkownik_fk FOREIGN KEY ( id_uzytkownika ) REFERENCES Uzytkownik ( id );

ALTER TABLE Zamowienie ADD CONSTRAINT zamowienie_dostawa_fk FOREIGN KEY ( id_dostawy ) REFERENCES Dostawa ( id );

CREATE TABLE Produkt (
	id INT NOT NULL,
	nazwa_produktu VARCHAR(255) NOT NULL,
	czy_skladnik INT NOT NULL,
	pozycja_w_konfiguracji INT NOT NULL,
	opis VARCHAR(255) NOT NULL,
	cena_brutto FLOAT NOT NULL,
	cena_netto FLOAT NOT NULL,
	ilosc INT NOT NULL,
	id_kategorii INT NOT NULL
);

ALTER TABLE Produkt ADD CONSTRAINT produkt_pk PRIMARY KEY ( id );

ALTER TABLE Produkt ADD CONSTRAINT produkt_kategoria_fk FOREIGN KEY ( id_kategorii ) REFERENCES Kategoria ( id );

CREATE TABLE Zdjecie (
	id INT NOT NULL,
	nazwa VARCHAR(255) NOT NULL,
	jpg VARCHAR(255) NOT NULL,
	data_dodania DATE NOT NULL,
	id_produktu INT NOT NULL
);

ALTER TABLE Zdjecie ADD CONSTRAINT zdjecie_pk PRIMARY KEY ( id );

ALTER TABLE Zdjecie ADD CONSTRAINT zdjecie_produkt_fk FOREIGN KEY ( id_produktu ) REFERENCES Produkt ( id );

CREATE TABLE Towar (
	id INT NOT NULL,
	id_produktu INT NOT NULL,
	id_zamowienia INT NOT NULL
);

ALTER TABLE Towar ADD CONSTRAINT towar_pk PRIMARY KEY ( id );

ALTER TABLE Towar ADD CONSTRAINT towar_produkt_fk FOREIGN KEY ( id_produktu ) REFERENCES Produkt ( id );

ALTER TABLE Towar ADD CONSTRAINT towar_zamowienie_fk FOREIGN KEY ( id_zamowienia ) REFERENCES Zamowienie ( id );