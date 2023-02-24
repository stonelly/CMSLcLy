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
-- Table structure for table `workflowmaster`
--

DROP TABLE IF EXISTS `workflowmaster`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `workflowmaster` (
  `ID` int NOT NULL AUTO_INCREMENT,
  `WorkflowID` int DEFAULT NULL,
  `Sequence` int DEFAULT NULL,
  `WorkFlowMasterDesc` varchar(500) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `WorkFlowMasterDesc_BM` varchar(500) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `WorkFlowMasterDesc_CN` varchar(500) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `WorkFlowMasterDuration` int DEFAULT '0',
  `IsSNP` int DEFAULT '0',
  `IsCP` int DEFAULT '0',
  `CreatedDate` timestamp NULL DEFAULT NULL,
  `CreatedBy` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  PRIMARY KEY (`ID`) USING BTREE,
  UNIQUE KEY `WorkFlowMasterID_UNIQUE` (`ID`) USING BTREE
) ENGINE=InnoDB AUTO_INCREMENT=43 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `workflowmaster`
--

LOCK TABLES `workflowmaster` WRITE;
/*!40000 ALTER TABLE `workflowmaster` DISABLE KEYS */;
INSERT INTO `workflowmaster` VALUES (1,1,1,'Getting Up','Penyediaan','',29,0,0,'2021-08-04 09:22:55','vinod@gmail.com'),(2,1,2,'S&P commence','Perjanjian Jualbeli Mula ','',65,0,0,'2021-08-04 09:23:46','vinod@gmail.com'),(3,1,3,'Payment (Differential Sum & stamping)','Bayaran (Duit Beza dan Duti Setem)','',30,0,0,'2021-08-20 03:50:07','vinod@gmail.com'),(4,1,4,'Payment from EPF for balance deposit, if appliable','Bayaran baki deposit melalui EPF (sekiranya ada)','',15,0,0,'2021-08-20 03:50:53','vinod@gmail.com'),(5,1,5,'Pay retention sum','Bayar remit Balasan','',20,0,0,'2021-08-20 04:37:41','vinod@gmail.com'),(14,2,1,'1','2','3',4,0,0,'2021-10-02 01:18:12',NULL),(15,2,2,'2','3','4',5,0,0,'2021-10-02 01:23:03',NULL),(16,2,5,'5','5','5',5,0,0,'2021-10-02 01:23:44',NULL),(17,2,5,'99','88','3',4,0,0,'2021-10-02 01:25:26',NULL),(18,NULL,6,'Final input','Langkah akhir',NULL,2,NULL,NULL,'2022-01-20 08:59:03',NULL),(19,NULL,6,'Final input','Langkah akhir',NULL,2,NULL,NULL,'2022-01-20 09:00:47',NULL),(20,4,1,'Step 1','Langkah 1',NULL,10,NULL,NULL,'2022-11-02 11:12:31',NULL),(21,4,2,'step 2','Langkah 2',NULL,10,NULL,NULL,'2022-11-02 11:12:52',NULL),(22,4,3,'Step 3','Langkah 3',NULL,10,NULL,NULL,'2022-11-02 11:13:17',NULL),(23,4,4,'step 4','Langkah 4',NULL,10,NULL,NULL,'2022-11-02 11:13:43',NULL),(24,4,5,'Step 5','Langkah 5',NULL,10,NULL,NULL,'2022-11-02 11:14:06',NULL),(25,4,6,'Step 6 - Sign off','Langkah 6',NULL,30,NULL,NULL,'2022-11-02 11:16:01',NULL),(26,5,1,'forward quotation to client follow up with client',NULL,NULL,1,NULL,NULL,'2022-11-13 06:11:36',NULL),(27,5,2,'follow up with client',NULL,NULL,1,NULL,NULL,'2022-11-13 06:12:22',NULL),(28,5,3,'Getting up -collect the followings documents:- (i) Purchaser\'s IC (ii) Vendor\'s IC (iii) cukai taksiran (iv) SPA (v) title',NULL,NULL,1,NULL,NULL,'2022-11-13 06:12:46',NULL),(29,5,2,'documents collected - prepare the SPA within 5 working days',NULL,NULL,4,NULL,NULL,'2022-11-13 06:13:09',NULL),(30,5,5,'The SPA is ready - arrange the Purchaser to sign to sign the SPA',NULL,NULL,5,NULL,NULL,'2022-11-13 06:13:39',NULL),(31,5,6,'Purchaser has signed the SPA. Thereafter, arrange the Vendor to sign the SPA',NULL,NULL,2,NULL,NULL,'2022-11-13 06:14:00',NULL),(32,5,7,'The Vendor has signed the SPA. Arrange the SPA to be stamped. Key in the SPA date in the system',NULL,NULL,2,NULL,NULL,'2022-11-13 06:14:18',NULL),(33,5,8,'Forward the stamped the SPA to the :- (i) Vendor (ii) Purchaser (iii) agent (iv) Purchaser\'s Financier\'s Solicitors. Lodge private caveat',NULL,NULL,2,NULL,NULL,'2022-11-13 06:14:42',NULL),(34,5,9,'received the letter from the Purchaser\'s Financier\'s Solicitor to request for documents',NULL,NULL,3,NULL,NULL,'2022-11-13 06:15:41',NULL),(35,5,10,'adjudicate the Memorandum of Transfer and reply to the Purchaser\'s Financier\'s Solicitors\'s letter. Request for the Purchaser\'s Financier\'s Undertaking.',NULL,NULL,5,NULL,NULL,'2022-11-13 06:15:57',NULL),(36,5,11,'collect the differential sum and legal fees. Pay stamp duty on the memorandum of transfer',NULL,NULL,3,NULL,NULL,'2022-11-13 06:16:23',NULL),(37,5,12,'received differential sum and Purchaser\'s Financier\'s Undertaking. Inform the Vendor to get ready to deliver vacant possession.',NULL,NULL,3,NULL,NULL,'2022-11-13 06:16:48',NULL),(38,5,13,'forward the duly stamped duly stamped Memorandum of Transfer, confirmation that differential sum paid and title to the Purchaser\'s Financier\'s Solicitors',NULL,NULL,3,NULL,NULL,'2022-11-13 06:17:11',NULL),(39,5,14,'received the Balance Purchase Price and prepare for apportionment of outgoings. Request the Vendor to deposit the keys of the Property with the SPA solicitors.',NULL,NULL,10,NULL,NULL,'2022-11-13 06:17:28',NULL),(40,5,15,'released Balance Purchase Price and hand over vacant possession',NULL,NULL,5,NULL,NULL,'2022-11-13 06:17:45',NULL),(41,5,16,'file the documents for change of address and recipient of the assessment receipt',NULL,NULL,3,NULL,NULL,'2022-11-13 06:18:07',NULL),(42,5,17,'close file',NULL,NULL,5,NULL,NULL,'2022-11-13 06:18:21',NULL);
/*!40000 ALTER TABLE `workflowmaster` ENABLE KEYS */;
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
