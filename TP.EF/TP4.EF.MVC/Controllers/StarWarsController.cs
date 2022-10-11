using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using TP4.EF.MVC.Models;
using Newtonsoft.Json.Linq;

namespace TP4.EF.MVC.Controllers
{
    public class StarWarsController : Controller
    {
        // GET: StarWars
        string Baseurl = "https://swapi.dev/api";
        public async Task<ActionResult> Index()
        {
            List<StarWarsCharacterView>swCharacter = new List<StarWarsCharacterView>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage Res = await client.GetAsync("api/people");
                if (Res.IsSuccessStatusCode)
                {
                    var EmpResponse = Res.Content.ReadAsStringAsync().Result;
                    JObject objResponse1 = (JObject)JsonConvert.DeserializeObject(EmpResponse);
               
                    foreach (var sub_obj in objResponse1["results"])
                    {
                        JObject jswchar = sub_obj as JObject;
                        StarWarsCharacterView swchar = jswchar.ToObject<StarWarsCharacterView>();
                        swCharacter.Add(swchar);
                    }
                }
                return View(swCharacter);
            }
        }
      
    }
}