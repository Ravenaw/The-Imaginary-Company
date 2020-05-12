using Microsoft.Toolkit.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace The_Imaginary_Company.ViewModel
{
    public class ViewModel : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;


        private static readonly ViewModel instance = new ViewModel();

        // Explicit static constructor to tell C# compilernot to mark type as beforefieldinit
        static ViewModel()
        {
        }

        private ViewModel()
        {
        }

        public static ViewModel Instance
        {
            get
            {
                return instance;
            }
        }


        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
