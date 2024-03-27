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
    public class MajorIndexViewModel
    {
        private readonly IMajorIndex major;

        public MajorIndexViewModel(IMajorIndex major)
        {
            this.major = major;
        }
        public MajorIndex DowJones { get; set; }
        public MajorIndex Nasdaq { get; set; }
        public MajorIndex SP500 { get; set; }

        public static MajorIndexViewModel LoadViewModel(IMajorIndex majorIndex)
        {
            MajorIndexViewModel model = new MajorIndexViewModel(majorIndex);
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
