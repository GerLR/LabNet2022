using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web.Mvc;
using TP4.EF.API.Models;

namespace TP4.EF.API.Controllers
{
    public class HomeController : Controller
    {
        string Baseurl = "https://swapi.dev/api";
        public async Task<ActionResult> Index()
        {
            List<StarWarsCharacterView> swCharacter = new List<StarWarsCharacterView>();
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

