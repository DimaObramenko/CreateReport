using MaterialTestTracker.Commands;
using MaterialTestTracker.Model;
using MaterialTestTracker.Services;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MaterialTestTracker.ViewModel
{
   public class MainInfoOfReportViewModel : INotifyPropertyChanged
    {
        public MainInfoOfReportViewModel(IDialogService dialogService)
        {
            Report = new MainInfoOfReportModel();
            _dialogService = dialogService;
            Report.Date = DateTime.Now;
        }

        private readonly IDialogService _dialogService;

        #region fields from view
        public string FirstAndSecondName
        {
            get { return Report.FirstAndSecondName; }
            set
            {
                Report.FirstAndSecondName = value;
                OnPropertyChanged("FirstAndSecondName");
            }
        }
        public string ProtocolNumber
        {
            get { return Report.ProtocolNumber; }
            set
            {
                Report.ProtocolNumber = value;
                OnPropertyChanged("ProtocolNumber");
            }
        }

        public string Material
        {
            get { return Report.Material; }
            set
            {
                Report.Material = value;
                OnPropertyChanged("Material");
            }
        }

        public string Indicators
        {
            get { return Report.Indicators; }
            set
            {
                Report.Indicators = value;
                OnPropertyChanged("Indicators");
            }
        }

        public string Customer
        {
            get { return Report.Customer; }
            set
            {
                Report.Customer = value;
                OnPropertyChanged("Customer");
            }
        }

        public string NumberOfContractWithCustomer
        {
            get { return Report.NumberOfContractWithCustomer; }
            set
            {
                Report.NumberOfContractWithCustomer = value;
                OnPropertyChanged("NumberOfContractWithCustomer");
            }
        }

        public DateTime Date
        {
            get { return Report.Date; }
            set
            {
                Report.Date = value;
                OnPropertyChanged("Date");
            }
        }

        #endregion

        private RelayCommand _nextButtonCommand;

        public RelayCommand NextButton
        {
            get
            {
                return _nextButtonCommand ??
                       (_nextButtonCommand = new RelayCommand(obj =>
                       {
                           try
                           {
                               DataBaseHelper dbHelper = new DataBaseHelper();
                               dbHelper.InputData(Report);

                               WordHelper wordHelper = new WordHelper();
                               wordHelper.Formation(dbHelper.GetData(Report));
                           }
                           catch (Exception ex)
                           {
                               _dialogService.ShowMessage(ex.Message);
                           }
                       }));
            }
        }

        public MainInfoOfReportModel Report { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
