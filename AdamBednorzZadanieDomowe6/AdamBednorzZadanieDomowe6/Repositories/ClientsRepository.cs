using AdamBednorzZadanieDomowe6.Models.Entities;
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

        /// <summary>
        /// implementacja metody usuwajacej użytkownika z bazy
        /// </summary>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public bool Delete(string firstName, string lastName, string password)
        {
            //sprawdzamy czy istnieje taki użytkownik w bazie, ktorego chcemy usunac
            Client clientToDelete = DbContext.Clients.FirstOrDefault(c => c.FirstName == firstName && c.LastName == lastName && c.Password == password);
            if (clientToDelete == null)
                return false;
            //usuwamy pacjenta z bazy danych
            DbContext.Clients.Remove(clientToDelete);

            //zapisujemy i zwracamy czy zapytanie przebiegło pomyslnie
            return DbContext.SaveChanges() > 0;
        }

        /// <summary>
        /// implementacja metody pobierajacej id klienta po danych
        /// </summary>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public int GetIdByName(string firstName, string lastName, string password)
        {
            Client selectedClient = DbContext.Clients.FirstOrDefault(c => c.FirstName == firstName && c.LastName == lastName && c.Password == password);

            //jesli takiego klienta nie ma w bazie
            if (selectedClient == null)
                return 0;

            return selectedClient.Id;

        }
    }
}
