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
    public class HoristaController : ControllerBase
    {

        private readonly P3Context db;

        public HoristaController(P3Context db)
        {
            this.db = db;
        }



        [HttpGet("Horistas/")]
        public List<FuncionarioVw> GetByHorista()
        {
            return db.FuncionarioVw.Where(X => X.HoristaId != null).ToList();
        }



        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult Post(Horista Horista)
        {
            db.Horista.Add(Horista);
            db.SaveChanges();
            return Ok();
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult Put(Horista Horista)
        {
            db.Horista.Update(Horista);
            db.SaveChanges();
            return Ok();
        }

    }
}
