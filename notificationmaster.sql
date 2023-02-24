CREATE TABLE `notificationmaster` (
  `ID` int NOT NULL AUTO_INCREMENT,
  `MessageID` int NOT NULL,
  `CustomerName` varchar(255) NOT NULL,
  `RoomName` varchar(255) NOT NULL,
  `Status` tinyint NOT NULL DEFAULT '0',
  `CreatedDate` datetime NOT NULL,
  `ModifiedDate` datetime NOT NULL,
  PRIMARY KEY (`ID`),
  KEY `ID` (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci