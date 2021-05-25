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
    public class TaxasServicoController : ControllerBase
    {
        private readonly P3Context db;

        public TaxasServicoController(P3Context db)
        {
            this.db = db;
        }



        [HttpGet]
        public List<TaxasServico> Get()
        {
            return db.TaxasServico.ToList();
        }

        [HttpGet("Ids/{Id}")]
        public List<TaxasServico> GetByIds(int Id)
        {
            return db.TaxasServico.Where(X => X.FuncionarioSindicalId == Id).ToList();
        }

        [HttpGet("Id/{Id}")]
        public TaxasServico GetById(int Id)
        {
            return db.TaxasServico.Where(X => X.TaxaServicoId == Id).FirstOrDefault();
        }


        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult Post(TaxasServico taxasServico)
        {
            db.TaxasServico.Add(taxasServico);
            db.SaveChanges();
            return Ok();
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult Put(TaxasServico TaxasServico)
        {
            db.TaxasServico.Update(TaxasServico);
            db.SaveChanges();
            return Ok();
        }

        [HttpDelete("{Id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<TaxasServico> Delete(int Id)
        {

            var Delete = db.TaxasServico.Where(x => x.TaxaServicoId == Id).FirstOrDefault();
            db.TaxasServico.Remove(Delete);
            db.SaveChanges();
            return Ok();
        }

    }
}
