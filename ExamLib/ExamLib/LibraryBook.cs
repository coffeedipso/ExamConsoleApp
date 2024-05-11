using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace ExamLib
{
    internal class LibraryBook
    {
        public int Book_Id {  get; set; }
        public string Title { get; set; }
        public string Author_FirstName {  get; set; }
        public string Author_SecondName { get; set; }
        public string Author_SurName { get; set; }
        public string Publisher {get; set; }
        public int Page_Count { get; set; }
        public string  Genre {  get; set; }
        public int Publication_Year {  get; set; }
        public int Cost_Price { get; set; }
        public int Selling_Price { get; set; }
        public bool Continuation {  get; set; }

        public bool SellBook { get; set; }

        public bool Writeoffbook { get; set; }
        public bool ContributeBook { get; set;}
        public bool Aside {  get; set; }

    }
}
