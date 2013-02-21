using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using BookShelf.Web.Models;
using Papa.Common;
using Ria.Common;

namespace BookShelf
{
    public class CheckoutViewModel : ViewModel
    {
        protected IPageConductor PageConductor { get; set; }
        protected IBookDataService BookDataService { get; set; }

        public CheckoutViewModel(
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
            }
        }

        protected override void RegisterCommands()
        {
        }

        public override void LoadData()
        {
            LoadCheckouts();
        }

        private void LoadCheckouts()
        {
            Checkouts = null;
            BookDataService.LoadCheckouts(GetCheckoutsCallback, null);
        }

        private void GetCheckoutsCallback(ServiceLoadResult<Checkout> result)
        {
            if (result.Error != null)
            {
                // handle error
            }
            else if (!result.Cancelled)
            {
                this.Checkouts = result.Entities;
                this.SelectedCheckout = this.Checkouts.FirstOrDefault();
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

        private IEnumerable<Checkout> _checkouts;
        public IEnumerable<Checkout> Checkouts
        {
            get { return _checkouts; }
            set
            {
                _checkouts = value;
                RaisePropertyChanged("Checkouts");
            }
        }

        private Checkout _selectedCheckout;
        public Checkout SelectedCheckout
        {
            get { return _selectedCheckout; }
            set
            {
                _selectedCheckout = value;
                RaisePropertyChanged("SelectedCheckout");
            }
        }
    }
}