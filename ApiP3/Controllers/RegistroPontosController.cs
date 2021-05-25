using ApiP3.DATA;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using miscellaneous.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiP3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistroPontosController : ControllerBase
    {

        private readonly P3Context db;

        public RegistroPontosController(P3Context db)
        {
            this.db = db;
        }

        [HttpGet]
        public List<RegistroPonto> Get()
        {
            return db.RegistroPontos.ToList();
        }

        [HttpGet("Id/{Id}")]
        public RegistroPonto GetById(int Id)
        {
            return db.RegistroPontos.Where(X => X.RegistroPontoId == Id).FirstOrDefault();
        }

        [HttpGet("Ids/{Id}")]
        public List<RegistroPonto> GetByIds(int Id)
        {
            return db.RegistroPontos.Where(X => X.FuncionariosId == Id).ToList();
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult Post(RegistroPonto Ponto)
        {

            db.RegistroPontos.Add(Ponto);
            var Data = db.SaveChanges();
            return Ok(Data);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult Put(RegistroPonto Ponto)
        {
            db.RegistroPontos.Update(Ponto);
            var Data =db.SaveChanges();
            return Ok(Data);
        }

        [HttpDelete("{Id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<RegistroPonto> Delete(int Id)
        {

            var Delete = db.RegistroPontos.Where(x => x.RegistroPontoId == Id).FirstOrDefault();
            db.RegistroPontos.Remove(Delete);
            db.SaveChanges();
            return Ok();
        }
       


    }
}
