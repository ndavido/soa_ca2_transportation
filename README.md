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
('0ee553c0-241d-45ee-8e30-a71a8e954827', 'Emerald Isle Coastal Odyssey', 'Derry', 'Cork'),
('f5d12657-f001-4af8-a0a9-6d31ac13b51f', 'Celtic Capitals Express', 'Dublin', 'Belfast'),
('3824237c-df75-47a8-8532-a6a656c32747', 'Atlantic Seaboard Trail', 'Waterford', 'Galway'),
('ffb2a9c7-d7ac-40c1-9ea3-2e7430e1f4ca', 'Emerald North-South Passage', 'Cork', 'Belfast'),
('8b3cc132-e2ef-4baa-9632-0e561f79bad2', 'Norman Heritage Voyager', 'Belfast', 'Kilkenny');

INSERT INTO `Schedule` (`ScheduleID`, `TravelID`, `DepartureTime`, `ArrivalTime`) VALUES
('4cf28686-cfd1-494a-ac81-48f2690f3bde', '0ee553c0-241d-45ee-8e30-a71a8e954827', '2024-08-13 13:00:04', '2024-10-30 22:56:33'),
('1eddae6a-32d9-466e-9f86-267e850be5f3', '0ee553c0-241d-45ee-8e30-a71a8e954827', '2023-12-28 19:11:08', '2024-10-18 07:12:17'),
('e778dca0-c3b2-4dda-942a-7f762cde3d28', '0ee553c0-241d-45ee-8e30-a71a8e954827', '2024-10-28 12:02:00', '2024-12-01 01:36:59'),
('7e26e6b3-92f1-4d77-bd6d-1ee77b6a547e', 'f5d12657-f001-4af8-a0a9-6d31ac13b51f', '2024-11-04 22:38:13', '2024-11-07 20:06:07'),
('fe204400-9aa2-48dc-a654-008138164616', 'f5d12657-f001-4af8-a0a9-6d31ac13b51f', '2024-10-28 20:31:18', '2024-11-13 14:42:30'),
('62c91b73-813e-41ba-a5ec-f24c546fa142', 'f5d12657-f001-4af8-a0a9-6d31ac13b51f', '2024-09-08 23:19:13', '2024-10-16 10:49:37'),
('173c6fcd-e0a1-493c-adcc-7fb53bdb379b', '3824237c-df75-47a8-8532-a6a656c32747', '2024-05-12 05:23:52', '2024-08-01 11:07:43'),
('f5e01250-0747-4b3e-81c9-8ae17faa79e1', '3824237c-df75-47a8-8532-a6a656c32747', '2024-02-26 10:19:06', '2024-04-09 09:14:05'),
('7664dc40-2e6f-4abc-939d-997a9d2a417d', '3824237c-df75-47a8-8532-a6a656c32747', '2024-06-03 07:56:12', '2024-11-05 15:27:19'),
('5e259587-7d40-4656-a661-7a1223d2732f', 'ffb2a9c7-d7ac-40c1-9ea3-2e7430e1f4ca', '2024-07-24 20:20:47', '2024-10-05 10:20:09'),
('945ef532-8169-4cfe-a09a-2d55a39b4939', 'ffb2a9c7-d7ac-40c1-9ea3-2e7430e1f4ca', '2024-09-28 09:47:16', '2024-10-13 16:02:10'),
('65daaacf-3038-46eb-afac-0fef69988e1f', 'ffb2a9c7-d7ac-40c1-9ea3-2e7430e1f4ca', '2024-09-20 11:31:21', '2024-12-01 00:21:53'),
('83eeeae4-649a-40c5-b4ed-1a64e54d5959', '8b3cc132-e2ef-4baa-9632-0e561f79bad2', '2024-02-04 10:06:11', '2024-10-14 19:01:37'),
('758f6f0d-5ccf-476e-8523-d6633962c189', '8b3cc132-e2ef-4baa-9632-0e561f79bad2', '2024-01-10 07:25:56', '2024-03-12 00:45:52'),
('694806ae-5c3f-48fc-83fe-c5a30a0fe87e', '8b3cc132-e2ef-4baa-9632-0e561f79bad2', '2024-06-24 17:49:56', '2024-09-20 09:12:32');
```
