using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TraderWpf.Commands;
using TraderWpf.Models;
using TraderWpf.ViewModels;

namespace TraderWpf.State.Navigators
{
    public class Navigator : ObservableObject ,INavigator
    {
        private ViewModelBase currentViewModel;
        public ViewModelBase CurrentViewModel
        {
            get => currentViewModel;
            set
            {
                currentViewModel = value;
                OnPropertyChanged(nameof(CurrentViewModel));
                
            }
        }

        public ICommand UpdateCurrentViewModelCommand => new UpdateViewModelCommand(this);

       
    }
}
