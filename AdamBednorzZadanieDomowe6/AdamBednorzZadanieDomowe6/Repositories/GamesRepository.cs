using AdamBednorzZadanieDomowe6.Models;
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
    public class GamesRepository : Repository, IGamesRepository
    {
        /// <summary>
        /// implementacja metody pobierajacej wszystkie gry z tabeli Games
        /// </summary>
        /// <returns></returns>
        public List<Game> GetGames()
        {
            return DbContext.Games.ToList();
        }
    }
}
