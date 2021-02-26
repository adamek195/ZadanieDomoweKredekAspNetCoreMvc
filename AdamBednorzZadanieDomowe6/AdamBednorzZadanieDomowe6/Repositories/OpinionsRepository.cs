using AdamBednorzZadanieDomowe6.Models.Entities;
using AdamBednorzZadanieDomowe6.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdamBednorzZadanieDomowe6.Repositories
{
    /// <summary>
    /// Klasa definiująca metody związane z komunikacją z bazą danych dla tabeli Games
    /// </summary>
    public class OpinionsRepository : Repository, IOpinionsRepository
    {
        /// <summary>
        /// implementacja metody dodająca nową opinię do bazy
        /// </summary>
        public bool AddOpinion(string firstName, string lastName, string password, string message)
        {
            //szukamy klienta i gry
            Client client = DbContext.Clients.SingleOrDefault(c => c.FirstName == firstName && c.LastName == lastName && c.Password == password);
            //jesli nie ma takiego klienta
            if (client == null)
                return false;

            //dodajemy nowe zamowienie
            Opinion opinionToAdd = new Opinion()
            {
                ClientId = client.Id,
                Message = message
            };

            //dodajemy zamowienie do bazy
            DbContext.Opinions.Add(opinionToAdd);

            //zwracamy true jesli wszystko przebieglo pomyslnie
            return DbContext.SaveChanges() > 0;
        }
    }
}
