using Microsoft.AspNetCore.Mvc;
using FisherInsuranceApi.Data;
using FisherInsuranceApi.Models;

namespace FisherInsuranceApi.Controllers
{
    [Route("api/claims")]
    public class ClaimsController : Controller
    {
        [HttpPost]
        public IActionResult Post([FromBody]Claim claim)
        {
            return Ok(db.CreateClaim(claim));
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(db.RetrieveQuote(id));
        }
        [HttpPut("{id}")]
        public IActionResult Put([FromBody]Claim claim)
        {
            return Ok(db.UpdateClaim(claim));
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            db.DeleteClaim(id);
            return Ok();
        }
        private IMemoryStore db;

        public ClaimsController(IMemoryStore repo)
        {
            db = repo;
            
        }
        [HttpGet]
        public IActionResult GetClaims()
        {
        return Ok(db.RetrieveAllClaims);
        }

    }
}