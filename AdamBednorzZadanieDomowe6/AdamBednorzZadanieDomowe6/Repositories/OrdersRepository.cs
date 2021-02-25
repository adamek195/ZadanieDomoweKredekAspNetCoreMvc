using AdamBednorzZadanieDomowe6.Models.Entities;
using AdamBednorzZadanieDomowe6.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdamBednorzZadanieDomowe6.Repositories
{
    public class OrdersRepository: Repository, IOrdersRepository
    {
        public bool AddOrder(string firstName, string lastName, string password, string gameName)
        {
            //szukamy klienta i gry
            Client client = DbContext.Clients.SingleOrDefault(c => c.FirstName == firstName && c.LastName == lastName && c.Password == password);
            Game game = DbContext.Games.SingleOrDefault(g => g.Name == gameName);
            //jesli nie ma takiego pacjenta lub dania w bazie zwroc falsz
            if (client == null || game == null)
                return false;

            //dodajemy nowe zamowienie
            Order orderToAdd = new Order()
            {
                ClientId = client.Id,
                GameId = game.Id
            };

            //dodajemy zamowienie do bazy
            DbContext.Orders.Add(orderToAdd);

            //zwracamy true jesli wszystko przebieglo pomyslnie
            return DbContext.SaveChanges() > 0;
        }
    }
}
