using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TraderWpf.State.Navigators;
using TraderWpf.ViewModels;
using static TraderWpf.State.Navigators.INavigator;

namespace TraderWpf.Commands
{
    public class UpdateViewModelCommand : ICommand
    {
        private readonly INavigator navigator;
        public event EventHandler? CanExecuteChanged;

        public UpdateViewModelCommand(INavigator navigator)
        {
            this.navigator = navigator;
        }

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            if(parameter is ViewType)
            {
                ViewType viewType = (ViewType)parameter;
                navigator.CurrentViewModel = viewType switch
                {
                    ViewType.Home => new HomeViewModel(),
                    ViewType.Portfolio => new PortfolioViewModel(),
                    ViewType.Buy => new BuyViewModel(),
                    _ => throw new NotImplementedException(),
                };
            }
        }
    }
}
