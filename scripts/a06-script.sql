--//////////////////////////////////////
/*
* PROJECT : SQ2 - Assignment 6
* FILE : a06-script.sql
* PROGRAMMER : Austin Che, Dong Qian
* DATE : 2017/04/12
* DESCRIPTION : This sql script creates the A06 database
*	and a Product table.
*/
--//////////////////////////////////////
-- Creating the EMS database (if it did not exist)
IF EXISTS (SELECT name FROM master.dbo.sysdatabases WHERE name='A06')
	DROP DATABASE A06;

CREATE DATABASE A06;
GO

USE A06;
GO

-- Creating the Product table
CREATE TABLE Product(
	Product_ID INT NOT NULL,
	Description NVARCHAR(1024) NULL,
	Unit_Price money NULL
);
GO

-- Insert some test data into the Product table
INSERT INTO Product(Product_ID, Description, Unit_Price) VALUES
	(1, 'Chips', 5.50),
	(2, 'Granola Bar', 1.25),
	(3, 'Ice Cream', 1.40),
	(4, 'Cookie', 1.35),
	(5, 'Chocolate', 2.65);
GO

SELECT * FROM Product;