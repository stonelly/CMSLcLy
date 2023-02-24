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
INSERT INTO `aspnetusers` VALUES ('2afb086f-1501-400b-9df2-447afd08d6b9','superadmin@gmail.com',_binary '\0','AH51+/PAyN//2Hs3tIhAJKXN6MrQV7+0ES3rn0onaHU2aZxvpQboSZNz01ns3QouzA==','7d3b4e77-d158-4c70-97e0-aa49596d5571',NULL,_binary '\0',_binary '\0',NULL,_binary '\0',0,'superadmin@gmail.com'),('51b2ab25-fb9b-4454-b938-f8618d5f7adb','Abc@gmail.com',_binary '\0','ANuAJiPzK2gI0Yo/E0rWXHiYQZ9v0i+zyV4EYOcsjNjmApsgZyVIr954PjHTixiXfw==','92de6bfd-8830-4b73-bae0-0533cc300d7a',NULL,_binary '\0',_binary '\0',NULL,_binary '\0',0,'Abc@gmail.com'),('54c1a940-1b4a-4972-8a1a-5eea16bd9c39','Partner1@test.com',_binary '\0','AO7y8tznG1lEYApcP8t2RsqdAh+m+wKvHOgmTVHYi4wly+Vw8A30SRA2BQwmJ/bEAA==','f2f7560f-00d9-46f7-983d-3d8934d0f061',NULL,_binary '\0',_binary '\0',NULL,_binary '\0',0,'Partner1@test.com'),('6bc8cee0-a03e-430b-9711-420ab0d6a596','demo@email.com',_binary '\0','APc6/pVPfTnpG89SRacXjlT+sRz+JQnZROws0WmCA20+axszJnmxbRulHtDXhiYEuQ==','18272ba5-bf6a-48a7-8116-3ac34dbb7f38',NULL,_binary '\0',_binary '\0',NULL,_binary '\0',0,'demo@email.com'),('7802176c-abc4-44d8-b0cf-bb4d25124121','stonelly123@gmail.com',_binary '\0','AARY46WQdMe+a8bfTj/i6NkCE7YT/OTTbsxHovnscHy68iA3T3YXgUR5xD+lpsH2QA==','b2076afd-198b-4233-abc2-5a23d1cccc62',NULL,_binary '\0',_binary '\0',NULL,_binary '\0',0,'stonelly123@gmail.com'),('7a956b51-0bab-4317-8366-e3b2a49be946','limteckfoo@yahoo.com',_binary '\0','ADFg9rkIfI8YLQoYe93Ts+g8Fx/ablwJOq5ZvbVi/8+rNMPkXTe7ZHpyoEs+TVFSbg==','985b1c41-921e-4e3f-9306-3eaa4cbfa529',NULL,_binary '\0',_binary '\0',NULL,_binary '\0',0,'limteckfoo@yahoo.com'),('8442a3d2-eca6-4c09-a8f1-3dc3f31267d9','vinod666@gmail.com',_binary '\0','AKclIEURkmWIwCRibEJ4zEpmMUM1R/ASXd1GpsIRcd7Q7X9PwlIAHTpbtVuGTXVUXw==','330304e5-1c97-4ac7-948c-1dfd1172bc53',NULL,_binary '\0',_binary '\0',NULL,_binary '\0',0,'vinod666@gmail.com'),('9a358623-369a-4948-a7de-c13f1768bf1d','JasperCo@simpe.net.com',_binary '\0','AJ2mlNfv35XAWhlfSlWydCRN4yhVfIUBeArQJ8aYlo0pRJs2rk/pqeP46/qkzoifkQ==','45995de9-250d-4f8b-bab7-bd6e1e21218f',NULL,_binary '\0',_binary '\0',NULL,_binary '\0',0,'JasperCo@simpe.net.com'),('9e6dd302-1fcd-4f1c-93e0-159ed513563f','test@gmail.com',_binary '\0','ABn1lPdk55mRy03m5CyNoTZdWOWZkOWhIfC65NI9rAAZwlv+dlahurmn7D6b7p/UuQ==','ce56c60d-1e56-438c-8db3-013efed6c458',NULL,_binary '\0',_binary '\0',NULL,_binary '\0',0,'test@gmail.com'),('c610c2f0-7647-470a-861f-ef8cfd3c3d67','FannyKang@hotmail.com',_binary '\0','APwpPWZtCFOXdXKObwvHX5ayR703YbBHVDvKVWbGTWlfaP3Woh7jQd9fclYbgh6alA==','36b6feb6-53ac-43da-9e16-64336e9e9a52',NULL,_binary '\0',_binary '\0',NULL,_binary '\0',0,'FannyKang@hotmail.com'),('d5143ca4-e3b3-4fdf-af75-bbd944b8e0d4','SimplyOne@gmail.com',_binary '\0','AMbNZeD5uyh/5XoigWwyUVBVc/pC+F8JPn9ctALLM9Ds2X3oCSQBSGgzfccJan6ZAQ==','3bfd6cef-87c8-41f8-acc2-84228b90b4b5',NULL,_binary '\0',_binary '\0',NULL,_binary '\0',0,'SimplyOne@gmail.com'),('d53edee5-21b6-47a1-b18b-207a7bb90c45','K_BG@gmail.com',_binary '\0','ACvvQhaiDkJf0ZYEgtBFohEcmgt+BHSCZgR9XRLNl+ngXFZVuzyepOKYyZgs7Qb5bQ==','70382b39-918c-4f30-a31a-728a4bd86e79',NULL,_binary '\0',_binary '\0',NULL,_binary '\0',0,'K_BG@gmail.com'),('de6f1df5-265e-4a9f-9d65-df3ec4f3ad2d','vinod3344@gmail.com',_binary '\0','ACLv1vgOyaUMd01tKAH07q5ZQfk+YEuxksIyVUBd+HM9/MOCMn2Y7hgkYZUR7WBAvw==','74b45d7e-55e5-493c-9bfe-03828b9fa122',NULL,_binary '\0',_binary '\0',NULL,_binary '\0',0,'vinod3344@gmail.com'),('f89251b9-2b48-4bcf-a525-2cc3929380ba','LA1@test.com',_binary '\0','ALzILmOfF8rsKAH+NdBYJ37KfJ0iBmj26AmsFROQitMpscpj+6zL/eNCm281QdSAGw==','518ad267-81a0-4afc-a9e3-a09412fe671e',NULL,_binary '\0',_binary '\0',NULL,_binary '\0',0,'LA1@test.com');
/*!40000 ALTER TABLE `aspnetusers` ENABLE KEYS */;
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
