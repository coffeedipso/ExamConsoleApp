USE LibraryBook
GO
INSERT INTO [dbo].[Books] (Title, Author_FirstName, Author_SecondName, Author_SurName, Publisher, Page_Count, Genre, Publication_Year, Cost_Price, Selling_Price, Continuation)
VALUES
('War and Peace', 'Leo', NULL, 'Tolstoy', '1869-01-01', 1225, 'Historical fiction', 1869, 500.00, 1000.00, 0),
('1984', 'George', NULL, 'Orwell', '1949-06-08', 328, 'Dystopian fiction', 1949, 300.00, 750.00, 0),
('To Kill a Mockingbird', 'Harper', NULL, 'Lee', '1960-07-11', 281, 'Southern Gothic', 1960, 350.00, 800.00, 0),
('The Great Gatsby', 'F. Scott', NULL, 'Fitzgerald', '1925-04-10', 180, 'Tragedy', 1925, 400.00, 850.00, 0),
('One Hundred Years of Solitude', 'Gabriel', 'Garcia', 'Marquez', '1967-05-30', 417, 'Magical realism', 1967, 450.00, 900.00, 0),
('Crime and Punishment', 'Fyodor', NULL, 'Dostoevsky', '1866-11-14', 671, 'Philosophical fiction', 1866, 550.00, 1100.00, 0),
('The Catcher in the Rye', 'J.D.', NULL, 'Salinger', '1951-07-16', 234, 'Realistic fiction', 1951, 320.00, 780.00, 0),
('Brave New World', 'Aldous', NULL, 'Huxley', '1932-04-30', 311, 'Science fiction', 1932, 380.00, 850.00, 1),
('The Hobbit', 'J.R.R.', NULL, 'Tolkien', '1937-09-21', 310, 'Fantasy', 1937, 400.00, 950.00, 1),
('Pride and Prejudice', 'Jane', NULL, 'Austen', '1813-01-28', 279, 'Romantic fiction', 1813, 320.00, 800.00, 0);
