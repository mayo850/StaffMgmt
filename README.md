# StaffMgmt

This repository provides a simple ASP.NET web application to manage staff assignments to various grants. Below are the steps to set up the database and configure the necessary settings to run the application.

---

## Database Setup

### 1. Create the Database

You can name the database anything you like. In this example, the database is named `GrantStaffDB`. If you choose a different name, make sure to update the connection string in your `web.config` file to reflect the name of your database.

### 2. Create the Tables

Run the following SQL queries to create the necessary tables in your database:

```sql
-- Staff Table
CREATE TABLE Staff (
    StaffID INT PRIMARY KEY IDENTITY(1,1),
    StaffName NVARCHAR(100) NOT NULL,
    Email NVARCHAR(100) NOT NULL,
    CertificationDate DATE NOT NULL
);

-- Grant Table
CREATE TABLE GrantInfo (
    GrantID INT PRIMARY KEY IDENTITY(1,1),
    GrantName NVARCHAR(50) NOT NULL
);

-- StaffGrantAssignment Table
CREATE TABLE StaffGrantAssignment (
    StaffGrantAssignmentID INT PRIMARY KEY IDENTITY(1,1),
    StaffID INT NOT NULL,
    GrantID INT NOT NULL,
    StartDate DATE NOT NULL,
    EndDate DATE NULL,
    FOREIGN KEY (StaffID) REFERENCES Staff(StaffID),
    FOREIGN KEY (GrantID) REFERENCES GrantInfo(GrantID)
);
```

## Sample Data

After creating the tables, you can insert some sample data into the database for testing. Run the following `INSERT` queries:

### Insert Staff

```sql
INSERT INTO Staff (StaffName, Email, CertificationDate)
VALUES 
('David Baluga', 'DavB@CPRD.EDU', '2024-04-05'),
('Mishe Smith', 'Mish1980@CPRD.EDU', '2023-07-08'),
('Bradely Smith', 'BSmith55@CPRD.EDU', '2023-05-24'),
('Gloria Marshel', 'GLSmith356@CPRD.EDU', '2023-08-02');
```

### Insert Grants
```sql
INSERT INTO GrantInfo (GrantName)
VALUES 
('ABC'),
('FFM'),
('MZMSH');
```

### Insert StaffGrantAssignment
```sql
INSERT INTO StaffGrantAssignment (StaffID, GrantID, StartDate, EndDate)
VALUES 
(1, 1, '2024-02-07', NULL),
(1, 2, '2024-05-05', NULL),
(1, 3, '2024-05-05', NULL),
(2, 1, '2024-02-07', NULL),
(2, 2, '2023-08-08', '2024-01-07'),
(3, 1, '2023-05-25', NULL),
(3, 2, '2023-05-25', NULL),
(3, 3, '2023-05-25', NULL),
(4, 1, '2023-08-08', '2024-02-07'),
(4, 2, '2024-08-08', NULL);
```
## Web.Config Setup

To connect your web application to the database, you will need to configure the `web.config` file. Add the following connection string to your `web.config`:

```xml
<configuration>
    <connectionStrings>
        <add name="GrantStaffDBConnection" 
             connectionString="Server=YOUR_SERVER_NAME;Database=GrantStaffDB;Integrated Security=True;" 
             providerName="System.Data.SqlClient" />
    </connectionStrings>
</configuration>
```
