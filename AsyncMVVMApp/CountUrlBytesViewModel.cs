using AsyncMVVMApp.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AsyncMVVMApp
{
    public sealed class CountUrlBytesViewModel
    {
        public CountUrlBytesViewModel(MainWindowViewModel parent, string url,
          AsyncCommand<int> command)
        {
            LoadingMessage = "Loading (" + url + ")...";
            Command = command;
            RemoveCommand = new DelegateCommand(() => parent.Operations.Remove(this));
        }

        public string LoadingMessage { get; private set; }

        public AsyncCommand<int> Command { get; private set; }

        public ICommand RemoveCommand { get; private set; }
    }
}
