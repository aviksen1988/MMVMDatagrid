using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace WpfDatagridMVVM
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        #region Private Members

        private ObservableCollection<MainWindowModel> gridSource = new ObservableCollection<MainWindowModel>();
        private bool isChecked = false;
        private string _firstName = "A2";
        private string _lastName = "B2";

        #endregion

        #region Public Properties

        public bool IsChecked
        {
            get { return isChecked; }
            set
            {
                isChecked = value;
                NotifyPropertyChanged("IsChecked");
            }
        }

        public ObservableCollection<MainWindowModel> GridSource
        {
            get { return gridSource; }
            set { gridSource = value; }
        }

        public string FirstName
        {
            get { return _firstName; }
            set
            {
                _firstName = value;
                NotifyPropertyChanged("FirstName");
            }
        }

        public string LastName
        {
            get { return _lastName; }
            set
            {
                _lastName = value;
                NotifyPropertyChanged("FirstName");
            }
        }

        #endregion 

        #region Constructor

        public MainWindowViewModel()
        {
            var model = new MainWindowModel
            {
                FirstName = "A1",
                LastName = "B1"
            };

            GridSource.Add(model);
            _canExecute = true;
        }

        #endregion

        #region ICommand Members

        private ICommand _clickCommand;
        public ICommand ClickCommand
        {
            get
            {
                return _clickCommand ?? (_clickCommand = new CommandHandler(() => MyAction(), _canExecute));
            }
        }
        private bool _canExecute;
        public void MyAction()
        {
            var source = new MainWindowModel
            {
                FirstName = FirstName,
                LastName = LastName
            };

            GridSource.Add(source);
        }

        #endregion
        
        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(String info)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }
        #endregion
    }
}
