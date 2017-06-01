using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Repozytorium.Models.Views
{
    public class OgloszenieCreateViewModel
    {
        public List<Miasto> Miasta { get; set; }
        public List<RodzajUmowy> RodzajeUmowy { get; set; }
        public List<Kategoria> Kategorie { get; set; }

        public Ogloszenie Ogloszenie { get; set; }

    }
}