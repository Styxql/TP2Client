using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP2Client.Models;

namespace TP2Client.Services
{
    public interface IService
    {
        public  Task<List<Serie>> GetSerieAsync(string nomControleur);
        public Task<bool> PostSerieAsync(string nomControleur, Serie serie);


    }
}
