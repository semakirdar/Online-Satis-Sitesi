using DAL.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace OnlineSatisSitesi.Controllers
{
    public class AlisVerisListesiController : Controller
    {
        // GET: AlisVerisListesi
        public ActionResult Index()
        {
            return View();
        }
        public async Task<ActionResult> UrunleriGetir()
        {

            Session["müsteriId"] = 1;
           using (HttpClient client =new HttpClient() )
            {
                var response = await client.GetAsync("https://localhost:44350/api/Servis");
                var model = JsonConvert.DeserializeObject<List<Urun>>(response.Content.ReadAsStringAsync().Result);
                return View(model);
            }
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<bool> SatinAl(FormCollection form)
        {
            bool result = false;

            if (form.Count > 1 )
            {
                List<Satis> satisList = new List<Satis>();
                for (int i = 1; i < form.Count; i++)
                {
                    Satis satis = new Satis();
                    satis.musteriId = Convert.ToInt32(Session["musteriId"]);
                    satis.urunİd =int.Parse( form[i]);
                    satis.tarih = DateTime.Now;

                    satisList.Add(satis);
                }


                using (HttpClient client =new HttpClient())
                {
                    var data = JsonConvert.SerializeObject(satisList);
                    HttpContent content = new StringContent(data,System.Text.Encoding.UTF8,"application/json");

                    var returnResult = await client.PostAsync("https://localhost:44350/api/Servis",content);
                    result = bool.Parse(returnResult.Content.ReadAsStringAsync().Result);
                }
            }
            return result;
        }
    }
}