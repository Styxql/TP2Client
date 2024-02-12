using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Formats.Asn1;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP2Client.Models;
using TP2Client.Services;
using TP2Client.Views;
using Windows.Security.Cryptography.Core;

namespace TP2Client.ViewsModels
{
    public class FilmViewModel : ObservableObject
    {
        public IRelayCommand BtnSetConversion { get; }
        
        private Serie serie;
        public Serie Serie {
            get { return serie; }
            set
            {
                serie = value;
                OnPropertyChanged();
            }
        }
       
        



       

        public FilmViewModel()
        {
            Serie = new Serie();
            

            this.GetDataOnLoadAsync();
            BtnSetConversion = new RelayCommand(ActionAddFilm);
            //BtnSetOtherConversion = new RelayCommand(ActionSetOtherConversion);
            
           
           
        }


        public async void GetDataOnLoadAsync()
        {
            WSService service = new WSService("https://apiserieslavque.azurewebsites.net/api/series");
            List<Serie> result = await service.GetSerieAsync("series");
            if (result == null)
            {
                 MessageAsync("API non disponible", "Erreur");
            }
            else
            {
                //Serie = new ObservableCollection<Serie>(result);
            }
        }
        public async void MessageAsync(string content, string title)
        {
            ContentDialog noApi = new ContentDialog
            {
                Title = title,
                Content = content,
                CloseButtonText = "OK"

            };
            noApi.XamlRoot = App.MainRoot.XamlRoot;

            ContentDialogResult result = await noApi.ShowAsync();

        }

        public async void ActionAddFilm()
        {
            bool res;
            WSService service = new WSService("https://apiserieslavque.azurewebsites.net/api/series");
            res= await service.PostSerieAsync(this.Serie);
            if (!res)
            {
                ContentDialog noApi = new ContentDialog
                {
                    Title = "marche pas",
                    Content = "marche pas",
                    CloseButtonText = "OK"

                };
                noApi.XamlRoot = App.MainRoot.XamlRoot;

                ContentDialogResult result = await noApi.ShowAsync();
            }
        }

       
       



    }


    }

