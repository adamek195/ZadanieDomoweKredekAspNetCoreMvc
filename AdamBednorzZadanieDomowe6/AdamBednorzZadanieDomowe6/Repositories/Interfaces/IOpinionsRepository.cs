using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdamBednorzZadanieDomowe6.Repositories.Interfaces
{
    /// <summary>
    /// Interfejs definiujący metody związane z komunikacją z bazą danych dla tabeli Opinions
    /// </summary>
    public interface IOpinionsRepository
    {
        /// <summary>
        /// abstrakcyjna metoda do dodawania opinii w bazie danych
        /// </summary>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <param name="password"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        bool AddOpinion(string firstName, string lastName, string password, string message);
    }
}
