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
-- Table structure for table `spa_loan_strata`
--

DROP TABLE IF EXISTS `spa_loan_strata`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `spa_loan_strata` (
  `ID` int NOT NULL AUTO_INCREMENT,
  `DocumentId` int NOT NULL,
  `Document_Type_Name` varchar(255) NOT NULL DEFAULT '',
  `Document_Agreement_Name` varchar(255) NOT NULL DEFAULT '',
  `Tenure_Type_Id` int DEFAULT NULL,
  `Lot_Type_Id` int DEFAULT NULL,
  `Area_Id` int DEFAULT NULL,
  `State_Id` int DEFAULT NULL,
  `Area_Type_Id` int DEFAULT NULL,
  `Geran_Type_Id` int DEFAULT NULL,
  `Date_Open_File` datetime DEFAULT NULL,
  `Land_Usage_Type_Id` int DEFAULT NULL,
  `Condition_Type_Id` int DEFAULT NULL,
  `Restriction_Type_Id` int DEFAULT NULL,
  `Building_Type_Id` int DEFAULT NULL,
  `Postal_Address` varchar(255) DEFAULT '',
  `Parcel_No` varchar(255) DEFAULT '',
  `Story_No` varchar(255) DEFAULT '',
  `Building_No` varchar(255) DEFAULT '',
  `Parcel_No_Description` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT '',
  `Unit_Area` int DEFAULT NULL,
  `CreatedDate` timestamp NULL DEFAULT NULL,
  `CreatedBy` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  PRIMARY KEY (`ID`) USING BTREE
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `spa_loan_strata`
--

LOCK TABLES `spa_loan_strata` WRITE;
/*!40000 ALTER TABLE `spa_loan_strata` DISABLE KEYS */;
INSERT INTO `spa_loan_strata` VALUES (1,6,'SPA','Strata Loan',10,29,0,0,36,39,'2022-09-11 00:21:48',47,42,51,54,'H.S.(M) 49192, P.T. 84950, Mukim Kapar, Daerah Klang, Negeri Selangor','No.28','2','A','parcel description',36,'2022-09-10 16:21:48','superadmin@gmail.com'),(3,76,'SPA','Loan Strata',NULL,NULL,NULL,NULL,NULL,39,'0001-01-01 00:00:00',NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,'2022-11-06 05:27:14','superadmin@gmail.com'),(4,84,'POTC','Loan Strata',NULL,30,73,58,NULL,39,'2022-08-11 00:00:00',49,44,51,54,'sdfs','ad','235','356','A234',NULL,'2022-11-07 12:04:54','superadmin@gmail.com');
/*!40000 ALTER TABLE `spa_loan_strata` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2022-11-18 17:39:30
