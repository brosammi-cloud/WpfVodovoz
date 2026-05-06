using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using WpfVodovoz.Models;

namespace WpfVodovoz.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        
        public string Title { get; set; }
        

        protected void OnPropertyChanged([CallerMemberName] string prop = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}