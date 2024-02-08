using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP2Client.Models;

namespace TP2Client.ViewsModels
{
    public class SearchViewModel:ObservableObject
    {
        private Serie serie;
        public Serie Serie
        {
            get { return serie; }
            set
            {
                serie = value;
                OnPropertyChanged();
            }
        }
        public SearchViewModel()
        {
            Serie=new Serie();
        }
    }
}
