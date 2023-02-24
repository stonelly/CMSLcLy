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
-- Table structure for table `spa_loan_for_loan`
--

DROP TABLE IF EXISTS `spa_loan_for_loan`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `spa_loan_for_loan` (
  `ID` int NOT NULL AUTO_INCREMENT,
  `DocumentId` int NOT NULL,
  `Document_Type_Name` varchar(255) NOT NULL DEFAULT '',
  `Document_Agreement_Name` varchar(255) NOT NULL DEFAULT '',
  `Borrower1_User_ID` int DEFAULT NULL,
  `Borrower2_User_ID` int DEFAULT NULL,
  `Borrower3_User_ID` int DEFAULT NULL,
  `Borrower4_User_ID` int DEFAULT NULL,
  `Borrower5_User_ID` int DEFAULT NULL,
  `Guarantor1_User_ID` int DEFAULT NULL,
  `Guarantor2_User_ID` int DEFAULT NULL,
  `Guarantor3_User_ID` int DEFAULT NULL,
  `Guarantor4_User_ID` int DEFAULT NULL,
  `Guarantor5_User_ID` int DEFAULT NULL,
  `Bank_Branch_ID` int DEFAULT NULL,
  `Bank_Reference` varchar(255) NOT NULL DEFAULT '',
  `Offer_Letter_Date` datetime DEFAULT NULL,
  `Letter_of_Instruction_Date` datetime DEFAULT NULL,
  `Officer1_Id` int NOT NULL DEFAULT '0',
  `Officer1_Username` varchar(255) NOT NULL DEFAULT '',
  `Officer1_Password` varchar(255) NOT NULL DEFAULT '',
  `Officer2_Id` int NOT NULL DEFAULT '0',
  `Officer2_Username` varchar(255) NOT NULL DEFAULT '',
  `Officer2_Password` varchar(255) NOT NULL DEFAULT '',
  `Conventional_Loan_Type` int DEFAULT NULL,
  `Conventional_Financing_Type` int DEFAULT NULL,
  `Conventional_Loan_Amount` decimal(19,4) NOT NULL,
  `Other_Loan1_Type` int DEFAULT NULL,
  `Other_Loan1_Amount` decimal(19,4) NOT NULL,
  `Other_Loan2_Type` int DEFAULT NULL,
  `Other_Loan2_Amount` decimal(19,4) NOT NULL,
  `Other_Loan3_Type` int DEFAULT NULL,
  `Other_Loan3_Amount` decimal(19,4) NOT NULL,
  `Other_Loan4_Type` int DEFAULT NULL,
  `Other_Loan4_Amount` decimal(19,4) NOT NULL,
  `Other_Loan5_Type` int DEFAULT NULL,
  `Other_Loan5_Amount` decimal(19,4) NOT NULL,
  `Other_Loan6_Type` int DEFAULT NULL,
  `Other_Loan6_Amount` decimal(19,4) NOT NULL,
  `Conventional_Loan_Total_Financing_Sum` decimal(19,4) NOT NULL,
  `Islamic_Loan_Type` int DEFAULT NULL,
  `Islamic_Financing_Type` int DEFAULT NULL,
  `Islamic_Financing_Amount` decimal(19,4) NOT NULL,
  `Other_Financing1_Type` int DEFAULT NULL,
  `Other_Financing1_Amount` decimal(19,4) NOT NULL,
  `Other_Financing2_Type` int DEFAULT NULL,
  `Other_Financing2_Amount` decimal(19,4) NOT NULL,
  `Other_Financing3_Type` int DEFAULT NULL,
  `Other_Financing3_Amount` decimal(19,4) NOT NULL,
  `Other_Financing4_Type` int DEFAULT NULL,
  `Other_Financing4_Amount` decimal(19,4) NOT NULL,
  `Other_Financing5_Type` int DEFAULT NULL,
  `Other_Financing5_Amount` decimal(19,4) NOT NULL,
  `Islamic_Loan_Total_Financing_Sum` decimal(19,4) NOT NULL,
  `Bank_Selling_Price` decimal(19,4) NOT NULL,
  `Bank_Purchase_Price` decimal(19,4) NOT NULL,
  `Other_Islamic_Loan1_Bank_Name` varchar(255) NOT NULL DEFAULT '0',
  `Other_Islamic_Loan1_Product_Type` int DEFAULT '0',
  `Other_Islamic_Loan1_Specification` varchar(255) NOT NULL DEFAULT '',
  `Other_Islamic_Loan1_Amount` decimal(19,4) NOT NULL,
  `Other_Islamic_Loan1_Unit_Percentage` decimal(19,4) NOT NULL,
  `Other_Islamic_Loan1_Ref` varchar(255) NOT NULL DEFAULT '',
  `Other_Islamic_Loan2_Bank_Name` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL DEFAULT '',
  `Other_Islamic_Loan2_Product_Type` int DEFAULT '0',
  `Other_Islamic_Loan2_Specification` varchar(255) NOT NULL DEFAULT '',
  `Other_Islamic_Loan2_Amount` decimal(19,4) NOT NULL,
  `Other_Islamic_Loan2_Unit_Percentage` decimal(19,4) NOT NULL,
  `Other_Islamic_Loan2_Ref` varchar(255) NOT NULL DEFAULT '',
  `Other_Islamic_Loan3_Bank_Name` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL DEFAULT '',
  `Other_Islamic_Loan3_Product_Type` int DEFAULT '0',
  `Other_Islamic_Loan3_Specification` varchar(255) NOT NULL DEFAULT '',
  `Other_Islamic_Loan3_Amount` decimal(19,4) NOT NULL,
  `Other_Islamic_Loan3_Unit_Percentage` decimal(19,4) NOT NULL,
  `Other_Islamic_Loan3_Ref` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL DEFAULT '',
  `Other_Islamic_Loan4_Bank_Name` varchar(255) NOT NULL DEFAULT '',
  `Other_Islamic_Loan4_Product_Type` int DEFAULT '0',
  `Other_Islamic_Loan4_Specification` varchar(255) NOT NULL DEFAULT '',
  `Other_Islamic_Loan4_Amount` decimal(19,4) NOT NULL,
  `Other_Islamic_Loan4_Unit_Percentage` decimal(19,4) NOT NULL,
  `Other_Islamic_Loan4_Ref` varchar(255) NOT NULL DEFAULT '',
  `Other_Islamic_Loan5_Bank_Name` varchar(255) NOT NULL DEFAULT '',
  `Other_Islamic_Loan5_Product_Type` int DEFAULT '0',
  `Other_Islamic_Loan5_Specification` varchar(255) NOT NULL DEFAULT '',
  `Other_Islamic_Loan5_Amount` decimal(19,4) NOT NULL,
  `Other_Islamic_Loan5_Unit_Percentage` decimal(19,4) NOT NULL,
  `Other_Islamic_Loan5_Ref` varchar(255) NOT NULL DEFAULT '',
  `Other_Islamic_Loan6_Bank_Name` varchar(255) NOT NULL DEFAULT '',
  `Other_Islamic_Loan6_Product_Type` int DEFAULT '0',
  `Other_Islamic_Loan6_Specification` varchar(255) NOT NULL DEFAULT '',
  `Other_Islamic_Loan6_Amount` decimal(19,4) NOT NULL,
  `Other_Islamic_Loan6_Unit_Percentage` decimal(19,4) NOT NULL,
  `Other_Islamic_Loan6_Ref` varchar(255) NOT NULL DEFAULT '',
  `Other_Islamic_Loan7_Bank_Name` varchar(255) NOT NULL DEFAULT '',
  `Other_Islamic_Loan7_Product_Type` int DEFAULT '0',
  `Other_Islamic_Loan7_Specification` varchar(255) NOT NULL DEFAULT '',
  `Other_Islamic_Loan7_Amount` decimal(19,4) NOT NULL,
  `Other_Islamic_Loan7_Unit_Percentage` decimal(19,4) NOT NULL,
  `Other_Islamic_Loan7_Ref` varchar(255) NOT NULL DEFAULT '',
  `Bank_Solicitor_ID` int DEFAULT NULL,
  `Bank_Solicitor_Firm_Phone_No` varchar(255) NOT NULL DEFAULT '',
  `Bank_Solicitor_Firm_Address1` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL DEFAULT '',
  `Bank_Solicitor_Firm_Address2` varchar(255) NOT NULL DEFAULT '',
  `Bank_Solicitor_Firm_Postcode` varchar(255) NOT NULL DEFAULT '',
  `Bank_Solicitor_Firm_City` varchar(255) NOT NULL DEFAULT '',
  `Bank_Solicitor_Firm_State` varchar(255) NOT NULL DEFAULT '',
  `Bank_Solicitor_Ref` varchar(255) NOT NULL DEFAULT '',
  `Bank_Solicitor_Email` varchar(255) NOT NULL DEFAULT '',
  `CreatedDate` timestamp NULL DEFAULT NULL,
  `CreatedBy` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  PRIMARY KEY (`ID`) USING BTREE
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `spa_loan_for_loan`
--

LOCK TABLES `spa_loan_for_loan` WRITE;
/*!40000 ALTER TABLE `spa_loan_for_loan` DISABLE KEYS */;
INSERT INTO `spa_loan_for_loan` VALUES (1,6,'SPA','Loan',13,0,0,0,0,21,0,0,0,0,1,'bank test ref','2022-09-11 00:46:17','2022-09-11 00:46:17',23,'officer 1','password',0,'','',0,0,350000.0000,0,0.0000,0,0.0000,0,0.0000,0,0.0000,0,0.0000,0,0.0000,0.0000,0,0,0.0000,0,0.0000,0,0.0000,0,0.0000,0,0.0000,0,0.0000,0.0000,0.0000,0.0000,'0',0,'',0.0000,0.0000,'','',0,'',0.0000,0.0000,'','',0,'',0.0000,0.0000,'','',0,'',0.0000,0.0000,'','',0,'',0.0000,0.0000,'','',0,'',0.0000,0.0000,'','',0,'',0.0000,0.0000,'',8,'+60333456611','No. 21,Jalan Tapah,','Off Jalan Goh Hock Huat','41400','Klang','Selangor','test','test@gmail.com','2022-09-10 16:46:17','superadmin@gmail.com');
/*!40000 ALTER TABLE `spa_loan_for_loan` ENABLE KEYS */;
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
