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
-- Table structure for table `messagemaster`
--

DROP TABLE IF EXISTS `messagemaster`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `messagemaster` (
  `ID` int NOT NULL AUTO_INCREMENT,
  `CustomerName` varchar(255) NOT NULL,
  `RoomName` varchar(255) NOT NULL,
  `Message` varchar(255) NOT NULL,
  `IsMessageRead` tinyint NOT NULL DEFAULT '0',
  `CreatedDate` datetime NOT NULL,
  `ModifiedDate` datetime NOT NULL,
  PRIMARY KEY (`ID`),
  KEY `ID` (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `messagemaster`
--

LOCK TABLES `messagemaster` WRITE;
/*!40000 ALTER TABLE `messagemaster` DISABLE KEYS */;
INSERT INTO `messagemaster` VALUES (1,'3c60fc6d-cb6f-47fd-844f-0924f7574aad','A001-0001','testing',0,'2022-03-04 21:51:57','2022-03-04 21:51:57'),(2,'3c60fc6d-cb6f-47fd-844f-0924f7574aad','A001-0001','test2',0,'2022-03-04 21:52:11','2022-03-04 21:52:12'),(3,'3c60fc6d-cb6f-47fd-844f-0924f7574aad','A001-0001','test3',0,'2022-03-04 22:19:17','2022-03-04 22:19:17'),(4,'3c60fc6d-cb6f-47fd-844f-0924f7574aad','A001-0001','test',0,'2022-03-20 00:40:53','2022-03-20 00:40:53'),(5,'3c60fc6d-cb6f-47fd-844f-0924f7574aad','A001-0002','test2',0,'2022-03-20 00:53:19','2022-03-20 00:53:19'),(6,'3c60fc6d-cb6f-47fd-844f-0924f7574aad','A001-0003','test3',0,'2022-03-20 00:53:24','2022-03-20 00:53:24'),(7,'3c60fc6d-cb6f-47fd-844f-0924f7574aad','A001-0004','test4',0,'2022-03-20 00:53:29','2022-03-20 00:53:29');
/*!40000 ALTER TABLE `messagemaster` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2022-11-18 17:39:34
