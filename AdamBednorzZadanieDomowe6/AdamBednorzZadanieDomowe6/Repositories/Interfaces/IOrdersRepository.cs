using AdamBednorzZadanieDomowe6.Models.Entities;
using System;
using System.Collections.Generic;


namespace AdamBednorzZadanieDomowe6.Repositories.Interfaces
{
    /// <summary>
    /// Interfejs definiujący metody związane z komunikacją z bazą danych dla tabeli Orders
    /// </summary>
    public interface IOrdersRepository
    {
        /// <summary>
        /// Abstrakcyjna metoda do dodawania zamowienia
        /// </summary>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <param name="password"></param>
        /// <param name="gameName"></param>
        /// <returns></returns>
        bool AddOrder(string firstName, string lastName, string password, string gameName);
        /// <summary>
        /// Abstrakcyjna metoda do pobierania listy zamowionych gier przez konkretnego klienta
        /// </summary>
        /// <param name="clientId"></param>
        /// <returns></returns>
        List<int> GetGamesIdByClientId(int clientId);
    }
}
