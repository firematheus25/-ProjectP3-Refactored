using ApiP3.DATA;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using miscellaneous.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiP3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AgendaPagamentoController : ControllerBase
    {

        private readonly P3Context db;

        public AgendaPagamentoController(P3Context db)
        {
            this.db = db;
        }

        [HttpGet]
        public List<AgendaPagamento> Get()
        {
            return db.AgendaPagamento.ToList();

        }

        [HttpGet("Id/{Id}")]
        public AgendaPagamento Get(int Id)
        {
            return db.AgendaPagamento.Where(X => X.AgendaId == Id).FirstOrDefault();

        }




        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<AgendaPagamento> Post(AgendaPagamento Agenda)
        {
            db.Add(Agenda);
            db.SaveChanges();
            return Ok();
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<AgendaPagamento> Put(AgendaPagamento Agenda)
        {
            db.Update(Agenda);
            db.SaveChanges();
            return Ok();
        }

        [HttpDelete("{Id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<AgendaPagamento> Delete(int Id)
        {
            var Delete = db.AgendaPagamento.Where(X => X.AgendaId == Id).FirstOrDefault();
            db.AgendaPagamento.Remove(Delete);
            db.SaveChanges();

            return Ok();
        }


    }
}
