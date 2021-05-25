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
    public class FolhaController : ControllerBase
    {


        private readonly P3Context db;

        public FolhaController(P3Context db)
        {
            this.db = db;
        }


        [HttpGet]
        public List<Folha> Get()
        {
            return db.Folhas.ToList();

        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<Folha> Post(Folha Folha)
        {
            return Ok();
        }
    }
}
