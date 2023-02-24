-- MySQL dump 10.13  Distrib 8.0.27, for Win64 (x86_64)
--
-- Host: localhost    Database: lawfirmhelper
-- ------------------------------------------------------
-- Server version	8.0.27

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
-- Table structure for table `aspnetroles`
--

DROP TABLE IF EXISTS `aspnetroles`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `aspnetroles` (
  `Id` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `Name` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `aspnetroles`
--

LOCK TABLES `aspnetroles` WRITE;
/*!40000 ALTER TABLE `aspnetroles` DISABLE KEYS */;
INSERT INTO `aspnetroles` VALUES ('0e508b9c-b53f-4d9e-b1e1-990cf225eba9','Admin'),('4765307e-2ad1-4b4d-89ab-8ba6581f9486','Clerk'),('79173ce9-9569-4a8c-8ca8-2390f1a7e76c','Developer'),('808775c3-ffe7-4561-9dee-6eae35b9a9a2','Client'),('b39cb724-c79c-40f8-a4d1-5bf957d7e4da','Superadmin'),('c2502171-9cdb-4a5f-bc5b-36f97966e506','NewClient'),('d09a8953-8c25-46ec-8719-8f40e84279cc','Firm'),('dc01aae1-e15e-49d3-b593-8e990088633c','Partner');
/*!40000 ALTER TABLE `aspnetroles` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `aspnetuserclaims`
--

DROP TABLE IF EXISTS `aspnetuserclaims`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `aspnetuserclaims` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `UserId` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `ClaimType` varchar(4000) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  `ClaimValue` varchar(4000) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `FK_userclaim.user_idx` (`UserId`),
  CONSTRAINT `FK_userclaim.user` FOREIGN KEY (`UserId`) REFERENCES `aspnetusers` (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `aspnetuserclaims`
--

LOCK TABLES `aspnetuserclaims` WRITE;
/*!40000 ALTER TABLE `aspnetuserclaims` DISABLE KEYS */;
/*!40000 ALTER TABLE `aspnetuserclaims` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `aspnetuserlogins`
--

DROP TABLE IF EXISTS `aspnetuserlogins`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `aspnetuserlogins` (
  `LoginProvider` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `ProviderKey` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `UserId` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  PRIMARY KEY (`LoginProvider`,`ProviderKey`,`UserId`),
  KEY `FK_userlogin.user_idx` (`UserId`),
  CONSTRAINT `FK_userlogin.user` FOREIGN KEY (`UserId`) REFERENCES `aspnetusers` (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `aspnetuserlogins`
--

LOCK TABLES `aspnetuserlogins` WRITE;
/*!40000 ALTER TABLE `aspnetuserlogins` DISABLE KEYS */;
/*!40000 ALTER TABLE `aspnetuserlogins` ENABLE KEYS */;
UNLOCK TABLES;

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
INSERT INTO `aspnetuserroles` VALUES ('7802176c-abc4-44d8-b0cf-bb4d25124121','4765307e-2ad1-4b4d-89ab-8ba6581f9486'),('3c60fc6d-cb6f-47fd-844f-0924f7574aad','808775c3-ffe7-4561-9dee-6eae35b9a9a2'),('51b2ab25-fb9b-4454-b938-f8618d5f7adb','808775c3-ffe7-4561-9dee-6eae35b9a9a2'),('6bc8cee0-a03e-430b-9711-420ab0d6a596','808775c3-ffe7-4561-9dee-6eae35b9a9a2'),('8442a3d2-eca6-4c09-a8f1-3dc3f31267d9','808775c3-ffe7-4561-9dee-6eae35b9a9a2'),('c610c2f0-7647-470a-861f-ef8cfd3c3d67','808775c3-ffe7-4561-9dee-6eae35b9a9a2'),('de6f1df5-265e-4a9f-9d65-df3ec4f3ad2d','808775c3-ffe7-4561-9dee-6eae35b9a9a2'),('2afb086f-1501-400b-9df2-447afd08d6b9','b39cb724-c79c-40f8-a4d1-5bf957d7e4da'),('9a358623-369a-4948-a7de-c13f1768bf1d','d09a8953-8c25-46ec-8719-8f40e84279cc'),('d5143ca4-e3b3-4fdf-af75-bbd944b8e0d4','d09a8953-8c25-46ec-8719-8f40e84279cc'),('d53edee5-21b6-47a1-b18b-207a7bb90c45','d09a8953-8c25-46ec-8719-8f40e84279cc');
/*!40000 ALTER TABLE `aspnetuserroles` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `aspnetusers`
--

DROP TABLE IF EXISTS `aspnetusers`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `aspnetusers` (
  `Id` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `Email` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  `EmailConfirmed` bit(1) NOT NULL,
  `PasswordHash` varchar(4000) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  `SecurityStamp` varchar(4000) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  `PhoneNumber` varchar(4000) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  `PhoneNumberConfirmed` bit(1) NOT NULL,
  `TwoFactorEnabled` bit(1) NOT NULL,
  `LockoutEndDateUtc` datetime DEFAULT NULL,
  `LockoutEnabled` bit(1) NOT NULL,
  `AccessFailedCount` int NOT NULL,
  `UserName` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  PRIMARY KEY (`Id`),
  KEY `Id` (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `aspnetusers`
--

LOCK TABLES `aspnetusers` WRITE;
/*!40000 ALTER TABLE `aspnetusers` DISABLE KEYS */;
INSERT INTO `aspnetusers` VALUES ('2afb086f-1501-400b-9df2-447afd08d6b9','superadmin@gmail.com',_binary '\0','AH51+/PAyN//2Hs3tIhAJKXN6MrQV7+0ES3rn0onaHU2aZxvpQboSZNz01ns3QouzA==','7d3b4e77-d158-4c70-97e0-aa49596d5571',NULL,_binary '\0',_binary '\0',NULL,_binary '\0',0,'superadmin@gmail.com'),('3c60fc6d-cb6f-47fd-844f-0924f7574aad','vinod@gmail.com',_binary '\0','ANYYYoHwcBA2xaQcDy+hJVfmkAfgbQ+folAbv4KIy2rHL1tMj0gLleHIS0CicoBwng==','e9382fdb-e3b2-48ae-8a24-02920a2d048d',NULL,_binary '\0',_binary '\0',NULL,_binary '\0',0,'vinod@gmail.com'),('51b2ab25-fb9b-4454-b938-f8618d5f7adb','Abc@gmail.com',_binary '\0','ANuAJiPzK2gI0Yo/E0rWXHiYQZ9v0i+zyV4EYOcsjNjmApsgZyVIr954PjHTixiXfw==','92de6bfd-8830-4b73-bae0-0533cc300d7a',NULL,_binary '\0',_binary '\0',NULL,_binary '\0',0,'Abc@gmail.com'),('6bc8cee0-a03e-430b-9711-420ab0d6a596','demo@email.com',_binary '\0','APc6/pVPfTnpG89SRacXjlT+sRz+JQnZROws0WmCA20+axszJnmxbRulHtDXhiYEuQ==','18272ba5-bf6a-48a7-8116-3ac34dbb7f38',NULL,_binary '\0',_binary '\0',NULL,_binary '\0',0,'demo@email.com'),('7802176c-abc4-44d8-b0cf-bb4d25124121','stonelly123@gmail.com',_binary '\0','AARY46WQdMe+a8bfTj/i6NkCE7YT/OTTbsxHovnscHy68iA3T3YXgUR5xD+lpsH2QA==','b2076afd-198b-4233-abc2-5a23d1cccc62',NULL,_binary '\0',_binary '\0',NULL,_binary '\0',0,'stonelly123@gmail.com'),('8442a3d2-eca6-4c09-a8f1-3dc3f31267d9','vinod666@gmail.com',_binary '\0','AKclIEURkmWIwCRibEJ4zEpmMUM1R/ASXd1GpsIRcd7Q7X9PwlIAHTpbtVuGTXVUXw==','330304e5-1c97-4ac7-948c-1dfd1172bc53',NULL,_binary '\0',_binary '\0',NULL,_binary '\0',0,'vinod666@gmail.com'),('9a358623-369a-4948-a7de-c13f1768bf1d','JasperCo@simpe.net.com',_binary '\0','AJ2mlNfv35XAWhlfSlWydCRN4yhVfIUBeArQJ8aYlo0pRJs2rk/pqeP46/qkzoifkQ==','45995de9-250d-4f8b-bab7-bd6e1e21218f',NULL,_binary '\0',_binary '\0',NULL,_binary '\0',0,'JasperCo@simpe.net.com'),('c610c2f0-7647-470a-861f-ef8cfd3c3d67','FannyKang@hotmail.com',_binary '\0','APwpPWZtCFOXdXKObwvHX5ayR703YbBHVDvKVWbGTWlfaP3Woh7jQd9fclYbgh6alA==','36b6feb6-53ac-43da-9e16-64336e9e9a52',NULL,_binary '\0',_binary '\0',NULL,_binary '\0',0,'FannyKang@hotmail.com'),('d5143ca4-e3b3-4fdf-af75-bbd944b8e0d4','SimplyOne@gmail.com',_binary '\0','AMbNZeD5uyh/5XoigWwyUVBVc/pC+F8JPn9ctALLM9Ds2X3oCSQBSGgzfccJan6ZAQ==','3bfd6cef-87c8-41f8-acc2-84228b90b4b5',NULL,_binary '\0',_binary '\0',NULL,_binary '\0',0,'SimplyOne@gmail.com'),('d53edee5-21b6-47a1-b18b-207a7bb90c45','K_BG@gmail.com',_binary '\0','ACvvQhaiDkJf0ZYEgtBFohEcmgt+BHSCZgR9XRLNl+ngXFZVuzyepOKYyZgs7Qb5bQ==','70382b39-918c-4f30-a31a-728a4bd86e79',NULL,_binary '\0',_binary '\0',NULL,_binary '\0',0,'K_BG@gmail.com'),('de6f1df5-265e-4a9f-9d65-df3ec4f3ad2d','vinod3344@gmail.com',_binary '\0','ACLv1vgOyaUMd01tKAH07q5ZQfk+YEuxksIyVUBd+HM9/MOCMn2Y7hgkYZUR7WBAvw==','74b45d7e-55e5-493c-9bfe-03828b9fa122',NULL,_binary '\0',_binary '\0',NULL,_binary '\0',0,'vinod3344@gmail.com');
/*!40000 ALTER TABLE `aspnetusers` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `bankmaster`
--

DROP TABLE IF EXISTS `bankmaster`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `bankmaster` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `BankShortCutID` int NOT NULL,
  `BranchName` varchar(255) NOT NULL DEFAULT '',
  `Address` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `Address2` varchar(255) DEFAULT '',
  `Address3` varchar(255) DEFAULT '',
  `PostCode` varchar(10) DEFAULT '',
  `State` varchar(50) DEFAULT '',
  `Phone` varchar(50) DEFAULT '',
  `Phone2` varchar(50) DEFAULT '',
  `Phone3` varchar(50) DEFAULT '',
  `Fax` varchar(50) DEFAULT '',
  `Fax2` varchar(50) DEFAULT '',
  `Email` varchar(50) DEFAULT '',
  `CACID` int NOT NULL,
  `Remarks` varchar(50) DEFAULT '',
  `CreatedDate` timestamp NULL DEFAULT CURRENT_TIMESTAMP,
  `CreatedBy` varchar(128) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `ModifyDate` datetime DEFAULT NULL,
  `ModifyBy` varchar(128) DEFAULT NULL,
  PRIMARY KEY (`Id`) USING BTREE,
  KEY `Id` (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `bankmaster`
--

LOCK TABLES `bankmaster` WRITE;
/*!40000 ALTER TABLE `bankmaster` DISABLE KEYS */;
INSERT INTO `bankmaster` VALUES (1,1,'CITI Ampang','Menara Hup Seng','H-123-A , Jalan P.Ramlee','KL 532121','53212','Kuala Lumpur','0123456789',NULL,NULL,'03-21232123',NULL,'HSBC@tedd.com',2,'try samve hsbc','2021-09-29 06:55:30','vinod@gmail.com','2022-01-05 20:08:43','superadmin@gmail.com'),(2,2,'Public Bank KLCC','KL, Menara Maybank Jalan Pudu',NULL,NULL,'53212','Kuala Lumpur','0123456789',NULL,NULL,'03-21232123',NULL,'pbb@tey.com',2,'try samve','2021-09-29 06:56:39','vinod@gmail.com','2022-01-05 21:09:58','superadmin@gmail.com');
/*!40000 ALTER TABLE `bankmaster` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `bankshortcutmaster`
--

DROP TABLE IF EXISTS `bankshortcutmaster`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `bankshortcutmaster` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `BankShortCut` varchar(50) NOT NULL,
  `BankName` varchar(128) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `CompanyNo` varchar(128) DEFAULT NULL,
  `RegistrationAddress` varchar(128) DEFAULT NULL,
  `CreatedDate` timestamp NULL DEFAULT CURRENT_TIMESTAMP,
  `CreatedBy` varchar(128) DEFAULT NULL,
  `ModifyDate` datetime DEFAULT NULL,
  `ModifyBy` varchar(128) DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `Id` (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `bankshortcutmaster`
--

LOCK TABLES `bankshortcutmaster` WRITE;
/*!40000 ALTER TABLE `bankshortcutmaster` DISABLE KEYS */;
INSERT INTO `bankshortcutmaster` VALUES (1,'HSBC','The Hongkong and Shanghai Banking Corporation','0127776V',NULL,'2021-09-28 23:48:27','vinod@gmail.com','2021-09-29 11:31:06',NULL),(2,'PBB','Public Bank Berhand','196501000672 (6463-H)',NULL,'2021-09-28 23:49:01','vinod@gmail.com','2021-09-29 11:31:07',NULL),(3,'CITI','CITIBANK BERHAD','199401011410 (297089-M).',NULL,'2021-09-28 23:49:35','vinod@gmail.com','2021-09-29 11:31:08',NULL),(4,'AM','AM Bank','01242776V',NULL,'2021-10-13 08:51:02','superadmin@gmail.com',NULL,NULL),(5,'MBB','Maybank Berhad','03212776V',NULL,'2021-10-13 08:57:24','superadmin@gmail.com',NULL,NULL);
/*!40000 ALTER TABLE `bankshortcutmaster` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `cacmaster`
--

DROP TABLE IF EXISTS `cacmaster`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `cacmaster` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `CACName` varchar(255) NOT NULL,
  `BankName` varchar(255) NOT NULL,
  `Address` varchar(255) DEFAULT NULL,
  `Address2` varchar(255) DEFAULT NULL,
  `Address3` varchar(255) DEFAULT NULL,
  `PostCode` varchar(10) DEFAULT NULL,
  `State` varchar(50) DEFAULT NULL,
  `Phone` varchar(50) DEFAULT NULL,
  `Phone2` varchar(50) DEFAULT NULL,
  `Phone3` varchar(50) DEFAULT NULL,
  `Fax` varchar(50) DEFAULT NULL,
  `Fax2` varchar(50) DEFAULT NULL,
  `Email` varchar(128) DEFAULT NULL,
  `CreatedDate` timestamp NULL DEFAULT CURRENT_TIMESTAMP,
  `CreatedBy` varchar(128) DEFAULT NULL,
  `ModifyDate` datetime DEFAULT NULL,
  `ModifyBy` varchar(128) DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `Id` (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `cacmaster`
--

LOCK TABLES `cacmaster` WRITE;
/*!40000 ALTER TABLE `cacmaster` DISABLE KEYS */;
INSERT INTO `cacmaster` VALUES (2,'HSBC Credit Control','HSBC','Menara Alliance ','H-123-A , Jalan P.Ramlee','KL 53212','53212','Kuala Lumpur','0123456789',NULL,NULL,'03-21232123',NULL,'HSBC@tey.com','2021-09-28 23:25:03','vinod@gmail.com','2021-10-02 06:11:44',NULL),(3,'AM Credit Control','AM Bank','Menara AmCorp','H-123-A , Jalan PJS 123','Petaling Jaya 43212','43212','Selangor','01242234342',NULL,NULL,'03-61232123',NULL,'AmCopr@aec.com','2021-09-28 23:30:25','vinod@gmail.com','2021-10-02 06:11:35',NULL),(4,'PBB Credit Control','Public Bank Berhand','NO 412A','Jalan Keloes','Taman Sipah','890112','Kuala Lumpur','+60121231231',NULL,NULL,NULL,NULL,'CAC_BG@pbb.net.com','2021-10-01 22:13:59','superadmin@gmail.com',NULL,NULL);
/*!40000 ALTER TABLE `cacmaster` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `documentmaster`
--

DROP TABLE IF EXISTS `documentmaster`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `documentmaster` (
  `ID` int NOT NULL AUTO_INCREMENT,
  `FileNo` varchar(50) DEFAULT NULL,
  `FileOpenDate` datetime DEFAULT NULL,
  `ClientID` varchar(128) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `PartnerID` varchar(128) DEFAULT NULL,
  `FirmID` varchar(128) DEFAULT NULL,
  `Status` int DEFAULT '1',
  `RelatedFileNo` varchar(50) DEFAULT NULL,
  `Remark` varchar(1000) DEFAULT NULL,
  `VendorID` varchar(128) DEFAULT NULL,
  `VendorFirmID` varchar(128) DEFAULT NULL,
  `VendorFirmTel` varchar(50) DEFAULT NULL,
  `VendorFirmEmail` varchar(50) DEFAULT NULL,
  `VendorFirmLocation` varchar(500) DEFAULT NULL,
  `VendorFirmFileRefNo` varchar(50) DEFAULT NULL,
  `PurchaserID` varchar(128) DEFAULT NULL,
  `PurchaserFirmID` varchar(128) DEFAULT NULL,
  `PurchaserFirmTel` varchar(50) DEFAULT NULL,
  `PurchaserFirmEmail` varchar(50) DEFAULT NULL,
  `PurchaserFirmLocation` varchar(500) DEFAULT NULL,
  `PurchaserFirmFileRefNo` varchar(50) DEFAULT NULL,
  `CreatedBy` varchar(128) DEFAULT NULL,
  `CreatedDate` timestamp NULL DEFAULT CURRENT_TIMESTAMP,
  `ModifyBy` varchar(128) DEFAULT NULL,
  `ModifyDate` datetime DEFAULT NULL,
  PRIMARY KEY (`ID`),
  UNIQUE KEY `FileNo` (`FileNo`),
  KEY `ID` (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `documentmaster`
--

LOCK TABLES `documentmaster` WRITE;
/*!40000 ALTER TABLE `documentmaster` DISABLE KEYS */;
/*!40000 ALTER TABLE `documentmaster` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `documentworkflow`
--

DROP TABLE IF EXISTS `documentworkflow`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `documentworkflow` (
  `ID` int NOT NULL AUTO_INCREMENT,
  `DocumentID` int DEFAULT NULL,
  `WorkflowDetailID` int DEFAULT NULL,
  `Sequence` int DEFAULT '0',
  `UserID` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `DueDate` datetime DEFAULT NULL,
  `isCompleted` int DEFAULT '0',
  `isRPA` int DEFAULT '0',
  `CreatedBy` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `CreatedDate` timestamp NULL DEFAULT CURRENT_TIMESTAMP,
  `ModifyBy` varchar(50) DEFAULT NULL,
  `ModifyDate` datetime DEFAULT NULL,
  PRIMARY KEY (`ID`),
  KEY `ID` (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `documentworkflow`
--

LOCK TABLES `documentworkflow` WRITE;
/*!40000 ALTER TABLE `documentworkflow` DISABLE KEYS */;
/*!40000 ALTER TABLE `documentworkflow` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `enummaster`
--

DROP TABLE IF EXISTS `enummaster`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `enummaster` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `EnumType` varchar(100) NOT NULL,
  `EnumName` varchar(100) NOT NULL,
  `EnumValue` varchar(100) NOT NULL,
  `Status` int NOT NULL DEFAULT '1',
  `CreatedDate` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `CreatedBy` varchar(128) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `ModifyDate` datetime DEFAULT NULL,
  `ModifyBy` varchar(128) DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `Id` (`Id`),
  KEY `EnumType` (`EnumType`),
  KEY `EnumName` (`EnumName`)
) ENGINE=InnoDB AUTO_INCREMENT=55 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `enummaster`
--

LOCK TABLES `enummaster` WRITE;
/*!40000 ALTER TABLE `enummaster` DISABLE KEYS */;
INSERT INTO `enummaster` VALUES (1,'IdentityType','NewIC','New IC',1,'2021-09-28 19:18:29','vinod@gmail.com',NULL,NULL),(2,'IdentityType','NewOldIC','New and Old IC',1,'2021-09-28 19:18:29','vinod@gmail.com',NULL,NULL),(3,'IdentityType','OldIC','Old IC',1,'2021-09-28 19:18:29','vinod@gmail.com',NULL,NULL),(4,'IdentityType','CompanyNo','Company No.',1,'2021-09-28 19:18:29','vinod@gmail.com',NULL,NULL),(5,'IdentityType','PassportNo','Passport No.',1,'2021-09-28 19:18:29','vinod@gmail.com',NULL,NULL),(6,'IdentityType','BusinessRegNo','Business Registration No.',1,'2021-09-28 19:18:29','vinod@gmail.com',NULL,NULL),(7,'IdentityType','SocietyNo','Society No.',1,'2021-09-28 19:18:29','vinod@gmail.com',NULL,NULL),(8,'IdentityType','Other','Other',1,'2021-09-28 19:18:29','vinod@gmail.com',NULL,NULL),(9,'OwningType','HSD','HSD',1,'2021-09-28 19:18:29','vinod@gmail.com',NULL,NULL),(10,'OwningType','HSM','HSM',1,'2021-09-28 19:18:29','vinod@gmail.com',NULL,NULL),(11,'OwningType','GM','GM',1,'2021-09-28 19:18:29','vinod@gmail.com',NULL,NULL),(12,'OwningType','GRN','GRN',1,'2021-09-28 19:18:29','vinod@gmail.com',NULL,NULL),(13,'OwningType','Geran','Geran',1,'2021-09-28 19:18:29','vinod@gmail.com',NULL,NULL),(14,'OwningType','GeranMukim','Geran Mukim',1,'2021-09-28 19:18:29','vinod@gmail.com',NULL,NULL),(15,'OwningType','PajakanNegeri','Pajakan Negeri',1,'2021-09-28 19:18:29','vinod@gmail.com',NULL,NULL),(16,'OwningType','PajakanMukim','Pajakan Mukim',1,'2021-09-28 19:18:29','vinod@gmail.com',NULL,NULL),(17,'OwningType','HakMilikSementaraDaerah','Hak Milik Sementara Daerah',1,'2021-09-28 19:18:29','vinod@gmail.com',NULL,NULL),(18,'OwningType','HakMilikSementaraMukim','Hak Milik Sementara Mukim',1,'2021-09-28 19:18:29','vinod@gmail.com',NULL,NULL),(19,'OwningType','CT','C.T.',1,'2021-09-28 19:18:29','vinod@gmail.com',NULL,NULL),(20,'OwningType','EMR','EMR',1,'2021-09-28 19:18:29','vinod@gmail.com',NULL,NULL),(21,'UserType','Vendor','Vendor',1,'2021-09-28 19:18:29','vinod@gmail.com',NULL,NULL),(22,'UserType','Purchaser','Purchaser',1,'2021-09-28 19:18:29','vinod@gmail.com',NULL,NULL),(23,'UserType','Borrower','Borrower',1,'2021-09-28 19:18:29','vinod@gmail.com',NULL,NULL),(24,'UserType','Developer','Developer',1,'2021-09-28 19:18:29','vinod@gmail.com',NULL,NULL),(25,'UserType','Proprietor','Proprietor',1,'2021-09-28 19:18:29','vinod@gmail.com',NULL,NULL),(26,'UserType','Guarantor','Guarantor',1,'2021-09-28 19:18:29','vinod@gmail.com',NULL,NULL),(27,'IdentityType','Helo','Helo Value',1,'2021-09-29 10:18:15','vinod@gmail.com',NULL,NULL),(28,'IdentityType','Helo 23','Helo Value 34',1,'2021-09-29 10:22:10','vinod@gmail.com','2021-10-02 02:34:25',NULL),(29,'LotType','Mukim','Mukim',1,'2021-09-29 20:39:53','vinod@gmail.com',NULL,NULL),(30,'LotType','Bandar','Bandar',1,'2021-09-29 20:40:02','vinod@gmail.com',NULL,NULL),(31,'LotType','Pekan','Pekan',1,'2021-09-29 20:40:10','vinod@gmail.com',NULL,NULL),(32,'TypeofLot','Mukim','Mukim',1,'2021-09-29 20:40:39','vinod@gmail.com',NULL,NULL),(33,'TypeofLot','Distinct','Distinct',1,'2021-09-29 20:40:46','vinod@gmail.com',NULL,NULL),(34,'TypeofLot','State','State',1,'2021-09-29 20:40:52','vinod@gmail.com',NULL,NULL),(35,'AreaType','SquareMeter','Square meter',1,'2021-09-29 20:41:13','vinod@gmail.com',NULL,NULL),(36,'AreaType','SquareFeet','Square Feet',1,'2021-09-29 20:41:25','vinod@gmail.com',NULL,NULL),(37,'AreaType','Acre','Acre',1,'2021-09-29 20:41:31','vinod@gmail.com',NULL,NULL),(38,'AreaType','Hectare','Hectare',1,'2021-09-29 20:41:40','vinod@gmail.com',NULL,NULL),(39,'GeranStatusType','Freehold','Freehold',1,'2021-09-29 20:42:39','vinod@gmail.com',NULL,NULL),(40,'GeranStatusType','Leasehold','Leasehold',1,'2021-09-29 20:42:45','vinod@gmail.com',NULL,NULL),(41,'GeranStatusType','Leasehold expiring on ','Leasehold expiring on ',1,'2021-09-29 20:43:00','vinod@gmail.com',NULL,NULL),(42,'ConditionType','BangunanKediaman','Bangunan Kediaman',1,'2021-09-29 20:43:37','vinod@gmail.com',NULL,NULL),(43,'ConditionType','Perusahaan','Perusahaan',1,'2021-09-29 20:43:53','vinod@gmail.com',NULL,NULL),(44,'ConditionType','BangunanPerniagaan','Bangunan Perniagaan',1,'2021-09-29 20:44:07','vinod@gmail.com',NULL,NULL),(45,'ConditionType','Tiada','Tiada',1,'2021-09-29 20:44:24','vinod@gmail.com',NULL,NULL),(46,'ConditionType','Pertanian','Pertanian',1,'2021-09-29 20:44:56','vinod@gmail.com',NULL,NULL),(47,'LandUsageCategoryType','Bangunan','Bangunan',1,'2021-09-29 20:45:14','vinod@gmail.com',NULL,NULL),(48,'LandUsageCategoryType','Perusahaan ','Perusahaan ',1,'2021-09-29 20:45:25','vinod@gmail.com',NULL,NULL),(49,'LandUsageCategoryType','Pertanian','Pertanian',1,'2021-09-29 20:45:37','vinod@gmail.com',NULL,NULL),(50,'LandUsageCategoryType','Tiada','Tiada',1,'2021-09-29 20:45:46','vinod@gmail.com',NULL,NULL),(51,'RestrictionType','Tiada','Tiada',1,'2021-09-29 20:46:08','vinod@gmail.com',NULL,NULL),(52,'RestrictionType','Ya','Tanah ini boleh dipindahmilik, dipajak atau digadai setelah mendapat kebenaran pihak berkuasa negeri',1,'2021-09-29 20:46:34','vinod@gmail.com',NULL,NULL),(53,'BuildingType','SingleStoreyTerraceHouse','Single storey terrace house',1,'2021-09-29 20:48:41','vinod@gmail.com',NULL,NULL),(54,'BuildingType','SingleStoreySemiDetached','Single storey semi detached',1,'2021-09-29 20:49:06','vinod@gmail.com',NULL,NULL);
/*!40000 ALTER TABLE `enummaster` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `firmmaster`
--

DROP TABLE IF EXISTS `firmmaster`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `firmmaster` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `AspNetUserID` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `FirmName` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  `Address` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  `Address2` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  `Address3` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  `PostCode` varchar(10) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  `City` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  `State` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  `Phone` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  `Phone2` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  `Phone3` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  `Fax` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  `Fax2` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  `Mobile` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  `Email` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  `Remark` varchar(500) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  `CreatedDate` timestamp NULL DEFAULT CURRENT_TIMESTAMP,
  `CreatedBy` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  `ModifyDate` datetime DEFAULT NULL,
  `ModifyBy` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  PRIMARY KEY (`Id`) USING BTREE,
  UNIQUE KEY `AspNetUserID` (`AspNetUserID`),
  KEY `Id` (`Id`) USING BTREE
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `firmmaster`
--

LOCK TABLES `firmmaster` WRITE;
/*!40000 ALTER TABLE `firmmaster` DISABLE KEYS */;
INSERT INTO `firmmaster` VALUES (1,'d53edee5-21b6-47a1-b18b-207a7bb90c45','K & BG solicotor','NO 412A','Jalan Keloes','Taman Sipah','890112','Kuala Lumpur','Kuala Lumpur','+60121231231',NULL,NULL,NULL,NULL,NULL,'K_BG@gmail.com','New Firm to review','2021-09-29 22:10:44','vinod@gmail.com','2021-10-02 05:53:43',NULL),(6,'9a358623-369a-4948-a7de-c13f1768bf1d','J & T Solicitors','NO 1, BLock D1','Jalan Keloes','Taman Sipah','890112','Kuala Lumpur','Kuala Lumpur','+60121231231',NULL,NULL,NULL,NULL,NULL,'Herlo_BG@JS.net.com',NULL,'2021-10-01 22:16:59','superadmin@gmail.com','2022-01-08 02:00:23',NULL),(7,'d5143ca4-e3b3-4fdf-af75-bbd944b8e0d4','Some & King Solicitor','NO 3, North South Point','Jalan Mid Valley Round','Taman Seputeh','51121','Kuala Lumpur','Kuala Lumpur','+60128923215',NULL,NULL,NULL,NULL,NULL,'SomeFirm@gmail.com',NULL,'2021-10-01 22:21:33','superadmin@gmail.com',NULL,NULL);
/*!40000 ALTER TABLE `firmmaster` ENABLE KEYS */;
UNLOCK TABLES;

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
INSERT INTO `firmprofile` VALUES (1,'Law Chambers of Low & Yow','No. 21,','Jalan Tapah,','Off Jalan Goh Hock Huat','NULL','41400','Klang','Selangor','Malaysia','+60333456611',NULL,NULL,'+60338855621',NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL);
/*!40000 ALTER TABLE `firmprofile` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `userdetail`
--

DROP TABLE IF EXISTS `userdetail`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `userdetail` (
  `UserDetailsId` int unsigned NOT NULL AUTO_INCREMENT,
  `AspNetUserId` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `UserTypeID` int DEFAULT '1',
  `IdentityType` int DEFAULT '0',
  `IdentityNo` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  `ConsumptionTaxNo` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT '0',
  `FullName` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  `Address` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  `Address2` varchar(255) DEFAULT NULL,
  `Address3` varchar(255) DEFAULT NULL,
  `PostCode` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  `City` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  `State` varchar(50) DEFAULT NULL,
  `Country` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  `PhoneNumber` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  `HomeContactNo` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  `OfficeContactNo` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  `MobileContactNo` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  `Fax` varchar(255) DEFAULT NULL,
  `Email` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  `TaxFileNo` varchar(255) DEFAULT NULL,
  `TaxBranch` varchar(255) DEFAULT NULL,
  `RegAddress` varchar(255) DEFAULT NULL,
  `RegAddress2` varchar(255) DEFAULT NULL,
  `RegAddress3` varchar(255) DEFAULT NULL,
  `RegPostCode` varchar(255) DEFAULT NULL,
  `RegCity` varchar(255) DEFAULT NULL,
  `RegState` varchar(255) DEFAULT NULL,
  `BussAddress` varchar(255) DEFAULT NULL,
  `BussAddress2` varchar(255) DEFAULT NULL,
  `BussAddress3` varchar(255) DEFAULT NULL,
  `BussPostCode` varchar(255) DEFAULT NULL,
  `BussCity` varchar(255) DEFAULT NULL,
  `BussState` varchar(255) DEFAULT NULL,
  `DirectorName` varchar(255) DEFAULT NULL,
  `DirectorIDNo` varchar(255) DEFAULT NULL,
  `DirectorSectName` varchar(255) DEFAULT NULL,
  `DirectorSectIDNo` varchar(255) DEFAULT NULL,
  `CreatedDate` datetime DEFAULT NULL,
  `CreatedBy` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  `ModifiedDate` datetime DEFAULT NULL,
  `ModifiedBy` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`UserDetailsId`),
  KEY `AspNetUserId` (`AspNetUserId`),
  CONSTRAINT `userdetail_ibfk_1` FOREIGN KEY (`AspNetUserId`) REFERENCES `aspnetusers` (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=27 DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `userdetail`
--

LOCK TABLES `userdetail` WRITE;
/*!40000 ALTER TABLE `userdetail` DISABLE KEYS */;
INSERT INTO `userdetail` VALUES (5,'7802176c-abc4-44d8-b0cf-bb4d25124121',24,1,'810212-14-1122','100','Sammy Chang','NO 412A','Jalan Keloes','Taman Sipah','890112','Kuala Lumpur','Kuala Lumpur','Malaysia','0121231231',NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,'2021-10-01 04:31:06',NULL,'2021-10-02 03:39:53',NULL),(9,'3c60fc6d-cb6f-47fd-844f-0924f7574aad',23,5,'A8891299','0','Mohadmad Syed bin Ali','NO 44','Jalan Runtuh ','Taman Sidat','41221','Kuala Kingta','Perak','Malaysia','+60124121144',NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,'2021-10-01 04:31:08',NULL,'2021-10-02 03:40:41',NULL),(13,'8442a3d2-eca6-4c09-a8f1-3dc3f31267d9',22,1,'610212-14-1122','99','Vincent Tan Bee Hing','NO 412A','Jalan Keloes','Taman Sipah','890112','Kuala Lumpur','Kuala Lumpur','Malaysia','012-1231231',NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,'2021-10-01 06:03:50',NULL,'2021-10-02 04:55:00',NULL),(14,'2afb086f-1501-400b-9df2-447afd08d6b9',25,4,'A2211312',NULL,'Connie Chung','NO 2','Jalan Jinjang','Taman Concreate','51212','Kuala Lumpur','Kuala Lumpur','Malaysia','+60121231231',NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,'2021-10-01 06:19:30',NULL,'2021-10-02 03:09:46',NULL),(20,'de6f1df5-265e-4a9f-9d65-df3ec4f3ad2d',24,3,'650909-01-5221',NULL,'Tony Stark','NO 888','Jalan Kaya','Taman Simpang Lapan','51992','Kuala Lumpur','Kuala Lumpur','Malaysia','+6012881188',NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,'2021-10-02 02:12:14',NULL,'2021-10-02 04:59:51',NULL),(21,'d53edee5-21b6-47a1-b18b-207a7bb90c45',NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,'2021-10-02 05:14:09',NULL,NULL,NULL),(22,'9a358623-369a-4948-a7de-c13f1768bf1d',21,1,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,'2021-10-02 06:15:48',NULL,'2021-10-13 14:56:42',NULL),(23,'d5143ca4-e3b3-4fdf-af75-bbd944b8e0d4',NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,'2021-10-02 06:20:02',NULL,NULL,NULL),(24,'c610c2f0-7647-470a-861f-ef8cfd3c3d67',22,1,'910212-06-2422','N23123 ','Fanny Kang Che Mei','NO 82','Jalan PJS 12/4','Taman Subang Indah','49142','Subang Jaya','Selangor','Malaysia','+6016-8729312',NULL,NULL,NULL,NULL,'FannyKang@hotmail.com',NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,'2021-10-02 06:22:16',NULL,'2021-10-02 06:24:10',NULL),(25,'51b2ab25-fb9b-4454-b938-f8618d5f7adb',22,5,'A2211234','10033211','Jenny Chang Heng Keng','NO 412A','Jalan Keloes','Taman Sipah','890112','Kuala Lumpur','Kuala Lumpur','Malaysia','+60121231231',NULL,NULL,NULL,NULL,'K_BG@gmail.com',NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,'2021-10-02 10:07:49',NULL,'2022-02-02 12:15:47',NULL),(26,'6bc8cee0-a03e-430b-9711-420ab0d6a596',21,5,'A221123','10033211','Ben Tang Keng Kong','NO 412A','Jalan Keloes','Taman Sipah','890112','Kuala Lumpur','Kuala Lumpur','Malaysia','+60121231231','1',NULL,NULL,NULL,'K_BG@gmail.com',NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,'2021-10-02 10:07:49',NULL,'2021-10-13 14:59:45',NULL);
/*!40000 ALTER TABLE `userdetail` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `workflow`
--

DROP TABLE IF EXISTS `workflow`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `workflow` (
  `ID` int NOT NULL AUTO_INCREMENT,
  `WorkflowDescrption` varchar(500) NOT NULL DEFAULT '0',
  `WorkflowDescrption_BM` varchar(500) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT '0',
  `WorkflowDescrption_CN` varchar(500) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT '0',
  `WorkflowTotalDuration` int DEFAULT NULL,
  `CriticalDuration` int DEFAULT NULL,
  `CreatedBy` varchar(500) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT '0',
  `CreatedDate` timestamp NULL DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`ID`),
  KEY `ID` (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `workflow`
--

LOCK TABLES `workflow` WRITE;
/*!40000 ALTER TABLE `workflow` DISABLE KEYS */;
INSERT INTO `workflow` VALUES (1,'SNP freehold - 2 parties',NULL,NULL,159,101,'vinod@gmail.com','2022-02-02 04:18:06'),(2,'SNP leasehold - 2 partie',NULL,NULL,NULL,50,NULL,'2021-10-02 00:47:27'),(3,'SNP freehold - 2 parties 99',NULL,NULL,NULL,12,NULL,'2022-01-29 19:24:32');
/*!40000 ALTER TABLE `workflow` ENABLE KEYS */;
UNLOCK TABLES;

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
) ENGINE=InnoDB AUTO_INCREMENT=39 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `workflowdetail`
--

