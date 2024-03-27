using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trader.API.Services;

namespace TraderWpf.ViewModels
{
     public class HomeViewModel:ViewModelBase
    {
        public MajorIndexViewModel viewModel { get; set; }
        public HomeViewModel(MajorIndexViewModel viewModel)
        {
            this.viewModel = viewModel;
        }
    }
}
