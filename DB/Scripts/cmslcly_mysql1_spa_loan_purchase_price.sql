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
-- Table structure for table `spa_loan_purchase_price`
--

DROP TABLE IF EXISTS `spa_loan_purchase_price`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `spa_loan_purchase_price` (
  `ID` int NOT NULL AUTO_INCREMENT,
  `Document_ID` int NOT NULL,
  `Document_Type_Name` varchar(255) NOT NULL DEFAULT '',
  `Document_Agreement_Name` varchar(255) NOT NULL DEFAULT '',
  `Purchase_Price` decimal(19,4) NOT NULL,
  `Earnest_Deposit` decimal(19,4) NOT NULL,
  `RPGT_Retention_Sum` decimal(19,4) NOT NULL,
  `Balance_Deposit` decimal(19,4) NOT NULL,
  `Total_Deposit` decimal(19,4) NOT NULL,
  `Balance_Purchase_Price` decimal(19,4) NOT NULL,
  `Consuption_Tax` decimal(19,4) NOT NULL,
  `Purchase_Price_After_Tax` decimal(19,4) NOT NULL,
  `Adjustment_Rate` decimal(19,4) NOT NULL,
  `Bank_Branch_ID` int DEFAULT NULL,
  `Charge_Presentation_No` varchar(255) DEFAULT '',
  `Existing_Borrower1_User_ID` int DEFAULT NULL,
  `Existing_Borrower2_User_ID` int DEFAULT NULL,
  `Existing_Borrower3_User_ID` int DEFAULT NULL,
  `Existing_Borrower4_User_ID` int DEFAULT NULL,
  `Existing_Borrower5_User_ID` int DEFAULT NULL,
  `CreatedDate` timestamp NULL DEFAULT NULL,
  `CreatedBy` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  PRIMARY KEY (`ID`) USING BTREE
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `spa_loan_purchase_price`
--

LOCK TABLES `spa_loan_purchase_price` WRITE;
/*!40000 ALTER TABLE `spa_loan_purchase_price` DISABLE KEYS */;
INSERT INTO `spa_loan_purchase_price` VALUES (1,6,'SPA','Purchase_Price',500000.0000,14000.0000,0.0000,36000.0000,50000.0000,450000.0000,0.0000,500000.0000,0.0000,1,'',13,0,0,0,0,'2022-09-10 16:14:43','superadmin@gmail.com'),(2,11,'SPA','Loan Purchase Price',120000.0000,1000.0000,4000.0000,5000.0000,10000.0000,104000.0000,0.0000,0.0000,0.0000,1,NULL,0,0,0,0,0,'2022-10-09 16:37:11','superadmin@gmail.com'),(3,76,'SPA','Loan Purchase Price',500000.0000,15000.0000,15000.0000,20000.0000,50000.0000,329000.0000,6.0000,0.0000,0.0000,1,NULL,0,0,0,0,0,'2022-11-06 05:27:14','superadmin@gmail.com');
/*!40000 ALTER TABLE `spa_loan_purchase_price` ENABLE KEYS */;
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
