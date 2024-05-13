using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Policy;
using Dapper;
using System.Data.Common;
namespace ExamLib
{
    internal class ExamLibREP
    {
        private readonly DbConnection _db;
        public ExamLibREP(string connectionStr)
        {
            if (string.IsNullOrEmpty(connectionStr)) throw new ArgumentNullException(nameof(connectionStr));
            _db = new SqlConnection(connectionStr);
            var employees = GetBooks(_db);
            //PrintBookList(employees);
        }

        public ExamLibREP()
        {
        }

        public  List<LibraryBook> GetBooks(IDbConnection connection)
        {
            var books = new List<LibraryBook>();
            try
            {
                books = connection.Query<LibraryBook>(
                    @"SELECT Book_Id,Title, Author_FirstName, Author_SecondName,Author_SurName, Publisher, Page_Count, Genre, Publication_Year, Cost_Price, Selling_Price, Continuation,SellBook,Writeoffbook,ContributeBook,Aside
              FROM BooksMain;")
                    .Select(e => new LibraryBook
                    {
                        Book_Id = e.Book_Id,
                        Title=e.Title,
                        Author_FirstName = e.Author_FirstName,
                        Author_SecondName = e.Author_SecondName,
                        Author_SurName=e.Author_SurName,
                        Publisher = e.Publisher,
                        Page_Count = e.Page_Count,
                        Genre = e.Genre,
                        Publication_Year = e.Publication_Year,
                        Cost_Price = e.Cost_Price,
                        Selling_Price = e.Selling_Price,
                        Continuation = e.Continuation,
                        SellBook=e.SellBook,
                        Writeoffbook=e.Writeoffbook,
                        ContributeBook=e.ContributeBook,
                        Aside=e.Aside,
                    }).ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Произошла ошибка при получении списка книг: " + ex.Message);
            }

            return books;
        }
        public void Dispose()
        {
            _db?.Close();
        }
        //private async Task OpenAsync()
        //{
        //    await _db.OpenAsync().ConfigureAwait(false);
        //}
    }
}