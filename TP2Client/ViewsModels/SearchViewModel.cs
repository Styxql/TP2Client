using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.UI.Xaml.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP2Client.Models;
using TP2Client.Services;

namespace TP2Client.ViewsModels
{
    public class SearchViewModel:ObservableObject
    {
        public IRelayCommand BtnSearch { get; }
        public IRelayCommand BtnModif { get; }
        public IRelayCommand BtnDelete { get; }
        private Serie searchedSerie;
        public Serie SearchedSerie
        {
            get { return searchedSerie; }
            set
            {
                searchedSerie = value;
                OnPropertyChanged();
            }

        }

        public SearchViewModel()
        {
            SearchedSerie=new Serie();
            BtnSearch = new RelayCommand(SearchSerie);
            BtnModif= new RelayCommand(ActionModifFilm);
            BtnDelete=new RelayCommand(DeleteSerie);
            this.GetDataOnLoadAsync();

        }
        
        public async void GetDataOnLoadAsync()
        {
            WSService service = new WSService("https://apiserieslavque.azurewebsites.net/api/series");
            List<Serie> result = await service.GetSerieAsync("series");
            if (result == null)
            {
                //MessageAsync("API non disponible", "Erreur");
            }
            else
            {
                //Serie = new ObservableCollection<Serie>(result);
            }
        }


        public async void SearchSerie()
        {
            WSService service = new WSService("https://apiserieslavque.azurewebsites.net/api/series");
            this.SearchedSerie = await service.GetASerieAsync(this.SearchedSerie);
            if (this.SearchedSerie==null)
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
        public async void ActionModifFilm()
        {
            bool res;
            WSService service = new WSService("https://apiserieslavque.azurewebsites.net/api/series");
            res = await service.PutSerieAsync(this.SearchedSerie);
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

        public async void DeleteSerie()
        {
            bool res;
            WSService service = new WSService("https://apiserieslavque.azurewebsites.net/api/series");
            res = await service.DeleteSerieAsync(this.SearchedSerie);
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
