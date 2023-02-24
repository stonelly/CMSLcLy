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
-- Table structure for table `workflowdetail`
--

DROP TABLE IF EXISTS `workflowdetail`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `workflowdetail` (
  `ID` int NOT NULL AUTO_INCREMENT,
  `WorkflowMasterID` int NOT NULL DEFAULT '0',
  `Sequence` int DEFAULT NULL,
  `Description` varchar(500) DEFAULT NULL,
  `Description_BM` varchar(500) DEFAULT NULL,
  `Description_CN` varchar(500) DEFAULT NULL,
  `Duration` int DEFAULT '0',
  `CreatedDate` timestamp NULL DEFAULT CURRENT_TIMESTAMP,
  `CreatedBy` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  PRIMARY KEY (`ID`),
  KEY `ID` (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=45 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `workflowdetail`
--

LOCK TABLES `workflowdetail` WRITE;
/*!40000 ALTER TABLE `workflowdetail` DISABLE KEYS */;
INSERT INTO `workflowdetail` VALUES (1,1,1,'called Vendor and Purchaser - provide quotation - inform parties on the documents required','Telefon Penjual dan Pembeli - bagi sebut harga (quotation) - maklum pihak-pihak dokumen-dokumen yang perlu disediakan',NULL,1,'2021-10-01 22:37:04','vinod@gmail.com'),(2,1,2,'follow up with Purchaser on the quotation','follow up dengan pembeli bagi berkenaan dengan sebut harga',NULL,2,'2021-10-23 12:24:13','vinod@gmail.com'),(3,1,3,'Purchaser appointed Law Chambers of Low & Yow','Pembeli melantik Tetuan Law Chambers of Low & Yow',NULL,1,'2021-10-23 12:25:40','vinod@gmail.com'),(4,1,4,'Received all the necessary documents and prepare sale and purchase agreement (complete within 5 working days) - fixed appointment with Purchaser and Vendor for execution of S&P','Terima semua dokumen-dokumen yang diperlukan. Buat perjanjian jual beli (Sedia dan lengkap dalam 5 hari bekerja)  - tetapkan temujanji dengan Pembeli dan Penjual untuk  tandatangan Perjanjian Jualbeli\r\n',NULL,1,'2021-10-01 22:37:04','vinod@gmail.com'),(5,1,5,' Sale and Purchase Agreement land search and bankruptcy search completed','Perjanjian Jualbeli, carian bankrup dan carian tanah siap\r\n',NULL,4,'2021-10-01 22:37:04','vinod@gmail.com'),(6,1,6,'Purchaser signed the S&P. \r\n','Pembeli tandatangan Perjanjian Jualbeli\r\n',NULL,2,'2021-10-01 22:37:04','vinod@gmail.com'),(7,1,7,'Vendor signed the S&P\r\n','Penjual tandatangan Perjanjian Jualbeli\r\n',NULL,2,'2021-10-01 22:37:04','vinod@gmail.com'),(8,1,8,'Date S&P and insert the S&P date on the system\r\n',' tarikhkan Perjanjian Jualbeli dan masukkan tarikh dalam system KIV\r\n',NULL,1,'2021-10-01 22:37:04','vinod@gmail.com'),(9,2,1,'stamped S&P and forward to agent. \r\n','stamp Perjanjian Jualbeli dan beri kepada agent hartanah \r\n',NULL,2,'2021-10-01 22:37:04','vinod@gmail.com'),(10,2,2,'Affirm SD for caveat\r\n','Ikrarkan Surat Akuan untuk caveat\r\n',NULL,1,'2021-10-01 22:37:04','vinod@gmail.com'),(11,2,3,'lodge private caveat. \r\n','masukkan caveat persendirian \r\n',NULL,1,'2021-10-01 22:37:04','vinod@gmail.com'),(12,2,4,'forward S&P  to Purchaser. Also forward stamped S&P to Vendor.\r\n','Bagi satu Perjanjian Jualbeli yang telah disetem kepada Pembeli dan juga Penjual . \r\n',NULL,1,'2021-10-01 22:37:04','vinod@gmail.com'),(13,2,5,'If we have not to received confirmation letter from Loan Solicitors, informed Purchaser (call & courier) \r\n','Sekiranya tidak dapat surat pengesahan daripada Peguam Bank Pembeli, maklumkan pembeli (telefon dan kurier) \r\n',NULL,2,'2021-10-01 22:37:04','vinod@gmail.com'),(14,2,6,'Received written letter from Loan Solicitors to request for redemption statement.\r\n','Terima surat pengesahan daripada Peguam Bank Pembeli untuk permohonan bagi surat tebusan\r\n',NULL,2,'2021-10-01 22:37:04','vinod@gmail.com'),(15,2,7,'request redemption statement\r\n','pohon surat penebusan\r\n',NULL,2,'2021-10-01 22:37:04','vinod@gmail.com'),(16,2,8,'received redemption statement. Adjudicate transfer form and affirm Statutory Declaration (bagi pengurangan duti setem dan bankrupt).\r\n','terima surat penubusan. Adjudicasi  borang pindah milik  dan ikrarkan surat akuan (bagi pengurangan duti setem dan bankrupcy)\r\n',NULL,10,'2021-10-01 22:37:04','vinod@gmail.com'),(17,2,9,'forward redemption statement and confirmation letter to Loan Solicitors\r\n','hantar surat penubusan dan surat pengesahan kepada peguam bank pembeli \r\n',NULL,3,'2021-10-01 22:37:04','vinod@gmail.com'),(18,2,10,'inform purchaser by phone and courier that we have complied with all the necessary request by Loan Solicitiors and we trust that purchaser financer is ready to release loan. Asked purchaser to follow up with loan solicitors to avoid late payment interest.\r\n','Maklum Pembeli (melalui kurier dan telefon), kami telah memberi semua dokumen-dokumen yang diperlukan oleh Peguam Bank Pembeli  dan kami percaya Bank Pembeli sedia untuk keluarkan kemudahan pembiayaan. Maklumkan Pembeli untuk follow up dengan peguam bank untuk pembayaran faedah pembayaran lewat.\r\n',NULL,2,'2021-10-01 22:37:04','vinod@gmail.com'),(19,2,11,'received notification from Loan Solicitors that the bank has released redemption sum \r\n','terima notifikasi daripada peguam bank bahawa bank telah membayar wang penubusan\r\n',NULL,5,'2021-10-01 22:37:04','vinod@gmail.com'),(20,2,12,'Forward discharge of charge to Vendor\'s Financier for execution.\r\n','hantar borang melepas gadaikan ke bank untuk tandatangan\r\n',NULL,2,'2021-10-01 22:37:04','vinod@gmail.com'),(21,2,13,'informed Vendor (call and courier) to get ready to deliver vacant possession.\r\n','maklum Penjual (telefon and kurier) sedia untuk memberi milikan kosong\r\n',NULL,2,'2021-10-01 22:37:04','vinod@gmail.com'),(22,2,14,'received title and discharge of charge. \r\n','terima geran original, borang melepas gadaian\r\n',NULL,10,'2021-10-01 22:37:04','vinod@gmail.com'),(23,2,15,'Forwarded original title, discharge of charge and transfer form to the loan solicitors.\r\n','hantar geran original, melepas gadaian dan borang pindahmilik kepada peguam bank pembeli\r\n',NULL,3,'2021-10-01 22:37:04','vinod@gmail.com'),(24,2,16,'Informed Purchaser (by courier and call) that we have forwarded original title to Loan Solicitors. Seek purchaser to follow up with Loan Solicitors to avoid late payment interest. (if necessary)\r\n','Maklum Pembeli (melalui kurier dan telefon), kami telah hantar geran original kepada peguam bank pembeli. Maklumkan Pembeli untuk follow up dengan peguam bank untuk mengelakkan pembayaran faedah pembayaran lewat (sekiranya perlu)\r\n',NULL,2,'2021-10-01 22:37:04','vinod@gmail.com'),(25,2,20,'close file\r\n','Tutup File\r\n',NULL,5,'2021-10-01 22:37:04','vinod@gmail.com'),(26,2,17,'received balance purchase price\r\n','Terima baki harga pembelian\r\n',NULL,5,'2021-10-01 22:37:04','vinod@gmail.com'),(27,2,19,'Parties received keys and balance purchase price.\r\n','Pembeli terima kunci dan Penjual terima baki harga pembelian\r\n',NULL,2,'2021-10-01 22:37:04','vinod@gmail.com'),(28,2,18,'apportionment of outgoings completed. Arrange for release of balance purchase price and delivery of keys\r\n','Pengiraan bill eletrik, air, indah water, cukai tanah, taksiran dan maintenance fee siap. Dalam proses untuk penyerahan milikan kosong dan pengeluaran baki harga pembelian.\r\n',NULL,3,'2021-10-01 22:37:04','vinod@gmail.com'),(29,3,1,'request for differential sum and legal fees\r\n','Maklumkan Pembeli untuk membayar duit beza dan duit guaman\r\n',NULL,10,'2021-10-01 22:37:04','vinod@gmail.com'),(30,3,2,'received differential sum and legal fees\r\n','Terima duti beza dan guaman\r\n',NULL,10,'2021-10-01 22:37:04','vinod@gmail.com'),(31,3,3,'pay stamp duty on MOT\r\n','bayar duti setem pindahmilik\r\n',NULL,10,'2021-10-01 22:37:04','vinod@gmail.com'),(32,4,1,'forward documents to Purchaser for EPF withdrawal\r\n','hantar dokumen kepada Pembeli bagi pengeluaran EPF\r\n',NULL,2,'2021-10-01 22:37:04','vinod@gmail.com'),(33,4,2,'follow up with Purchaser for EPF withdrawal\r\n','follow up dengan pembeli bagi pengeluaran EPF\r\n',NULL,3,'2021-10-01 22:37:04','vinod@gmail.com'),(34,4,3,'received payment from the Purchaser\'s EPF withdrawal \r\n','terima pengeluaran EPF daripada pembeli\r\n',NULL,7,'2021-10-01 22:37:04','vinod@gmail.com'),(35,4,4,'forward balance deposit to Vendor\r\n','hantar baki deposit kepada Penjual\r\n',NULL,3,'2021-10-01 22:37:04','vinod@gmail.com'),(36,5,1,'Pay retention sum\r\n','Bayar remit Balasan\r\n',NULL,10,'2021-10-01 22:37:04','vinod@gmail.com'),(37,5,2,'file CKHT\r\n','File Borang Cukai Keuntungan Harta Tanah \r\n',NULL,10,'2021-10-01 22:37:04','vinod@gmail.com'),(38,1,9,'follow up with Purchaser on the quotation 1',NULL,NULL,15,'2021-10-25 06:52:58','superadmin@gmail.com'),(39,20,1,'Step 1 - Register',NULL,NULL,5,'2022-11-02 11:17:38','superadmin@gmail.com'),(40,20,2,'Step 1 - Submission',NULL,NULL,3,'2022-11-02 11:18:14','superadmin@gmail.com'),(41,20,3,'Step 1 - Documentation',NULL,NULL,2,'2022-11-02 11:18:45','superadmin@gmail.com'),(42,21,1,'Step 2 - Handover developer',NULL,NULL,5,'2022-11-02 11:19:55','superadmin@gmail.com'),(43,21,2,'Step 2 - Verify by Developer',NULL,NULL,2,'2022-11-02 11:20:14','superadmin@gmail.com'),(44,21,3,'step 2 - Sign off by developer',NULL,NULL,3,'2022-11-02 11:20:30','superadmin@gmail.com');
/*!40000 ALTER TABLE `workflowdetail` ENABLE KEYS */;
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
