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
    public class ComissionadoController : ControllerBase
    {
        private readonly P3Context db;

        public ComissionadoController(P3Context db)
        {
            this.db = db;
        }

        [HttpGet("Comissionados/")]
        public List<FuncionarioVw> GetByComissionado()
        {
            return db.FuncionarioVw.Where(X => X.ComissionadoId != null).ToList();
        }


        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult Post(Comissionado Comissionado)
        {
            db.Comissionado.Add(Comissionado);
            db.SaveChanges();
            return Ok();
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult Put(Comissionado Comissionado)
        {
            db.Comissionado.Update(Comissionado);
            db.SaveChanges();
            return Ok();
        }
    }
}
