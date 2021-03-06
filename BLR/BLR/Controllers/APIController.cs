﻿using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace BLR.Controllers
{
    public class APIController : Controller
    {
        // GET: API
        const string userAgent = "Mozilla / 5.0(Windows NT 6.1; Win64; x64; rv: 47.0) Gecko / 20100101 Firefox / 47.0";

        // GET list of beer
        [HttpGet]
        public ActionResult GetBeer()
        {
            HttpWebRequest request = WebRequest.CreateHttp("https://api.punkapi.com/v2/beers?per_page=80&page=1");
            request.UserAgent = userAgent;
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            if (response.StatusCode == HttpStatusCode.OK)
            {
                StreamReader data = new StreamReader(response.GetResponseStream());

                string jsonData = data.ReadToEnd();
                JObject beerData = JObject.Parse("{beers:" + jsonData + "}");
                ViewBag.BeerList = beerData;
            }

            return View();
        }
    }
}