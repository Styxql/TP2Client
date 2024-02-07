using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using TP2Client.Models;

namespace TP2Client.Services
{
    public class WSService:IService
    {
        private readonly HttpClient HttpClient;

        public WSService(string url)
        {
            HttpClient = new HttpClient();
            HttpClient.BaseAddress = new Uri("https://apiserieslavque.azurewebsites.net/api/series");
            HttpClient.DefaultRequestHeaders.Accept.Clear();
            HttpClient.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }


        public async Task<List<Serie>> GetSerieAsync(string nomControleur)
        {
            try
            {
                return await HttpClient.GetFromJsonAsync<List<Serie>>(nomControleur);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public bool Task<Serie> PostSerieAsync(string nomControleur,Serie serie)
        {
            try
            {
                return await HttpClient.PostAsJsonAsync<Serie>(nomControleur, serie);
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
