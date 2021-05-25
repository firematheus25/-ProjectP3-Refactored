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
    public class FuncionariosSindicais : ControllerBase
    {
        private readonly P3Context db;

        public FuncionariosSindicais(P3Context db)
        {
            this.db = db;
        }


        [HttpGet]
        public List<FuncionarioSindical> Get()
        {
            return db.FuncionarioSindical.ToList();
        }

        [HttpGet("Id/{Id}")]
        public FuncionarioSindical GetById(int Id)
        {
            return db.FuncionarioSindical.Where(X => X.FuncionarioSindicalId == Id).FirstOrDefault();
        }

        [HttpGet("Funcionario/{Id}")]
        public FuncionarioSindical GetByFuncionario(int Id)
        {
            return db.FuncionarioSindical.Where(X => X.FuncionariosId == Id).FirstOrDefault();
        }


        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult Post(FuncionarioSindical FuncionarioSindical)
        {
            db.FuncionarioSindical.Add(FuncionarioSindical);
            db.SaveChanges();
            return Ok();
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult Put(FuncionarioSindical FuncionarioSindical)
        {
            db.FuncionarioSindical.Update(FuncionarioSindical);
            db.SaveChanges();
            return Ok();
        }

        [HttpDelete("{Id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<FuncionarioSindical> Delete(int Id)
        {

            var Delete = db.FuncionarioSindical.Where(x => x.FuncionariosId == Id).FirstOrDefault();
            db.FuncionarioSindical.Remove(Delete);
            db.SaveChanges();
            return Ok();
        }
    }
}
