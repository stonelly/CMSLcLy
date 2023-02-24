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
  `IsFavourite` tinyint NOT NULL DEFAULT '0',
  `CreatedDate` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `CreatedBy` varchar(128) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `ModifyDate` datetime DEFAULT NULL,
  `ModifyBy` varchar(128) DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `Id` (`Id`),
  KEY `EnumType` (`EnumType`),
  KEY `EnumName` (`EnumName`)
) ENGINE=InnoDB AUTO_INCREMENT=97 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `enummaster`
--

LOCK TABLES `enummaster` WRITE;
/*!40000 ALTER TABLE `enummaster` DISABLE KEYS */;
INSERT INTO `enummaster` VALUES (1,'IdentityType','NewIC','New IC',1,0,'2021-09-28 19:18:29','vinod@gmail.com',NULL,NULL),(2,'IdentityType','NewOldIC','New and Old IC',1,0,'2021-09-28 19:18:29','vinod@gmail.com',NULL,NULL),(3,'IdentityType','OldIC','Old IC',1,0,'2021-09-28 19:18:29','vinod@gmail.com',NULL,NULL),(4,'IdentityType','CompanyNo','Company No.',1,0,'2021-09-28 19:18:29','vinod@gmail.com',NULL,NULL),(5,'IdentityType','PassportNo','Passport No.',1,0,'2021-09-28 19:18:29','vinod@gmail.com',NULL,NULL),(6,'IdentityType','BusinessRegNo','Business Registration No.',1,0,'2021-09-28 19:18:29','vinod@gmail.com',NULL,NULL),(7,'IdentityType','SocietyNo','Society No.',1,0,'2021-09-28 19:18:29','vinod@gmail.com',NULL,NULL),(8,'IdentityType','Other','Other',1,0,'2021-09-28 19:18:29','vinod@gmail.com',NULL,NULL),(9,'OwningType','HSD','HSD',1,0,'2021-09-28 19:18:29','vinod@gmail.com',NULL,NULL),(10,'OwningType','HSM','HSM',1,0,'2021-09-28 19:18:29','vinod@gmail.com',NULL,NULL),(11,'OwningType','GM','GM',1,0,'2021-09-28 19:18:29','vinod@gmail.com',NULL,NULL),(12,'OwningType','GRN','GRN',1,0,'2021-09-28 19:18:29','vinod@gmail.com',NULL,NULL),(13,'OwningType','Geran','Geran',1,0,'2021-09-28 19:18:29','vinod@gmail.com',NULL,NULL),(14,'OwningType','GeranMukim','Geran Mukim',1,0,'2021-09-28 19:18:29','vinod@gmail.com',NULL,NULL),(15,'OwningType','PajakanNegeri','Pajakan Negeri',1,0,'2021-09-28 19:18:29','vinod@gmail.com',NULL,NULL),(16,'OwningType','PajakanMukim','Pajakan Mukim',1,0,'2021-09-28 19:18:29','vinod@gmail.com',NULL,NULL),(17,'OwningType','HakMilikSementaraDaerah','Hak Milik Sementara Daerah',1,0,'2021-09-28 19:18:29','vinod@gmail.com',NULL,NULL),(18,'OwningType','HakMilikSementaraMukim','Hak Milik Sementara Mukim',1,0,'2021-09-28 19:18:29','vinod@gmail.com',NULL,NULL),(19,'OwningType','CT','C.T.',1,0,'2021-09-28 19:18:29','vinod@gmail.com',NULL,NULL),(20,'OwningType','EMR','EMR',1,0,'2021-09-28 19:18:29','vinod@gmail.com',NULL,NULL),(21,'UserType','Vendor','Vendor',1,0,'2021-09-28 19:18:29','vinod@gmail.com',NULL,NULL),(22,'UserType','Purchaser','Purchaser',1,0,'2021-09-28 19:18:29','vinod@gmail.com',NULL,NULL),(23,'UserType','Borrower','Borrower',1,0,'2021-09-28 19:18:29','vinod@gmail.com',NULL,NULL),(24,'UserType','Developer','Developer',1,0,'2021-09-28 19:18:29','vinod@gmail.com',NULL,NULL),(25,'UserType','Proprietor','Proprietor',1,0,'2021-09-28 19:18:29','vinod@gmail.com',NULL,NULL),(26,'UserType','Guarantor','Guarantor',1,0,'2021-09-28 19:18:29','vinod@gmail.com',NULL,NULL),(27,'IdentityType','Halloween','Ghost',1,0,'2021-09-29 10:18:15','vinod@gmail.com','2022-11-13 14:34:49',NULL),(28,'IdentityType','Helo 23','Helo Value 34',1,0,'2021-09-29 10:22:10','vinod@gmail.com','2021-10-02 02:34:25',NULL),(29,'LotType','Mukim','Mukim',1,0,'2021-09-29 20:39:53','vinod@gmail.com',NULL,NULL),(30,'LotType','Bandar','Bandar',1,0,'2021-09-29 20:40:02','vinod@gmail.com',NULL,NULL),(31,'LotType','Pekan','Pekan',1,0,'2021-09-29 20:40:10','vinod@gmail.com',NULL,NULL),(32,'TypeofLot','Mukim','Mukim',1,0,'2021-09-29 20:40:39','vinod@gmail.com',NULL,NULL),(33,'TypeofLot','Distinc','Distinct',1,0,'2021-09-29 20:40:46','vinod@gmail.com','2022-11-13 14:38:43',NULL),(34,'TypeofLot','State','State',1,0,'2021-09-29 20:40:52','vinod@gmail.com',NULL,NULL),(35,'AreaType','SquareMeter','Square meter',1,0,'2021-09-29 20:41:13','vinod@gmail.com',NULL,NULL),(36,'AreaType','SquareFeet','Square Feet',1,0,'2021-09-29 20:41:25','vinod@gmail.com',NULL,NULL),(37,'AreaType','Acre','Acre',1,0,'2021-09-29 20:41:31','vinod@gmail.com',NULL,NULL),(38,'AreaType','Hectare','Hectare',1,0,'2021-09-29 20:41:40','vinod@gmail.com',NULL,NULL),(39,'GeranStatusType','Freehold','Freehold',1,0,'2021-09-29 20:42:39','vinod@gmail.com',NULL,NULL),(40,'GeranStatusType','Leasehold','Leasehold',1,0,'2021-09-29 20:42:45','vinod@gmail.com',NULL,NULL),(41,'GeranStatusType','Leasehold expiring on ','Leasehold expiring on ',1,0,'2021-09-29 20:43:00','vinod@gmail.com',NULL,NULL),(42,'ConditionType','BangunanKediaman','Bangunan Kediaman',1,0,'2021-09-29 20:43:37','vinod@gmail.com',NULL,NULL),(43,'ConditionType','Perusahaan','Perusahaan',1,0,'2021-09-29 20:43:53','vinod@gmail.com',NULL,NULL),(44,'ConditionType','BangunanPerniagaan','Bangunan Perniagaan',1,0,'2021-09-29 20:44:07','vinod@gmail.com',NULL,NULL),(45,'ConditionType','Tiada','Tiada',1,0,'2021-09-29 20:44:24','vinod@gmail.com',NULL,NULL),(46,'ConditionType','Pertanian','Pertanian',1,0,'2021-09-29 20:44:56','vinod@gmail.com',NULL,NULL),(47,'LandUsageCategoryType','Bangunan','Bangunan',1,0,'2021-09-29 20:45:14','vinod@gmail.com',NULL,NULL),(48,'LandUsageCategoryType','Perusahaan ','Perusahaan ',1,0,'2021-09-29 20:45:25','vinod@gmail.com',NULL,NULL),(49,'LandUsageCategoryType','Pertanian','Pertanian',1,0,'2021-09-29 20:45:37','vinod@gmail.com',NULL,NULL),(50,'LandUsageCategoryType','Tiada','Tiada',1,0,'2021-09-29 20:45:46','vinod@gmail.com',NULL,NULL),(51,'RestrictionType','Tiada','Tiada',1,0,'2021-09-29 20:46:08','vinod@gmail.com',NULL,NULL),(52,'RestrictionType','Ya','Tanah ini boleh dipindahmilik, dipajak atau digadai setelah mendapat kebenaran pihak berkuasa negeri',1,0,'2021-09-29 20:46:34','vinod@gmail.com',NULL,NULL),(53,'BuildingType','SingleStoreyTerraceHouse','Single storey terrace house',1,0,'2021-09-29 20:48:41','vinod@gmail.com',NULL,NULL),(54,'BuildingType','SingleStoreySemiDetached','Single storey semi detached',1,0,'2021-09-29 20:49:06','vinod@gmail.com',NULL,NULL),(55,'StateType','Johor','Johor',1,0,'2022-10-09 16:53:29','vinod@gmail.com','2022-10-10 00:53:29',''),(57,'StateType','Kedah','Kedah',1,0,'2022-10-09 16:54:58','vinod@gmail.com','2022-10-10 00:54:58',''),(58,'StateType','Kelantan','Kelantan',1,0,'2022-10-09 16:54:58','vinod@gmail.com','2022-10-10 00:54:58',''),(59,'StateType','Melacca','Melacca',1,0,'2022-10-09 16:54:58','vinod@gmail.com','2022-10-10 00:54:58',''),(60,'StateType','Negeri Sembilan','Negeri Sembilan',1,0,'2022-10-09 16:54:58','vinod@gmail.com','2022-10-10 00:54:58',''),(61,'StateType','Pahang','Pahang',1,0,'2022-10-09 16:55:50','vinod@gmail.com','2022-10-10 00:55:50',''),(62,'StateType','Penang','Penang',1,0,'2022-10-09 16:55:50','vinod@gmail.com','2022-10-10 00:55:50',''),(63,'StateType','Perak','Perak',1,0,'2022-10-09 16:55:50','vinod@gmail.com','2022-10-10 00:55:50',''),(64,'StateType','Perlis','Perlis',1,0,'2022-10-09 16:55:50','vinod@gmail.com','2022-10-10 00:55:50',''),(65,'StateType','Sabah','Sabah',1,0,'2022-10-09 16:55:50','vinod@gmail.com','2022-10-10 00:55:50',''),(66,'StateType','Sarawak','Sarawak',1,0,'2022-10-09 16:55:50','vinod@gmail.com','2022-10-10 00:55:50',''),(67,'StateType','Selangor','Selangor',1,0,'2022-10-09 16:55:50','vinod@gmail.com','2022-10-10 00:55:50',''),(68,'StateType','Terengganu','Terengganu',1,0,'2022-10-09 16:55:50','vinod@gmail.com','2022-10-10 00:55:50',''),(69,'StateType','Kuala Lumpur','Kuala Lumpur',1,0,'2022-10-09 16:55:50','vinod@gmail.com','2022-10-10 00:55:50',''),(70,'StateType','Labuan','Labuan',1,0,'2022-10-09 16:55:50','vinod@gmail.com','2022-10-10 00:55:50',''),(71,'StateType','Putra Jaya','Putra Jaya',1,0,'2022-10-09 16:55:50','vinod@gmail.com','2022-10-10 00:55:50',''),(72,'DistrictType','Gombak','Gombak',1,0,'2022-10-09 17:04:04','vinod@gmail.com','2022-10-10 01:04:04',''),(73,'DistrictType','Hulu Langat','Hulu Langat',1,0,'2022-10-09 17:04:04','vinod@gmail.com','2022-10-10 01:04:04',''),(74,'DistrictType','Hulu Selangor','Hulu Selangor',1,0,'2022-10-09 17:04:04','vinod@gmail.com','2022-10-10 01:04:04',''),(75,'DistrictType','Klang','Klang',1,0,'2022-10-09 17:04:04','vinod@gmail.com','2022-10-10 01:04:04',''),(76,'DistrictType','Kuala Langat','Kuala Langat',1,0,'2022-10-09 17:04:04','vinod@gmail.com','2022-10-10 01:04:04',''),(77,'DistrictType','Kuala Selangor','Kuala Selangor',1,0,'2022-10-09 17:04:04','vinod@gmail.com','2022-10-10 01:04:04',''),(78,'DistrictType','Petaling','Petaling',1,0,'2022-10-09 17:04:04','vinod@gmail.com','2022-10-10 01:04:04',''),(79,'DistrictType','Sabak Bernam','Sabak Bernam',1,0,'2022-10-09 17:04:04','vinod@gmail.com','2022-10-10 01:04:04',''),(80,'DistrictType','Sepang','Sepang',1,0,'2022-10-09 17:04:04','vinod@gmail.com','2022-10-10 01:04:04',''),(81,'DocumentType','SPA','SPA',1,0,'2022-10-10 13:06:01',NULL,NULL,NULL),(82,'DocumentType','SPA LCLY Free','SPA LCLY Free',1,0,'2022-10-10 13:06:57',NULL,NULL,NULL),(83,'DocumentType','MOT Both company','MOT Both company',1,0,'2022-10-10 13:07:13',NULL,NULL,NULL),(84,'DocumentType','MOT 2V & 2P','MOT 2V & 2P',1,0,'2022-10-10 13:07:29',NULL,NULL,NULL),(85,'DocumentType','Letter (P & V) confirmation - encumbred','Letter (P & V) confirmation - encumbred',1,0,'2022-10-10 13:07:45',NULL,NULL,NULL),(86,'IdentityType','Just do it','Nike',1,0,'2022-11-13 06:34:21','superadmin@gmail.com',NULL,NULL),(87,'OwningType','123456','testing 123',1,0,'2022-11-13 06:35:53','superadmin@gmail.com','2022-11-13 14:36:15',NULL),(88,'UserType','12367856','129033',1,0,'2022-11-13 06:37:27','superadmin@gmail.com','2022-11-13 14:37:48',NULL),(89,'TypeofLot','lot123','231 lots',1,0,'2022-11-13 06:38:36','superadmin@gmail.com','2022-11-13 14:38:47',NULL),(90,'TypeofLot','Type of Lot','PT',1,0,'2022-11-13 06:39:15','superadmin@gmail.com','2022-11-13 14:39:41',NULL),(91,'AreaType','square meter','M22',1,0,'2022-11-13 06:40:11','superadmin@gmail.com','2022-11-13 14:40:16',NULL),(92,'GeranStatusType','345','eril',1,0,'2022-11-13 06:48:11','superadmin@gmail.com','2022-11-13 14:48:18',NULL),(93,'ConditionType','456','789999',1,0,'2022-11-13 06:48:44','superadmin@gmail.com','2022-11-13 14:48:49',NULL),(94,'LandUsageCategoryType','pertanian','tanaman kelapa',1,0,'2022-11-13 06:49:09','superadmin@gmail.com',NULL,NULL),(95,'RestrictionType','transfer charge and lease','x tcldd',1,0,'2022-11-13 06:49:35','superadmin@gmail.com','2022-11-13 14:49:40',NULL),(96,'BuildingType','office lot','3 store',1,0,'2022-11-13 06:50:01','superadmin@gmail.com','2022-11-13 14:50:07',NULL);
/*!40000 ALTER TABLE `enummaster` ENABLE KEYS */;
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
