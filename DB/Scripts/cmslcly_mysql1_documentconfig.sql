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
-- Table structure for table `documentconfig`
--

DROP TABLE IF EXISTS `documentconfig`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `documentconfig` (
  `documentID` int NOT NULL AUTO_INCREMENT,
  `documentType` varchar(50) DEFAULT NULL,
  `documentPath` varchar(1000) DEFAULT NULL,
  `documentName` varchar(200) DEFAULT NULL,
  `dataSource` varchar(100) DEFAULT NULL,
  `primary_key` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`documentID`)
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `documentconfig`
--

LOCK TABLES `documentconfig` WRITE;
/*!40000 ALTER TABLE `documentconfig` DISABLE KEYS */;
INSERT INTO `documentconfig` VALUES (1,'SPA','C:inetpubwwwbackendDocumentTemplateSPA Strata.docx','SPA Strata.docx','dsspa_loan_for_loan','ClientID'),(3,'MOT Both company','','MOT Both company.docx','dsspa_loan_for_loan','ClientID'),(4,'MOT 2V & 2P','','MOT 2V & 2P.docx','dsspa_loan_for_loan','ClientID'),(5,'Letter (P & V) confirmation - encumbred','','Letter (P & V) confirmation - encumbred.docx','dsspa_loan_for_loan','ClientID'),(6,'MOT 2V & 2P','DocumentTemplate','test.docx','dsspa_loan_for_loan','ClientID');
/*!40000 ALTER TABLE `documentconfig` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2022-11-18 17:39:27
