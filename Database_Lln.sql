DROP SCHEMA IF EXISTS DB_Leerlingen;
CREATE SCHEMA DB_Leerlingen;
USE DB_Leerlingen;
SET AUTOCOMMIT=0;

DROP TABLE IF EXISTS `tblKlas`;
CREATE TABLE tblKlas(
  kindid    		INTEGER(6)  NOT NULL PRIMARY KEY 
  ,uniekeklascode 	VARCHAR(10) NOT NULL
  ,omschrijving  	VARCHAR(25)
);
INSERT INTO tblKlas(kindid, uniekeklascode, omschrijving) VALUES (23587,"6NIT","6 Netwerken & IT");
INSERT INTO tblKlas(kindid, uniekeklascode, omschrijving) VALUES (25956,"6NIT","6 Netwerken & IT");
INSERT INTO tblKlas(kindid, uniekeklascode, omschrijving) VALUES (26928,"6NIT","6 Netwerken & IT");
INSERT INTO tblKlas(kindid, uniekeklascode, omschrijving) VALUES (27611,"6NIT","6 Netwerken & IT");
INSERT INTO tblKlas(kindid, uniekeklascode, omschrijving) VALUES (36680,"6NIT","6 Netwerken & IT");
INSERT INTO tblKlas(kindid, uniekeklascode, omschrijving) VALUES (65051,"6NIT","6 Netwerken & IT");
INSERT INTO tblKlas(kindid, uniekeklascode, omschrijving) VALUES (69442,"6NIT","6 Netwerken & IT");
INSERT INTO tblKlas(kindid, uniekeklascode, omschrijving) VALUES (69510,"6NIT","6 Netwerken & IT");
INSERT INTO tblKlas(kindid, uniekeklascode, omschrijving) VALUES (69677,"6NIT","6 Netwerken & IT");
INSERT INTO tblKlas(kindid, uniekeklascode, omschrijving) VALUES (73240,"6NIT","6 Netwerken & IT");
INSERT INTO tblKlas(kindid, uniekeklascode, omschrijving) VALUES (86734,"6NIT","6 Netwerken & IT");
INSERT INTO tblKlas(kindid, uniekeklascode, omschrijving) VALUES (90197,"6NIT","6 Netwerken & IT");
INSERT INTO tblKlas(kindid, uniekeklascode, omschrijving) VALUES (90273,"6NIT","6 Netwerken & IT");
INSERT INTO tblKlas(kindid, uniekeklascode, omschrijving) VALUES (141299,"6NIT","6 Netwerken & IT");

