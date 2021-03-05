using DAL.Models;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Servis.Controllers
{
    public class ServisController : ApiController
    {
        // GET: api/Servis
        public List<Urun> Get()
        {//veritabanında bulunan bütün ürünleri get işlemiyle çağırmış oluyorum
            using (AlisVerisContext context = new AlisVerisContext())
            {
                return context.Urunler.ToList();
            }
        }

        // GET: api/Servis/5
        public Urun Get(int id)
        {//ıd ye göre getirme işlemi
            using (AlisVerisContext context = new AlisVerisContext())
            {
                //id sini bildiğimiz bir ürününün bütün özelliklerini çağırma işlemi
                return context.Urunler.Single(u => u.id == id);
            }
        }

        // POST: api/Servis
        public bool Post(List<Satis> satisListesi)
        {
            try
            {
                using(AlisVerisContext context=new AlisVerisContext())
                {
                    context.Satislar.AddRange(satisListesi);
                    context.SaveChanges();
                    return true;
                }

            }
            catch (Exception)
            {

                return false;
            }
        }

        // PUT: api/Servis/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Servis/5
        public void Delete(int id)
        {
        }
    }
}
