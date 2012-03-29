use master;
go
DROP DATABASE db_MERP;
go
CREATE DATABASE db_MERP;
go
Use db_MERP;

CREATE TABLE tbl_Prd( 
Prd# INTEGER PRIMARY KEY NOT NULL IDENTITY(1,1),
PrdNumber INTEGER,
PrdName VARCHAR(30),
PrdEAN VARCHAR(13),
PrdPricePurchase FLOAT,
PrdPriceSale FLOAT,
PrdPrdcat# INTEGER,
PrdSup# INTEGER,

)

CREATE TABLE tbl_Prdcat(
Prdcat# INTEGER PRIMARY KEY NOT NULL IDENTITY(1,1),
PrdcatNumber INTEGER,
PrdcatName VARCHAR(30),
)



CREATE TABLE tbl_Cus(
Cus# INTEGER PRIMARY KEY IDENTITY(1,1), 
CusNumber INTEGER,
CusFirstname VARCHAR(75),
CusLastname VARCHAR(75),
CusContactname VARCHAR(75),
CusUsr# INTEGER,
CusIscompany BIT
)


CREATE TABLE tbl_Sup(
Sup# INTEGER PRIMARY KEY IDENTITY(1,1), 
SupNumber INTEGER,
SupFirstname VARCHAR(75),
SupLastname VARCHAR(75),
SupContactname VARCHAR(75),
SupUsr# INTEGER,
SupIscompany BIT
)

CREATE TABLE tbl_Usr(
Usr# INTEGER PRIMARY KEY NOT NULL IDENTITY(1,1),
UsrNumber INTEGER NOT NULL,
UsrIdent VARCHAR(3) NOT NULL,
UsrName VARCHAR(30) NOT NULL,
UsrIsEmployer BIT, 
UsrPassword VARCHAR(32) NOT NULL,
UsrLogedin BIT NOT NULL
)

CREATE TABLE tbl_Sah(
Sah# INTEGER PRIMARY KEY IDENTITY(1,1),
SahNumber INTEGER, 
SahCus# INTEGER,
SahCreatedate DATETIME
)

CREATE TABLE tbl_Puh(
Puh# INTEGER PRIMARY KEY IDENTITY(1,1),
PuhNumber INTEGER, 
PuhSup# INTEGER,
PuhCreatedate DATETIME
)

CREATE TABLE tbl_Pui(
Pui# INTEGER PRIMARY KEY IDENTITY(1,1),
PuiNumber INTEGER,
PuiPuh# INTEGER,
PuiPrd# INTEGER,
Puivat FLOAT,
Puidiscount FLOAT
)

CREATE TABLE tbl_Sai(
Sai# INTEGER PRIMARY KEY IDENTITY(1,1),
SaiNumber INTEGER,
SaiSah# INTEGER,
SaiPrd# INTEGER,
Saivat FLOAT,
Saidiscount FLOAT
)	




ALTER TABLE tbl_Prd ADD FOREIGN KEY (PrdPrdcat#) REFERENCES tbl_Prdcat(Prdcat#);
ALTER TABLE tbl_Prd ADD FOREIGN KEY (PrdSup#) REFERENCES tbl_Sup(Sup#);
ALTER TABLE tbl_Cus ADD FOREIGN KEY (CusUsr#) REFERENCES tbl_Usr(Usr#);
ALTER TABLE tbl_Sup ADD FOREIGN KEY (SupUsr#) REFERENCES tbl_Usr(Usr#);
ALTER TABLE tbl_Sah ADD FOREIGN KEY (SahCus#) REFERENCES tbl_Cus(Cus#);
ALTER TABLE tbl_Puh ADD FOREIGN KEY (PuhSup#) REFERENCES tbl_Sup(Sup#);
ALTER TABLE tbl_Pui ADD FOREIGN KEY (PuiPuh#) REFERENCES tbl_Puh(Puh#);
ALTER TABLE tbl_Pui ADD FOREIGN KEY (PuiPrd#) REFERENCES tbl_Prd(Prd#);
ALTER TABLE tbl_Sai ADD FOREIGN KEY (SaiSah#) REFERENCES tbl_Sah(Sah#);
ALTER TABLE tbl_Sai ADD FOREIGN KEY (SaiPrd#) REFERENCES tbl_Prd(Prd#);






INSERT INTO tbl_PrdCat(PrdcatName) VALUES ('Hardware');
INSERT INTO tbl_PrdCat(PrdcatName) VALUES ('Software');

/* TEST DATEN */

INSERT INTO tbl_Prd( PrdName, PrdEAN, PrdPricePurchase, PrdPriceSale, PrdPrdcat#) VALUES ('MSSQLSERVER', 'EAXqqwepj', 12.5, 155, 2);
INSERT INTO tbl_Prd( PrdName, PrdEAN, PrdPricePurchase, PrdPriceSale, PrdPrdcat#) VALUES ('MSOFFICE', 'EAXqqwepj', 50, 75, 2);
INSERT INTO tbl_Prd( PrdName, PrdEAN, PrdPricePurchase, PrdPriceSale, PrdPrdcat#) VALUES ('DELL XPS', 'EAXqqwepj', 750, 1500, 1);

INSERT INTO tbl_Usr( UsrIdent, UsrIsEmployer, UsrLogedin, UsrName, UsrNumber, UsrPassword) VALUES ('hbs', 1, 1, 'Simi', 123, 123);
