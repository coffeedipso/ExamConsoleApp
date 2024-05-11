using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamLib
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string _connectionStr = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=LibraryBook;Integrated Security=SSPI";
            DbConnection _db = new SqlConnection(_connectionStr);
            var book = new ExamLibREP(_connectionStr);
            var bookList = book.GetBooks(_db);
            ActionsWithBooks.PrintBookList(bookList);
            MenuForBooks.Menu(_db);
            Console.ReadKey();
        }
    }
}
