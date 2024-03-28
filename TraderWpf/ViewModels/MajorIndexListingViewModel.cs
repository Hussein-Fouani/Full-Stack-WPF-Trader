using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trader.API.Services;
using Trader.Domain.Models;
using Trader.Domain.Services;

namespace TraderWpf.ViewModels
{
    public class MajorIndexListingViewModel:ViewModelBase
    {
        private readonly IMajorIndex major;

        private MajorIndex _dowJones;
        public MajorIndexListingViewModel(IMajorIndex major)
        {
            this.major = major;
        }
        public MajorIndex DowJones {
            get { return _dowJones; }
            set
            {
                _dowJones = value;
                OnPropertyChanged(nameof(DowJones));
            }
            }
        public MajorIndex _nasdaq;
        public MajorIndex Nasdaq {
            get { return _nasdaq; }
            set
            {
                _nasdaq = value;
                OnPropertyChanged(nameof(Nasdaq));
            }
        }
        public MajorIndex _SP500;
        public MajorIndex SP500
        {
            get { return _SP500; }
            set
            {
                _SP500 = value;
                OnPropertyChanged(nameof(_SP500));
            }
        }

        public static MajorIndexListingViewModel LoadViewModel(IMajorIndex majorIndex)
        {
            MajorIndexListingViewModel model = new MajorIndexListingViewModel(majorIndex);
            model.LoadMajorIndexes();
            return model;
        }

        public void LoadMajorIndexes()
        {
            major.GetMajorIndex(MajorIndexType.DowJones).ContinueWith(task =>
            {
                if (task.Exception == null)
                {
                    DowJones=task.Result;
                }
                });
            major.GetMajorIndex(MajorIndexType.Nasdaq).ContinueWith(task =>
            {
                if (task.Exception == null)
                {
                    Nasdaq = task.Result;
                }
            });
            major.GetMajorIndex(MajorIndexType.SP500).ContinueWith(task =>
            {
                if (task.Exception == null)
                {
                    SP500 = task.Result;
                }
            });

        }
    }
}
