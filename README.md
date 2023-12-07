# soa_ca2_transportation
```
CREATE TABLE `Travel` (
    `TravelID` CHAR(36) NOT NULL,
    `TravelName` VARCHAR(255) NOT NULL,
    `StartLocation` VARCHAR(255) NOT NULL,
    `EndLocation` VARCHAR(255) NOT NULL,
    PRIMARY KEY (`TravelID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

CREATE TABLE `Schedule` (
    `ScheduleID` CHAR(36) NOT NULL,
    `TravelID` CHAR(36) NOT NULL,
    `DepartureTime` DATETIME NOT NULL,
    `ArrivalTime` DATETIME NOT NULL,
    PRIMARY KEY (`ScheduleID`),
    FOREIGN KEY (`TravelID`) REFERENCES `Travel` (`TravelID`)
        ON DELETE CASCADE
        ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;
```

```
INSERT INTO `Travel` (`TravelID`, `TravelName`, `StartLocation`, `EndLocation`) VALUES
('1', 'Emerald Isle Coastal Odyssey', 'Derry', 'Cork'),
('2', 'Celtic Capitals Express', 'Dublin', 'Belfast'),
('3', 'Atlantic Seaboard Trail', 'Waterford', 'Galway'),
('4', 'Emerald North-South Passage', 'Cork', 'Belfast'),
('5', 'Norman Heritage Voyager', 'Belfast', 'Kilkenny');

INSERT INTO `Schedule` (`ScheduleID`, `TravelID`, `DepartureTime`, `ArrivalTime`) VALUES
('1', '1', '2024-08-13 13:00:04', '2024-10-30 22:56:33'),
('2', '1', '2023-12-28 19:11:08', '2024-10-18 07:12:17'),
('3', '1', '2024-10-28 12:02:00', '2024-12-01 01:36:59'),
('4', '2', '2024-11-04 22:38:13', '2024-11-07 20:06:07'),
('5', '2', '2024-10-28 20:31:18', '2024-11-13 14:42:30'),
('6', '2', '2024-09-08 23:19:13', '2024-10-16 10:49:37'),
('7', '3', '2024-05-12 05:23:52', '2024-08-01 11:07:43'),
('8', '3', '2024-02-26 10:19:06', '2024-04-09 09:14:05'),
('9', '3', '2024-06-03 07:56:12', '2024-11-05 15:27:19'),
('10', '4', '2024-07-24 20:20:47', '2024-10-05 10:20:09'),
('11', '4', '2024-09-28 09:47:16', '2024-10-13 16:02:10'),
('12', '4', '2024-09-20 11:31:21', '2024-12-01 00:21:53'),
('13', '5', '2024-02-04 10:06:11', '2024-10-14 19:01:37'),
('14', '5', '2024-01-10 07:25:56', '2024-03-12 00:45:52'),
('15', '5', '2024-06-24 17:49:56', '2024-09-20 09:12:32');
```
