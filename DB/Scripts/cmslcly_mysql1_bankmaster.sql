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
-- Table structure for table `bankmaster`
--

DROP TABLE IF EXISTS `bankmaster`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `bankmaster` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `BankShortCutID` int NOT NULL,
  `BranchName` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL DEFAULT '',
  `Address` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `Address2` varchar(255) DEFAULT '',
  `Address3` varchar(255) DEFAULT '',
  `PostCode` varchar(10) DEFAULT '',
  `State` varchar(50) DEFAULT '',
  `Phone` varchar(50) DEFAULT '',
  `Phone2` varchar(50) DEFAULT '',
  `Phone3` varchar(50) DEFAULT '',
  `Fax` varchar(50) DEFAULT '',
  `Fax2` varchar(50) DEFAULT '',
  `Email` varchar(50) DEFAULT '',
  `CACID` int NOT NULL,
  `Remarks` varchar(50) DEFAULT '',
  `CreatedDate` timestamp NULL DEFAULT CURRENT_TIMESTAMP,
  `CreatedBy` varchar(128) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `ModifyDate` datetime DEFAULT NULL,
  `ModifyBy` varchar(128) DEFAULT NULL,
  PRIMARY KEY (`Id`) USING BTREE,
  KEY `Id` (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `bankmaster`
--

LOCK TABLES `bankmaster` WRITE;
/*!40000 ALTER TABLE `bankmaster` DISABLE KEYS */;
INSERT INTO `bankmaster` VALUES (1,1,'CITI Ampang','Menara Hup Seng','H-123-A , Jalan P.Ramlee','KL 532121','53212','Kuala Lumpur','0123456789',NULL,NULL,'03-21232123',NULL,'HSBC@tedd.com',2,'try samve hsbc','2021-09-29 06:55:30','vinod@gmail.com','2022-01-05 20:08:43','superadmin@gmail.com'),(3,2,'Jalan Tapah','No. 62, 64 & 66, Jalan Tapah','Off Jalan Goh Hock Huat',NULL,'41400','Selangor',NULL,NULL,NULL,NULL,NULL,NULL,4,NULL,'2022-11-07 12:26:48','superadmin@gmail.com','2022-11-07 20:26:48','superadmin@gmail.com');
/*!40000 ALTER TABLE `bankmaster` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2022-11-18 17:39:33
