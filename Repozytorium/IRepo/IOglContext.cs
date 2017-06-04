using Repozytorium.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;

namespace Repozytorium.IRepo
{
    public interface IOglContext
    {
        DbSet<Kategoria> Kategorie { get; set; }
        DbSet<Ogloszenie> Ogloszenia { get; set; }
        DbSet<Uzytkownik> Uzytkownik { get; set; }
        DbSet<Ogloszenie_Kategoria> Ogloszenie_Kategoria { get; set; }
        DbSet<CV> CV { get; set; }
        DbSet<Doswiadczenie> Doswiadczenie { get; set; }
        DbSet<Wiadomosc> Wiadomosc { get; set; }
        DbSet<Miasto> Miasto { get; set; }
        DbSet<RodzajUmowy> RodzajUmowy { get; set; }
        int SaveChanges();
        Database Database { get; }
        DbEntityEntry Entry(object entity);
    }
}