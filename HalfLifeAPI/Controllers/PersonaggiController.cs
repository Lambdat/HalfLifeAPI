using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HalfLifeAPI.Data;
using HalfLifeAPI.Models;
using Utility;
using HalfLifeAPI.Services;

namespace HalfLifeAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PersonaggiController : ControllerBase
    {

        private IDAO<Personaggio> _iPersonaggiService = DAOPersonaggi.GetInstance();

        [HttpGet]
        public List<Personaggio> Leggi() 
        {
            return _iPersonaggiService.Leggi();
        }

    }
}