LOCK TABLES `workflowdetail` WRITE;
/*!40000 ALTER TABLE `workflowdetail` DISABLE KEYS */;
INSERT INTO `workflowdetail` VALUES (1,1,1,'called Vendor and Purchaser - provide quotation - inform parties on the documents required','Telefon Penjual dan Pembeli - bagi sebut harga (quotation) - maklum pihak-pihak dokumen-dokumen yang perlu disediakan',NULL,1,'2021-10-01 22:37:04','vinod@gmail.com'),(2,1,2,'follow up with Purchaser on the quotation','follow up dengan pembeli bagi berkenaan dengan sebut harga',NULL,2,'2021-10-23 12:24:13','vinod@gmail.com'),(3,1,3,'Purchaser appointed Law Chambers of Low & Yow','Pembeli melantik Tetuan Law Chambers of Low & Yow',NULL,1,'2021-10-23 12:25:40','vinod@gmail.com'),(4,1,4,'Received all the necessary documents and prepare sale and purchase agreement (complete within 5 working days) - fixed appointment with Purchaser and Vendor for execution of S&P','Terima semua dokumen-dokumen yang diperlukan. Buat perjanjian jual beli (Sedia dan lengkap dalam 5 hari bekerja)  - tetapkan temujanji dengan Pembeli dan Penjual untuk  tandatangan Perjanjian Jualbeli\r\n',NULL,1,'2021-10-01 22:37:04','vinod@gmail.com'),(5,1,5,' Sale and Purchase Agreement land search and bankruptcy search completed','Perjanjian Jualbeli, carian bankrup dan carian tanah siap\r\n',NULL,4,'2021-10-01 22:37:04','vinod@gmail.com'),(6,1,6,'Purchaser signed the S&P. \r\n','Pembeli tandatangan Perjanjian Jualbeli\r\n',NULL,2,'2021-10-01 22:37:04','vinod@gmail.com'),(7,1,7,'Vendor signed the S&P\r\n','Penjual tandatangan Perjanjian Jualbeli\r\n',NULL,2,'2021-10-01 22:37:04','vinod@gmail.com'),(8,1,8,'Date S&P and insert the S&P date on the system\r\n',' tarikhkan Perjanjian Jualbeli dan masukkan tarikh dalam system KIV\r\n',NULL,1,'2021-10-01 22:37:04','vinod@gmail.com'),(9,2,1,'stamped S&P and forward to agent. \r\n','stamp Perjanjian Jualbeli dan beri kepada agent hartanah \r\n',NULL,2,'2021-10-01 22:37:04','vinod@gmail.com'),(10,2,2,'Affirm SD for caveat\r\n','Ikrarkan Surat Akuan untuk caveat\r\n',NULL,1,'2021-10-01 22:37:04','vinod@gmail.com'),(11,2,3,'lodge private caveat. \r\n','masukkan caveat persendirian \r\n',NULL,1,'2021-10-01 22:37:04','vinod@gmail.com'),(12,2,4,'forward S&P  to Purchaser. Also forward stamped S&P to Vendor.\r\n','Bagi satu Perjanjian Jualbeli yang telah disetem kepada Pembeli dan juga Penjual . \r\n',NULL,1,'2021-10-01 22:37:04','vinod@gmail.com'),(13,2,5,'If we have not to received confirmation letter from Loan Solicitors, informed Purchaser (call & courier) \r\n','Sekiranya tidak dapat surat pengesahan daripada Peguam Bank Pembeli, maklumkan pembeli (telefon dan kurier) \r\n',NULL,2,'2021-10-01 22:37:04','vinod@gmail.com'),(14,2,6,'Received written letter from Loan Solicitors to request for redemption statement.\r\n','Terima surat pengesahan daripada Peguam Bank Pembeli untuk permohonan bagi surat tebusan\r\n',NULL,2,'2021-10-01 22:37:04','vinod@gmail.com'),(15,2,7,'request redemption statement\r\n','pohon surat penebusan\r\n',NULL,2,'2021-10-01 22:37:04','vinod@gmail.com'),(16,2,8,'received redemption statement. Adjudicate transfer form and affirm Statutory Declaration (bagi pengurangan duti setem dan bankrupt).\r\n','terima surat penubusan. Adjudicasi  borang pindah milik  dan ikrarkan surat akuan (bagi pengurangan duti setem dan bankrupcy)\r\n',NULL,10,'2021-10-01 22:37:04','vinod@gmail.com'),(17,2,9,'forward redemption statement and confirmation letter to Loan Solicitors\r\n','hantar surat penubusan dan surat pengesahan kepada peguam bank pembeli \r\n',NULL,3,'2021-10-01 22:37:04','vinod@gmail.com'),(18,2,10,'inform purchaser by phone and courier that we have complied with all the necessary request by Loan Solicitiors and we trust that purchaser financer is ready to release loan. Asked purchaser to follow up with loan solicitors to avoid late payment interest.\r\n','Maklum Pembeli (melalui kurier dan telefon), kami telah memberi semua dokumen-dokumen yang diperlukan oleh Peguam Bank Pembeli  dan kami percaya Bank Pembeli sedia untuk keluarkan kemudahan pembiayaan. Maklumkan Pembeli untuk follow up dengan peguam bank untuk pembayaran faedah pembayaran lewat.\r\n',NULL,2,'2021-10-01 22:37:04','vinod@gmail.com'),(19,2,11,'received notification from Loan Solicitors that the bank has released redemption sum \r\n','terima notifikasi daripada peguam bank bahawa bank telah membayar wang penubusan\r\n',NULL,5,'2021-10-01 22:37:04','vinod@gmail.com'),(20,2,12,'Forward discharge of charge to Vendor\'s Financier for execution.\r\n','hantar borang melepas gadaikan ke bank untuk tandatangan\r\n',NULL,2,'2021-10-01 22:37:04','vinod@gmail.com'),(21,2,13,'informed Vendor (call and courier) to get ready to deliver vacant possession.\r\n','maklum Penjual (telefon and kurier) sedia untuk memberi milikan kosong\r\n',NULL,2,'2021-10-01 22:37:04','vinod@gmail.com'),(22,2,14,'received title and discharge of charge. \r\n','terima geran original, borang melepas gadaian\r\n',NULL,10,'2021-10-01 22:37:04','vinod@gmail.com'),(23,2,15,'Forwarded original title, discharge of charge and transfer form to the loan solicitors.\r\n','hantar geran original, melepas gadaian dan borang pindahmilik kepada peguam bank pembeli\r\n',NULL,3,'2021-10-01 22:37:04','vinod@gmail.com'),(24,2,16,'Informed Purchaser (by courier and call) that we have forwarded original title to Loan Solicitors. Seek purchaser to follow up with Loan Solicitors to avoid late payment interest. (if necessary)\r\n','Maklum Pembeli (melalui kurier dan telefon), kami telah hantar geran original kepada peguam bank pembeli. Maklumkan Pembeli untuk follow up dengan peguam bank untuk mengelakkan pembayaran faedah pembayaran lewat (sekiranya perlu)\r\n',NULL,2,'2021-10-01 22:37:04','vinod@gmail.com'),(25,2,20,'close file\r\n','Tutup File\r\n',NULL,5,'2021-10-01 22:37:04','vinod@gmail.com'),(26,2,17,'received balance purchase price\r\n','Terima baki harga pembelian\r\n',NULL,5,'2021-10-01 22:37:04','vinod@gmail.com'),(27,2,19,'Parties received keys and balance purchase price.\r\n','Pembeli terima kunci dan Penjual terima baki harga pembelian\r\n',NULL,2,'2021-10-01 22:37:04','vinod@gmail.com'),(28,2,18,'apportionment of outgoings completed. Arrange for release of balance purchase price and delivery of keys\r\n','Pengiraan bill eletrik, air, indah water, cukai tanah, taksiran dan maintenance fee siap. Dalam proses untuk penyerahan milikan kosong dan pengeluaran baki harga pembelian.\r\n',NULL,3,'2021-10-01 22:37:04','vinod@gmail.com'),(29,3,1,'request for differential sum and legal fees\r\n','Maklumkan Pembeli untuk membayar duit beza dan duit guaman\r\n',NULL,10,'2021-10-01 22:37:04','vinod@gmail.com'),(30,3,2,'received differential sum and legal fees\r\n','Terima duti beza dan guaman\r\n',NULL,10,'2021-10-01 22:37:04','vinod@gmail.com'),(31,3,3,'pay stamp duty on MOT\r\n','bayar duti setem pindahmilik\r\n',NULL,10,'2021-10-01 22:37:04','vinod@gmail.com'),(32,4,1,'forward documents to Purchaser for EPF withdrawal\r\n','hantar dokumen kepada Pembeli bagi pengeluaran EPF\r\n',NULL,2,'2021-10-01 22:37:04','vinod@gmail.com'),(33,4,2,'follow up with Purchaser for EPF withdrawal\r\n','follow up dengan pembeli bagi pengeluaran EPF\r\n',NULL,3,'2021-10-01 22:37:04','vinod@gmail.com'),(34,4,3,'received payment from the Purchaser\'s EPF withdrawal \r\n','terima pengeluaran EPF daripada pembeli\r\n',NULL,7,'2021-10-01 22:37:04','vinod@gmail.com'),(35,4,4,'forward balance deposit to Vendor\r\n','hantar baki deposit kepada Penjual\r\n',NULL,3,'2021-10-01 22:37:04','vinod@gmail.com'),(36,5,1,'Pay retention sum\r\n','Bayar remit Balasan\r\n',NULL,10,'2021-10-01 22:37:04','vinod@gmail.com'),(37,5,2,'file CKHT\r\n','File Borang Cukai Keuntungan Harta Tanah \r\n',NULL,10,'2021-10-01 22:37:04','vinod@gmail.com'),(38,1,9,'follow up with Purchaser on the quotation 1',NULL,NULL,15,'2021-10-25 06:52:58','superadmin@gmail.com');
/*!40000 ALTER TABLE `workflowdetail` ENABLE KEYS */;
UNLOCK TABLES;

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
) ENGINE=InnoDB AUTO_INCREMENT=20 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `workflowmaster`
--

