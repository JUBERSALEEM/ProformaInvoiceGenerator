-- Database Initialization
CREATE DATABASE GlassAutomationDB;
GO
USE GlassAutomationDB;
GO

-- Header Table: Status and Reports Summary
CREATE TABLE PI_Headers (
    PI_ID INT PRIMARY KEY IDENTITY(1,1),
    PINumber NVARCHAR(50) UNIQUE,
    PIDate DATE DEFAULT GETDATE(),
    CustomerName NVARCHAR(200),
    CustomerTRN_VAT NVARCHAR(50), -- Combined Single Box
    PI_Status NVARCHAR(20) DEFAULT 'Pending', -- Confirmed/Pending
    TotalSqm DECIMAL(18,4),
    TotalGrossAmountAED DECIMAL(18,2)
);

-- Specifications Table: Smart Grid Data
CREATE TABLE PI_Specifications (
    RowID INT PRIMARY KEY IDENTITY(1,1),
    PI_ID INT,
    SectionName NVARCHAR(MAX), -- Full Auto-Gen Spec
    W1 DECIMAL(18,2), H1 DECIMAL(18,2),
    W2 DECIMAL(18,2) DEFAULT 0, H2 DECIMAL(18,2) DEFAULT 0,
    Qty INT,
    Sqm DECIMAL(18,4), -- 0.5 Rule applied
    SqmPrice DECIMAL(18,2), -- Surcharge applied
    TotalPrice DECIMAL(18,2),
    FOREIGN KEY (PI_ID) REFERENCES PI_Headers(PI_ID) ON DELETE CASCADE
);

-- View for Monthly Confirmed Reports
GO
CREATE VIEW View_MonthlyConfirmedReport AS
SELECT MONTH(PIDate) as Month, YEAR(PIDate) as Year, SUM(TotalSqm) as SqmSold, SUM(TotalGrossAmountAED) as Revenue
FROM PI_Headers WHERE PI_Status = 'Confirmed'
GROUP BY MONTH(PIDate), YEAR(PIDate);
