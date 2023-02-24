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
-- Table structure for table `spa_loan_chain_of_ownership`
--

DROP TABLE IF EXISTS `spa_loan_chain_of_ownership`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `spa_loan_chain_of_ownership` (
  `ID` int NOT NULL AUTO_INCREMENT,
  `DocumentId` int NOT NULL,
  `Document_Type_Name` varchar(255) NOT NULL DEFAULT '',
  `Document_Agreement_Name` varchar(255) NOT NULL DEFAULT '',
  `Purchaser1_User_ID` int DEFAULT NULL,
  `Purchaser1_DOA_Date` timestamp NULL DEFAULT NULL,
  `Purchaser1_FA_Date` timestamp NULL DEFAULT NULL,
  `Purchaser1_Loan_Date` timestamp NULL DEFAULT NULL,
  `Purchaser1_DRR_Date` timestamp NULL DEFAULT NULL,
  `Purchaser2_User_ID` int DEFAULT NULL,
  `Purchaser2_DOA_Date` timestamp NULL DEFAULT NULL,
  `Purchaser2_FA_Date` timestamp NULL DEFAULT NULL,
  `Purchaser2_Loan_Date` timestamp NULL DEFAULT NULL,
  `Purchaser2_DRR_Date` timestamp NULL DEFAULT NULL,
  `Purchaser3_User_ID` int DEFAULT NULL,
  `Purchaser3_DOA_Date` timestamp NULL DEFAULT NULL,
  `Purchaser3_FA_Date` timestamp NULL DEFAULT NULL,
  `Purchaser3_Loan_Date` timestamp NULL DEFAULT NULL,
  `Purchaser3_DRR_Date` timestamp NULL DEFAULT NULL,
  `Purchaser4_User_ID` int DEFAULT NULL,
  `Purchaser4_DOA_Date` timestamp NULL DEFAULT NULL,
  `Purchaser4_FA_Date` timestamp NULL DEFAULT NULL,
  `Purchaser4_Loan_Date` timestamp NULL DEFAULT NULL,
  `Purchaser4_DRR_Date` timestamp NULL DEFAULT NULL,
  `Purchaser5_User_ID` int DEFAULT NULL,
  `Purchaser5_DOA_Date` timestamp NULL DEFAULT NULL,
  `Purchaser5_FA_Date` timestamp NULL DEFAULT NULL,
  `Purchaser5_Loan_Date` timestamp NULL DEFAULT NULL,
  `Purchaser5_DRR_Date` timestamp NULL DEFAULT NULL,
  `Purchaser6_User_ID` int DEFAULT NULL,
  `Purchaser6_DOA_Date` timestamp NULL DEFAULT NULL,
  `Purchaser6_FA_Date` timestamp NULL DEFAULT NULL,
  `Purchaser6_Loan_Date` timestamp NULL DEFAULT NULL,
  `Purchaser6_DRR_Date` timestamp NULL DEFAULT NULL,
  `Purchaser7_User_ID` int DEFAULT NULL,
  `Purchaser7_DOA_Date` timestamp NULL DEFAULT NULL,
  `Purchaser7_FA_Date` timestamp NULL DEFAULT NULL,
  `Purchaser7_Loan_Date` timestamp NULL DEFAULT NULL,
  `Purchaser7_DRR_Date` timestamp NULL DEFAULT NULL,
  `CreatedDate` timestamp NULL DEFAULT NULL,
  `CreatedBy` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  PRIMARY KEY (`ID`) USING BTREE
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `spa_loan_chain_of_ownership`
--

LOCK TABLES `spa_loan_chain_of_ownership` WRITE;
/*!40000 ALTER TABLE `spa_loan_chain_of_ownership` DISABLE KEYS */;
INSERT INTO `spa_loan_chain_of_ownership` VALUES (1,6,'SPA','Chain of Ownership',13,'2022-09-10 16:47:47','2022-09-10 16:47:47','2022-09-10 16:47:47','2022-09-10 16:47:47',0,'2022-09-10 16:47:47','2022-09-10 16:47:47','2022-09-10 16:47:47','2022-09-10 16:47:47',0,'2022-09-10 16:47:47','2022-09-10 16:47:47','2022-09-10 16:47:47','2022-09-10 16:47:47',0,'2022-09-10 16:47:47','2022-09-10 16:47:47','2022-09-10 16:47:47','2022-09-10 16:47:47',0,'2022-09-10 16:47:47','2022-09-10 16:47:47','2022-09-10 16:47:47','2022-09-10 16:47:47',0,'2022-09-10 16:47:47','2022-09-10 16:47:47','2022-09-10 16:47:47','2022-09-10 16:47:47',0,'2022-09-10 16:47:47','2022-09-10 16:47:47','2022-09-10 16:47:47','2022-09-10 16:47:47','2022-09-10 16:47:47','superadmin@gmail.com');
/*!40000 ALTER TABLE `spa_loan_chain_of_ownership` ENABLE KEYS */;
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