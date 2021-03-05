using DAL.Models;
using System;
using System.Data.Entity;
using System.Linq;

namespace DAL
{
    public class AlisVerisContext : DbContext
    {
        // Your context has been configured to use a 'AlisVerisContext' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'DAL.AlisVerisContext' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'AlisVerisContext' 
        // connection string in the application configuration file.
        public AlisVerisContext()
            : base("name=AlisVerisDb")//veritabaný adý
        {
            Database.SetInitializer(new Configuration());
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

      public virtual DbSet<Urun>Urunler{ get; set; }
        public virtual DbSet<Satis> Satislar{ get; set; }
        public virtual DbSet<Musteri>Musteriler{ get; set; }

    }

    public class Configuration : CreateDatabaseIfNotExists<AlisVerisContext>
    {
        protected override void Seed(AlisVerisContext context)
        {
            context.Musteriler.Add(new Musteri { Ad = "Ali", Soyad = "Hazýr" });
            context.Musteriler.Add(new Musteri { Ad = "Cemre", Soyad = "Çabuk" });


            //ürünleri diziler þeklinde ekleyecez
            context.Urunler.AddRange(new Urun[]
                {//burada ürünleri model olarak tutuyoruz
                new Urun() {Ad="bilgisayar", Fiyat=3000, Resim="bilgisayar.jpg"},
                new Urun() {Ad="telefon", Fiyat=2000, Resim="telefon.jpg"},
                 new Urun() {Ad="saat", Fiyat=1000, Resim="saat.jpg"}
            });

            context.SaveChanges();//veritabanýna ekleme iþlemi yapýyor
        }
    }
}