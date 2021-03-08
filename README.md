##Script to create Database
CREATE SCHEMA `billstopay` ;

CREATE TABLE `billstopay`.`billtopay` (
  `Id` CHAR(36) NOT NULL,
  `Name` VARCHAR(8000) NOT NULL,
  `OriginalValue` DECIMAL(10,2) NOT NULL,
  `DueDate` DATETIME NOT NULL,
  `PayDay` DATETIME NOT NULL,
  `NumberOfDaysOverdue` INT NOT NULL,
  PRIMARY KEY (`Id`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;

CREATE TABLE `billstopay`.`latefee` (
  `Id` CHAR(36) NOT NULL,
  `MinDaysInOverdue` INT NOT NULL,
  `Fee` DECIMAL(10,2) NOT NULL,
  `InterestPerDay` DECIMAL(10,2) NOT NULL,
  PRIMARY KEY (`Id`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;
