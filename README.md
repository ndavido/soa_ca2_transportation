# soa_ca2_transportation
```
CREATE TABLE `Route` (
    `RouteID` CHAR(36) NOT NULL,
    `RouteName` VARCHAR(255) NOT NULL,
    `StartLocation` VARCHAR(255) NOT NULL,
    `EndLocation` VARCHAR(255) NOT NULL,
    PRIMARY KEY (`RouteID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

CREATE TABLE `Schedule` (
    `ScheduleID` CHAR(36) NOT NULL,
    `RouteID` CHAR(36) NOT NULL,
    `DepartureTime` DATETIME NOT NULL,
    `ArrivalTime` DATETIME NOT NULL,
    PRIMARY KEY (`ScheduleID`),
    CONSTRAINT `fk_Schedule_Route` FOREIGN KEY (`RouteID`) REFERENCES `Route` (`RouteID`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;
```
