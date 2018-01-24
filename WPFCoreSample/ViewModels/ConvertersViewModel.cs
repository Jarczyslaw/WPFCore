using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFCore;
using WPFCoreSample.Models;

namespace WPFCoreSample.ViewModels
{
    public class ConvertersViewModel : BaseViewModel
    {
        private int pointer = 0;
        private ConverterTypes[] converterTypes;

        private ConverterTypes selectedType;
        public ConverterTypes SelectedType
        {
            get { return selectedType; }
            set { Set(ref selectedType, value); }
        }

        public RelayCommand ChangeTypeCommand { get; }

        public ConvertersViewModel()
        {
            converterTypes = (ConverterTypes[])Enum.GetValues(typeof(ConverterTypes));
            SelectedType = converterTypes[0];
            ChangeTypeCommand = new RelayCommand(() =>
            {
                pointer++;
                if (pointer >= converterTypes.Length)
                    pointer = 0;
                SelectedType = converterTypes[pointer];
            });
        }
    }
}
