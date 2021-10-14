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
        private IDAO<Personaggio> _idao;

        public PersonaggiController(IDAO<Personaggio> _idao) //L'istanza sarà passata nel file Startup.cs sottoforma di pattern Dependency Injection
        {
            this._idao = _idao;
        }



        [HttpGet]
        public List<Personaggio> Leggi() 
        {
            return _idao.Leggi();
        }

        //Cerca con Wild Card {Id} passata per route
        [HttpGet("{id}")]
        public Personaggio Cerca([FromRoute]int id)
        {
            return _idao.Cerca(id);
        }

        [HttpPost]
        public IActionResult Aggiungi([FromBody] Personaggio p)
        {
            _idao.Aggiungi(p);

            return Ok(); //return del 200 OK di Postman
        }

        //Eliminazione con Wild Card {id} passata per route
        [HttpDelete("{id}")]
        public IActionResult Elimina([FromRoute] int id)
        {
            _idao.Elimina(id);

            return Ok();
        }
        
        //Modifica con Wild Card {id} passata per route
        [HttpPut("{id}")]
        public IActionResult Modifica([FromBody] Personaggio p, [FromRoute] int id)
        {
            _idao.Modifica(p, id);

            return Ok();
        }




    }
}
