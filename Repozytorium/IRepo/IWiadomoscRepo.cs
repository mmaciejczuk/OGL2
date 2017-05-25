using Repozytorium.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Repozytorium.IRepo
{
    public interface IWiadomoscRepo
    {
        void WyslijWiadomosc(Wiadomosc wiadomosc);
    }
}