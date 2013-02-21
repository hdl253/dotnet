using Papa.Common;

namespace BookShelf
{
    public class Error : NotifiableObject
    {
        private string _description;
        private string _title;

        public string Description
        {
            get { return _description; }
            set
            {
                _description = value;
                RaisePropertyChanged("Description");
            }
        }

        public string Title
        {
            get { return _title; }
            set
            {
                _title = value;
                RaisePropertyChanged("Title");
            }
        }
    }
}
