using System.Collections.Generic;
using System.ServiceModel.DomainServices.Client;
using BookShelf.Web.Models;
using System.Collections.ObjectModel;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using Papa.Common;

namespace BookShelf.Old
{
    public class BookViewModel : ViewModel
    {
        private const int _pageSize = 10;
        protected IPageConductor PageConductor { get; set; }
        protected IBookDataService BookDataService { get; set; }

        public RelayCommand ClearFilterCommand { get; set; }
        public RelayCommand SearchBooksCommand { get; set; }
        public RelayCommand LoadMoreBooksCommand { get; set; }
        public RelayCommand SelectCategoryCommand { get; set; }
        public RelayCommand EditBookCommand { get; set; }
        public RelayCommand SaveBooksCommand { get; set; }

        public BookViewModel(
            IPageConductor pageConductor,
            IBookDataService bookDataService)
        {
            PageConductor = pageConductor;
            BookDataService = bookDataService;
            BookDataService.NotifyHasChanges += BookDataService_NotifyHasChanges;

            //InitializeModels();
            RegisterCommands();
            LoadData();
        }

        private void BookDataService_NotifyHasChanges(object sender, HasChangesEventArgs e)
        {
            HasChanges = e.HasChanges;
            SaveBooksCommand.RaiseCanExecuteChanged();
        }

        protected override void RegisterCommands()
        {
            ClearFilterCommand = new RelayCommand(OnClearFilter);
            SearchBooksCommand = new RelayCommand(OnSearchBooks);
            LoadMoreBooksCommand = new RelayCommand(OnLoadMoreBooks);
            SelectCategoryCommand = new RelayCommand(OnSelectCategory);
            EditBookCommand = new RelayCommand(OnEditBook);
            SaveBooksCommand = new RelayCommand(OnSaveBooks, () => HasChanges);
        }

        private void OnSaveBooks()
        {
            BookDataService.Save(SaveBooksCallback, null);
        }

        private void SaveBooksCallback(SubmitOperation op)
        {
            string msg = op.HasError ? "Save was unsuccessful" : "Save was successful";
            var dialogMessage = new SavedBookDialogMessage(msg, "Save");
            Messenger.Default.Send(dialogMessage);
        }

        public override void LoadData()
        {
            LoadBookOfDays();
            LoadCategories();
        }

        private void OnSelectCategory()
        {
            if (SelectedCategory != null)
            {
                LoadBooksByCategory();
            }
        }

        private void OnClearFilter()
        {
            TitleFilter = string.Empty;
            LoadBooksByCategory();
        }

        private void OnSearchBooks()
        {
            if (!string.IsNullOrEmpty(TitleFilter))
            {
                LoadBooksByTitle();
            }
        }

        //private void InitializeModels()
        //{
        //    Categories = new ObservableCollection<Category>();
        //    Books = new ObservableCollection<Book>();
        //    BooksOfTheDay = new ObservableCollection<BookOfDay>();
        //    SelectedBook = new Book();
        //}

        public void LoadBookOfDays()
        {
            //BooksOfTheDay.Clear();
            BooksOfTheDay = null;
            BookDataService.GetBooksOfTheDay(GetBooksOfTheDayCallback);
        }

        //private void GetBooksOfTheDayCallback(IEnumerable<BookOfDay> booksOfDay)
        private void GetBooksOfTheDayCallback(ObservableCollection<BookOfDay> booksOfDay)
        {
            if (booksOfDay != null)
            {
                //foreach (var bookOfDay in booksOfDay)
                //{
                //    BooksOfTheDay.Add(bookOfDay);
                //}
                this.BooksOfTheDay = booksOfDay;
            }
        }

        public void LoadCategories()
        {
            //Categories.Clear();
            Categories = null;
            BookDataService.GetCategories(GetCategoriesCallback);
        }

        private void GetCategoriesCallback(ObservableCollection<Category> categories)
        {
            if (categories != null)
            {
                this.Categories = categories;
                if (Categories.Count > 0)
                {
                    SelectedCategory = Categories[0];
                }
                LoadBooksByCategory();
            }
        }

        private void OnLoadMoreBooks()
        {
            if (SelectedCategory != null)
                BookDataService.GetMoreBooksByCategory(GetBooksCallback, SelectedCategory.CategoryID, _pageSize);
        }

        public void LoadBooksByCategory()
        {
            //Books.Clear();
            Books = null;
            if (SelectedCategory != null)
                BookDataService.GetBooksByCategory(GetBooksCallback, SelectedCategory.CategoryID, _pageSize);
        }

        public void LoadBooksByTitle()
        {
            //Books.Clear();
            Books = null;
            if (SelectedCategory != null)
                BookDataService.GetBooksByTitle(GetBooksCallback, SelectedCategory.CategoryID, TitleFilter);
        }

        private void GetBooksCallback(ObservableCollection<Book> books)
        {
            if (books != null)
            {
                if (Books == null)
                {
                    Books = books;
                }
                else
                {
                    foreach (var book in books)
                    {
                        Books.Add(book);
                    }
                }

                if (Books.Count > 0)
                {
                    SelectedBook = Books[0];
                }

            }
        }

        private bool _hasChanges;
        public bool HasChanges
        {
            get { return _hasChanges; }
            set
            {
                _hasChanges = value;
                RaisePropertyChanged("HasChanges");
            }
        }

        private ObservableCollection<Book> _books;
        public ObservableCollection<Book> Books
        {
            get { return _books; }
            set
            {
                _books = value;
                RaisePropertyChanged("Books");
            }
        }

        private ObservableCollection<Category> _categories;
        public ObservableCollection<Category> Categories
        {
            get { return _categories; }
            set
            {
                _categories = value;
                RaisePropertyChanged("Categories");
            }
        }

        private ObservableCollection<BookOfDay> _booksOfTheDay;
        public ObservableCollection<BookOfDay> BooksOfTheDay
        {
            get { return _booksOfTheDay; }
            set
            {
                _booksOfTheDay = value;
                RaisePropertyChanged("BooksOfTheDay");
            }
        }

        private Category _selectedCategory;
        public Category SelectedCategory
        {
            get { return _selectedCategory; }
            set
            {
                _selectedCategory = value;
                RaisePropertyChanged("SelectedCategory");
            }
        }

        private Book _selectedBook;
        public Book SelectedBook
        {
            get { return _selectedBook; }
            set
            {
                _selectedBook = value;
                RaisePropertyChanged("SelectedBook");
            }
        }

        private string _titleFilter;
        public string TitleFilter
        {
            get { return _titleFilter; }
            set
            {
                _titleFilter = value;
                RaisePropertyChanged("TitleFilter");
            }
        }

        private void OnEditBook()
        {
            Messenger.Default.Send(new LaunchEditBookMessage() { Book = SelectedBook });
        }
    }
}