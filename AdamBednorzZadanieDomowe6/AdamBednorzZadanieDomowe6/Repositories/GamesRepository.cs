using System;
using AdamBednorzZadanieDomowe6.Models.Entities;
using AdamBednorzZadanieDomowe6.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;

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
        /// <summary>
        /// implementacja metody pobierajacej wszystkie nazwy gier z tabeli Games
        /// </summary>
        /// <returns></returns>
        public List<String> GetGamesNames()
        {
            List<string> allNames = new List<string>();

            foreach (var game in DbContext.Games)
            {
                allNames.Add(game.Name);
            }

            return allNames;
        }
        /// <summary>
        /// implementacja metody zwracajaca konkretna gre na podstawie nazwy
        /// </summary>
        /// <param name="selectedGame"></param>
        /// <returns></returns>
        public Game GetGameByName(string selectedGame)
        {
            var game = DbContext.Games.Where(a => a.Name.ToLower() == selectedGame.ToLower()).FirstOrDefault();

            return game;
        }

        /// <summary>
        /// implementacja metody zwracajaca nazwe gry na podstawie imienia
        /// </summary>
        /// <param name="gameId"></param>
        /// <returns></returns>
        public string GetGameNameById(int gameId)
        {
            Game gameName = DbContext.Games.SingleOrDefault(g => g.Id == gameId);

            //jesli taka gra nie istnieje o podanym id
            if (gameName == null)
                return null;

            return gameName.Name;
        }
    }
}
