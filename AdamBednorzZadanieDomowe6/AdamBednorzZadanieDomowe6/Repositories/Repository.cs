using AdamBednorzZadanieDomowe6.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdamBednorzZadanieDomowe6.Repositories
{
    /// <summary>
    /// klasa abstrakcyjna potrzebna do obslugi tabel z baz danych
    /// </summary>
    public class Repository
    {
        //zmienna przechowujaca 
        protected readonly DataBaseContext DbContext = new DataBaseContext();
    }
}
