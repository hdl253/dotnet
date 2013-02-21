using System;
using System.Collections.ObjectModel;
using BookShelf.Web.Models;

namespace BookShelf
{
    public class DesignBooks : ObservableCollection<Book>
    {
        private Category _designCategory;
        public DesignBooks()
        {
            _designCategory = new DesignCategories()[0];

            for (int i = 0; i < 20; i++)
            {
                Add(CreateDesignBook(i));
            }
        }

        private Book CreateDesignBook(int i)
        {
            var book = new Book(){
                                 AddedDate = new DateTime(2005, 3, 3),
                                 ASIN = "0596523092",
                                 ImageSource = "/Assets/0596523092.jpg",
                                 Author = "John Smith",
                                 BookID = 123,
                                 Category = _designCategory,
                                 //CategoryID = 1,
                                 //Checkouts = 
                                 Description = "The best book ever created by man! Don't believe me? Well, ask anyone. Seriously. Once you pick it up, you won't be able to put it down.",
                                 //Member = 
                                 MemberID = 2,
                                 PublishDate = new DateTime(2001, 11, 3),
                                 Title = "Contoso Adventures",
                             };
            return book;
        }

    }
}