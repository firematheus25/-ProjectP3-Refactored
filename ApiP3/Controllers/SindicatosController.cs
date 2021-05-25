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
    public class SindicatosController : ControllerBase
    {

        private readonly P3Context db;

        public SindicatosController(P3Context db)
        {
            this.db = db;
        }

        [HttpGet]
        public List<Sindicato> Get()
        {
            return db.Sindicato.ToList();
        }

        [HttpGet("Id/{Id}")]
        public Sindicato GetById(int Id)
        {
            return db.Sindicato.Where(X => X.SindicatosId == Id).FirstOrDefault();
        }



        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult Post(Sindicato Sindicato)
        {
            db.Sindicato.Add(Sindicato);
            var Data = db.SaveChanges();
            return Ok(Data);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult Put(Sindicato Sindicato)
        {
            db.Sindicato.Update(Sindicato);
            var Data = db.SaveChanges();
            return Ok(Data);
        }

        [HttpDelete("{Id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<Sindicato> Delete(int Id)
        {

            var Delete = db.Sindicato.Where(x => x.SindicatosId == Id).FirstOrDefault();
            db.Sindicato.Remove(Delete);
            db.SaveChanges();
            return Ok();
        }
    }
}
