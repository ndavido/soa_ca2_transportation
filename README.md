<h1 align="center">
   Soa CA2 Transport Api
</h1>
<div align="center">
<a href='https://transportationsoaca2api.azurewebsites.net'>
  My Api can be accessed from this link
</a>
</div>

### Educational Resources
1. #### Api Key Authentication
   The following links helped me understand how to create an Api Key and how to implement it into the Swagger Template.

   >[Using API Key Authentication To Secure ASP.NET Core Web API; Gowtham K](https://www.c-sharpcorner.com/article/using-api-key-authentication-to-secure-asp-net-core-web-api/)

   >[SWAGGER UI FOR API KEY AUTHENTICATION FLOW WITH .NET CORE 6; gowthamk91](https://gowthamcbe.com/2022/02/21/swagger-ui-for-api-key-authentication-flow-with-net-core-6/)

   >[ADDING AN API SECURITY DEFINITION AND REQUIREMENT USING SWAGGER UI; DENNIS ADOLFI](https://adolfi.dev/blog/adding-an-api-security-definition-and-requirement-using-swagger-ui/)

2. #### Connection Resiliency
   During the development process I had frequent issues with connectivity to my database. The following link helped me solve this issue.

   >[Connection Resiliency; Microsoft](https://learn.microsoft.com/en-us/ef/core/miscellaneous/connection-resiliency)

3. #### Azure mysql Database
   To establish a live mysql database on azure, I used the following tutorials to guide me through the process.

   >[Use MySQL Workbench with Azure Database for MySQL - Flexible Server; Microsoft](https://learn.microsoft.com/en-us/azure/mysql/flexible-server/connect-workbench)

   >[Connect & Query Azure Database for MySQL Flexible Server using MySQL Workbench |Create Execute Table; 
Cloud Knowledge](https://www.youtube.com/watch?v=4Q1J2T9MMns)

4. #### Publishing Api
   The following sources allowed me to have my .net web core api deployed on the azure server

   >[Publish an ASP.NET Core web API to Azure API Management with Visual Studio; Microsoft](https://learn.microsoft.com/en-us/aspnet/core/tutorials/publish-to-azure-api-management-using-vs?view=aspnetcore-6.0)

   >[How to deploy asp.net core web api to azure app service; kudvenkat](https://www.youtube.com/watch?v=MP4zatl3jF8)

5. #### Default Swagger Page
   I used this forum to save time and not having to change the url in order to get to the Swagger template.

   >[Default swagger index page not loading by default in Azure; Stackoverflow](https://stackoverflow.com/questions/67970993/default-swagger-index-page-not-loading-by-default-in-azure)

6. #### Debugging Object Cycle
   During the development process I came across an issue where my Api would not display null in Schedules for Travels and vice versa. This forum helped me solve this issue.

   >[.NET Core 3.0 possible object cycle was detected which is not supported; Stackoverflow](https://stackoverflow.com/questions/59199593/net-core-3-0-possible-object-cycle-was-detected-which-is-not-supported)

## mysql Insertions
### Database & Tables
```sql
DROP DATABASE IF EXISTS transportation_soa_ca2;

CREATE DATABASE transportation_soa_ca2;

USE transportation_soa_ca2;

DROP TABLE IF EXISTS Schedule;
DROP TABLE IF EXISTS Travel;

CREATE TABLE Travel (
    TravelID INT NOT NULL,
    TravelName VARCHAR(255) NOT NULL,
    StartLocation VARCHAR(255) NOT NULL,
    EndLocation VARCHAR(255) NOT NULL,
    PRIMARY KEY (TravelID)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

CREATE TABLE Schedule (
    ScheduleID INT NOT NULL,
    TravelID INT NOT NULL,
    DepartureTime DATETIME NOT NULL,
    ArrivalTime DATETIME NOT NULL,
    PRIMARY KEY (ScheduleID),
    FOREIGN KEY (TravelID) REFERENCES Travel (TravelID)
        ON DELETE CASCADE
        ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;
```
### Populating The Tables
```sql
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
