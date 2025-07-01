-- Tạo cơ sở dữ liệu
CREATE DATABASE NguyenVanKhai_2310900046;
GO

-- Sử dụng cơ sở dữ liệu vừa tạo
USE NguyenVanKhai_2310900046;
GO

-- Tạo bảng HvtEmployee
CREATE TABLE NvkEmployee (
    nvkEmpId INT PRIMARY KEY IDENTITY(1,1),
    nvkEmpName NVARCHAR(100),
    nvkEmpLevel NVARCHAR(50),
    nvkEmpStartDate DATE,
    nvkEmpStatus BIT
);
GO

-- Thêm ít nhất 3 bản ghi (trong đó có 1 bản ghi là thông tin của bạn)
INSERT INTO NvkEmployee (nvkEmpName, nvkEmpLevel, nvkEmpStartDate, nvkEmpStatus)
VALUES 
(N'Nguyễn Văn Khải', N'Dev', '2025-06-01', 1),
(N'Nguyen Van A', N'Staff', '2024-12-15', 1),
(N'Tran Thi B', N'Manager', '2023-05-20', 0);
GO
