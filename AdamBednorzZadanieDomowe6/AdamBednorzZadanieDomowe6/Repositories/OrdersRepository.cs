using AdamBednorzZadanieDomowe6.Models.Entities;
using AdamBednorzZadanieDomowe6.Repositories.Interfaces;
using System.Linq;

namespace AdamBednorzZadanieDomowe6.Repositories
{
    /// <summary>
    /// Klasa definiująca metody związane z komunikacją z bazą danych dla tabeli Orders
    /// </summary>
    public class OrdersRepository: Repository, IOrdersRepository
    {
        public bool AddOrder(string firstName, string lastName, string password, string gameName)
        {
            //szukamy klienta i gry
            Client client = DbContext.Clients.SingleOrDefault(c => c.FirstName == firstName && c.LastName == lastName && c.Password == password);
            Game game = DbContext.Games.SingleOrDefault(g => g.Name == gameName);
            //jesli nie ma takiego klienta lub gry w bazie zwroc falsz
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
