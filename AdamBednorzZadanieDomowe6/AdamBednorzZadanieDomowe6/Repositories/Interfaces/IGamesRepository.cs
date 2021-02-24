using AdamBednorzZadanieDomowe6.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdamBednorzZadanieDomowe6.Repositories.Interfaces
{
    /// <summary>
    /// Interfejs definiujący metody związane z komunikacją z bazą danych dla tabeli Games
    /// </summary>
    interface IGamesRepository
    {
        /// <summary>
        /// Abstrakcyjna metoda do pobierania wszystkich gier z tabeli Games
        /// </summary>
        /// <returns></returns>
        List<Game> GetGames();
    }
}
