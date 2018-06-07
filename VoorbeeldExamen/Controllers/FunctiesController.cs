using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using VoorbeeldExamen.Models;

namespace VoorbeeldExamen.Controllers
{
    public class FunctiesController : Controller
    {
        private VBEXDBContext db = new VBEXDBContext();

        // GET: Personeels/Create
        public ActionResult ProjectAanmaken()
        {
            return View();
        }
    }
}