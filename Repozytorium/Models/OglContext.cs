using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity.ModelConfiguration.Conventions;
using Repozytorium.Models;
using Repozytorium.IRepo;
using System;

namespace Repozytorium.Models
{
    public class OglContext : IdentityDbContext, IOglContext
    {
        public OglContext()
            : base("DefaultConnection")
        {
        }

        public static OglContext Create()
        {
            return new OglContext();
        }

        public DbSet<Kategoria> Kategorie { get; set; }
        public DbSet<Ogloszenie> Ogloszenia { get; set; }
        public DbSet<Uzytkownik> Uzytkownik { get; set; }
        public DbSet<Ogloszenie_Kategoria> Ogloszenie_Kategoria { get; set; }
        public DbSet<CV> CV { get; set; }
        public DbSet<Doswiadczenie> Doswiadczenie { get; set; }
        public DbSet<Wymaganie> Wymaganie { get; set; }
        public DbSet<Miasto> Miasto { get; set; }
        public DbSet<RodzajUmowy> RodzajUmowy { get; set; }
        public DbSet<Wiadomosc> Wiadomosc { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            // Wyłącza konwencję CascadeDelete
            // CascadeDelete zostanie włączone za pomocą Fluent API
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            // używa się Fluent API, aby ustalić powiązanie pomiędzy tabelami 
            // i włączyć CascadeDelete dla tego powiązania

            modelBuilder.Entity<Ogloszenie>().
                HasRequired(x => x.Uzytkownik).
                WithMany(x => x.Ogloszenia).
                HasForeignKey(x => x.UzytkownikId).
                WillCascadeOnDelete(true);
        }
    }
}