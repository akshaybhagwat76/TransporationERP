using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TransportationERP.BL.Repository;
using TransportationERP.ViewModel;

namespace TransportationERP.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TransportationController : ControllerBase
    {
        private readonly ITransportation _Transportations;
        public TransportationController(ITransportation Transportations)
        {
            _Transportations = Transportations;

        }

        [HttpGet]
        [Route("GetTransportationFormInitialData")]
        public IActionResult GetTransportationsFormInitialData()
        {
            try
            {
                var list = _Transportations.GetTransportationFormInitialData();
                return Ok(list);
            }
            catch (Exception ex)
            {
                return StatusCode(200);
            }
        }
        [HttpPost]
        [Route("SaveTransportationData")]
        public IActionResult SaveTransportationData(SaveTransportationData model)
        {

            try
            {
                var res = _Transportations.SaveTransportationData(model);
                if (res)
                {
                    return Ok();
                }
                else
                {
                    return BadRequest();
                }


            }
            catch (Exception ex)
            {
                return BadRequest();
            }



        }






    }
}
