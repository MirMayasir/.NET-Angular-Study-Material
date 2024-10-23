create database CapstoneProject;
use CapstoneProject
CREATE TABLE Users (
    UserID INT IDENTITY(1,1) PRIMARY KEY,
    Username VARCHAR(50) NOT NULL,
    Email VARCHAR(100) NOT NULL,
    PasswordHash VARCHAR(255) NOT NULL 
);

INSERT INTO Users (Username, Email, PasswordHash)
VALUES ('jane_doe', 'jane@example.com', 'Jone@123');

select * from Users

delete from users

CREATE TABLE Drugs (
    DrugID INT PRIMARY KEY IDENTITY(1,1), 
    Name VARCHAR(100) NOT NULL,           
    Description TEXT,                     
    Manufacturer VARCHAR(100),            
    Price DECIMAL(10, 2) NOT NULL,        
    Stock INT NOT NULL,                   
    Region VARCHAR(50)                    
);

INSERT INTO Drugs (Name, Description, Manufacturer, Price, Stock, Region)
VALUES
('Aspirin', 'Pain reliever and fever reducer', 'Pharma Inc.', 9.99, 100, 'North America'),
('Ibuprofen', 'Nonsteroidal anti-inflammatory drug', 'MediCorp', 14.99, 50, 'Europe'),
('Paracetamol', 'Analgesic and antipyretic', 'HealthPlus', 12.99, 75, 'Asia');


CREATE TABLE Subscriptions (
    SubscriptionID INT PRIMARY KEY IDENTITY(1,1),  
    Username VARCHAR(50) NOT NULL,                  
    IsSubscribed BIT DEFAULT 1,          
    SubscriptionDate Date, 
    UnsubscribeDate Date,                 
);
select * from Subscriptions
delete from Subscriptions
ALTER TABLE Subscriptions
ADD PlanType NVARCHAR(50);


DROP TABLE booking;

CREATE TABLE booking (
    bookingId INT PRIMARY KEY,
    drugName VARCHAR(100) NOT NULL,
    drugDescription TEXT,
    Manufacturer VARCHAR(100),
    Price DECIMAL(10, 2) NOT NULL,
    Region VARCHAR(50),
    customerName VARCHAR(20),
    dosagePeriod INT
);

ALTER TABLE booking DROP COLUMN bookDate;

ALTER TABLE booking ADD bookDate DATE DEFAULT GETDATE();

delete from booking
select * from booking

