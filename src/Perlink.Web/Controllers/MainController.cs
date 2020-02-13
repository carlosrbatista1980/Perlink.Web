using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Results;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Perlink.Data.Data;
using Perlink.Services;
using Perlink.Services.Base;
using Perlink.Web.Models;

namespace Perlink.Web.Controllers
{

    public class MainController : Controller
    {
        public MainService _service;

        public MainController(MainService service)
        {
            _service = service;
        }

        // GET: Main
        public async Task<ActionResult> Index()
        {
            var suits = _service.GetLawsuitList();
            return View(suits);
        }

        // GET: Main/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Main/Create
        public ActionResult Create()
        {
            return View();
        }

        
        public IActionResult Create(LawViewModel lawViewModel)
        {
            if (lawViewModel != null)
            {
                Lawsuit lawsuit = new Lawsuit();
                //lawsuit.SuitNumber = lawViewModel.numeroDoProcesso;
                //lawsuit.CourtCosts = lawViewModel.valor;
                //lawsuit.LawofficeId = lawViewModel.escritorioId;
                //lawsuit.SuitCreationTime = lawViewModel.dataDeCriacaoDoProcesso;

                var result = _service.Create(lawsuit);
                if (result == ServiceEnums.CreateState.Success)
                {
                    //return Created("", lawViewModel);
                }
            }

            //return RedirectToAction("Index", lawViewModel);
            return BadRequest();
        }

        // GET: Main/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Main/Edit/5
        [Microsoft.AspNetCore.Mvc.HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Main/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Main/Delete/5
        [Microsoft.AspNetCore.Mvc.HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}