using System;
using System.Collections.Generic;
using System.Numerics;
namespace Day4Task
{

    public class Program
    {
        public static void Main()
        {
            var books = new List<Book>
            {
                new Book("123", "C#", new[] {"O"}, new DateTime(2024, 12, 25), 2),
                new Book("321", "C++", new[] {"T"}, new DateTime(2024, 12, 25), 1)
            };


            #region Delegate
            ////1
            //listDel del;
            ////2
            //del = Conditions.Even;
            ////3
            ////del = Conditions.Odd;
            ////del = Conditions.DivideBy5;
            //Conditions o = new Conditions();
            //del = o.DivideBy7;
            //Predicate<int> del;
            //del = Conditions.Even;
            //Func<int, bool> delv02 = Conditions.Odd;
            //List<int> res = ListOperations.Filter(list, i => i % 4 == 0);
            //foreach (int i in res)
            //{
            //    Console.WriteLine(i);
            //}
            #endregion

            Func<Book, string> fPtr = BookFunctions.GetTitle;
            Console.WriteLine("========Delegate========");
            LibraryEngine.ProcessBooks(books, fPtr);

            #region BCLDelegates
            //BCL Delegates
            //Action => return void (17 input param)
            //Predicate => return bool (T one param)
            //Func => return T (17 input para)
            #endregion

            fPtr = BookFunctions.GetAuthors;
            Console.WriteLine("\n========Using BCL Delegate========");
            LibraryEngine.ProcessBooks(books, fPtr);

            #region AnonymousFunction
            //anonFunction
            // listDel delV2 = delegate (int i) { return i % 3 == 0; };
            #endregion

            fPtr = delegate (Book book) { return $"ISBN: {book.ISBN}"; };
            Console.WriteLine("\n========Using Anonymous Method========");
            LibraryEngine.ProcessBooks(books, fPtr);


            #region LambdaExp
            //Lambda Exp
            //listDel delV3 =  i=> i % 3 == 0;
            #endregion

            fPtr = B => $"Publication Date: {B.PublicationDate:yyyy-MM-dd}";
            Console.WriteLine("\n========Using Lambda Expression========");
            LibraryEngine.ProcessBooks(books, fPtr);
        }
    }
}