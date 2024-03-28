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
        public MajorIndexListingViewModel majorIndexListingViewModel { get; set; }
        public HomeViewModel(MajorIndexListingViewModel viewModel)
        {
            this.majorIndexListingViewModel = viewModel;
        }
    }
}
