using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdamBednorzZadanieDomowe6.Repositories.Interfaces
{
    /// <summary>
    /// Interfejs definiujący metody związane z komunikacją z bazą danych dla tabeli Orders
    /// </summary>
    public interface IOrdersRepository
    {
        /// <summary>
        /// Abstrakcyjna metoda 
        /// </summary>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <param name="password"></param>
        /// <param name="gameName"></param>
        /// <returns></returns>
        bool AddOrder(string firstName, string lastName, string password, string gameName);
    }
}
