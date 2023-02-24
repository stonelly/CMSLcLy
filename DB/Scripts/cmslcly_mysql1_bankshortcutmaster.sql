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
-- Table structure for table `bankshortcutmaster`
--

DROP TABLE IF EXISTS `bankshortcutmaster`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `bankshortcutmaster` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `BankShortCut` varchar(50) NOT NULL,
  `BankName` varchar(128) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `CompanyNo` varchar(128) DEFAULT NULL,
  `RegistrationAddress` varchar(128) DEFAULT NULL,
  `CreatedDate` timestamp NULL DEFAULT CURRENT_TIMESTAMP,
  `CreatedBy` varchar(128) DEFAULT NULL,
  `ModifyDate` datetime DEFAULT NULL,
  `ModifyBy` varchar(128) DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `Id` (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `bankshortcutmaster`
--

LOCK TABLES `bankshortcutmaster` WRITE;
/*!40000 ALTER TABLE `bankshortcutmaster` DISABLE KEYS */;
INSERT INTO `bankshortcutmaster` VALUES (1,'HSBC','The Hongkong and Shanghai Banking Corporation','0127776V',NULL,'2021-09-28 23:48:27','vinod@gmail.com','2021-09-29 11:31:06',NULL),(2,'PBB','Public Bank Berhad','196501000672 (6463-H)',NULL,'2021-09-28 23:49:01','vinod@gmail.com','2022-11-07 20:34:20',NULL),(3,'CITI','CITIBANK BERHAD','199401011410 (297089-M).',NULL,'2021-09-28 23:49:35','vinod@gmail.com','2021-09-29 11:31:08',NULL),(4,'AM','AM Bank','01242776V',NULL,'2021-10-13 08:51:02','superadmin@gmail.com',NULL,NULL),(5,'MBB','Maybank Berhad','03212776V',NULL,'2021-10-13 08:57:24','superadmin@gmail.com',NULL,NULL);
/*!40000 ALTER TABLE `bankshortcutmaster` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2022-11-18 17:39:29
