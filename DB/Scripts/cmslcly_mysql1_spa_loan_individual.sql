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
-- Table structure for table `spa_loan_individual`
--

DROP TABLE IF EXISTS `spa_loan_individual`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `spa_loan_individual` (
  `ID` int NOT NULL AUTO_INCREMENT,
  `Document_ID` int NOT NULL,
  `Document_Type_Name` varchar(255) NOT NULL DEFAULT '',
  `Document_Agreement_Name` varchar(255) NOT NULL DEFAULT '',
  `Tenure_Type_Id` int DEFAULT NULL,
  `Land_Usage_Type_Id` int DEFAULT NULL,
  `Area_Id` int DEFAULT NULL,
  `State_Id` int DEFAULT NULL,
  `Area_Type_Id` int DEFAULT NULL,
  `Geran_Type_ID` int DEFAULT NULL,
  `Date_Open_File` datetime DEFAULT NULL,
  `Condition_Type_ID` int DEFAULT NULL,
  `Restriction_Type_ID` int DEFAULT NULL,
  `Building_Type_ID` int DEFAULT NULL,
  `Postal_Address` varchar(255) DEFAULT '',
  `CreatedDate` timestamp NULL DEFAULT NULL,
  `CreatedBy` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  PRIMARY KEY (`ID`) USING BTREE
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `spa_loan_individual`
--

LOCK TABLES `spa_loan_individual` WRITE;
/*!40000 ALTER TABLE `spa_loan_individual` DISABLE KEYS */;
INSERT INTO `spa_loan_individual` VALUES (1,6,'SPA','Loan Individual',10,47,0,0,36,39,'2022-09-11 00:03:44',43,52,53,'H.S.(M) 49192, P.T. 84950, Mukim Kapar, Daerah Klang, Negeri Selangor','2022-09-10 16:03:44','superadmin@gmail.com'),(5,76,'SPA','Loan Individual',NULL,48,74,58,NULL,40,'2022-08-11 00:00:00',43,51,53,'adds','2022-11-06 05:27:14','superadmin@gmail.com'),(6,84,'POTC','Loan Individual',NULL,48,75,58,NULL,40,'2022-01-11 00:00:00',42,51,53,'hi','2022-11-07 12:04:54','superadmin@gmail.com');
/*!40000 ALTER TABLE `spa_loan_individual` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2022-11-18 17:39:28
