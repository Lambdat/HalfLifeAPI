using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HalfLifeAPI.Data;
using HalfLifeAPI.Models;
using Utility;


namespace HalfLifeAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PersonaggiController : ControllerBase
    {
        //oggetto di tipo interfaccia = all instanza del DAO
        private IDAO<Personaggio> _iPersonaggiService = DAOPersonaggi.GetInstance();

        [HttpGet]
        public List<Personaggio> Leggi() 
        {
            return _iPersonaggiService.Leggi();
        }

        //Cerca con Wild Card {Id}
        [HttpGet("{id}")]
        public Personaggio Cerca([FromRoute]int id)
        {
            return _iPersonaggiService.Cerca(id);
        }

        [HttpPost]
        public IActionResult Aggiungi([FromBody] Personaggio p)
        {
            _iPersonaggiService.Aggiungi(p);

            return Ok();
        }

    }
}
