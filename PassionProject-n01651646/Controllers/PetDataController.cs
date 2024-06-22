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
using System.Diagnostics;
using PassionProject_n01651646.Models;

namespace PassionProject_n01651646.Controllers
{
    public class PetDataController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/PetData/ListPets
        [HttpGet]
        [Route("api/PetData/ListPets")]


        public IEnumerable<PetDto> ListPets()
        {
            List<Pet> Pets = db.Pets.ToList();
            List<PetDto> PetDtos = new List<PetDto>();

            Pets.ForEach(p => PetDtos.Add(new PetDto()
            {
                PetId = p.PetId,
                Name = p.Name,
                Species = p.Species,
                Breed = p.Breed,
                Age = p.Age
            }));

            return PetDtos;
        }

        // GET: api/PetData/FindPet/5
        [ResponseType(typeof(Pet))]
        [HttpGet]
        [Route("api/PetData/FindPet/{id}")]


        public IHttpActionResult FindPet(int id)
        {
            Pet Pet = db.Pets.Find(id);
            if (Pet == null)
            {
                return NotFound();
            }

            PetDto PetDto = new PetDto()
            {
                PetId = Pet.PetId,
                Name = Pet.Name,
                Species = Pet.Species,
                Breed = Pet.Breed,
                Age = Pet.Age
            };

            return Ok(PetDto);
        }

        // POST: api/PetData/UpdatePet/5
        [ResponseType(typeof(void))]
        [HttpPost]
        [Route("api/PetData/UpdatePet/{id}")]
        public IHttpActionResult UpdatePet(int id, Pet pet)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != pet.PetId)
            {
                return BadRequest();
            }

            db.Entry(pet).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PetExists(id))
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


        // POST: api/PetData/AddPet
        [ResponseType(typeof(Pet))]
        [HttpPost]
        [Route("api/PetData/AddPet")]
        public IHttpActionResult AddPet(Pet pet)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Pets.Add(pet);
            db.SaveChanges();

            return Ok(pet);
        }

        // POST: api/PetData/DeletePet/5
        [ResponseType(typeof(Pet))]
        [HttpPost]
        [Route("api/PetData/DeletePet/{id}")]
        public IHttpActionResult DeletePet(int id)
        {
            Pet pet = db.Pets.Find(id);
            if (pet == null)
            {
                return NotFound();
            }

            db.Pets.Remove(pet);
            db.SaveChanges();

            return Ok();
        }
        // GET: api/PetData/ListInquiriesForPet/5
        [HttpGet]
        [Route("api/PetData/ListInquiriesForPet/{petid}")]
        public IEnumerable<InquiryDto> ListInquiriesForPet(int petid)
        {
            // Retrieve inquiries for the specified pet
            List<Inquiry> inquiries = db.Inquiries.Where(i => i.PetId == petid).ToList();
            List<InquiryDto> inquiryDtos = new List<InquiryDto>();

            inquiries.ForEach(i => inquiryDtos.Add(new InquiryDto()
            {
                InquiryId = i.InquiryId,
                PetName = i.PetName,
                PetId = i.PetId,
                Username = i.Username,
                InquiryText = i.InquiryText
            }));

            return inquiryDtos;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PetExists(int id)
        {
            return db.Pets.Count(e => e.PetId == id) > 0;
        }
    }
}