DROP TABLE IF EXISTS `tblLeerlingen`;
CREATE TABLE tblLeerlingen(
  kindid    		INTEGER(6)  NOT NULL PRIMARY KEY 
  ,kindnaam 		VARCHAR(20) NOT NULL
  ,kindvoornaam 	VARCHAR(20) NOT NULL
  ,straat 			VARCHAR(40) NOT NULL
  ,huisnr 			VARCHAR(6) NOT NULL
  ,postcode 		INTEGER(4) NOT NULL
  ,woonplaats 		VARCHAR(20) NOT NULL
  ,land 			VARCHAR(20) NOT NULL
  ,kindemailadres 	VARCHAR(50)
  ,geslacht 		VARCHAR(1) NOT NULL
  ,geboortedatum 	date NOT NULL
  ,geboorteplaats 	VARCHAR(20) NOT NULL
);
INSERT INTO tblLeerlingen(kindid, kindnaam, kindvoornaam, straat, huisnr, postcode, woonplaats, land, kindemailadres, geslacht, geboortedatum, geboorteplaats) VALUES (23587,"De Lannoy", "Jarno", "Beukenlaan", "14", 9320, "Erembodegem", "België", "", "M", '2005-03-15', "Aalst");
INSERT INTO tblLeerlingen(kindid, kindnaam, kindvoornaam, straat, huisnr, postcode, woonplaats, land, kindemailadres, geslacht, geboortedatum, geboorteplaats) VALUES (25956,"Van den Hooff", "Gilles", "Kruisstraat", "55B", 9308, "Gijzegem", "België", "", "M", '2006-08-02', "Aalst");
INSERT INTO tblLeerlingen(kindid, kindnaam, kindvoornaam, straat, huisnr, postcode, woonplaats, land, kindemailadres, geslacht, geboortedatum, geboorteplaats) VALUES (26928,"De Cock", "Simon-Francis", "Kouterbaan", "2", 9310, "Herdersem", "België", "decocksimonfrancis@gmail.com", "M", '2006-11-05', "Aalst" );
INSERT INTO tblLeerlingen(kindid, kindnaam, kindvoornaam, straat, huisnr, postcode, woonplaats, land, kindemailadres, geslacht, geboortedatum, geboorteplaats) VALUES (27611,"Habyarimana", "Kenzo-Yannick", "Park De Blieck", "24", 9300, "Aalst", "België", "kenzoyannick@gmail.com", "M", '2006-11-15', "Brussel");
INSERT INTO tblLeerlingen(kindid, kindnaam, kindvoornaam, straat, huisnr, postcode, woonplaats, land, kindemailadres, geslacht, geboortedatum, geboorteplaats) VALUES (36680,"De Cock", "Lucas", "Karel Van De Woestijnestraat", "14", 9300, "Aalst", "België", "decock_lucas@leerling.smi-aalst.be", "M", '2006-09-12', "Aalst");
INSERT INTO tblLeerlingen(kindid, kindnaam, kindvoornaam, straat, huisnr, postcode, woonplaats, land, kindemailadres, geslacht, geboortedatum, geboorteplaats) VALUES (65051,"Abdallah", "Ahmad", "Larewei", "11", 9300, "Aalst", "België", "ahmad58596@hotmail.com", "M", '2006-09-16', "Aalst");
INSERT INTO tblLeerlingen(kindid, kindnaam, kindvoornaam, straat, huisnr, postcode, woonplaats, land, kindemailadres, geslacht, geboortedatum, geboorteplaats) VALUES (69442,"Pinheiro", "Telmo Miguel", "Welvaartstraat", "78", 9300, "Aalst", "België", "telmomiguelpinheiro@gmail.com", "M", '2006-09-28', "Lisboa");
INSERT INTO tblLeerlingen(kindid, kindnaam, kindvoornaam, straat, huisnr, postcode, woonplaats, land, kindemailadres, geslacht, geboortedatum, geboorteplaats) VALUES (69510,"Van Aelbrouck", "Bo", "Kriekenlaan", "10", 9300, "Aalst", "België", "bovanaelbrouck9@gmail.com", "V", '2005-09-26', "Aalst");
INSERT INTO tblLeerlingen(kindid, kindnaam, kindvoornaam, straat, huisnr, postcode, woonplaats, land, kindemailadres, geslacht, geboortedatum, geboorteplaats) VALUES (69677,"Lievens", "Ilias", "Guido Gezellestraat", "95", 9300, "Aalst", "Belgiê", "ilias.lievens2006@gmail.com", "M", '2006-02-07', "Aalst");
INSERT INTO tblLeerlingen(kindid, kindnaam, kindvoornaam, straat, huisnr, postcode, woonplaats, land, kindemailadres, geslacht, geboortedatum, geboorteplaats) VALUES (73240,"De Wannemaeker", "Joshua", "Boudewijnlaan", "79", 9300, "Aalst", "België", "joshua.dw06@gmail.com", "M", '2006-11-04', "Gent");
INSERT INTO tblLeerlingen(kindid, kindnaam, kindvoornaam, straat, huisnr, postcode, woonplaats, land, kindemailadres, geslacht, geboortedatum, geboorteplaats) VALUES (86734,"Verduyckt", "Xander", "Blokmanstraat", "10", 9420, "Erpe-Mere", "België", "xverduyckt@gmail.com", "M", '2005-12-19', "Aalst");
INSERT INTO tblLeerlingen(kindid, kindnaam, kindvoornaam, straat, huisnr, postcode, woonplaats, land, kindemailadres, geslacht, geboortedatum, geboorteplaats) VALUES (90197,"Ngahanne", "Zack", "Vrijheidsstraat", "60", 1770, "Liederkerke", "België", "Zackflo@gmail.com", "M", '2006-04-19', "Anderlecht");
INSERT INTO tblLeerlingen(kindid, kindnaam, kindvoornaam, straat, huisnr, postcode, woonplaats, land, kindemailadres, geslacht, geboortedatum, geboorteplaats) VALUES (90273,"Schokaert", "Milan", "Babbelaarstraat", "48", 9308, "Hofstade", "België", "", "M", '2006-08-03', "Aalst");
INSERT INTO tblLeerlingen(kindid, kindnaam, kindvoornaam, straat, huisnr, postcode, woonplaats, land, kindemailadres, geslacht, geboortedatum, geboorteplaats) VALUES (141299,"Jans", "Emiel", "Pol De Montstraat", "26", 1741, "Wambeek", "België", "emiel.jans2@telenet.be", "M", '2006-08-02', "Jette");

