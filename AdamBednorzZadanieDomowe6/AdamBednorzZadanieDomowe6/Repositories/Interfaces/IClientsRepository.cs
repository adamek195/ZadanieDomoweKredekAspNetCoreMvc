using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdamBednorzZadanieDomowe6.Repositories.Interfaces
{
    /// <summary>
    /// Interfejs definiujący metody związane z komunikacją z bazą danych dla tabeli Clients
    /// </summary>
    public interface IClientsRepository
    {
        /// <summary>
        /// abstrakcyjna metoda do logowania w sklepie
        /// </summary>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        bool SignIn(string firstName, string lastName, string password);
    }
}
