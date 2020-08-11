-- phpMyAdmin SQL Dump
-- version 5.0.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: 2020 m. Bal 01 d. 19:06
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
-- Database: `leidiniaik`
--

-- --------------------------------------------------------

--
-- Sukurta duomenų struktūra lentelei `leidiniai`
--

CREATE TABLE `leidiniai` (
  `Leidinio_kodas` int(11) NOT NULL,
  `Leidinio_pavadinimas` varchar(255) NOT NULL,
  `Egzemplioriaus_kaina` decimal(8,2) NOT NULL,
  `Periodiskumas_per_menesi` int(11) NOT NULL,
  `Leidejo_pavadinimas` varchar(255) NOT NULL,
  `Lanku_skaicius` decimal(8,2) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Sukurta duomenų kopija lentelei `leidiniai`
--

INSERT INTO `leidiniai` (`Leidinio_kodas`, `Leidinio_pavadinimas`, `Egzemplioriaus_kaina`, `Periodiskumas_per_menesi`, `Leidejo_pavadinimas`, `Lanku_skaicius`) VALUES
(666, 'Fizika', '1.60', 2, 'KTU', '2.00'),
(777, 'Chemija', '2.30', 1, 'VU', '2.00'),
(888, 'Biologija', '0.00', 1, 'LMD', '2.00'),
(999, 'Tukas', '1.45', 1, 'Tukas', '2.00');

-- --------------------------------------------------------

--
-- Sukurta duomenų struktūra lentelei `uzsakymai`
--

CREATE TABLE `uzsakymai` (
  `Uzsakovo_kodas` int(11) NOT NULL,
  `Leidinio_kodas` int(11) NOT NULL,
  `Uzsakymo_periodas_menesiais` int(11) NOT NULL,
  `Platintojo_kodas` int(11) NOT NULL,
  `Uzsakymo_data` date NOT NULL,
  `Egzemplioriu_skaicius` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Sukurta duomenų kopija lentelei `uzsakymai`
--

INSERT INTO `uzsakymai` (`Uzsakovo_kodas`, `Leidinio_kodas`, `Uzsakymo_periodas_menesiais`, `Platintojo_kodas`, `Uzsakymo_data`, `Egzemplioriu_skaicius`) VALUES
(1212, 666, 1, 1234, '2020-03-20', 2),
(1212, 888, 2, 1234, '2020-03-04', 6),
(1313, 777, 1, 1234, '2020-02-11', 8),
(1313, 888, 1, 1234, '2020-01-28', 1),
(1313, 999, 1, 1234, '2020-02-18', 3);

CREATE TABLE `platintojai` (
  `Platintojo_pavarde` varchar(255) NOT NULL,
  `Leidinio_kodas` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

ALTER TABLE `platintojai`
   ADD KEY `uzsako` (`Leidinio_kodas`);

ALTER TABLE `platintojai`
  ADD CONSTRAINT `platina` FOREIGN KEY (`Leidinio_kodas`) REFERENCES `leidiniai` (`Leidinio_kodas`);

--
-- Indexes for dumped tables
--

--
-- Indexes for table `leidiniai`
--
ALTER TABLE `leidiniai`
  ADD PRIMARY KEY (`Leidinio_kodas`);

--
-- Indexes for table `uzsakymai`
--
ALTER TABLE `uzsakymai`
  ADD KEY `uzsako` (`Leidinio_kodas`);

--
-- Apribojimai eksportuotom lentelėm
--

--
-- Apribojimai lentelei `uzsakymai`
--
ALTER TABLE `uzsakymai`
  ADD CONSTRAINT `uzsako` FOREIGN KEY (`Leidinio_kodas`) REFERENCES `leidiniai` (`Leidinio_kodas`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
