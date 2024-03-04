using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using api.Models;


namespace api.Controllers
{
    public class EcoPointsController : ControllerBase
    {
        private readonly List<EcopointsModel> ecopoints;

        public EcoPointsController()
        {
            ecopoints = new List<EcopointsModel>();
        }

        // GET: api/EcoPoints
        [HttpGet]
        public ActionResult<IEnumerable<EcopointsModel>> Get()
        {
            return Ok(ecopoints);
        }

        // GET: api/EcoPoints/5
        [HttpGet("{id}")]
        public ActionResult<EcopointsModel> Get(int id)
        {
            var ecopoint = ecopoints.Find(e => e.IdMaterial == id);
            if (ecopoint == null)
            {
                return NotFound();
            }
            return Ok(ecopoint);
        }

        // POST: api/EcoPoints
        [HttpPost]
        public ActionResult<EcopointsModel> Post([FromBody] EcopointsModel ecopoint)
        {
            ecopoints.Add(ecopoint);
            return CreatedAtAction(nameof(Get), new { id = ecopoint.IdMaterial }, ecopoint);
        }

        // PUT: api/EcoPoints/5
        [HttpPut("{id}")]
        public ActionResult<EcopointsModel> Put(int id, [FromBody] EcopointsModel ecopoint)
        {
            var index = ecopoints.FindIndex(e => e.IdMaterial == id);
            if (index == -1)
            {
                return NotFound();
            }
            ecopoints[index] = ecopoint;
            return Ok(ecopoint);
        }

        // DELETE: api/EcoPoints/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var index = ecopoints.FindIndex(e => e.IdMaterial == id);
            if (index == -1)
            {
                return NotFound();
            }
            ecopoints.RemoveAt(index);
            return NoContent();
        }
    }

}