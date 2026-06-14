use Postal_HR_System;

CREATE TABLE Users(
    UserID INT PRIMARY KEY IDENTITY(1,1),
    FirstName NVARCHAR(100) NOT NULL,
    Division NVARCHAR(50) NOT NULL,
    Designation NVARCHAR(50) NOT NULL,
    NIC NVARCHAR(20) NOT NULL UNIQUE,
    Password NVARCHAR(100) NOT NULL,
    CreatedDate DATETIME DEFAULT GETDATE()
)
drop table Users;
INSERT INTO Users (FullName, Email, PhoneNumber, Department, Designation, NIC, Password,ConfirmPassword)
VALUES (
    'Madhavi Mihika',
    'mihikamadhavi123@gmail.com',
    '0702666941',
    'HR Department',
    'HR Manager',
    '200145800123',
    'root123',
	'root123'
);

select * from Users;
delete from Users where id='2';

//when i delete id 1 or someything again I can replace them starting from 1

DBCC CHECKIDENT ('Users', RESEED, 0);




