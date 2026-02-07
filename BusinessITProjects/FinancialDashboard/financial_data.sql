-- 1️⃣ Opret database (hvis den ikke findes)
CREATE DATABASE IF NOT EXISTS FinancialDashboard;
USE FinancialDashboard;

-- 2️⃣ Tabel til virksomheder
CREATE TABLE Companies (
    id INT PRIMARY KEY AUTO_INCREMENT,
    name VARCHAR(100) NOT NULL
);

-- 3️⃣ Tabel til økonomiske data
CREATE TABLE Financials (
    id INT PRIMARY KEY AUTO_INCREMENT,
    company_id INT NOT NULL,
    year INT NOT NULL,
    revenue DECIMAL(12,2) NOT NULL,
    expenses DECIMAL(12,2) NOT NULL,
    FOREIGN KEY (company_id) REFERENCES Companies(id)
);

-- 4️⃣ Eksempeldata for virksomheder
INSERT INTO Companies (name) VALUES
('TechCorp'),
('GreenEnergy'),
('SmartFinance'),
('FutureSolutions');

-- 5️⃣ Eksempeldata for finansielle resultater
INSERT INTO Financials (company_id, year, revenue, expenses) VALUES
(1, 2025, 1500000, 900000),
(2, 2025, 1200000, 700000),
(3, 2025, 800000, 400000),
(4, 2025, 2000000, 1500000);

-- 6️⃣ Eksempel på en forespørgsel (profitberegning)
SELECT c.name AS Company, f.year AS Year, f.revenue AS Revenue, f.expenses AS Expenses,
       (f.revenue - f.expenses) AS Profit
FROM Companies c
JOIN Financials f ON c.id = f.company_id
ORDER BY Profit DESC;
