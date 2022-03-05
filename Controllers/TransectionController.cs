using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TransportationERP.BL.Repository;

namespace TransportationERP.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TransectionController : ControllerBase
    {






        private readonly ITransection _transection;
        public TransectionController(ITransection transection)
        {
            _transection = transection;

        }

        [HttpGet]
        [Route("GetTransectionsListForDT")]
        public IActionResult GetTransectionsListForDT(string user_id)
        {

            try
            {
                var list = _transection.GetTransectionDT(user_id);
                return Ok(list);
            }
            catch (Exception ex)
            {
                return StatusCode(200);
            }

        }



        [HttpGet]
        [Route("GetDetailsOfTicket")]
        public IActionResult GetDetailsOfTicket(string ticket_no)
        {

            try
            {
                var obj = _transection.GetDetailsOfTicket(ticket_no);
                return Ok(obj);
            }
            catch (Exception ex)
            {
                return StatusCode(200);
            }

        }




    }
}
