using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ExamLib.ExamLibREP;
namespace ExamLib
{
    internal class ActionsWithBooks
    {
        public static List<LibraryBook> books = new List<LibraryBook>();

        public static void PrintBookList(List<LibraryBook> books)
        {
            Console.WriteLine("Your library");
            Console.WriteLine();
            foreach (var book in books)
            {
                Console.WriteLine($"Book ID: {book.Book_Id}");
                Console.WriteLine($"Author: {book.Author_FirstName} {book.Author_SecondName} {book.Author_SurName}");
                Console.WriteLine($"Publisher: {book.Publisher}");
                Console.WriteLine($"Page Count: {book.Page_Count}");
                Console.WriteLine($"Genre: {book.Genre}");
                Console.WriteLine($"Publication Year: {book.Publication_Year}");
                Console.WriteLine($"Cost Price: {book.Cost_Price}");
                Console.WriteLine($"Selling Price: {book.Selling_Price}");
                Console.WriteLine($"Continuation: {book.Continuation}");
                Console.WriteLine($"Sell book: {book.SellBook}");
                Console.WriteLine($"Write off book: {book.Writeoffbook}");
                Console.WriteLine($"Contribute book: {book.ContributeBook}");
                Console.WriteLine($"Aside: {book.Aside}");

                Console.WriteLine();
            }
        }

        public static List<LibraryBook> AddBook(List<LibraryBook> books)
        {
            try
            {
                Console.WriteLine("Enter data to add a new book:");

                Console.Write("Title: ");
                string title = Console.ReadLine();

                Console.Write("Author's First Name: ");
                string firstName = Console.ReadLine();

                Console.Write("Author's second Name: ");
                string secondName = Console.ReadLine();

                Console.Write("Author's surName: ");
                string authorSurName = Console.ReadLine();

                Console.Write("Publisher: ");
                string publisher = Console.ReadLine();

                Console.Write("Page Count: ");
                if (!int.TryParse(Console.ReadLine(), out int pageCount))
                {
                    throw new ArgumentException("Invalid page count. Please enter an integer.");
                }

                Console.Write("Genre: ");
                string genre = Console.ReadLine();

                Console.Write("Publication Year: ");
                if (!int.TryParse(Console.ReadLine(), out int publicationYear))
                {
                    throw new ArgumentException("Invalid publication year. Please enter an integer.");
                }

                Console.Write("Cost Price: ");
                if (!int.TryParse(Console.ReadLine(), out int costPrice))
                {
                    throw new ArgumentException("Invalid cost price. Please enter a number.");
                }

                Console.Write("Selling Price: ");
                if (!int.TryParse(Console.ReadLine(), out int sellingPrice))
                {
                    throw new ArgumentException("Invalid selling price. Please enter a number.");
                }

                Console.Write("Continuation (yes/no): ");
                bool continuation = Console.ReadLine().ToLower() == "yes";
                int maxIndex = books.Any() ? books.Max(b => b.Book_Id) : 0;

                LibraryBook newBook = new LibraryBook
                {
                    Book_Id=maxIndex+1,
                    Title = title,
                    Author_FirstName = firstName,
                    Author_SecondName = secondName,
                    Author_SurName = authorSurName,
                    Publisher = publisher,
                    Page_Count = pageCount,
                    Genre = genre,
                    Publication_Year = publicationYear,
                    Cost_Price = costPrice,
                    Selling_Price = sellingPrice,
                    Continuation = continuation
                };

                //books.Add(newBook);
                List<LibraryBook> updatedBooks = new List<LibraryBook>(books);
                updatedBooks.Add(newBook);
                Console.WriteLine("New book successfully added!");
                Console.WriteLine();
                //Console.WriteLine("Updated List of Books:");
                //foreach (var book in currentBooks)
                //{
                //    Console.WriteLine($"{book.Title} - {book.Author_FirstName} {book.Author_SurName}");
                //}

                return updatedBooks;
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while adding the book: " + ex.Message);
                return books;
            }
        }
        public static List<LibraryBook> DeleteBookById(List<LibraryBook> books)
        {
            try
            {
                Console.WriteLine("Enter the Book ID you want to delete:");
                int bookIdToDelete = int.Parse(Console.ReadLine());

                LibraryBook bookToDelete = books.FirstOrDefault(b => b.Book_Id == bookIdToDelete);

                if (bookToDelete != null)
                {
                    books.Remove(bookToDelete);
                    Console.WriteLine("Book with ID " + bookIdToDelete + " successfully deleted!");

                    for (int i = 0; i < books.Count; i++)
                    {
                        books[i].Book_Id = i + 1;
                    }

                    Console.WriteLine("Book indexes re-calculated.");
                }
                else
                {
                    Console.WriteLine("Book with ID " + bookIdToDelete + " not found in the library.");
                }

                return books; 
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while deleting the book: " + ex.Message);
                return books; 
            }
        }
        public static List<LibraryBook> EditBook(List<LibraryBook> books)
        {
            try
            {
                Console.WriteLine("Enter the Book ID you want to edit:");
                int bookIdToEdit = int.Parse(Console.ReadLine());

                LibraryBook bookToEdit = books.FirstOrDefault(b => b.Book_Id == bookIdToEdit);

                if (bookToEdit == null)
                {
                    Console.WriteLine("Book with ID " + bookIdToEdit + " not found in the library.");
                    return books;
                }

                Console.WriteLine("Enter new data for the book:");

                Console.Write("Title: ");
                bookToEdit.Title = Console.ReadLine();

                Console.Write("Author's First Name: ");
                bookToEdit.Author_FirstName = Console.ReadLine();

                Console.Write("Author's Second Name: ");
                bookToEdit.Author_SecondName = Console.ReadLine();

                Console.Write("Author's Surname: ");
                bookToEdit.Author_SurName = Console.ReadLine();

                Console.Write("Publisher: ");
                bookToEdit.Publisher = Console.ReadLine();

                Console.Write("Page Count: ");
                if (!int.TryParse(Console.ReadLine(), out int pageCount))
                {
                    throw new ArgumentException("Invalid page count. Please enter an integer.");
                }
                bookToEdit.Page_Count = pageCount;

                Console.Write("Genre: ");
                bookToEdit.Genre = Console.ReadLine();

                Console.Write("Publication Year: ");
                if (!int.TryParse(Console.ReadLine(), out int publicationYear))
                {
                    throw new ArgumentException("Invalid publication year. Please enter an integer.");
                }
                bookToEdit.Publication_Year = publicationYear;

                Console.Write("Cost Price: ");
                if (!int.TryParse(Console.ReadLine(), out int costPrice))
                {
                    throw new ArgumentException("Invalid cost price. Please enter a number.");
                }
                bookToEdit.Cost_Price = costPrice;

                Console.Write("Selling Price: ");
                if (!int.TryParse(Console.ReadLine(), out int sellingPrice))
                {
                    throw new ArgumentException("Invalid selling price. Please enter a number.");
                }
                bookToEdit.Selling_Price = sellingPrice;

                Console.Write("Continuation (yes/no): ");
                bookToEdit.Continuation = Console.ReadLine().ToLower() == "yes";

                Console.WriteLine("Book successfully updated!");
                Console.WriteLine();

                return books;
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while editing the book: " + ex.Message);
                return books;
            }
        }

