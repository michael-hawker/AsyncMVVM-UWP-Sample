using AsyncMVVMApp.Helpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AsyncMVVMApp
{
    public sealed class MainWindowViewModel : INotifyPropertyChanged
    {
        public MainWindowViewModel()
        {
            Url = "http://www.bing.com/";
            Operations = new ObservableCollection<CountUrlBytesViewModel>();
            CountUrlBytesCommand = new DelegateCommand(() =>
            {
                var countBytes = new AsyncCommand<int>(token =>
                  MyStaticService.DownloadAndCountBytesAsync(
                  Url, token));

                countBytes.Execute(null);
                Operations.Add(new CountUrlBytesViewModel(this, Url, countBytes));
            });
        }

        private string _url;
        public string Url
        {
            get { return _url; }
            set
            {
                _url = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<CountUrlBytesViewModel> Operations
        { get; private set; }

        public ICommand CountUrlBytesCommand { get; private set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
