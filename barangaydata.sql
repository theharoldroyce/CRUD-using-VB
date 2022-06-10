-- phpMyAdmin SQL Dump
-- version 5.1.0
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Oct 20, 2021 at 11:05 PM
-- Server version: 10.4.18-MariaDB
-- PHP Version: 8.0.3

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `barangaydata`
--

-- --------------------------------------------------------

--
-- Table structure for table `tbl_sign_in`
--

CREATE TABLE `tbl_sign_in` (
  `ID_NUMBER` varchar(100) NOT NULL,
  `NAME` varchar(100) NOT NULL,
  `DEPARTMENT` varchar(100) NOT NULL,
  `USERNAME` varchar(100) NOT NULL,
  `PASSWORD` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `tbl_sign_in`
--

INSERT INTO `tbl_sign_in` (`ID_NUMBER`, `NAME`, `DEPARTMENT`, `USERNAME`, `PASSWORD`) VALUES
('110022', 'ADMIN', 'ADMIN', 'ADMIN', 'ADMIN123');

-- --------------------------------------------------------

--
-- Table structure for table `vitamin2`
--

CREATE TABLE `vitamin2` (
  `NO` int(5) NOT NULL,
  `CHILDNAME` varchar(50) DEFAULT NULL,
  `BDAY` varchar(25) DEFAULT NULL,
  `AGE_MONTH` varchar(25) DEFAULT NULL,
  `GENDER` varchar(5) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `vitamin2`
--

INSERT INTO `vitamin2` (`NO`, `CHILDNAME`, `BDAY`, `AGE_MONTH`, `GENDER`) VALUES
(1, 'UMALI,PRINCESS NATHALIA', '1-30-20', '8', 'F'),
(2, 'DELA SALDE, KOBE BEAN', '4-20-20', '6', 'M'),
(3, 'MELENDREZ,DYLAN YAEL', '2-10-20', '7', 'M'),
(4, 'OSORIO,ZANE ARNOLD', '2-18-20', '7', 'M'),
(5, 'MELENDREZ,QUEENSON', '2-28-20', '7', 'F'),
(6, 'MELENDREZ,JOHNFOLD', '2-18-20', '7', 'M'),
(7, 'ABES,ANA JOY', '12-27-19', '9', 'F'),
(8, 'MELENDREZ,NAECEL JADE', '10-11-19', '11', 'F'),
(9, 'MELENDREZ,TYRON REIGN', '12-3-19', '9', 'M'),
(10, 'VILLAFRANCA,JHEANNA FAITH', '12-9-19', '9', 'F'),
(11, 'REVAS,CALEB ASTONE', '11-29-19', '10', 'M'),
(12, 'ADMIN ADMIN', 'ADMIN', 'ADMIN', 'ADMIN');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `tbl_sign_in`
--
ALTER TABLE `tbl_sign_in`
  ADD PRIMARY KEY (`ID_NUMBER`);

--
-- Indexes for table `vitamin2`
--
ALTER TABLE `vitamin2`
  ADD PRIMARY KEY (`NO`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `vitamin2`
--
ALTER TABLE `vitamin2`
  MODIFY `NO` int(5) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=20;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
