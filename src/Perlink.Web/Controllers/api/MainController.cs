using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using Perlink.Data.Data;
using Perlink.Services;
using Perlink.Services.Base;
using Perlink.Web.Models;
using Perlink.Web.Validations;
using FromBodyAttribute = Microsoft.AspNetCore.Mvc.FromBodyAttribute;

namespace Perlink.Web.Controllers.api
{
    public class MainController : ApiController
    {
        public MainService _service;

        public MainController(MainService service)
        {
            _service = service;
        }

        [Microsoft.AspNetCore.Mvc.Route("api/[controller]")]
        [Microsoft.AspNetCore.Mvc.HttpPost]
        public IHttpActionResult Create([FromBody] LawViewModel lawViewModel)
        {
            
            var validation = new MainValidator().Validate(lawViewModel);

            if (validation.IsValid)
            {
                Lawsuit ls = new Lawsuit();
                ls.SuitNumber = lawViewModel.NumeroDoProcesso;
                ls.SuitCreationTime = lawViewModel.dataDeCriacaoDoProcesso;
                ls.CourtCosts = lawViewModel.valor;
                ls.LawofficeId = lawViewModel.escritorioId;

                var result = _service.Create(ls);
                if (result == ServiceEnums.CreateState.Success)
                {
                    return Ok(result);
                }

                return StatusCode(HttpStatusCode.PartialContent);
            }

            return BadRequest();
        }
    }
}
