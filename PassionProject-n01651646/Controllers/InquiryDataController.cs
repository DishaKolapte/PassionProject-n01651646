using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using PassionProject_n01651646.Models;

namespace PassionProject_n01651646.Controllers
{
    public class InquiryDataController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/InquiryData/ListInquiries
        [HttpGet]
        [Route("api/InquiryData/ListInquiries")]
        public IEnumerable<InquiryDto> ListInquiries()
        {
            List<Inquiry> Inquiries = db.Inquiries.ToList();
            List<InquiryDto> InquiryDtos = new List<InquiryDto>();

            Inquiries.ForEach(i => InquiryDtos.Add(new InquiryDto()
            {
                InquiryId = i.InquiryId,
                PetName = i.PetName,
                PetId = i.PetId,
                Username = i.Username,
                UserId = i.UserId,
                InquiryText = i.InquiryText
            }));

            return InquiryDtos;
        }

        // GET: api/InquiryData/FindInquiry/5
        [ResponseType(typeof(InquiryDto))]
        [HttpGet]
        [Route("api/InquiryData/FindInquiry/{id}")]
        public IHttpActionResult FindInquiry(int id)
        {
            Inquiry inquiry = db.Inquiries.Find(id);
            if (inquiry == null)
            {
                return NotFound();
            }

            InquiryDto InquiryDto = new InquiryDto()
            {
                InquiryId = inquiry.InquiryId,
                PetName = inquiry.PetName,
                PetId = inquiry.PetId,
                Username = inquiry.Username,
                UserId = inquiry.UserId,
                InquiryText = inquiry.InquiryText
            };

            return Ok(InquiryDto);
        }

        // POST: api/InquiryData/UpdateInquiry/5
        [ResponseType(typeof(void))]
        [HttpPost]
        [Route("api/InquiryData/UpdateInquiry/{id}")]
        public IHttpActionResult UpdateInquiry(int id, Inquiry inquiry)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != inquiry.InquiryId)
            {
                return BadRequest();
            }

            db.Entry(inquiry).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InquiryExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/InquiryData/AddInquiry
        [ResponseType(typeof(Inquiry))]
        [HttpPost]
        [Route("api/InquiryData/AddInquiry")]
        public IHttpActionResult AddInquiry(Inquiry inquiry)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Inquiries.Add(inquiry);
            db.SaveChanges();

            return Ok(inquiry);
        }

        // POST: api/InquiryData/DeleteInquiry/5
        [ResponseType(typeof(Inquiry))]
        [HttpPost]
        [Route("api/InquiryData/DeleteInquiry/{id}")]
        public IHttpActionResult DeleteInquiry(int id)
        {
            Inquiry inquiry = db.Inquiries.Find(id);
            if (inquiry == null)
            {
                return NotFound();
            }

            db.Inquiries.Remove(inquiry);
            db.SaveChanges();

            return Ok();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool InquiryExists(int id)
        {
            return db.Inquiries.Count(e => e.InquiryId == id) > 0;
        }
    }
}