        public static List<LibraryBook> SellBook(List<LibraryBook> books)
        {
            try
            {
                Console.WriteLine("Enter the Book ID you want to sell:");
                int bookIdToSell = int.Parse(Console.ReadLine());

                LibraryBook bookToSell = books.FirstOrDefault(b => b.Book_Id == bookIdToSell);

                if (bookToSell != null)
                {
                    bookToSell.SellBook = true;
                    Console.WriteLine("Book with ID " + bookIdToSell + " marked as sold!");
                }
                else
                {
                    Console.WriteLine("Book with ID " + bookIdToSell + " not found in the library.");
                }

                return books;
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while marking the book as sold: " + ex.Message);
                return books;
            }
        }
        public static List<LibraryBook> WriteOffBook(List<LibraryBook> books)
        {
            try
            {
                Console.WriteLine("Enter the Book ID you want to write off:");
                int bookIdToWriteOff = int.Parse(Console.ReadLine());

                LibraryBook bookToWriteOff = books.FirstOrDefault(b => b.Book_Id == bookIdToWriteOff);

                if (bookToWriteOff != null)
                {
                    bookToWriteOff.Writeoffbook = true;
                    Console.WriteLine("Book with ID " + bookIdToWriteOff + " marked as written off!");
                }
                else
                {
                    Console.WriteLine("Book with ID " + bookIdToWriteOff + " not found in the library.");
                }

                return books;
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while marking the book as written off: " + ex.Message);
                return books;
            }
        }
        public static List<LibraryBook> PutBookAside(List<LibraryBook> books)
        {
            try
            {
                Console.WriteLine("Enter the Book ID you want to put aside for a specific customer:");
                int bookIdToPutAside = int.Parse(Console.ReadLine());

                LibraryBook bookToPutAside = books.FirstOrDefault(b => b.Book_Id == bookIdToPutAside);

                if (bookToPutAside != null)
                {
                    bookToPutAside.Aside = true;
                    Console.WriteLine($"Book with ID {bookIdToPutAside} successfully put aside.");
                }
                else
                {
                    Console.WriteLine($"Book with ID {bookIdToPutAside} not found in the library.");
                }

                return books;
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while putting the book aside: " + ex.Message);
                return books;
            }
        }
        public static List<LibraryBook> ContributeBook(List<LibraryBook> books)
        {
            try
            {
                Console.WriteLine("Enter the Book ID you want to contribute to promotion:");
                int bookIdToContribute = int.Parse(Console.ReadLine());

                LibraryBook bookToContribute = books.FirstOrDefault(b => b.Book_Id == bookIdToContribute);

                if (bookToContribute != null)
                {
                    // Update the book information to mark it as contributed to promotion
                    bookToContribute.ContributeBook = true;

                    Console.WriteLine($"Book with ID {bookIdToContribute} successfully contributed to promotion.");
                }
                else
                {
                    Console.WriteLine($"Book with ID {bookIdToContribute} not found in the library.");
                }

                return books;
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while contributing the book to promotion: " + ex.Message);
                return books;
            }
        }
    }
}
