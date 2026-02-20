-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Feb 20, 2026 at 02:02 PM
-- Server version: 10.4.32-MariaDB
-- PHP Version: 8.2.12

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `etiqa_tech_exam`
--

DELIMITER $$
--
-- Procedures
--
CREATE DEFINER=`root`@`localhost` PROCEDURE `GetEmployeeByNumber` (IN `empId` VARCHAR(50))   BEGIN
    SELECT * FROM Employees WHERE EmployeeNumber = empId;
END$$

DELIMITER ;

-- --------------------------------------------------------

--
-- Table structure for table `employees`
--

CREATE TABLE `employees` (
  `EmployeeNumber` varchar(255) NOT NULL,
  `FullName` longtext NOT NULL,
  `DateOfBirth` datetime(6) NOT NULL,
  `DailyRate` decimal(65,30) NOT NULL,
  `WorkingDays` longtext NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `employees`
--

INSERT INTO `employees` (`EmployeeNumber`, `FullName`, `DateOfBirth`, `DailyRate`, `WorkingDays`) VALUES
('ALL-88214-26SEP2026', 'ALLYSSA BERNABE', '2026-09-26 00:00:00.000000', 1500.000000000000000000000000000000, 'MWF'),
('DEL-12340-10JAN1994', 'DELA CRUZ, JUAN', '1994-05-17 00:00:00.000000', 2000.000000000000000000000000000000, 'MWF'),
('SY*-00779-10SEP1994', 'SY, ANNIE', '1994-09-01 00:00:00.000000', 1500.000000000000000000000000000000, 'TTHS');

-- --------------------------------------------------------

--
-- Table structure for table `tech_exam`
--

CREATE TABLE `tech_exam` (
  `EmployeeNumber` varchar(32) NOT NULL,
  `FullName` varchar(255) NOT NULL,
  `DateofBirth` date NOT NULL,
  `DailyRate` decimal(32,0) NOT NULL,
  `WorkingDays` varchar(8) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Table structure for table `__efmigrationshistory`
--

CREATE TABLE `__efmigrationshistory` (
  `MigrationId` varchar(150) NOT NULL,
  `ProductVersion` varchar(32) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `__efmigrationshistory`
--

INSERT INTO `__efmigrationshistory` (`MigrationId`, `ProductVersion`) VALUES
('20260220124332_InitialCreate', '9.0.13');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `employees`
--
ALTER TABLE `employees`
  ADD PRIMARY KEY (`EmployeeNumber`);

--
-- Indexes for table `__efmigrationshistory`
--
ALTER TABLE `__efmigrationshistory`
  ADD PRIMARY KEY (`MigrationId`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
