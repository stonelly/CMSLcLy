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
-- Table structure for table `firmprofile`
--

DROP TABLE IF EXISTS `firmprofile`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `firmprofile` (
  `ID` int NOT NULL,
  `firm_name` varchar(256) DEFAULT NULL,
  `add1` varchar(100) DEFAULT NULL,
  `add2` varchar(100) DEFAULT NULL,
  `add3` varchar(100) DEFAULT NULL,
  `add4` varchar(100) DEFAULT NULL,
  `postcode` varchar(45) DEFAULT NULL,
  `Town` varchar(45) DEFAULT NULL,
  `state` varchar(45) DEFAULT NULL,
  `Country` varchar(100) DEFAULT NULL,
  `phone1` varchar(45) DEFAULT NULL,
  `phone2` varchar(45) DEFAULT NULL,
  `phone3` varchar(45) DEFAULT NULL,
  `fax1` varchar(45) DEFAULT NULL,
  `fax2` varchar(45) DEFAULT NULL,
  `email` varchar(100) DEFAULT NULL,
  `irb_no` varchar(45) DEFAULT NULL,
  `irb_branch` varchar(100) DEFAULT NULL,
  `socso_no` varchar(45) DEFAULT NULL,
  `socso_branch` varchar(100) DEFAULT NULL,
  `epf_no` varchar(45) DEFAULT NULL,
  `epf_branch` varchar(100) DEFAULT NULL,
  `gst_sst_no` varchar(45) DEFAULT NULL,
  `freefield1` varchar(45) DEFAULT NULL,
  `freefield2` varchar(45) DEFAULT NULL,
  `freefield3` varchar(45) DEFAULT NULL,
  `freefield4` varchar(45) DEFAULT NULL,
  `freefield5` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `firmprofile`
--

LOCK TABLES `firmprofile` WRITE;
/*!40000 ALTER TABLE `firmprofile` DISABLE KEYS */;
INSERT INTO `firmprofile` VALUES (1,'Law Chambers of Low & Yow','No. 21,','Jalan Tapah,','Off Jalan Goh Hock Huat','NULL','41400','Klang','Selangor','Malaysia','+60333456611',NULL,NULL,'+6033114404',NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,'54c1a940-1b4a-4972-8a1a-5eea16bd9c39',NULL,NULL,NULL,NULL);
/*!40000 ALTER TABLE `firmprofile` ENABLE KEYS */;
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
