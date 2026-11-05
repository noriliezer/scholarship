USE scholarship_db;
GO

CREATE TABLE admins (
    admin_id INT IDENTITY(1,1) PRIMARY KEY,
    username NVARCHAR(50) NOT NULL UNIQUE,
    email NVARCHAR(100) NOT NULL UNIQUE,
    password_hash NVARCHAR(255) NOT NULL,
    created_at DATETIME2 NOT NULL DEFAULT SYSDATETIME()
);

CREATE TABLE scholarships (
    scholarship_id INT IDENTITY(1,1) PRIMARY KEY,
    name NVARCHAR(100) NOT NULL,
    amount DECIMAL(10,2) NOT NULL,
    deadline DATE NOT NULL,
    slots INT NOT NULL,
    status NVARCHAR(20) NOT NULL DEFAULT 'Available'
);

CREATE TABLE students (
    student_id NVARCHAR(20) PRIMARY KEY,
    full_name NVARCHAR(100) NOT NULL,
    course NVARCHAR(100) NULL,
    year_level TINYINT NULL,
    email NVARCHAR(100) NULL UNIQUE
);

CREATE TABLE applications (
    application_id INT IDENTITY(1,1) PRIMARY KEY,
    student_id NVARCHAR(20) NOT NULL REFERENCES students(student_id),
    scholarship_id INT NOT NULL REFERENCES scholarships(scholarship_id),
    date_applied DATETIME2 NOT NULL DEFAULT SYSDATETIME(),
    status NVARCHAR(20) NOT NULL DEFAULT 'Pending'
);

CREATE TABLE messages (
    message_id INT IDENTITY(1,1) PRIMARY KEY,
    admin_id INT NOT NULL REFERENCES admins(admin_id),
    recipient_group NVARCHAR(30) NOT NULL,
    subject NVARCHAR(150) NOT NULL,
    body NVARCHAR(MAX) NOT NULL,
    sent_at DATETIME2 NOT NULL DEFAULT SYSDATETIME()
);
GO

INSERT INTO scholarships (name, amount, deadline, slots, status) VALUES
('Academic Excellence', 10000.00, '2026-12-31', 5, 'Available'),
('Financial Aid', 5000.00, '2026-11-30', 10, 'Available');

INSERT INTO students (student_id, full_name, course, year_level, email) VALUES
('2024-0001', 'mark2', 'BSIS', 2, 'mark2@gmail.com'),
('2024-0002', 'mark3', 'BSIT', 3, 'mark3@gmail.com'),
('2026-0001', 'ener', 'BSIS', 1, 'ener@gmail.com'),
('2026-0002', 'mark', 'BSIT', 2, 'mark@gmail.com'),
('2026-0003', 'nher', 'BSIS', 3, 'nher@gmail.com'),
('2026-0004', 'kurt', 'BSIT', 1, 'kurt@gmail.com'),
('2026-0005', 'cherry', 'BSIS', 4, 'cherry@gmail.com'),
('2026-0006', 'ener1', 'BSIS', 1, 'ener1@gmail.com'),
('2026-0007', 'mark1', 'BSIT', 2, 'mark1@gmail.com'),
('2026-0008', 'nher1', 'BSIS', 3, 'nher1@gmail.com'),
('2026-0009', 'kurt1', 'BSIT', 1, 'kurt1@gmail.com'),
('2026-0010', 'cherry1', 'BSIS', 4, 'cherry1@gmail.com');

INSERT INTO applications (student_id, scholarship_id, date_applied, status) VALUES
('2024-0001', 1, '2026-11-01 07:30', 'Accepted'),
('2024-0002', 2, '2026-11-03 09:00', 'Accepted'),
('2026-0001', 1, '2026-11-01 08:15', 'Pending'),
('2026-0002', 2, '2026-11-01 09:30', 'Pending'),
('2026-0003', 1, '2026-11-02 10:05', 'Accepted'),
('2026-0004', 2, '2026-11-02 13:40', 'Rejected'),
('2026-0005', 1, '2026-11-02 15:20', 'Accepted'),
('2026-0006', 2, '2026-11-03 08:50', 'Pending'),
('2026-0007', 1, '2026-11-03 11:10', 'Pending'),
('2026-0008', 2, '2026-11-03 14:25', 'Accepted'),
('2026-0009', 1, '2026-11-04 09:00', 'Rejected'),
('2026-0010', 2, '2026-11-04 16:45', 'Pending');