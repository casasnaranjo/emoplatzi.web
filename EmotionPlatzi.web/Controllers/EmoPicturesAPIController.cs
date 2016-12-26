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
using EmoPlatzi.web.Models;
using EmotionPlatzi.web.Models;

namespace EmotionPlatzi.web.Controllers
{
    public class EmoPicturesAPIController : ApiController
    {
        private emotionplatzi db = new emotionplatzi();

        // GET: api/EmoPicturesAPI
        public IQueryable<EmoPicture> GetEmoPictures()
        {
            return db.EmoPictures;
        }

        // GET: api/EmoPicturesAPI/5
        [ResponseType(typeof(EmoPicture))]
        public IHttpActionResult GetEmoPicture(int id)
        {
            EmoPicture emoPicture = db.EmoPictures.Find(id);
            if (emoPicture == null)
            {
                return NotFound();
            }

            return Ok(emoPicture);
        }

        // PUT: api/EmoPicturesAPI/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutEmoPicture(int id, EmoPicture emoPicture)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != emoPicture.id)
            {
                return BadRequest();
            }

            db.Entry(emoPicture).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmoPictureExists(id))
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

        // POST: api/EmoPicturesAPI
        [ResponseType(typeof(EmoPicture))]
        public IHttpActionResult PostEmoPicture(EmoPicture emoPicture)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.EmoPictures.Add(emoPicture);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = emoPicture.id }, emoPicture);
        }

        // DELETE: api/EmoPicturesAPI/5
        [ResponseType(typeof(EmoPicture))]
        public IHttpActionResult DeleteEmoPicture(int id)
        {
            EmoPicture emoPicture = db.EmoPictures.Find(id);
            if (emoPicture == null)
            {
                return NotFound();
            }

            db.EmoPictures.Remove(emoPicture);
            db.SaveChanges();

            return Ok(emoPicture);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool EmoPictureExists(int id)
        {
            return db.EmoPictures.Count(e => e.id == id) > 0;
        }
    }
}