DROP TABLE IF EXISTS `tblOuders`;
CREATE TABLE tblOuders(
kindid    			INTEGER(6)  NOT NULL PRIMARY KEY 
,ouderid    		INTEGER(6)  NOT NULL
,oudernaam 			VARCHAR(20)
,oudervoornaam		VARCHAR(20)
,ouderemailadres 	VARCHAR(40)
);
INSERT INTO tblOuders(kindid, ouderid, zetelid) VALUES (23587,1,0);
INSERT INTO tblOuders(kindid, ouderid,zetelid) VALUES (25956,2,0);
INSERT INTO tblOuders(kindid, ouderid,zetelid) VALUES (26928,3,0);
INSERT INTO tblOuders(kindid, ouderid,zetelid) VALUES (27611,4,0);
INSERT INTO tblOuders(kindid, ouderid,zetelid) VALUES (36680,5,0);
INSERT INTO tblOuders(kindid, ouderid,zetelid) VALUES (65051,6,0);
INSERT INTO tblOuders(kindid, ouderid,zetelid) VALUES (69442,7,0);
INSERT INTO tblOuders(kindid, ouderid,zetelid) VALUES (69510,8,0);
INSERT INTO tblOuders(kindid, ouderid,zetelid) VALUES (69677,9,0);
INSERT INTO tblOuders(kindid, ouderid,zetelid) VALUES (73240,10,0);
INSERT INTO tblOuders(kindid, ouderid,zetelid) VALUES (86734,11,0);
INSERT INTO tblOuders(kindid, ouderid,zetelid) VALUES (90197,12,0);
INSERT INTO tblOuders(kindid, ouderid,zetelid) VALUES (90273,13,0);
INSERT INTO tblOuders(kindid, ouderid,zetelid) VALUES (141299,14,0);



DROP TABLE IF EXISTS `tblTickets`;
CREATE TABLE tblTickets(
ouderid    			INTEGER(6)  NOT NULL PRIMARY KEY
,ticketid    		INTEGER(6)
,zetelid    		INTEGER(6)
);
INSERT INTO tblTickets(ouderid) VALUES (1);
INSERT INTO tblTickets(ouderid) VALUES (2);
INSERT INTO tblTickets(ouderid) VALUES (3);
INSERT INTO tblTickets(ouderid) VALUES (4);
INSERT INTO tblTickets(ouderid) VALUES (5);
INSERT INTO tblTickets(ouderid) VALUES (6);
INSERT INTO tblTickets(ouderid) VALUES (7);
INSERT INTO tblTickets(ouderid) VALUES (8);
INSERT INTO tblTickets(ouderid) VALUES (9);
INSERT INTO tblTickets(ouderid) VALUES (10);
INSERT INTO tblTickets(ouderid) VALUES (12);
INSERT INTO tblTickets(ouderid) VALUES (13);
INSERT INTO tblTickets(ouderid) VALUES (14);