namespace BookShelf.Web.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.Data.Objects.DataClasses;
    using System.Linq;
    using System.ServiceModel.DomainServices.Hosting;
    using System.ServiceModel.DomainServices.Server;


    // The MetadataTypeAttribute identifies BookMetadata as the class
    // that carries additional metadata for the Book class.
    [MetadataTypeAttribute(typeof(Book.BookMetadata))]
    public partial class Book
    {

        // This class allows you to attach custom attributes to properties
        // of the Book class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class BookMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private BookMetadata()
            {
            }

            public DateTime AddedDate { get; set; }

            public string ASIN { get; set; }

            public string Author { get; set; }

            public int BookID { get; set; }

            public EntityCollection<BookOfDay> BookOfDays { get; set; }

            [Include]
            public Category Category { get; set; }

            public int CategoryID { get; set; }

            public EntityCollection<Checkout> Checkouts { get; set; }

            public string Description { get; set; }

            public Member Member { get; set; }

            public int MemberID { get; set; }

            public DateTime PublishDate { get; set; }

            public EntityCollection<Request> Requests { get; set; }

            public string Title { get; set; }
        }
    }

    // The MetadataTypeAttribute identifies BookOfDayMetadata as the class
    // that carries additional metadata for the BookOfDay class.
    [MetadataTypeAttribute(typeof(BookOfDay.BookOfDayMetadata))]
    public partial class BookOfDay
    {

        // This class allows you to attach custom attributes to properties
        // of the BookOfDay class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class BookOfDayMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private BookOfDayMetadata()
            {
            }


            //TODO - Include the book for the object graph
            [Include]
            public Book Book { get; set; }

            public int BookID { get; set; }

            public DateTime Day { get; set; }
        }
    }

    // The MetadataTypeAttribute identifies CategoryMetadata as the class
    // that carries additional metadata for the Category class.
    [MetadataTypeAttribute(typeof(Category.CategoryMetadata))]
    public partial class Category
    {

        // This class allows you to attach custom attributes to properties
        // of the Category class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class CategoryMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private CategoryMetadata()
            {
            }

            public EntityCollection<Book> Books { get; set; }

            public int CategoryID { get; set; }

            public string CategoryName { get; set; }
        }
    }

    // The MetadataTypeAttribute identifies CheckoutMetadata as the class
    // that carries additional metadata for the Checkout class.
    [MetadataTypeAttribute(typeof(Checkout.CheckoutMetadata))]
    public partial class Checkout
    {

        // This class allows you to attach custom attributes to properties
        // of the Checkout class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class CheckoutMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private CheckoutMetadata()
            {
            }

            //TODO - Include the book for the object graph
            [Include]
            public Book Book { get; set; }

            public int BookID { get; set; }

            public DateTime CheckoutDate { get; set; }

            public int CheckoutID { get; set; }

            //TODO - Include the book for the object graph
            [Include]
            public Member Member { get; set; }

            public int MemberID { get; set; }

            public EntityCollection<Request> Requests { get; set; }

            public bool Returned { get; set; }
        }
    }

    // The MetadataTypeAttribute identifies MemberMetadata as the class
    // that carries additional metadata for the Member class.
    [MetadataTypeAttribute(typeof(Member.MemberMetadata))]
    public partial class Member
    {

        // This class allows you to attach custom attributes to properties
        // of the Member class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class MemberMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private MemberMetadata()
            {
            }

            public EntityCollection<Book> Books { get; set; }

            public EntityCollection<Checkout> Checkouts { get; set; }

            public DateTime JoinDate { get; set; }

            public DateTime LoginDate { get; set; }

            public string MemberAlias { get; set; }

            public int MemberID { get; set; }

            public string MemberName { get; set; }

            public string MemberOffice { get; set; }

            public string Password { get; set; }

            public EntityCollection<Request> Requests { get; set; }
        }
    }
}
