using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Repozytorium.Models.Views
{
    public class WiadomosciViewModel
    {
        public string UzytkownikId { get; set; }
        public List<Wiadomosc> Wiadomosci { get; set; }

    }
}