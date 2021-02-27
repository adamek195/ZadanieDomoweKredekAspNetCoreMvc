﻿using AdamBednorzZadanieDomowe6.Models.Entities;
using AdamBednorzZadanieDomowe6.Repositories.Interfaces;
using System.Linq;


namespace AdamBednorzZadanieDomowe6.Repositories
{
    /// <summary>
    /// Klasa definiująca metody związane z komunikacją z bazą danych dla tabeli Clients
    /// </summary>
    public class ClientsRepository : Repository, IClientsRepository
    {
        /// <summary>
        /// implementacja metody do logowania 
        /// </summary>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public bool SignIn(string firstName, string lastName, string password)
        {
            Client client = DbContext.Clients.SingleOrDefault(c => c.FirstName == firstName && c.LastName == lastName && c.Password == password);
            return client != null;
        }
        public bool Register(string firstName, string lastName, string password, int phoneNumber)
        {
            //sprawdzamy czy taki klient juz istnieje
            Client foundedClient = DbContext.Clients.FirstOrDefault(c => c.FirstName == firstName && c.LastName == lastName && c.Password == password);

            //jesli istnieje zwroc falsz
            if (foundedClient != null)
                return false;

            Client client = new Client()
            {
                FirstName = firstName,
                LastName = lastName,
                Password = password,
                PhoneNumber = phoneNumber
            };

            //dodajemy klienta do bazy
            DbContext.Clients.Add(client);

            //zapisujemy i zwracamy czy zapytanie przebiegło pomyslnie
            return DbContext.SaveChanges() > 0;
        }
    }
}
