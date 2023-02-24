CREATE DATABASE  IF NOT EXISTS `cmslcly_mysql1` /*!40100 DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci */ /*!80016 DEFAULT ENCRYPTION='N' */;
USE `cmslcly_mysql1`;
-- MySQL dump 10.13  Distrib 8.0.28, for Win64 (x86_64)
--
-- Host: localhost    Database: cmslcly_mysql1
-- ------------------------------------------------------
-- Server version	8.0.28

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `cacmaster`
--

DROP TABLE IF EXISTS `cacmaster`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `cacmaster` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `CACName` varchar(255) NOT NULL,
  `BankName` varchar(255) NOT NULL,
  `Address` varchar(255) DEFAULT NULL,
  `Address2` varchar(255) DEFAULT NULL,
  `Address3` varchar(255) DEFAULT NULL,
  `PostCode` varchar(10) DEFAULT NULL,
  `State` varchar(50) DEFAULT NULL,
  `Phone` varchar(50) DEFAULT NULL,
  `Phone2` varchar(50) DEFAULT NULL,
  `Phone3` varchar(50) DEFAULT NULL,
  `Fax` varchar(50) DEFAULT NULL,
  `Fax2` varchar(50) DEFAULT NULL,
  `Email` varchar(128) DEFAULT NULL,
  `CreatedDate` timestamp NULL DEFAULT CURRENT_TIMESTAMP,
  `CreatedBy` varchar(128) DEFAULT NULL,
  `ModifyDate` datetime DEFAULT NULL,
  `ModifyBy` varchar(128) DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `Id` (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `cacmaster`
--

LOCK TABLES `cacmaster` WRITE;
/*!40000 ALTER TABLE `cacmaster` DISABLE KEYS */;
INSERT INTO `cacmaster` VALUES (3,'AM Credit Control','AM Bank','Menara AmCorp','H-123-A , Jalan PJS 123','Petaling Jaya 43212','43212','Selangor','01242234342',NULL,NULL,'03-61232123',NULL,'AmCopr@aec.com','2021-09-28 23:30:25','vinod@gmail.com','2021-10-02 06:11:35',NULL),(4,'PBB Credit Control','Public Bank Berhad','2nd Floor, No. 64 & No. 66, Jalan Tapah','Off Jalan Goh Hock Huat','Taman Sipah','41400','Selangor','+60121231231',NULL,NULL,NULL,NULL,'CAC_BG@pbb.net.com','2021-10-01 22:13:59','superadmin@gmail.com','2022-11-07 20:31:45',NULL),(5,'CIMB Hub','CIMB BANK BERHAD','Level 13, No. 26','Jalan Sultan Ismail',NULL,'50250','Kuala Lumpur','03-21807600',NULL,NULL,NULL,NULL,NULL,'2022-11-07 12:33:06','superadmin@gmail.com',NULL,NULL);
/*!40000 ALTER TABLE `cacmaster` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2022-11-18 17:39:32
