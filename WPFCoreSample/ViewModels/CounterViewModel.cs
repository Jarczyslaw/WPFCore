using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFCore;

namespace WPFCoreSample.ViewModels
{
    public class CounterViewModel : BaseViewModel
    {
        private int counterValue = 0;
        public int CounterValue
        {
            get { return counterValue; }
            set { Set(ref counterValue, value); }
        }

        private int maxCounterValue = 10;
        public int MaxCounterValue
        {
            get { return maxCounterValue; }
        }

        public RelayCommand IncrementCommand { get; private set; }
        public RelayCommand ResetCommand { get; private set; }

        public CounterViewModel()
        {
            IncrementCommand = new RelayCommand(() => CounterValue++,
            () =>
            {
                return CounterValue < MaxCounterValue;
            });
            ResetCommand = new RelayCommand(() => CounterValue = 0);
        }
    }
}
