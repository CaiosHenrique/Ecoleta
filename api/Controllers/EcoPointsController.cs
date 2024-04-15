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
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<EcopointsModel>> GetAll()
        {
            try
            {
                return StatusCode(200, ecopoints);
            }
            catch (System.Exception)
            {
                return StatusCode(500);
            }
        }

        // GET: api/EcoPoints/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<EcopointsModel> Get(int id)
        {
            try
            {
            var ecopoint = ecopoints.Find(e => e.IdMaterial == id);
            if (ecopoint == null)
            {
                return StatusCode(404);
            }
            return StatusCode(200, ecopoint);
            }
            catch (System.Exception)
            {
                return StatusCode(500);
            }
        }

        // POST: api/EcoPoints
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<EcopointsModel> Post([FromBody] EcopointsModel ecopoint)
        {
            try
            {
                ecopoints.Add(ecopoint);
                return StatusCode(201, ecopoint);
            }
            catch (System.Exception ex)
            {
                return StatusCode(400, ex.Message);
            }
        }

        // PUT: api/EcoPoints/5
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<EcopointsModel> Put(int id, [FromBody] EcopointsModel ecopoint)
        {
            try
            {
                var index = ecopoints.FindIndex(e => e.IdMaterial == id);
                if (index == -1)
                {
                    return StatusCode(404);
                }
                ecopoints[index] = ecopoint;
                return StatusCode(200, ecopoint);
            }
            catch (System.Exception)
            {
                return StatusCode(500);
            }
        }

        // DELETE: api/EcoPoints/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult Delete(int id)
        {
            try
            {
            var index = ecopoints.FindIndex(e => e.IdMaterial == id);
            if (index == -1)
            {
                return StatusCode(404);
            }
            ecopoints.RemoveAt(index);
            return StatusCode(200);
            }
            catch (System.Exception)
            {
                return StatusCode(500);
            }
        }
    }

}