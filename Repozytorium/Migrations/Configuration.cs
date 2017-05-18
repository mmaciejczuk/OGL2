namespace Repozytorium.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    internal sealed class Configuration : DbMigrationsConfiguration<Repozytorium.Models.OglContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(Repozytorium.Models.OglContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            // Do debugowania metody seed
            //if (System.Diagnostics.Debugger.IsAttached == false)            
            //    System.Diagnostics.Debugger.Launch();

            //SeedRoles(context);
            //SeedUsers(context);
            //SeedOgloszenia(context);
            //SeedKategorie(context);
            //SeedOgloszenie_Kategoria(context);
            //SeedKategorie(context);
        }

        private void SeedOgloszenie_Kategoria(OglContext context)
        {
            for ( int i = 1; i < 10; i++)
            {
                var okat = new Ogloszenie_Kategoria()
                {
                    Id = i,
                    OgloszenieId = i / 2 + 1,
                    KategoriaId = i / 2 + 2
                };
                context.Set<Ogloszenie_Kategoria>().AddOrUpdate(okat);
            }
            context.SaveChanges();
        }

        private void SeedKategorie(OglContext context)
        {

            if (true) { var kat = new Kategoria() { Nazwa = " Grafik", Tresc = "Grafik", MetaTytul = "Grafik", MetaOpis = "Grafik", MetaSlowa = "Grafik", ParentId = 1 }; context.Set<Kategoria>().AddOrUpdate(kat); context.SaveChanges(); }
            if (true) { var kat = new Kategoria() { Nazwa = " Pracownik biurowy", Tresc = "Pracownik biurowy", MetaTytul = "Pracownik biurowy", MetaOpis = "Pracownik biurowy", MetaSlowa = "Pracownik biurowy", ParentId = 1 }; context.Set<Kategoria>().AddOrUpdate(kat); context.SaveChanges(); }
            if (true) { var kat = new Kategoria() { Nazwa = " Urzêdnik pañstwowy", Tresc = "Urzêdnik pañstwowy", MetaTytul = "Urzêdnik pañstwowy", MetaOpis = "Urzêdnik pañstwowy", MetaSlowa = "Urzêdnik pañstwowy", ParentId = 1 }; context.Set<Kategoria>().AddOrUpdate(kat); context.SaveChanges(); }
            if (true) { var kat = new Kategoria() { Nazwa = " Lekarz", Tresc = "Lekarz", MetaTytul = "Lekarz", MetaOpis = "Lekarz", MetaSlowa = "Lekarz", ParentId = 1 }; context.Set<Kategoria>().AddOrUpdate(kat); context.SaveChanges(); }
            if (true) { var kat = new Kategoria() { Nazwa = " Specjalista ds. zakupów", Tresc = "Specjalista ds. zakupów", MetaTytul = "Specjalista ds. zakupów", MetaOpis = "Specjalista ds. zakupów", MetaSlowa = "Specjalista ds. zakupów", ParentId = 1 }; context.Set<Kategoria>().AddOrUpdate(kat); context.SaveChanges(); }
            if (true) { var kat = new Kategoria() { Nazwa = " Programista", Tresc = "Programista", MetaTytul = "Programista", MetaOpis = "Programista", MetaSlowa = "Programista", ParentId = 1 }; context.Set<Kategoria>().AddOrUpdate(kat); context.SaveChanges(); }
            if (true) { var kat = new Kategoria() { Nazwa = " Specjalista ds. PR", Tresc = "Specjalista ds. PR", MetaTytul = "Specjalista ds. PR", MetaOpis = "Specjalista ds. PR", MetaSlowa = "Specjalista ds. PR", ParentId = 1 }; context.Set<Kategoria>().AddOrUpdate(kat); context.SaveChanges(); }
            if (true) { var kat = new Kategoria() { Nazwa = " Architekt wnêtrz / krajobrazu", Tresc = "Architekt wnêtrz / krajobrazu", MetaTytul = "Architekt wnêtrz / krajobrazu", MetaOpis = "Architekt wnêtrz / krajobrazu", MetaSlowa = "Architekt wnêtrz / krajobrazu", ParentId = 1 }; context.Set<Kategoria>().AddOrUpdate(kat); context.SaveChanges(); }
            if (true) { var kat = new Kategoria() { Nazwa = " Ekonomista", Tresc = "Ekonomista", MetaTytul = "Ekonomista", MetaOpis = "Ekonomista", MetaSlowa = "Ekonomista", ParentId = 1 }; context.Set<Kategoria>().AddOrUpdate(kat); context.SaveChanges(); }
            if (true) { var kat = new Kategoria() { Nazwa = " Specjalista ds. marketingu", Tresc = "Specjalista ds. marketingu", MetaTytul = "Specjalista ds. marketingu", MetaOpis = "Specjalista ds. marketingu", MetaSlowa = "Specjalista ds. marketingu", ParentId = 1 }; context.Set<Kategoria>().AddOrUpdate(kat); context.SaveChanges(); }
            if (true) { var kat = new Kategoria() { Nazwa = " Programista baz danych", Tresc = "Programista baz danych", MetaTytul = "Programista baz danych", MetaOpis = "Programista baz danych", MetaSlowa = "Programista baz danych", ParentId = 1 }; context.Set<Kategoria>().AddOrUpdate(kat); context.SaveChanges(); }
            if (true) { var kat = new Kategoria() { Nazwa = " Prawnik", Tresc = "Prawnik", MetaTytul = "Prawnik", MetaOpis = "Prawnik", MetaSlowa = "Prawnik", ParentId = 1 }; context.Set<Kategoria>().AddOrUpdate(kat); context.SaveChanges(); }
            if (true) { var kat = new Kategoria() { Nazwa = " In¿ynier Œrodowiska", Tresc = "In¿ynier Œrodowiska", MetaTytul = "In¿ynier Œrodowiska", MetaOpis = "In¿ynier Œrodowiska", MetaSlowa = "In¿ynier Œrodowiska", ParentId = 1 }; context.Set<Kategoria>().AddOrUpdate(kat); context.SaveChanges(); }
            if (true) { var kat = new Kategoria() { Nazwa = " Webmaster", Tresc = "Webmaster", MetaTytul = "Webmaster", MetaOpis = "Webmaster", MetaSlowa = "Webmaster", ParentId = 1 }; context.Set<Kategoria>().AddOrUpdate(kat); context.SaveChanges(); }
            if (true) { var kat = new Kategoria() { Nazwa = " Specjalista ds. ochrony œrodowiska", Tresc = "Specjalista ds. ochrony œrodowiska", MetaTytul = "Specjalista ds. ochrony œrodowiska", MetaOpis = "Specjalista ds. ochrony œrodowiska", MetaSlowa = "Specjalista ds. ochrony œrodowiska", ParentId = 1 }; context.Set<Kategoria>().AddOrUpdate(kat); context.SaveChanges(); }
            if (true) { var kat = new Kategoria() { Nazwa = " Automatyk", Tresc = "Automatyk", MetaTytul = "Automatyk", MetaOpis = "Automatyk", MetaSlowa = "Automatyk", ParentId = 1 }; context.Set<Kategoria>().AddOrUpdate(kat); context.SaveChanges(); }
            if (true) { var kat = new Kategoria() { Nazwa = " Projektant wzornictwa", Tresc = "Projektant wzornictwa", MetaTytul = "Projektant wzornictwa", MetaOpis = "Projektant wzornictwa", MetaSlowa = "Projektant wzornictwa", ParentId = 1 }; context.Set<Kategoria>().AddOrUpdate(kat); context.SaveChanges(); }
            if (true) { var kat = new Kategoria() { Nazwa = " Laborant", Tresc = "Laborant", MetaTytul = "Laborant", MetaOpis = "Laborant", MetaSlowa = "Laborant", ParentId = 1 }; context.Set<Kategoria>().AddOrUpdate(kat); context.SaveChanges(); }
            if (true) { var kat = new Kategoria() { Nazwa = " Specjalista ds. transportu", Tresc = "Specjalista ds. transportu", MetaTytul = "Specjalista ds. transportu", MetaOpis = "Specjalista ds. transportu", MetaSlowa = "Specjalista ds. transportu", ParentId = 1 }; context.Set<Kategoria>().AddOrUpdate(kat); context.SaveChanges(); }
            if (true) { var kat = new Kategoria() { Nazwa = " Tester aplikacji", Tresc = "Tester aplikacji", MetaTytul = "Tester aplikacji", MetaOpis = "Tester aplikacji", MetaSlowa = "Tester aplikacji", ParentId = 1 }; context.Set<Kategoria>().AddOrUpdate(kat); context.SaveChanges(); }
            if (true) { var kat = new Kategoria() { Nazwa = " Dyrektor ds.Administracyjnych", Tresc = "Dyrektor ds.Administracyjnych", MetaTytul = "Dyrektor ds.Administracyjnych", MetaOpis = "Dyrektor ds.Administracyjnych", MetaSlowa = "Dyrektor ds.Administracyjnych", ParentId = 1 }; context.Set<Kategoria>().AddOrUpdate(kat); context.SaveChanges(); }
            if (true) { var kat = new Kategoria() { Nazwa = " Dietetyk", Tresc = "Dietetyk", MetaTytul = "Dietetyk", MetaOpis = "Dietetyk", MetaSlowa = "Dietetyk", ParentId = 1 }; context.Set<Kategoria>().AddOrUpdate(kat); context.SaveChanges(); }
            if (true) { var kat = new Kategoria() { Nazwa = " Koordynator robót budowlanych", Tresc = "Koordynator robót budowlanych", MetaTytul = "Koordynator robót budowlanych", MetaOpis = "Koordynator robót budowlanych", MetaSlowa = "Koordynator robót budowlanych", ParentId = 1 }; context.Set<Kategoria>().AddOrUpdate(kat); context.SaveChanges(); }
            if (true) { var kat = new Kategoria() { Nazwa = " Specjalista ds. turystyki", Tresc = "Specjalista ds. turystyki", MetaTytul = "Specjalista ds. turystyki", MetaOpis = "Specjalista ds. turystyki", MetaSlowa = "Specjalista ds. turystyki", ParentId = 1 }; context.Set<Kategoria>().AddOrUpdate(kat); context.SaveChanges(); }
            if (true) { var kat = new Kategoria() { Nazwa = " Specjalista ds. BHP", Tresc = "Specjalista ds. BHP", MetaTytul = "Specjalista ds. BHP", MetaOpis = "Specjalista ds. BHP", MetaSlowa = "Specjalista ds. BHP", ParentId = 1 }; context.Set<Kategoria>().AddOrUpdate(kat); context.SaveChanges(); }
            if (true) { var kat = new Kategoria() { Nazwa = " Spedytor", Tresc = "Spedytor", MetaTytul = "Spedytor", MetaOpis = "Spedytor", MetaSlowa = "Spedytor", ParentId = 1 }; context.Set<Kategoria>().AddOrUpdate(kat); context.SaveChanges(); }
            if (true) { var kat = new Kategoria() { Nazwa = " Koordynator sprzeda¿y", Tresc = "Koordynator sprzeda¿y", MetaTytul = "Koordynator sprzeda¿y", MetaOpis = "Koordynator sprzeda¿y", MetaSlowa = "Koordynator sprzeda¿y", ParentId = 1 }; context.Set<Kategoria>().AddOrUpdate(kat); context.SaveChanges(); }
            if (true) { var kat = new Kategoria() { Nazwa = " Dyrektor ds. Rozwoju", Tresc = "Dyrektor ds. Rozwoju", MetaTytul = "Dyrektor ds. Rozwoju", MetaOpis = "Dyrektor ds. Rozwoju", MetaSlowa = "Dyrektor ds. Rozwoju", ParentId = 1 }; context.Set<Kategoria>().AddOrUpdate(kat); context.SaveChanges(); }
            if (true) { var kat = new Kategoria() { Nazwa = " Pedagog", Tresc = "Pedagog", MetaTytul = "Pedagog", MetaOpis = "Pedagog", MetaSlowa = "Pedagog", ParentId = 1 }; context.Set<Kategoria>().AddOrUpdate(kat); context.SaveChanges(); }
            if (true) { var kat = new Kategoria() { Nazwa = " Kurator s¹dowy", Tresc = "Kurator s¹dowy", MetaTytul = "Kurator s¹dowy", MetaOpis = "Kurator s¹dowy", MetaSlowa = "Kurator s¹dowy", ParentId = 1 }; context.Set<Kategoria>().AddOrUpdate(kat); context.SaveChanges(); }
            if (true) { var kat = new Kategoria() { Nazwa = " Analityk rynku", Tresc = "Analityk rynku", MetaTytul = "Analityk rynku", MetaOpis = "Analityk rynku", MetaSlowa = "Analityk rynku", ParentId = 1 }; context.Set<Kategoria>().AddOrUpdate(kat); context.SaveChanges(); }
            if (true) { var kat = new Kategoria() { Nazwa = " Key account manager", Tresc = "Key account manager", MetaTytul = "Key account manager", MetaOpis = "Key account manager", MetaSlowa = "Key account manager", ParentId = 1 }; context.Set<Kategoria>().AddOrUpdate(kat); context.SaveChanges(); }
            if (true) { var kat = new Kategoria() { Nazwa = " Specjalista ds. obs³ugi klienta", Tresc = "Specjalista ds. obs³ugi klienta", MetaTytul = "Specjalista ds. obs³ugi klienta", MetaOpis = "Specjalista ds. obs³ugi klienta", MetaSlowa = "Specjalista ds. obs³ugi klienta", ParentId = 1 }; context.Set<Kategoria>().AddOrUpdate(kat); context.SaveChanges(); }
            if (true) { var kat = new Kategoria() { Nazwa = " Fakturzystka", Tresc = "Fakturzystka", MetaTytul = "Fakturzystka", MetaOpis = "Fakturzystka", MetaSlowa = "Fakturzystka", ParentId = 1 }; context.Set<Kategoria>().AddOrUpdate(kat); context.SaveChanges(); }
            if (true) { var kat = new Kategoria() { Nazwa = " Technolog", Tresc = "Technolog", MetaTytul = "Technolog", MetaOpis = "Technolog", MetaSlowa = "Technolog", ParentId = 1 }; context.Set<Kategoria>().AddOrUpdate(kat); context.SaveChanges(); }
            if (true) { var kat = new Kategoria() { Nazwa = " Administrator danych osobowych", Tresc = "Administrator danych osobowych", MetaTytul = "Administrator danych osobowych", MetaOpis = "Administrator danych osobowych", MetaSlowa = "Administrator danych osobowych", ParentId = 1 }; context.Set<Kategoria>().AddOrUpdate(kat); context.SaveChanges(); }
            if (true) { var kat = new Kategoria() { Nazwa = " Dyrektor ds. Logistyki", Tresc = "Dyrektor ds. Logistyki", MetaTytul = "Dyrektor ds. Logistyki", MetaOpis = "Dyrektor ds. Logistyki", MetaSlowa = "Dyrektor ds. Logistyki", ParentId = 1 }; context.Set<Kategoria>().AddOrUpdate(kat); context.SaveChanges(); }
            if (true) { var kat = new Kategoria() { Nazwa = " T³umacz", Tresc = "T³umacz", MetaTytul = "T³umacz", MetaOpis = "T³umacz", MetaSlowa = "T³umacz", ParentId = 1 }; context.Set<Kategoria>().AddOrUpdate(kat); context.SaveChanges(); }
            if (true) { var kat = new Kategoria() { Nazwa = " Doradca zawodowy", Tresc = "Doradca zawodowy", MetaTytul = "Doradca zawodowy", MetaOpis = "Doradca zawodowy", MetaSlowa = "Doradca zawodowy", ParentId = 1 }; context.Set<Kategoria>().AddOrUpdate(kat); context.SaveChanges(); }
            if (true) { var kat = new Kategoria() { Nazwa = " Dyrektor ds. Personalnych", Tresc = "Dyrektor ds. Personalnych", MetaTytul = "Dyrektor ds. Personalnych", MetaOpis = "Dyrektor ds. Personalnych", MetaSlowa = "Dyrektor ds. Personalnych", ParentId = 1 }; context.Set<Kategoria>().AddOrUpdate(kat); context.SaveChanges(); }
            if (true) { var kat = new Kategoria() { Nazwa = " Konstruktor", Tresc = "Konstruktor", MetaTytul = "Konstruktor", MetaOpis = "Konstruktor", MetaSlowa = "Konstruktor", ParentId = 1 }; context.Set<Kategoria>().AddOrUpdate(kat); context.SaveChanges(); }
            if (true) { var kat = new Kategoria() { Nazwa = " Pe³nomocnik ds. Jakoœci", Tresc = "Pe³nomocnik ds. Jakoœci", MetaTytul = "Pe³nomocnik ds. Jakoœci", MetaOpis = "Pe³nomocnik ds. Jakoœci", MetaSlowa = "Pe³nomocnik ds. Jakoœci", ParentId = 1 }; context.Set<Kategoria>().AddOrUpdate(kat); context.SaveChanges(); }
            if (true) { var kat = new Kategoria() { Nazwa = " Asystentka zarz¹du", Tresc = "Asystentka zarz¹du", MetaTytul = "Asystentka zarz¹du", MetaOpis = "Asystentka zarz¹du", MetaSlowa = "Asystentka zarz¹du", ParentId = 1 }; context.Set<Kategoria>().AddOrUpdate(kat); context.SaveChanges(); }
            if (true) { var kat = new Kategoria() { Nazwa = " Farmaceuta", Tresc = "Farmaceuta", MetaTytul = "Farmaceuta", MetaOpis = "Farmaceuta", MetaSlowa = "Farmaceuta", ParentId = 1 }; context.Set<Kategoria>().AddOrUpdate(kat); context.SaveChanges(); }
            if (true) { var kat = new Kategoria() { Nazwa = " Dyrektor ds. Finansowych", Tresc = "Dyrektor ds. Finansowych", MetaTytul = "Dyrektor ds. Finansowych", MetaOpis = "Dyrektor ds. Finansowych", MetaSlowa = "Dyrektor ds. Finansowych", ParentId = 1 }; context.Set<Kategoria>().AddOrUpdate(kat); context.SaveChanges(); }
            if (true) { var kat = new Kategoria() { Nazwa = " Architekt budownictwa", Tresc = "Architekt budownictwa", MetaTytul = "Architekt budownictwa", MetaOpis = "Architekt budownictwa", MetaSlowa = "Architekt budownictwa", ParentId = 1 }; context.Set<Kategoria>().AddOrUpdate(kat); context.SaveChanges(); }
            if (true) { var kat = new Kategoria() { Nazwa = " Specjalista ds. planowania produkcji", Tresc = "Specjalista ds. planowania produkcji", MetaTytul = "Specjalista ds. planowania produkcji", MetaOpis = "Specjalista ds. planowania produkcji", MetaSlowa = "Specjalista ds. planowania produkcji", ParentId = 1 }; context.Set<Kategoria>().AddOrUpdate(kat); context.SaveChanges(); }
            if (true) { var kat = new Kategoria() { Nazwa = " Adwokat", Tresc = "Adwokat", MetaTytul = "Adwokat", MetaOpis = "Adwokat", MetaSlowa = "Adwokat", ParentId = 1 }; context.Set<Kategoria>().AddOrUpdate(kat); context.SaveChanges(); }
            if (true) { var kat = new Kategoria() { Nazwa = " Agent celny", Tresc = "Agent celny", MetaTytul = "Agent celny", MetaOpis = "Agent celny", MetaSlowa = "Agent celny", ParentId = 1 }; context.Set<Kategoria>().AddOrUpdate(kat); context.SaveChanges(); }
            if (true) { var kat = new Kategoria() { Nazwa = " Project Manager", Tresc = "Project Manager", MetaTytul = "Project Manager", MetaOpis = "Project Manager", MetaSlowa = "Project Manager", ParentId = 1 }; context.Set<Kategoria>().AddOrUpdate(kat); context.SaveChanges(); }
            if (true) { var kat = new Kategoria() { Nazwa = " Projektant IT", Tresc = "Projektant IT", MetaTytul = "Projektant IT", MetaOpis = "Projektant IT", MetaSlowa = "Projektant IT", ParentId = 1 }; context.Set<Kategoria>().AddOrUpdate(kat); context.SaveChanges(); }
            if (true) { var kat = new Kategoria() { Nazwa = " Specjalista ds. inwestycji", Tresc = "Specjalista ds. inwestycji", MetaTytul = "Specjalista ds. inwestycji", MetaOpis = "Specjalista ds. inwestycji", MetaSlowa = "Specjalista ds. inwestycji", ParentId = 1 }; context.Set<Kategoria>().AddOrUpdate(kat); context.SaveChanges(); }
            if (true) { var kat = new Kategoria() { Nazwa = " Copywriter", Tresc = "Copywriter", MetaTytul = "Copywriter", MetaOpis = "Copywriter", MetaSlowa = "Copywriter", ParentId = 1 }; context.Set<Kategoria>().AddOrUpdate(kat); context.SaveChanges(); }
            if (true) { var kat = new Kategoria() { Nazwa = " Specjalista ds. reklamacji", Tresc = "Specjalista ds. reklamacji", MetaTytul = "Specjalista ds. reklamacji", MetaOpis = "Specjalista ds. reklamacji", MetaSlowa = "Specjalista ds. reklamacji", ParentId = 1 }; context.Set<Kategoria>().AddOrUpdate(kat); context.SaveChanges(); }
            if (true) { var kat = new Kategoria() { Nazwa = " Ksiêgowa", Tresc = "Ksiêgowa", MetaTytul = "Ksiêgowa", MetaOpis = "Ksiêgowa", MetaSlowa = "Ksiêgowa", ParentId = 1 }; context.Set<Kategoria>().AddOrUpdate(kat); context.SaveChanges(); }
            if (true) { var kat = new Kategoria() { Nazwa = " Geodeta", Tresc = "Geodeta", MetaTytul = "Geodeta", MetaOpis = "Geodeta", MetaSlowa = "Geodeta", ParentId = 1 }; context.Set<Kategoria>().AddOrUpdate(kat); context.SaveChanges(); }
            if (true) { var kat = new Kategoria() { Nazwa = " Administrator", Tresc = "Administrator", MetaTytul = "Administrator", MetaOpis = "Administrator", MetaSlowa = "Administrator", ParentId = 1 }; context.Set<Kategoria>().AddOrUpdate(kat); context.SaveChanges(); }
            if (true) { var kat = new Kategoria() { Nazwa = " Przedstawiciel handlowy", Tresc = "Przedstawiciel handlowy", MetaTytul = "Przedstawiciel handlowy", MetaOpis = "Przedstawiciel handlowy", MetaSlowa = "Przedstawiciel handlowy", ParentId = 1 }; context.Set<Kategoria>().AddOrUpdate(kat); context.SaveChanges(); }
            if (true) { var kat = new Kategoria() { Nazwa = " Recepcjonistka", Tresc = "Recepcjonistka", MetaTytul = "Recepcjonistka", MetaOpis = "Recepcjonistka", MetaSlowa = "Recepcjonistka", ParentId = 1 }; context.Set<Kategoria>().AddOrUpdate(kat); context.SaveChanges(); }
            if (true) { var kat = new Kategoria() { Nazwa = " Pracownik socjalny", Tresc = "Pracownik socjalny", MetaTytul = "Pracownik socjalny", MetaOpis = "Pracownik socjalny", MetaSlowa = "Pracownik socjalny", ParentId = 1 }; context.Set<Kategoria>().AddOrUpdate(kat); context.SaveChanges(); }
            if (true) { var kat = new Kategoria() { Nazwa = " In¿ynier Budowy", Tresc = "In¿ynier Budowy", MetaTytul = "In¿ynier Budowy", MetaOpis = "In¿ynier Budowy", MetaSlowa = "In¿ynier Budowy", ParentId = 1 }; context.Set<Kategoria>().AddOrUpdate(kat); context.SaveChanges(); }
            if (true) { var kat = new Kategoria() { Nazwa = " Doradca finansowy", Tresc = "Doradca finansowy", MetaTytul = "Doradca finansowy", MetaOpis = "Doradca finansowy", MetaSlowa = "Doradca finansowy", ParentId = 1 }; context.Set<Kategoria>().AddOrUpdate(kat); context.SaveChanges(); }
            if (true) { var kat = new Kategoria() { Nazwa = " Lektor", Tresc = "Lektor", MetaTytul = "Lektor", MetaOpis = "Lektor", MetaSlowa = "Lektor", ParentId = 1 }; context.Set<Kategoria>().AddOrUpdate(kat); context.SaveChanges(); }
            if (true) { var kat = new Kategoria() { Nazwa = " Pilot wycieczek", Tresc = "Pilot wycieczek", MetaTytul = "Pilot wycieczek", MetaOpis = "Pilot wycieczek", MetaSlowa = "Pilot wycieczek", ParentId = 1 }; context.Set<Kategoria>().AddOrUpdate(kat); context.SaveChanges(); }
            if (true) { var kat = new Kategoria() { Nazwa = " Trener", Tresc = "Trener", MetaTytul = "Trener", MetaOpis = "Trener", MetaSlowa = "Trener", ParentId = 1 }; context.Set<Kategoria>().AddOrUpdate(kat); context.SaveChanges(); }
            if (true) { var kat = new Kategoria() { Nazwa = " Konsultant ds. Wdro¿eñ", Tresc = "Konsultant ds. Wdro¿eñ", MetaTytul = "Konsultant ds. Wdro¿eñ", MetaOpis = "Konsultant ds. Wdro¿eñ", MetaSlowa = "Konsultant ds. Wdro¿eñ", ParentId = 1 }; context.Set<Kategoria>().AddOrUpdate(kat); context.SaveChanges(); }
            if (true) { var kat = new Kategoria() { Nazwa = " Dziennikarz", Tresc = "Dziennikarz", MetaTytul = "Dziennikarz", MetaOpis = "Dziennikarz", MetaSlowa = "Dziennikarz", ParentId = 1 }; context.Set<Kategoria>().AddOrUpdate(kat); context.SaveChanges(); }
            if (true) { var kat = new Kategoria() { Nazwa = " Product Manager", Tresc = "Product Manager", MetaTytul = "Product Manager", MetaOpis = "Product Manager", MetaSlowa = "Product Manager", ParentId = 1 }; context.Set<Kategoria>().AddOrUpdate(kat); context.SaveChanges(); }
            if (true) { var kat = new Kategoria() { Nazwa = " Agenta nieruchomoœci", Tresc = "Agenta nieruchomoœci", MetaTytul = "Agenta nieruchomoœci", MetaOpis = "Agenta nieruchomoœci", MetaSlowa = "Agenta nieruchomoœci", ParentId = 1 }; context.Set<Kategoria>().AddOrUpdate(kat); context.SaveChanges(); }
            if (true) { var kat = new Kategoria() { Nazwa = " In¿ynier utrzymania ruchu", Tresc = "In¿ynier utrzymania ruchu", MetaTytul = "In¿ynier utrzymania ruchu", MetaOpis = "In¿ynier utrzymania ruchu", MetaSlowa = "In¿ynier utrzymania ruchu", ParentId = 1 }; context.Set<Kategoria>().AddOrUpdate(kat); context.SaveChanges(); }
            if (true) { var kat = new Kategoria() { Nazwa = " Handlowiec", Tresc = "Handlowiec", MetaTytul = "Handlowiec", MetaOpis = "Handlowiec", MetaSlowa = "Handlowiec", ParentId = 1 }; context.Set<Kategoria>().AddOrUpdate(kat); context.SaveChanges(); }
            if (true) { var kat = new Kategoria() { Nazwa = " Specjalista ds. funduszy unijnych", Tresc = "Specjalista ds. funduszy unijnych", MetaTytul = "Specjalista ds. funduszy unijnych", MetaOpis = "Specjalista ds. funduszy unijnych", MetaSlowa = "Specjalista ds. funduszy unijnych", ParentId = 1 }; context.Set<Kategoria>().AddOrUpdate(kat); context.SaveChanges(); }
            if (true) { var kat = new Kategoria() { Nazwa = " Projektant konstrukcji budowlanych", Tresc = "Projektant konstrukcji budowlanych", MetaTytul = "Projektant konstrukcji budowlanych", MetaOpis = "Projektant konstrukcji budowlanych", MetaSlowa = "Projektant konstrukcji budowlanych", ParentId = 1 }; context.Set<Kategoria>().AddOrUpdate(kat); context.SaveChanges(); }
            if (true) { var kat = new Kategoria() { Nazwa = " Przedstawiciel medyczny", Tresc = "Przedstawiciel medyczny", MetaTytul = "Przedstawiciel medyczny", MetaOpis = "Przedstawiciel medyczny", MetaSlowa = "Przedstawiciel medyczny", ParentId = 1 }; context.Set<Kategoria>().AddOrUpdate(kat); context.SaveChanges(); }
            if (true) { var kat = new Kategoria() { Nazwa = " Office Manager", Tresc = "Office Manager", MetaTytul = "Office Manager", MetaOpis = "Office Manager", MetaSlowa = "Office Manager", ParentId = 1 }; context.Set<Kategoria>().AddOrUpdate(kat); context.SaveChanges(); }
            if (true) { var kat = new Kategoria() { Nazwa = " Notariusz", Tresc = "Notariusz", MetaTytul = "Notariusz", MetaOpis = "Notariusz", MetaSlowa = "Notariusz", ParentId = 1 }; context.Set<Kategoria>().AddOrUpdate(kat); context.SaveChanges(); }
            if (true) { var kat = new Kategoria() { Nazwa = " Programista PLC", Tresc = "Programista PLC", MetaTytul = "Programista PLC", MetaOpis = "Programista PLC", MetaSlowa = "Programista PLC", ParentId = 1 }; context.Set<Kategoria>().AddOrUpdate(kat); context.SaveChanges(); }
            if (true) { var kat = new Kategoria() { Nazwa = " Doradca techniczno-handlowy", Tresc = "Doradca techniczno-handlowy", MetaTytul = "Doradca techniczno-handlowy", MetaOpis = "Doradca techniczno-handlowy", MetaSlowa = "Doradca techniczno-handlowy", ParentId = 1 }; context.Set<Kategoria>().AddOrUpdate(kat); context.SaveChanges(); }
            if (true) { var kat = new Kategoria() { Nazwa = " Kierownik Magazynu", Tresc = "Kierownik Magazynu", MetaTytul = "Kierownik Magazynu", MetaOpis = "Kierownik Magazynu", MetaSlowa = "Kierownik Magazynu", ParentId = 1 }; context.Set<Kategoria>().AddOrUpdate(kat); context.SaveChanges(); }
            if (true) { var kat = new Kategoria() { Nazwa = " Specjalista ds. windykacji", Tresc = "Specjalista ds. windykacji", MetaTytul = "Specjalista ds. windykacji", MetaOpis = "Specjalista ds. windykacji", MetaSlowa = "Specjalista ds. windykacji", ParentId = 1 }; context.Set<Kategoria>().AddOrUpdate(kat); context.SaveChanges(); }
            if (true) { var kat = new Kategoria() { Nazwa = " In¿ynier ds. Wdra¿ania Produkcji", Tresc = "In¿ynier ds. Wdra¿ania Produkcji", MetaTytul = "In¿ynier ds. Wdra¿ania Produkcji", MetaOpis = "In¿ynier ds. Wdra¿ania Produkcji", MetaSlowa = "In¿ynier ds. Wdra¿ania Produkcji", ParentId = 1 }; context.Set<Kategoria>().AddOrUpdate(kat); context.SaveChanges(); }
            if (true) { var kat = new Kategoria() { Nazwa = " Dyrektor ds. Sprzeda¿y", Tresc = "Dyrektor ds. Sprzeda¿y", MetaTytul = "Dyrektor ds. Sprzeda¿y", MetaOpis = "Dyrektor ds. Sprzeda¿y", MetaSlowa = "Dyrektor ds. Sprzeda¿y", ParentId = 1 }; context.Set<Kategoria>().AddOrUpdate(kat); context.SaveChanges(); }
            if (true) { var kat = new Kategoria() { Nazwa = " Specjalista ds. badañ i rozwoju", Tresc = "Specjalista ds. badañ i rozwoju", MetaTytul = "Specjalista ds. badañ i rozwoju", MetaOpis = "Specjalista ds. badañ i rozwoju", MetaSlowa = "Specjalista ds. badañ i rozwoju", ParentId = 1 }; context.Set<Kategoria>().AddOrUpdate(kat); context.SaveChanges(); }
            if (true) { var kat = new Kategoria() { Nazwa = " Prezenter", Tresc = "Prezenter", MetaTytul = "Prezenter", MetaOpis = "Prezenter", MetaSlowa = "Prezenter", ParentId = 1 }; context.Set<Kategoria>().AddOrUpdate(kat); context.SaveChanges(); }
            if (true) { var kat = new Kategoria() { Nazwa = " Rzeczoznawca", Tresc = "Rzeczoznawca", MetaTytul = "Rzeczoznawca", MetaOpis = "Rzeczoznawca", MetaSlowa = "Rzeczoznawca", ParentId = 1 }; context.Set<Kategoria>().AddOrUpdate(kat); context.SaveChanges(); }
            if (true) { var kat = new Kategoria() { Nazwa = " Dyrektor ds. Marketingu", Tresc = "Dyrektor ds. Marketingu", MetaTytul = "Dyrektor ds. Marketingu", MetaOpis = "Dyrektor ds. Marketingu", MetaSlowa = "Dyrektor ds. Marketingu", ParentId = 1 }; context.Set<Kategoria>().AddOrUpdate(kat); context.SaveChanges(); }
            if (true) { var kat = new Kategoria() { Nazwa = " Kierownik punktu sprzeda¿y", Tresc = "Kierownik punktu sprzeda¿y", MetaTytul = "Kierownik punktu sprzeda¿y", MetaOpis = "Kierownik punktu sprzeda¿y", MetaSlowa = "Kierownik punktu sprzeda¿y", ParentId = 1 }; context.Set<Kategoria>().AddOrUpdate(kat); context.SaveChanges(); }
            if (true) { var kat = new Kategoria() { Nazwa = " Radca prawny", Tresc = "Radca prawny", MetaTytul = "Radca prawny", MetaOpis = "Radca prawny", MetaSlowa = "Radca prawny", ParentId = 1 }; context.Set<Kategoria>().AddOrUpdate(kat); context.SaveChanges(); }
            if (true) { var kat = new Kategoria() { Nazwa = " Kosztorysant", Tresc = "Kosztorysant", MetaTytul = "Kosztorysant", MetaOpis = "Kosztorysant", MetaSlowa = "Kosztorysant", ParentId = 1 }; context.Set<Kategoria>().AddOrUpdate(kat); context.SaveChanges(); }
            if (true) { var kat = new Kategoria() { Nazwa = " Specjalista ds. dostaw", Tresc = "Specjalista ds. dostaw", MetaTytul = "Specjalista ds. dostaw", MetaOpis = "Specjalista ds. dostaw", MetaSlowa = "Specjalista ds. dostaw", ParentId = 1 }; context.Set<Kategoria>().AddOrUpdate(kat); context.SaveChanges(); }
            if (true) { var kat = new Kategoria() { Nazwa = " Telemarketer", Tresc = "Telemarketer", MetaTytul = "Telemarketer", MetaOpis = "Telemarketer", MetaSlowa = "Telemarketer", ParentId = 1 }; context.Set<Kategoria>().AddOrUpdate(kat); context.SaveChanges(); }
            if (true) { var kat = new Kategoria() { Nazwa = " Specjalista ds. pozycjonowania", Tresc = "Specjalista ds. pozycjonowania", MetaTytul = "Specjalista ds. pozycjonowania", MetaOpis = "Specjalista ds. pozycjonowania", MetaSlowa = "Specjalista ds. pozycjonowania", ParentId = 1 }; context.Set<Kategoria>().AddOrUpdate(kat); context.SaveChanges(); }
            if (true) { var kat = new Kategoria() { Nazwa = " Dyrektor ds. Produkcji", Tresc = "Dyrektor ds. Produkcji", MetaTytul = "Dyrektor ds. Produkcji", MetaOpis = "Dyrektor ds. Produkcji", MetaSlowa = "Dyrektor ds. Produkcji", ParentId = 1 }; context.Set<Kategoria>().AddOrUpdate(kat); context.SaveChanges(); }
            if (true) { var kat = new Kategoria() { Nazwa = " Doradca podatkowy", Tresc = "Doradca podatkowy", MetaTytul = "Doradca podatkowy", MetaOpis = "Doradca podatkowy", MetaSlowa = "Doradca podatkowy", ParentId = 1 }; context.Set<Kategoria>().AddOrUpdate(kat); context.SaveChanges(); }
            if (true) { var kat = new Kategoria() { Nazwa = " Specjalista ds. ofertowania", Tresc = "Specjalista ds. ofertowania", MetaTytul = "Specjalista ds. ofertowania", MetaOpis = "Specjalista ds. ofertowania", MetaSlowa = "Specjalista ds. ofertowania", ParentId = 1 }; context.Set<Kategoria>().AddOrUpdate(kat); context.SaveChanges(); }
            if (true) { var kat = new Kategoria() { Nazwa = " Kierownik kontraktu", Tresc = "Kierownik kontraktu", MetaTytul = "Kierownik kontraktu", MetaOpis = "Kierownik kontraktu", MetaSlowa = "Kierownik kontraktu", ParentId = 1 }; context.Set<Kategoria>().AddOrUpdate(kat); context.SaveChanges(); }
            if (true) { var kat = new Kategoria() { Nazwa = " Analityk systemów", Tresc = "Analityk systemów", MetaTytul = "Analityk systemów", MetaOpis = "Analityk systemów", MetaSlowa = "Analityk systemów", ParentId = 1 }; context.Set<Kategoria>().AddOrUpdate(kat); context.SaveChanges(); }
            if (true) { var kat = new Kategoria() { Nazwa = " Nauczyciel", Tresc = "Nauczyciel", MetaTytul = "Nauczyciel", MetaOpis = "Nauczyciel", MetaSlowa = "Nauczyciel", ParentId = 1 }; context.Set<Kategoria>().AddOrUpdate(kat); context.SaveChanges(); }
            if (true) { var kat = new Kategoria() { Nazwa = " Specjalista ds. kadr i p³ac", Tresc = "Specjalista ds. kadr i p³ac", MetaTytul = "Specjalista ds. kadr i p³ac", MetaOpis = "Specjalista ds. kadr i p³ac", MetaSlowa = "Specjalista ds. kadr i p³ac", ParentId = 1 }; context.Set<Kategoria>().AddOrUpdate(kat); context.SaveChanges(); }
            if (true) { var kat = new Kategoria() { Nazwa = " Specjalista ds. rekrutacji", Tresc = "Specjalista ds. rekrutacji", MetaTytul = "Specjalista ds. rekrutacji", MetaOpis = "Specjalista ds. rekrutacji", MetaSlowa = "Specjalista ds. rekrutacji", ParentId = 1 }; context.Set<Kategoria>().AddOrUpdate(kat); context.SaveChanges(); }

        }

        private void SeedOgloszenia(OglContext context)
        {
            var idUzytkownika = context.Set<Uzytkownik>().Where(u => u.UserName == "Admin").FirstOrDefault().Id;
            for (int i = 0; i <= 10; i++)
            {
                var ogl = new Ogloszenie()
                {
                    Id = i,
                    UzytkownikId = idUzytkownika,
                    Tresc = "Treœæ og³oszenia" + i.ToString(),
                    Tytul = "Tytu³ og³oszenia" + i.ToString(),
                    DataDodania = DateTime.Now.AddDays(-i),
                };
                context.Set<Ogloszenie>().AddOrUpdate(ogl);
            }
            context.SaveChanges();
        }

        private void SeedUsers(OglContext context)
        {
            var store = new UserStore<Uzytkownik>(context);
            var manager = new UserManager<Uzytkownik>(store);

            if (!context.Users.Any(u => u.UserName == "Admin"))
            {
                var user = new Uzytkownik { UserName = "Admin" };
                var adminresult = manager.Create(user, "12345678");
                if (adminresult.Succeeded)
                    manager.AddToRole(user.Id, "Admin");                               
            }

            if (!context.Users.Any(u => u.UserName == "Marek"))
            {
                var user = new Uzytkownik { UserName = "marek@AspNetMvc.pl" };
                var adminresult = manager.Create(user, "1234Abc,");
                if (adminresult.Succeeded)
                    manager.AddToRole(user.Id, "Pracownik");
            }
            if (!context.Users.Any(u => u.UserName == "Prezes"))
            {
                var user = new Uzytkownik { UserName = "prezes@AspNetMvc.pl" };
                var adminresult = manager.Create(user, "1234Abc,");
                if (adminresult.Succeeded)
                    manager.AddToRole(user.Id, "Admin");
            }
        }

        // Admin mo¿e wszystko (SZCZEGÓ£Y, EDYTUJ, USUÑ)
        // Pracownik mo¿e (EDUTUJ, DODAJ) nie mo¿e (USUÑ)
        // zwyk³y u¿ytkownik mo¿e wszystko (SZCZEGÓ£Y, EDYTUJ, USUÑ), ale tylko na swoich og³oszeniach
        private void SeedRoles(OglContext context)
        {
            var roleManager = 
                new RoleManager<Microsoft.AspNet.Identity.EntityFramework.IdentityRole>
                (new RoleStore<IdentityRole>());

            if (!roleManager.RoleExists("Admin"))
            {
                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                role.Name = "Admin";
                roleManager.Create(role);
            }
            if(!roleManager.RoleExists("Pracownik"))
            {
                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                role.Name = "Pracownik";
                roleManager.Create(role);
            }
        }
    }
}
