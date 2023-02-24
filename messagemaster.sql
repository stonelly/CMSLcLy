CREATE TABLE `messagemaster` (
  `ID` int NOT NULL AUTO_INCREMENT,
  `CustomerName` varchar(255) NOT NULL,
  `RoomName` varchar(255) NOT NULL,
  `Message` varchar(255) NOT NULL,
  `IsMessageRead` tinyint NOT NULL DEFAULT '0',
  `CreatedDate` datetime NOT NULL,
  `ModifiedDate` datetime NOT NULL,
  PRIMARY KEY (`ID`),
  KEY `ID` (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci