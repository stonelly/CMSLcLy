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
-- Table structure for table `aspnetuserroles`
--

DROP TABLE IF EXISTS `aspnetuserroles`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `aspnetuserroles` (
  `UserId` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `RoleId` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  PRIMARY KEY (`UserId`),
  KEY `FK_userroles.roles_idx` (`RoleId`),
  CONSTRAINT `FK_userroles.roles` FOREIGN KEY (`RoleId`) REFERENCES `aspnetroles` (`Id`),
  CONSTRAINT `FK_userroles.user` FOREIGN KEY (`UserId`) REFERENCES `aspnetusers` (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `aspnetuserroles`
--

LOCK TABLES `aspnetuserroles` WRITE;
/*!40000 ALTER TABLE `aspnetuserroles` DISABLE KEYS */;
INSERT INTO `aspnetuserroles` VALUES ('9e6dd302-1fcd-4f1c-93e0-159ed513563f','0e508b9c-b53f-4d9e-b1e1-990cf225eba9'),('7802176c-abc4-44d8-b0cf-bb4d25124121','4765307e-2ad1-4b4d-89ab-8ba6581f9486'),('51b2ab25-fb9b-4454-b938-f8618d5f7adb','808775c3-ffe7-4561-9dee-6eae35b9a9a2'),('6bc8cee0-a03e-430b-9711-420ab0d6a596','808775c3-ffe7-4561-9dee-6eae35b9a9a2'),('7a956b51-0bab-4317-8366-e3b2a49be946','808775c3-ffe7-4561-9dee-6eae35b9a9a2'),('8442a3d2-eca6-4c09-a8f1-3dc3f31267d9','808775c3-ffe7-4561-9dee-6eae35b9a9a2'),('c610c2f0-7647-470a-861f-ef8cfd3c3d67','808775c3-ffe7-4561-9dee-6eae35b9a9a2'),('de6f1df5-265e-4a9f-9d65-df3ec4f3ad2d','808775c3-ffe7-4561-9dee-6eae35b9a9a2'),('f89251b9-2b48-4bcf-a525-2cc3929380ba','83202f7a-438d-4a68-9bbf-bdd86dc5871c'),('2afb086f-1501-400b-9df2-447afd08d6b9','b39cb724-c79c-40f8-a4d1-5bf957d7e4da'),('9a358623-369a-4948-a7de-c13f1768bf1d','d09a8953-8c25-46ec-8719-8f40e84279cc'),('d5143ca4-e3b3-4fdf-af75-bbd944b8e0d4','d09a8953-8c25-46ec-8719-8f40e84279cc'),('d53edee5-21b6-47a1-b18b-207a7bb90c45','d09a8953-8c25-46ec-8719-8f40e84279cc'),('54c1a940-1b4a-4972-8a1a-5eea16bd9c39','dc01aae1-e15e-49d3-b593-8e990088633c');
/*!40000 ALTER TABLE `aspnetuserroles` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2022-11-18 17:39:31