LOCK TABLES `workflowmaster` WRITE;
/*!40000 ALTER TABLE `workflowmaster` DISABLE KEYS */;
INSERT INTO `workflowmaster` VALUES (1,1,1,'Getting Up','Penyediaan','',29,0,0,'2021-08-04 09:22:55','vinod@gmail.com'),(2,1,2,'S&P commence','Perjanjian Jualbeli Mula ','',65,0,0,'2021-08-04 09:23:46','vinod@gmail.com'),(3,1,3,'Payment (Differential Sum & stamping)','Bayaran (Duit Beza dan Duti Setem)','',30,0,0,'2021-08-20 03:50:07','vinod@gmail.com'),(4,1,4,'Payment from EPF for balance deposit, if appliable','Bayaran baki deposit melalui EPF (sekiranya ada)','',15,0,0,'2021-08-20 03:50:53','vinod@gmail.com'),(5,1,5,'Pay retention sum','Bayar remit Balasan','',20,0,0,'2021-08-20 04:37:41','vinod@gmail.com'),(14,2,1,'1','2','3',4,0,0,'2021-10-02 01:18:12',NULL),(15,2,2,'2','3','4',5,0,0,'2021-10-02 01:23:03',NULL),(16,2,5,'5','5','5',5,0,0,'2021-10-02 01:23:44',NULL),(17,2,5,'99','88','3',4,0,0,'2021-10-02 01:25:26',NULL),(18,NULL,6,'Final input','Langkah akhir',NULL,2,NULL,NULL,'2022-01-20 08:59:03',NULL),(19,NULL,6,'Final input','Langkah akhir',NULL,2,NULL,NULL,'2022-01-20 09:00:47',NULL);
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

-- Dump completed on 2022-02-16 11:12:17
