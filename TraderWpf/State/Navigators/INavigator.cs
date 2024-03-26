using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TraderWpf.ViewModels;

namespace TraderWpf.State.Navigators
{
    public enum ViewType
    {
        Home,
        Portfolio,
        Buy,
    }
    public interface INavigator
    {
       
        ViewModelBase CurrentViewModel { get; set; }
        ICommand UpdateCurrentViewModelCommand { get; }



    }
}
