using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ExamLib.ActionsWithBooks;

/* 
 Приложение должно позволять: 
добавлять книги,
удалять книги, 
редак-тировать параметры книг,
продавать книги, списывать книги,
вносить книги в акции (например, неделя книг новогодней тематики со скидкой 10%), 
от-кладывать книги для конкретного покупателя. 
/
Приложение должно предоставить функциональность по поиску книг по таким параметрам:
название книги, автор, жанр. 
Приложение должно предо-ставлять возможность просмотреть список новинок, 
список самых прода-ваемых книг, список самых популярных авторов,
список самых популярных жанров по итогам дня, недели, месяца, года. 
Необходимо предусмотреть возможность входа по логину и паролю.
 */


namespace ExamLib
{
    internal class MenuForBooks
    {
        private static List<LibraryBook> books;
        private static ExamLibREP rep = new ExamLibREP();
        private static string connectionSTR = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=LibraryBook;Integrated Security=SSPI";
        private static DbConnection _db = new SqlConnection(connectionSTR);


        public static void Menu(IDbConnection connection)
        {
            if (books == null)
            {
                books = rep.GetBooks(_db);
            }

            Console.WriteLine("1 - Add book");
            Console.WriteLine("2 - Delete book");
            Console.WriteLine("3 - Edit book");
            Console.WriteLine("4 - Sell book"); //продавать книгу
            Console.WriteLine("5 - Write off book"); //списать книгу
            Console.WriteLine("6 - Contribute book"); //вносить книгу в акции
            Console.WriteLine("7 - Put the book aside"); // откладывать книгу для конкретного покупателя
            Console.WriteLine("8 - Show books");
            Console.WriteLine("9 - Filters");
            Console.WriteLine("10 - Exit");

            long userChoice = Int64.Parse(Console.ReadLine());
            switch (userChoice)
            {
                case 1:
                    books = ActionsWithBooks.AddBook(books);
                    Menu(connection);
                    break;
                case 2:
                    books = ActionsWithBooks.DeleteBookById(books);
                    Menu(connection);
                    break;
                case 3:
                    books=ActionsWithBooks.EditBook(books);
                    Menu(connection);
                    break;
                case 4:
                    books = ActionsWithBooks.SellBook(books);
                    Menu(connection);
                    break;
                case 5:
                    books = ActionsWithBooks.WriteOffBook(books);
                    Menu(connection);
                    break;
                case 6:
                    ActionsWithBooks.ContributeBook(books);
                    Menu(connection);
                    break;
                case 7:
                    books = ActionsWithBooks.PutBookAside(books);
                    Menu(connection);
                    break;
                case 8:
                    ActionsWithBooks.PrintBookList(books);
                    Menu(connection);
                    break;
                case 9:
                    break;
                case 10:
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please select a valid option.");
                    break;
            }
        }
        public static IDbConnection GetConnection()
        {
            return _db;
        }
    }
}
