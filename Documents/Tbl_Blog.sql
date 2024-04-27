-- -------------------------------------------------------------
-- TablePlus 6.0.0(550)
--
-- https://tableplus.com/
--
-- Database: DotNetTrainingBatch4
-- Generation Time: 2024-04-27 11:59:47.8730 PM
-- -------------------------------------------------------------


DROP TABLE IF EXISTS [dbo].[Tbl_Blog];
-- This script only contains the table creation statements and does not fully represent the table in the database. It's still missing: sequences, indices, triggers. Do not use it as a backup.

CREATE TABLE [dbo].[Tbl_Blog] (
    [BlogId] int IDENTITY,
    [BlogTitle] varchar(50),
    [BlogAuthor] varchar(50),
    [BlogContent] varchar(50),
    PRIMARY KEY ([BlogId])
);

INSERT INTO [dbo].[Tbl_Blog] ([BlogId], [BlogTitle], [BlogAuthor], [BlogContent]) VALUES
('1', N'Test Title', N'Test Author', N'Test Content'),
('2', N'Test Title', N'Test Author', N'Test Content'),
('3', N'Test Title', N'Test Author', N'Test Content'),
('4', N'Test Title', N'Test Author', N'Test Content'),
('5', N'Test Title', N'Test Author', N'Test Content'),
('6', N'Test Title', N'Test Author', N'Test Content'),
('7', N'Test Title', N'Test Author', N'Test Content'),
('8', N'Test Title', N'Test Author', N'Test Content'),
('9', N'Test Title', N'Test Author', N'Test Content'),
('10', N'update title', N'update author', N'update content'),
('12', N'title', N'author', N'content');
