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
    public class FolhaEspelhoController : ControllerBase
    {

        private readonly P3Context db;

        public FolhaEspelhoController(P3Context db)
        {
            this.db = db;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<FolhaEspelho> Post(FolhaEspelho Folha)
        {
            using (var transaction = db.Database.BeginTransaction())
            {
                foreach (var item in Folha.ListFolha)
                {
                    var folha = new Folha();
                    folha.FuncionariosId = item.FuncionariosId;
                    folha.Nome = item.Nome;
                    folha.MetodoPagamento = item.MetodoPagamento;
                    folha.Salario = item.Salario;
                    folha.DtPagamento = item.DtPagamento;                    


                    db.Folhas.Add(folha);
                    db.SaveChanges();

                }
                transaction.Commit();
                return Ok();
            }

        }
    }
}
