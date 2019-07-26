using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CustomerSupport.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CustomerSupport.Controllers
{
    [Produces("application/json")]
    [Route("api/Complaints")]
    public class ComplaintsController : ControllerBase
    {

        readonly ComplaintDBContext complaintDBContext;

        public ComplaintsController(ComplaintDBContext context)
        {
            complaintDBContext = context;
        }

        // GET: api/Complaints
        [HttpGet]
        public IEnumerable<Complaint> Get()
        {
            return complaintDBContext.Complaint.ToList();
        }

        // GET: api/Complaints/5
        [HttpGet("{id}", Name = "Get")]
        public Complaint Get(int id)
        {
            return complaintDBContext.Complaint.FirstOrDefault(e => e.Id == id);
        }

        // GET:api/complaints?unit=1
        [HttpGet("unit/{unit}", Name = "GetByUnit")]
        public IEnumerable<Complaint> GetComplaintsByUnit(int unit)
        {
            return complaintDBContext.Complaint.Where(e => e.CompanyUnit == unit).ToList();
        }

        // POST: api/Complaints
        [HttpPost]
        public IActionResult Post([FromBody]Complaint complaint)
        {
            if (complaint == null)
            {
                return BadRequest(new { message = "Complaint is null" });
            }

            complaintDBContext.Complaint.Add(complaint);
            complaintDBContext.SaveChanges();

            return CreatedAtRoute("Get", new { id = complaint.Id }, complaint);
        }
        
        // PUT: api/Complaints/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]Complaint complaint)
        {
            if (complaint == null)
            {
                return BadRequest(new { message = "Complaint is null" });
            }

            Complaint complaintToUpdate = complaintDBContext.Complaint.FirstOrDefault(e => e.Id == id);

            if (complaintToUpdate == null)
            {
                return NotFound(new { message = "Complaint not found" });
            }

            complaintToUpdate.Resolved = complaint.Resolved;
            complaintDBContext.SaveChanges();
            return Ok();
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Complaint complaint = complaintDBContext.Complaint.FirstOrDefault(e => e.Id == id);
            try
            {
                complaintDBContext.Complaint.Remove(complaint);
                complaintDBContext.SaveChanges();
                return NoContent();
            } catch(Exception)
            {
                return NotFound(new { message = "Unable to delete complaint" });
            }
        }
    }
}
