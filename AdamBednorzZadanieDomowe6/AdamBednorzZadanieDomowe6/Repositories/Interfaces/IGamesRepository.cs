using AdamBednorzZadanieDomowe6.Models.Entities;
using System;
using System.Collections.Generic;

namespace AdamBednorzZadanieDomowe6.Repositories.Interfaces
{
    /// <summary>
    /// Interfejs definiujący metody związane z komunikacją z bazą danych dla tabeli Games
    /// </summary>
    public interface IGamesRepository
    {
        /// <summary>
        /// Abstrakcyjna metoda do pobierania wszystkich gier z tabeli Games
        /// </summary>
        /// <returns></returns>
        List<Game> GetGames();
        /// <summary>
        /// abstrkacyjna metoda do pobierania nazw gier
        /// </summary>
        /// <returns></returns>
        List<String> GetGamesNames();
        /// <summary>
        /// abstrakcyjna metoda do pobrania konretnej gry na podstawie nazwy
        /// </summary>
        /// <param name="selectedGame"></param>
        /// <returns></returns>
        Game GetGameByName(string selectedGame);

    }
}
