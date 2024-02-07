using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP2Client.Models;

namespace TP2Client.ViewsModels
{
    public class FilmView: ObservableObject
    {
        private Serie serie;
        public FilmView()
        {
            serie = new Serie();
        }

        public Serie Serie
        {
            get
            {
                return this.Serie;
            }

            set
            {
                this.Serie = value;
            }
        }
    }
}
