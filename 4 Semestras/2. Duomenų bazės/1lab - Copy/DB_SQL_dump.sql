-- phpMyAdmin SQL Dump
-- version 5.0.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: 2020 m. Kov 01 d. 18:01
-- Server version: 10.4.11-MariaDB
-- PHP Version: 7.4.2

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `kalba`
--

-- --------------------------------------------------------

--
-- Sukurta duomenų struktūra lentelei `kompanija`
--

CREATE TABLE `kompanija` (
  `pavadinimas` varchar(255) NOT NULL,
  `telefonas` varchar(255) NOT NULL,
  `el_pastas` varchar(255) NOT NULL,
  `id_KOMPANIJA` int(11) NOT NULL,
  `fk_MIESTASid_MIESTAS` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Sukurta duomenų kopija lentelei `kompanija`
--

INSERT INTO `kompanija` (`pavadinimas`, `telefonas`, `el_pastas`, `id_KOMPANIJA`, `fk_MIESTASid_MIESTAS`) VALUES
('Kalbos linija', '+37062626176', 'kalboslinija@gmail.com', 2, 2),
('Dictionary lessons', '0800413632', 'dictcourses@gmail.com', 11, 84),
('Language jam', '08000148731', 'lanjam@gmail.com', 22, 17),
('Chinese future', '0800911041', 'chinesereg@gmail.com', 23, 36),
('English for beginners', '009715624821', 'englishdubai@gmai.com', 27, 59),
('Slav Languages', '0800002293', 'slavspeak@gmail.com', 32, 67),
('BuchSpeak', '+40376300244', 'speakbuc@gmail.com', 33, 33),
('Cork Language courses', '1800901782', 'corklanguages@gmail.com', 39, 25),
('Speaking heart', '003915496327', 'heartsp@gmail.com', 40, 53),
('Internet speaking', '020-109338', 'speechint@gmail.com', 49, 99),
('English for elders', '080029666', 'elderyeng@gmail.com', 55, 65),
('Rusų kursai', '+3706751281', 'ruskinow@gmail.com', 57, 1),
('Talking Courses', '06-800-16400', 'talklistenspeak@gmail.com', 61, 166),
('English for imigrants', '08000698395', 'reghere@gmail.com', 62, 22),
('Peach learning', '003456915478', 'languagebook@gmail.com', 89, 57),
('language fundamentals', '0800281752', 'startlearning@gmail.com', 90, 80),
('Good morning talk', '08000868762', 'gmtnow@gmail.com', 96, 16),
('Odense communications', '80820196', 'odensespeak@gmail.com', 100, 76),
('Lietuvių kursai', '+37069011721', 'mokykisdabar@gmail.com', 134, 3),
('Learn Porto', '800180368', 'portolearn@gmail.com', 144, 41);

-- --------------------------------------------------------

--
-- Sukurta duomenų struktūra lentelei `kursas`
--

CREATE TABLE `kursas` (
  `kalba` varchar(255) NOT NULL,
  `trukme_menesiais` int(11) NOT NULL,
  `kaina` decimal(8,2) NOT NULL,
  `mokiniu_skaicius` int(11) NOT NULL,
  `id` int(11) NOT NULL,
  `mokymosi_medziaga` char(10) NOT NULL,
  `lygis` char(2) NOT NULL,
  `savaites_diena` char(14) NOT NULL,
  `fk_MOKYTOJASasmens_kodas` varchar(255) NOT NULL
) ;

--
-- Sukurta duomenų kopija lentelei `kursas`
--

INSERT INTO `kursas` (`kalba`, `trukme_menesiais`, `kaina`, `mokiniu_skaicius`, `id`, `mokymosi_medziaga`, `lygis`, `savaites_diena`, `fk_MOKYTOJASasmens_kodas`) VALUES
('Anglų', 4, '381.00', 20, 1, 'internetas', 'C1', 'pirmadienis', '51017579997'),
('Mandarinų', 3, '328.00', 10, 4, 'paskaitos', 'B1', 'sestadienis', '36707751753'),
('Rusų', 2, '283.00', 15, 6, 'paskaitos', 'A2', 'antradienis', '49683663985'),
('Vokiečių', 1, '125.00', 15, 8, 'internetas', 'A1', 'treciadienis', '69698077085'),
('Italų', 3, '343.00', 30, 11, 'internetas', 'B2', 'pirmadienis', '54832847771'),
('Lietuvių', 12, '387.00', 50, 19, 'paskaitos', 'C2', 'sestadienis', '42287518616'),
('Estų', 6, '202.00', 20, 21, 'internetas', 'C1', 'pirmadienis', '53663444417'),
('Lenkų', 7, '171.00', 31, 27, 'internetas', 'A2', 'antradienis', '69257902155'),
('Graikų', 5, '346.00', 5, 33, 'paskaitos', 'B2', 'penktadienis', '68365928909'),
('Japonų', 6, '333.00', 21, 41, 'paskaitos', 'A1', 'pirmadienis', '46354339024'),
('Lietuvių', 2, '153.00', 22, 44, 'internetas', 'A1', 'pirmadienis', '49016881836'),
('Kinų', 9, '400.00', 15, 49, 'paskaitos', 'C1', 'sestadienis', '36856130345'),
('Prancūzų', 12, '500.00', 5, 52, 'paskaitos', 'C1', 'antradienis', '43985729142'),
('Anglų', 4, '152.00', 41, 69, 'paskaitos', 'B2', 'ketvirtadienis', '44109473831'),
('Ispanų', 6, '299.00', 30, 77, 'internetas', 'C1', 'pirmadienis', '53339736559'),
('Arabų', 5, '421.00', 55, 80, 'paskaitos', 'B1', 'pirmadienis', '41973441128'),
('Švedų', 4, '399.00', 21, 89, 'internetas', 'C1', 'pirmadienis', '52902045741'),
('Danų', 5, '299.00', 25, 100, 'internetas', 'A2', 'sestadienis', '49932872069'),
('Norvegų', 24, '600.00', 50, 101, 'paskaitos', 'C2', 'penktadienis', '65914497590'),
('Lenkų', 4, '159.00', 20, 109, 'internetas', 'A2', 'treciadienis', '65829651002');

-- --------------------------------------------------------

--
-- Sukurta duomenų struktūra lentelei `lankomas_kursas`
--

CREATE TABLE `lankomas_kursas` (
  `max_mokiniu` int(11) NOT NULL,
  `kalba` varchar(255) NOT NULL,
  `lygis` char(2) NOT NULL,
  `id_LANKOMAS_KURSAS` int(11) NOT NULL,
  `fk_SUTARTISnr` int(11) NOT NULL,
  `fk_KURSASid` int(11) NOT NULL
) ;

--
-- Sukurta duomenų kopija lentelei `lankomas_kursas`
--

INSERT INTO `lankomas_kursas` (`max_mokiniu`, `kalba`, `lygis`, `id_LANKOMAS_KURSAS`, `fk_SUTARTISnr`, `fk_KURSASid`) VALUES
(20, 'Anglų', 'C1', 2, 40, 1),
(10, 'Mandarinų', 'B1', 5, 29, 4),
(15, 'Rusų', 'A2', 7, 47, 6),
(15, 'Vokiečių', 'A1', 9, 32, 8),
(15, 'Vokiečių', 'A1', 10, 57, 8),
(30, 'Italų', 'B2', 12, 19, 11),
(50, 'Lietuvių', 'C2', 20, 5, 19),
(20, 'Estų', 'C1', 22, 50, 21),
(31, 'Lenkų', 'A2', 28, 25, 27),
(5, 'Graikų', 'B2', 34, 7, 33),
(21, 'Japonų', 'A1', 42, 15, 41),
(22, 'Lietuvių', 'A1', 45, 3, 44),
(15, 'Kinų', 'C1', 50, 10, 49),
(5, 'Prancūzų', 'C1', 53, 43, 52),
(41, 'Anglų', 'B2', 70, 37, 69),
(30, 'Ispanų', 'C1', 78, 24, 77),
(55, 'Arabų', 'B1', 81, 68, 80),
(21, 'Švedų', 'C1', 90, 98, 89),
(25, 'Danų', 'A2', 101, 72, 100),
(50, 'Norvegų', 'C2', 102, 2, 101);

-- --------------------------------------------------------

--
-- Sukurta duomenų struktūra lentelei `miestas`
--

CREATE TABLE `miestas` (
  `pavadinimas` varchar(255) NOT NULL,
  `salis` varchar(255) NOT NULL,
  `id_MIESTAS` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Sukurta duomenų kopija lentelei `miestas`
--

INSERT INTO `miestas` (`pavadinimas`, `salis`, `id_MIESTAS`) VALUES
('Klaipėda', 'Lietuva', 1),
('Kaunas', 'Lietuva', 2),
('Vilnius', 'Lietuva', 3),
('Londonas', 'Anglija', 16),
('Birminghamas', 'Anglija', 17),
('Jorkas', 'Anglija', 22),
('Cork', 'Airija', 25),
('Buchareštas', 'Romunija', 33),
('Lyon', 'Prancūzija', 36),
('Porto', 'Portugalija', 41),
('Genoa', 'Italija', 53),
('Granada', 'Ispanija', 57),
('Dubajus', 'Jungtiniai Arabų Emiratai', 59),
('Ghentas', 'Belgija', 65),
('Bratislava', 'Slovakija', 67),
('Odense', 'Danija', 76),
('Innsbruckas', 'Austrija', 80),
('Helsinkis', 'Suomija', 84),
('Gothenburgas', 'Švedija', 99),
('Budapeštas', 'Vengrija', 166);

-- --------------------------------------------------------

--
-- Sukurta duomenų struktūra lentelei `mokejimas`
--

CREATE TABLE `mokejimas` (
  `data` date NOT NULL,
  `suma` decimal(8,2) NOT NULL,
  `mokejimo_tipas` char(8) NOT NULL,
  `id_MOKEJIMAS` int(11) NOT NULL,
  `fk_MOKINYSasmens_kodas` varchar(255) NOT NULL,
  `fk_SASKAITAnr` int(11) NOT NULL
) ;

--
-- Sukurta duomenų kopija lentelei `mokejimas`
--

INSERT INTO `mokejimas` (`data`, `suma`, `mokejimo_tipas`, `id_MOKEJIMAS`, `fk_MOKINYSasmens_kodas`, `fk_SASKAITAnr`) VALUES
('1964-05-03', '155.00', 'grynieji', 1, '38186514539', 1),
('1965-11-02', '455.00', 'grynieji', 4, '52497824360', 5),
('1969-08-24', '254.00', 'grynieji', 5, '41031626883', 6),
('1969-11-17', '300.00', 'grynieji', 10, '54804528762', 11),
('1977-09-06', '256.00', 'grynieji', 14, '67569125167', 15),
('1978-01-06', '455.00', 'grynieji', 18, '63393880766', 19),
('1979-12-24', '521.00', 'grynieji', 20, '54683925662', 21),
('1983-03-14', '259.00', 'grynieji', 25, '69135342022', 26),
('1984-06-15', '399.00', 'grynieji', 28, '57695955415', 29),
('1986-03-04', '252.00', 'grynieji', 30, '65406182278', 31),
('1986-09-18', '311.00', 'grynieji', 32, '40738181625', 33),
('1988-08-15', '300.00', 'grynieji', 55, '37996009433', 56),
('1989-10-20', '100.00', 'grynieji', 73, '58878617988', 74),
('1989-11-02', '99.00', 'grynieji', 87, '52484914709', 88),
('1993-04-10', '288.00', 'grynieji', 88, '51904805353', 89),
('1999-12-14', '461.00', 'grynieji', 90, '47620768053', 91),
('2001-10-23', '287.00', 'kortele', 98, '39330245265', 99),
('2004-11-22', '765.00', 'kortele', 100, '62789077400', 101),
('2010-10-25', '355.00', 'kortele', 123, '54861371511', 124),
('2012-05-20', '75.00', 'kortele', 155, '49131030289', 156);

-- --------------------------------------------------------

--
-- Sukurta duomenų struktūra lentelei `mokinys`
--

CREATE TABLE `mokinys` (
  `vardas` varchar(255) NOT NULL,
  `pavarde` varchar(255) NOT NULL,
  `gimimo_data` date NOT NULL,
  `asmens_kodas` varchar(255) NOT NULL,
  `telefonas` varchar(255) NOT NULL,
  `el_pastas` varchar(255) NOT NULL,
  `adresas` varchar(255) NOT NULL,
  `lytis` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Sukurta duomenų kopija lentelei `mokinys`
--

INSERT INTO `mokinys` (`vardas`, `pavarde`, `gimimo_data`, `asmens_kodas`, `telefonas`, `el_pastas`, `adresas`, `lytis`) VALUES
('Jodi', 'Frazier', '2004-12-27', '37996009433', '(935) 758-3327', 'arathi@outlook.com', '346 Constitution Dr.\r\nFall River, MA 02720', 'Moteris'),
('Alex', 'Perry', '1928-12-29', '38186514539', '(651) 545-4899', 'kildjean@sbcglobal.net', '789 Creekside Ave.\r\nWestminster, MD 21157', 'Vyras'),
('Norman', 'Logan', '1976-03-28', '39330245265', '(385) 384-6685', 'hampton@outlook.com', '56 Meadowbrook Court\r\nRoy, UT 84067', 'Vyras'),
('Jerald', 'Cain', '2003-12-25', '40738181625', '(891) 581-7208', 'smcnabb@mac.com', '982 Sunbeam Dr.\r\nBrooklyn, NY 11201', 'Vyras'),
('Austin', 'Weaver', '1934-01-17', '41031626883', '(461) 285-2653', 'gravyface@me.com', '8026 West Catherine Lane\r\nOoltewah, TN 37363', 'Vyras'),
('Natasha', 'Bradley', '1974-04-28', '47620768053', '(935) 412-3871', 'kalpol@outlook.com', '789 Harvey St.\r\nWindsor Mill, MD 21244', 'Moteris'),
('Sean', 'Jefferson', '1975-08-05', '49131030289', '(888) 642-0636', 'andale@icloud.com', '7697 Saxton Street\r\nJacksonville, NC 28540', 'Vyras'),
('Lela', 'Allison', '2012-02-24', '51904805353', '(587) 820-0592', 'mccurley@msn.com', '7763 Bald Hill Street\r\nMount Vernon, NY 10550', 'Moteris'),
('Lana', 'Guzman', '2020-03-11', '52484914709', '(210) 694-9553', 'jgoerzen@yahoo.com', '16 E. Silver Spear St.\r\nMadison Heights, MI 48071', 'Moteris'),
('Alfredo', 'Stevenson', '1938-06-28', '52497824360', '(418) 634-0352', 'wonderkid@aol.com', '25 Talbot St.\r\nSnellville, GA 30039', 'Vyras'),
('Daisy', 'Nichols', '1969-06-17', '54683925662', '(917) 882-9664', 'wenzlaff@gmail.com', '9628 Ashley St.\r\nMokena, IL 60448', 'Moteris'),
('Camille', 'Mathis', '1970-02-28', '54804528762', '(761) 207-4211', 'guialbu@sbcglobal.net', '31 Brown Drive\r\nNorth Brunswick, NJ 08902', 'Moteris'),
('Sabrina', 'Wilson', '1972-05-02', '54861371511', '(391) 611-7972', 'rsmartin@yahoo.com', '10 Franklin Ave.\r\nTerre Haute, IN 47802', 'Moteris'),
('Daryl', 'Osborne', '1983-03-29', '57695955415', '(421) 782-2540', 'michiel@comcast.net', '965 Wagon St.\r\nWarner Robins, GA 31088', 'Vyras'),
('Josefina', 'Norman', '1974-02-18', '58878617988', '(841) 917-4126', 'msusa@me.com', '830 Proctor Lane\r\nGoshen, IN 46526', 'Moteris'),
('Rudolph', 'Summers', '1921-11-09', '62789077400', '(280) 903-3664', 'grolschie@icloud.com', '8709 Ridgeview Lane\r\nLaurel, MD 20707', 'Vyras'),
('Christina', 'Stone', '1951-04-22', '63393880766', '(279) 605-6371', 'ideguy@comcast.net', '7593 Bradford Street\r\nMobile, AL 36605', 'Moteris'),
('Dianne', 'Underwood', '2006-05-05', '65406182278', '(996) 401-1587', 'willg@msn.com', '7087 Chestnut Avenue\r\nQueensbury, NY 12804', 'Moteris'),
('Casey', 'Reed', '1955-06-13', '67569125167', '(238) 821-0027', 'konit@gmail.com', '7057 W. Hilldale Ave.\r\nConyers, GA 30012', 'Vyras'),
('Dale', 'Howell', '2000-08-16', '69135342022', '(818) 318-0487', 'mfleming@optonline.net', '155 Valley St.\r\nHarrisburg, PA 17109', 'Moteris');

-- --------------------------------------------------------

--
-- Sukurta duomenų struktūra lentelei `mokykla`
--

CREATE TABLE `mokykla` (
  `pavadinimas` varchar(255) NOT NULL,
  `telefonas` varchar(255) NOT NULL,
  `adresas` varchar(255) NOT NULL,
  `el_pastas` varchar(255) NOT NULL,
  `tinklalapis` varchar(255) NOT NULL,
  `id_MOKYKLA` int(11) NOT NULL,
  `fk_KOMPANIJAid_KOMPANIJA` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Sukurta duomenų kopija lentelei `mokykla`
--

INSERT INTO `mokykla` (`pavadinimas`, `telefonas`, `adresas`, `el_pastas`, `tinklalapis`, `id_MOKYKLA`, `fk_KOMPANIJAid_KOMPANIJA`) VALUES
('Desert Sands Conservatory', '(540) 617-6648', '591 E. Helen Street\r\nBloomfield, NJ 07003', 'desertsandsconservaroty@gmail.com', 'www.desertsandsconservaroty.com', 3, 2),
('University of Helsinki', '0800568268', '9483 Nicolls Street\r\nClover, SC 29710', 'unihelsinki@gmail.com', 'www.helsinkiuni.com', 16, 11),
('Millenium Elementary', '(437) 964-3338', '8161 Snake Hill St.\r\nCalhoun, GA 30701', 'milleniume@gmail.com', 'www.milleniume.com', 25, 22),
('Heriott Watt University', '009723928265', '444 Pacific Street\r\nRoslindale, MA 02131', 'heriottwattuni@gmail.com', 'www.heriottwattuniversity.com', 30, 27),
('Buch elementary', '+40371257124', '8943 Green Hill St.\r\nValrico, FL 33594', 'belementary@gmail.com', 'www.buchelementary.com', 36, 33),
('Monarch School', '(373) 939-2398', '78 Country St.\r\nVineland, NJ 08360', 'monarchschool@gmail.com', 'www.monarchschool.com', 37, 32),
('Sunshine Institute', '(689) 500-5888', '8908 Temple Street\r\nWest Palm Beach, FL 33404', 'suhshineinst@gmail.com', 'www.suhshineinst.com', 42, 40),
('Cork\'s white house', '1800657167', '7349 Princess Drive\r\nCouncil Bluffs, IA 51501', 'whitehousecork@gmail.com', 'www.whitehousecork.com', 45, 39),
('Darwin High', '(703) 828-7861', '5 North Illinois Avenue\r\nMarshalltown, IA 50158', 'darwinhigh@gmail.com', 'www.darwinhigh.com', 50, 49),
('Central High School', '(582) 729-1733', '72 N. Edgewater St.\r\nMuscatine, IA 52761', 'centralhigh@gmail.com', 'www.cehntralhigh.com', 56, 55),
('Bear River Institute', '(480) 277-7867', '40 Glendale Road\r\nPort Jefferson Station, NY 11776', 'bearriver@gmail.com', 'www.bearriver.com', 66, 62),
('Savanna Secondary School', '(258) 536-1739', '7 Plymouth St.\r\nStone Mountain, GA 30083', 'savannasecondary@gmail.com', 'www.savannasecondary.com', 68, 61),
('Pleasant Grove School of Fine Arts', '(373) 319-4095', '597 Jennings St.\r\nScarsdale, NY 10583', 'pleasantgroveschool@gmail.com', 'www.pleasantgroveschool.com', 69, 57),
('Woodside School for Boys', '(535) 983-9821', '9486 West Hamilton St.\r\nPalm Harbor, FL 34683', 'woodside@gmail.com', 'www.woodside.com', 75, 23),
('Ravenwood School for Girls', '(597) 293-8428', '90 Kingston St.\r\nGibsonia, PA 15044', 'ravenwoodschool@gmail.com', 'www.ravenwoodschool.com', 91, 90),
('Oceanside School', '(309) 676-0916', '6 Fremont Ave.\r\nDacula, GA 30019', 'oceansideschool@gmail.com', 'www.oceansideschool.com', 92, 89),
('Mountainview Institute', '(722) 714-3604', '223 Meadowbrook Street\r\nHamburg, NY 14075', 'mountainview@gmail.com', 'www.mountainview.com', 100, 96),
('Whale Gulch Grammar School', '(794) 470-5750', '7243 Bank Street\r\nFar Rockaway, NY 11691', 'whalegulchgrammar@gmailcom', 'www.whalegulchgrammar.com', 101, 100),
('Eastview Grammar School', '(373) 932-4701', '9 Rock Creek Rd.\r\nPalmetto, FL 34221', 'eastviewgrammar@gmail.com', 'www.eastviewgrammar.com', 135, 134),
('Coral Springs Academy', '(673) 570-5872', '7049 Trout Ave.\r\nHackensack, NJ 07601', 'coralsprings@gmail.com', 'www.coralsprings.com', 150, 144);

-- --------------------------------------------------------

--
-- Sukurta duomenų struktūra lentelei `mokytojas`
--

CREATE TABLE `mokytojas` (
  `vardas` varchar(255) NOT NULL,
  `pavarde` varchar(255) NOT NULL,
  `amzius` int(11) NOT NULL,
  `lytis` varchar(255) NOT NULL,
  `asmens_kodas` varchar(255) NOT NULL,
  `specializacija` char(7) NOT NULL,
  `fk_MOKYKLAid_MOKYKLA` int(11) NOT NULL
) ;

--
-- Sukurta duomenų kopija lentelei `mokytojas`
--

INSERT INTO `mokytojas` (`vardas`, `pavarde`, `amzius`, `lytis`, `asmens_kodas`, `specializacija`, `fk_MOKYKLAid_MOKYKLA`) VALUES
('Tara', 'Garner', 64, 'Moteris', '35953975830', 'pietu', 150),
('Blanca', 'Reynolds', 52, 'Moteris', '36707751753', 'vakaru', 36),
('Genevieve', 'Bates', 55, 'Moteris', '36856130345', 'siaures', 3),
('Jimmie', 'Mills', 29, 'Vyras', '41973441128', 'rytu', 45),
('Deanna', 'Rogers', 66, 'Moteris', '42287518616', 'rytu', 30),
('Samantha', 'Glover', 69, 'Moteris', '42522395004', 'pietu', 91),
('Geraldine', 'Porter', 32, 'Moteris', '43985729142', 'rytu', 30),
('Guadalupe', 'Pearson', 19, 'Moteris', '44109473831', 'siaures', 42),
('Erica', 'Erickson', 87, 'Moteris', '46354339024', 'siaures', 37),
('Eva', 'Cohen', 27, 'Moteris', '49016881836', 'vakaru', 101),
('Bradley', 'Frazier', 46, 'Vyras', '49683663985', 'vakaru', 25),
('Lamar', 'Holmes', 31, 'Vyras', '49932872069', 'pietu', 135),
('Alex\r\n', 'Burgess', 25, 'Vyras', '51017579997', 'vakaru', 50),
('Tracy', 'Holt', 26, 'Moteris', '51037700469', 'siaures', 56),
('Krista', 'Christensen', 32, 'Moteris', '52902045741', 'rytu', 66),
('Gwendolyn', 'Mcdonald', 65, 'Moteris', '53339736559', 'rytu', 92),
('Delores', 'Weber', 59, 'Moteris', '53663444417', 'rytu', 69),
('Clifton', 'Bennett', 54, 'Vyras', '54832847771', 'vakaru', 50),
('Noah', 'Chavez', 51, 'Vyras', '65829651002', 'rytu', 16),
('Luis', 'Yates', 44, 'Vyras', '65914497590', 'vakaru', 68),
('Diane', 'Allison', 54, 'Moteris', '68365928909', 'rytu', 50),
('Denise', 'Swanson', 64, 'Moteris', '69257902155', 'pietu', 100),
('Christian', 'Russell', 75, 'Vyras', '69698077085', 'vakaru', 75);

-- --------------------------------------------------------

--
-- Sukurta duomenų struktūra lentelei `saskaita`
--

CREATE TABLE `saskaita` (
  `nr` int(11) NOT NULL,
  `data` date NOT NULL,
  `suma` decimal(8,2) NOT NULL,
  `fk_SUTARTISnr` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Sukurta duomenų kopija lentelei `saskaita`
--

INSERT INTO `saskaita` (`nr`, `data`, `suma`, `fk_SUTARTISnr`) VALUES
(1, '1964-05-03', '155.00', 32),
(5, '1965-11-02', '455.00', 40),
(6, '1969-08-24', '254.00', 37),
(11, '1969-11-17', '300.00', 68),
(15, '1977-09-06', '256.00', 72),
(19, '1978-01-06', '455.00', 50),
(21, '1979-12-24', '521.00', 7),
(26, '1983-03-14', '259.00', 24),
(29, '1984-06-15', '399.00', 19),
(31, '1986-03-04', '252.00', 15),
(33, '1986-09-18', '311.00', 10),
(56, '1988-08-15', '300.00', 25),
(74, '1989-10-20', '100.00', 5),
(88, '1989-11-02', '99.00', 3),
(89, '1993-04-10', '288.00', 29),
(91, '1999-12-14', '461.00', 2),
(99, '2001-10-23', '287.00', 43),
(101, '2004-11-22', '765.00', 47),
(124, '2010-10-25', '355.00', 57),
(156, '2012-05-20', '75.00', 98);

-- --------------------------------------------------------

--
-- Sukurta duomenų struktūra lentelei `sutartis`
--

CREATE TABLE `sutartis` (
  `nr` int(11) NOT NULL,
  `sutarties_data` date NOT NULL,
  `pradzios_data` date NOT NULL,
  `busena` char(11) NOT NULL,
  `fk_MOKYKLAid_MOKYKLA` int(11) NOT NULL,
  `fk_MOKINYSasmens_kodas` varchar(255) NOT NULL
) ;

--
-- Sukurta duomenų kopija lentelei `sutartis`
--

INSERT INTO `sutartis` (`nr`, `sutarties_data`, `pradzios_data`, `busena`, `fk_MOKYKLAid_MOKYKLA`, `fk_MOKINYSasmens_kodas`) VALUES
(2, '1981-05-23', '1981-05-10', 'uzbaigta', 150, '67569125167'),
(3, '1968-02-27', '1968-02-24', 'uzbaigta', 66, '38186514539'),
(5, '1969-06-19', '1969-06-02', 'uzbaigta', 66, '41031626883'),
(7, '1973-03-20', '1973-03-15', 'uzbaigta', 36, '52497824360'),
(10, '1974-09-05', '1974-09-01', 'uzbaigta', 56, '54804528762'),
(15, '1983-10-15', '1983-10-09', 'uzbaigta', 45, '63393880766'),
(19, '1984-09-28', '1984-09-27', 'uzbaigta', 50, '54683925662'),
(24, '1984-10-09', '1984-10-02', 'uzbaigta', 3, '69135342022'),
(25, '1985-08-08', '1985-08-03', 'uzbaigta', 135, '57695955415'),
(29, '1989-02-17', '1989-02-10', 'uzbaigta', 30, '65406182278'),
(32, '1989-09-05', '1989-09-01', 'nutraukta', 25, '40738181625'),
(37, '1996-03-07', '1996-03-01', 'nutraukta', 37, '37996009433'),
(40, '2000-10-04', '2000-09-27', 'nutraukta', 100, '58878617988'),
(43, '2000-10-25', '2000-10-20', 'uzbaigta', 92, '52484914709'),
(47, '2004-01-28', '2004-01-25', 'uzbaigta', 69, '51904805353'),
(50, '2005-03-31', '2005-03-27', 'patvirtinta', 91, '47620768053'),
(57, '2020-07-28', '2020-07-20', 'uzsakyta', 68, '39330245265'),
(68, '2010-02-25', '2010-02-15', 'nutraukta', 42, '62789077400'),
(72, '2212-03-15', '2021-03-09', 'patvirtinta', 16, '54861371511'),
(98, '2019-10-01', '2019-09-10', 'uzsakyta', 101, '49131030289');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `kompanija`
--
ALTER TABLE `kompanija`
  ADD PRIMARY KEY (`id_KOMPANIJA`),
  ADD KEY `yra` (`fk_MIESTASid_MIESTAS`);

--
-- Indexes for table `kursas`
--
ALTER TABLE `kursas`
  ADD PRIMARY KEY (`id`),
  ADD KEY `veda` (`fk_MOKYTOJASasmens_kodas`);

--
-- Indexes for table `lankomas_kursas`
--
ALTER TABLE `lankomas_kursas`
  ADD PRIMARY KEY (`id_LANKOMAS_KURSAS`),
  ADD KEY `ieina` (`fk_SUTARTISnr`),
  ADD KEY `lanko` (`fk_KURSASid`);

--
-- Indexes for table `miestas`
--
ALTER TABLE `miestas`
  ADD PRIMARY KEY (`id_MIESTAS`);

--
-- Indexes for table `mokejimas`
--
ALTER TABLE `mokejimas`
  ADD PRIMARY KEY (`id_MOKEJIMAS`),
  ADD KEY `sumokejo` (`fk_MOKINYSasmens_kodas`),
  ADD KEY `apmoka` (`fk_SASKAITAnr`);

--
-- Indexes for table `mokinys`
--
ALTER TABLE `mokinys`
  ADD PRIMARY KEY (`asmens_kodas`);

--
-- Indexes for table `mokykla`
--
ALTER TABLE `mokykla`
  ADD PRIMARY KEY (`id_MOKYKLA`),
  ADD KEY `turi` (`fk_KOMPANIJAid_KOMPANIJA`);

--
-- Indexes for table `mokytojas`
--
ALTER TABLE `mokytojas`
  ADD PRIMARY KEY (`asmens_kodas`),
  ADD KEY `idarbina` (`fk_MOKYKLAid_MOKYKLA`);

--
-- Indexes for table `saskaita`
--
ALTER TABLE `saskaita`
  ADD PRIMARY KEY (`nr`),
  ADD KEY `israso` (`fk_SUTARTISnr`);

--
-- Indexes for table `sutartis`
--
ALTER TABLE `sutartis`
  ADD PRIMARY KEY (`nr`),
  ADD KEY `patvirtina` (`fk_MOKYKLAid_MOKYKLA`),
  ADD KEY `pasiraso` (`fk_MOKINYSasmens_kodas`);

--
-- Apribojimai eksportuotom lentelėm
--

--
-- Apribojimai lentelei `kompanija`
--
ALTER TABLE `kompanija`
  ADD CONSTRAINT `yra` FOREIGN KEY (`fk_MIESTASid_MIESTAS`) REFERENCES `miestas` (`id_MIESTAS`);

--
-- Apribojimai lentelei `kursas`
--
ALTER TABLE `kursas`
  ADD CONSTRAINT `veda` FOREIGN KEY (`fk_MOKYTOJASasmens_kodas`) REFERENCES `mokytojas` (`asmens_kodas`);

--
-- Apribojimai lentelei `lankomas_kursas`
--
ALTER TABLE `lankomas_kursas`
  ADD CONSTRAINT `ieina` FOREIGN KEY (`fk_SUTARTISnr`) REFERENCES `sutartis` (`nr`),
  ADD CONSTRAINT `lanko` FOREIGN KEY (`fk_KURSASid`) REFERENCES `kursas` (`id`);

--
-- Apribojimai lentelei `mokejimas`
--
ALTER TABLE `mokejimas`
  ADD CONSTRAINT `apmoka` FOREIGN KEY (`fk_SASKAITAnr`) REFERENCES `saskaita` (`nr`),
  ADD CONSTRAINT `sumokejo` FOREIGN KEY (`fk_MOKINYSasmens_kodas`) REFERENCES `mokinys` (`asmens_kodas`);

--
-- Apribojimai lentelei `mokykla`
--
ALTER TABLE `mokykla`
  ADD CONSTRAINT `turi` FOREIGN KEY (`fk_KOMPANIJAid_KOMPANIJA`) REFERENCES `kompanija` (`id_KOMPANIJA`);

--
-- Apribojimai lentelei `mokytojas`
--
ALTER TABLE `mokytojas`
  ADD CONSTRAINT `idarbina` FOREIGN KEY (`fk_MOKYKLAid_MOKYKLA`) REFERENCES `mokykla` (`id_MOKYKLA`);

--
-- Apribojimai lentelei `saskaita`
--
ALTER TABLE `saskaita`
  ADD CONSTRAINT `israso` FOREIGN KEY (`fk_SUTARTISnr`) REFERENCES `sutartis` (`nr`);

--
-- Apribojimai lentelei `sutartis`
--
ALTER TABLE `sutartis`
  ADD CONSTRAINT `pasiraso` FOREIGN KEY (`fk_MOKINYSasmens_kodas`) REFERENCES `mokinys` (`asmens_kodas`),
  ADD CONSTRAINT `patvirtina` FOREIGN KEY (`fk_MOKYKLAid_MOKYKLA`) REFERENCES `mokykla` (`id_MOKYKLA`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
