using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdamBednorzZadanieDomowe6.ViewModels
{
    /// <summary>
    /// klasa w ktora jest modelem gry w sklepie
    /// na liscie bedziemy przechowywac infomacje o konkretnych grach(jeszcze nie ma bazy danych)
    /// </summary>
    public class GameViewModel
    {
        /// <summary>
        /// kontruktor tworzacy model
        /// </summary>
        /// <param name="name"></param>
        /// <param name="producer"></param>
        /// <param name="price"></param>
        /// <param name="photoPath"></param>
        public GameViewModel(string name, string producer, decimal price, string photoPath)
        {
            this.Name = name;
            this.Producer = producer;
            this.Price = price;
            this.PhotoPath = photoPath;
        }
        //atrybuty modelu
        public string Name { get; set; }
        public string Producer { get; set; }
        public decimal Price { get; set; }
        public string PhotoPath { get; set; }
    }
}
