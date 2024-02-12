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
    public class WSService
    {
        private readonly HttpClient HttpClient;

        public WSService(string url)
        {
            HttpClient = new HttpClient();
            HttpClient.BaseAddress = new Uri("https://apiserieslavque.azurewebsites.net/api/");
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
        public async Task<Serie> GetASerieAsync(Serie serie)
        {
            var response = await HttpClient.GetAsync("series/" + serie.Serieid);

            if (response.IsSuccessStatusCode)
            {
                var serieFromResponse = await response.Content.ReadAsAsync<Serie>();
                return serieFromResponse;
            }
            else
            {
                return null;
            }
        }

        public async Task<bool> PostSerieAsync(Serie serie)
        {
            var response=await HttpClient.PostAsJsonAsync("series", serie);
            var test = response.Content.ReadAsStringAsync();

            return response.IsSuccessStatusCode;
        }

        public async Task<bool> PutSerieAsync(Serie serie)
        {
            var response= await HttpClient.PutAsJsonAsync("series/"+serie.Serieid,serie);
            return response.IsSuccessStatusCode;
        }
        public async Task<bool> DeleteSerieAsync(Serie serie)
        {
            var response = await HttpClient.DeleteAsync("series/" + serie.Serieid);
            return response.IsSuccessStatusCode;
        }

        






    }
}
