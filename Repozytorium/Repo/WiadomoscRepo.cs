using Repozytorium.IRepo;
using Repozytorium.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Repozytorium.Repo
{
    public class WiadomoscRepo : IWiadomoscRepo
    {
        private readonly IOglContext _db;
        public WiadomoscRepo(IOglContext db)
        {
            _db = db;
        }
        public void WyslijWiadomosc(Wiadomosc wiadomosc)
        {
            _db.Wiadomosc.Add(wiadomosc);
        }
    }
}