using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using BookShelf.Web.Models;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using Microsoft.Windows.Data.DomainServices;
using Papa.Common;
using Ria.Common;

namespace BookShelf
{
    public class BookViewModel : ViewModel
    {
        private const int _pageSize = 10;

        private int _pageIndex;

        protected IPageConductor PageConductor { get; set; }
        protected IBookDataService BookDataService { get; set; }

        public RelayCommand ClearFilterCommand { get; set; }
        public RelayCommand EditBookCommand { get; set; }
        public RelayCommand LoadMoreBooksCommand { get; set; }
        public RelayCommand SaveBooksCommand { get; set; }
        public RelayCommand SearchBooksCommand { get; set; }
        public RelayCommand SelectCategoryCommand { get; set; }

        public BookViewModel(
            IPageConductor pageConductor,
            IBookDataService bookDataService)
        {
            PageConductor = pageConductor;
            BookDataService = bookDataService;
            BookDataService.EntityContainer.PropertyChanged += BookDataService_PropertyChanged;

            RegisterCommands();
            LoadData();
        }

        private void BookDataService_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "HasChanges")
            {
                HasChanges = BookDataService.EntityContainer.HasChanges;
                SaveBooksCommand.RaiseCanExecuteChanged();
            }
        }

        protected override void RegisterCommands()
        {
            ClearFilterCommand = new RelayCommand(OnClearFilter);
            EditBookCommand = new RelayCommand(OnEditBook);
            LoadMoreBooksCommand = new RelayCommand(OnLoadMoreBooksByCategory);
            SaveBooksCommand = new RelayCommand(OnSaveBooks, () => HasChanges);
            SearchBooksCommand = new RelayCommand(OnSearchBooks);
            SelectCategoryCommand = new RelayCommand(OnSelectCategory);
        }

        public override void LoadData()
        {
            LoadBookOfDays();
            LoadCategories();
        }

        private void OnClearFilter()
        {
            TitleFilter = string.Empty;
            LoadBooksByCategory();
        }

        private void OnEditBook()
        {
            Messenger.Default.Send(new LaunchEditBookMessage() { Book = SelectedBook });
        }

        private void OnSaveBooks()
        {
            BookDataService.SubmitChanges(SaveBooksCallback, null);
        }

        private void SaveBooksCallback(ServiceSubmitChangesResult result)
        {
            string msg = (result.Error != null) ? "Save was unsuccessful" : "Save was successful";
            var dialogMessage = new SavedBookDialogMessage(msg, "Save");
            Messenger.Default.Send(dialogMessage);
        }

        private void OnSearchBooks()
        {
            if (!string.IsNullOrEmpty(TitleFilter))
            {
                LoadBooksByTitle();
            }
        }

        private void OnSelectCategory()
        {
            if (SelectedCategory != null)
            {
                LoadBooksByCategory();
            }
        }

        public void LoadBookOfDays()
        {
            BooksOfTheDay = null;
            BookDataService.LoadBooksOfTheDay(LoadBooksOfTheDayCallback, null);
        }

        private void LoadBooksOfTheDayCallback(ServiceLoadResult<BookOfDay> result)
        {
            if (result.Error != null)
            {
                // handle error
            }
            else if (!result.Cancelled)
            {
                this.BooksOfTheDay = result.Entities;
            }
        }

        public void LoadCategories()
        {
            Categories = null;
            BookDataService.LoadCategories(LoadCategoriesCallback, null);
        }

        private void LoadCategoriesCallback(ServiceLoadResult<Category> result)
        {
            if (result.Error != null)
            {
                // handle error
            }
            else if (!result.Cancelled)
            {
                this.Categories = result.Entities;
                this.SelectedCategory = Categories.FirstOrDefault();
                LoadBooksByCategory();
            }
        }

        public void LoadBooksByCategory()
        {
            _pageIndex = 0;
            Books = null;
            if (SelectedCategory != null)
            {
                BookDataService.LoadBooksByCategory(
                    SelectedCategory.CategoryID,
                    new QueryBuilder<Book>().Take(_pageSize),
                    LoadBooksCallback,
                    null);
            }
        }

        private void OnLoadMoreBooksByCategory()
        {
            if (SelectedCategory != null)
            {
                _pageIndex++;
                BookDataService.LoadBooksByCategory(
                    SelectedCategory.CategoryID,
                    new QueryBuilder<Book>().Skip(_pageIndex * _pageSize).Take(_pageSize),
                    LoadBooksCallback,
                    null);
            }
        }

        public void LoadBooksByTitle()
        {
            _pageIndex = 0;
            Books = null;
            if (SelectedCategory != null)
            {
                BookDataService.LoadBooksByCategory(
                    SelectedCategory.CategoryID,
                    new QueryBuilder<Book>().Where(b => b.Title.Contains(TitleFilter)),
                    LoadBooksCallback,
                    null);
            }
        }

        private void LoadBooksCallback(ServiceLoadResult<Book> result)
        {
            if (result.Error != null)
            {
                // handle error
            }
            else if (!result.Cancelled)
            {
                if (Books == null)
                {
                    Books = result.Entities as ICollection<Book>;
                }
                else
                {
                    foreach (var book in result.Entities)
                    {
                        Books.Add(book);
                    }
                }

                SelectedBook = Books.FirstOrDefault();
            }
        }

        private ICollection<Book> _books;
        public ICollection<Book> Books
        {
            get { return _books; }
            set
            {
                _books = value;
                RaisePropertyChanged("Books");
            }
        }

        private IEnumerable<BookOfDay> _booksOfTheDay;
        public IEnumerable<BookOfDay> BooksOfTheDay
        {
            get { return _booksOfTheDay; }
            set
            {
                _booksOfTheDay = value;
                RaisePropertyChanged("BooksOfTheDay");
            }
        }

        private IEnumerable<Category> _categories;
        public IEnumerable<Category> Categories
        {
            get { return _categories; }
            set
            {
                _categories = value;
                RaisePropertyChanged("Categories");
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
    }
}