using System;

namespace BookShelf.Web.Models
{
    public partial class Book
    {
        private string _imageSource;
        public string ImageSource
        {
            get
            {
                if (string.IsNullOrEmpty(_imageSource))
                {
                    const string format = "/Assets/Images/{0}.jpg";
                    return String.Format(format, ASIN);
                }
                else
                {
                    return _imageSource;
                }
                
            }
            set { _imageSource = value; }
        }


        //public override string ToString()
        //{
        //    return this.Title + " by " + this.Author;
        //}
    }

    //public partial class Category
    //{
    //    public override string ToString()
    //    {
    //        return this.CategoryName;
    //    }
    //}

    //public partial class BookOfDay
    //{
    //    public override string ToString()
    //    {
    //        return this.Book.Title;
    //    }
    //}
}