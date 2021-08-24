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
using web_api.Models;

namespace web_api.Controllers
{
    public class paymentListsController : ApiController
    {
        private DBModel db = new DBModel();

        // GET: api/paymentLists
        public IQueryable<paymentList> GetpaymentLists()
        {
            return db.paymentLists;
        }

        // GET: api/paymentLists/5
        [ResponseType(typeof(paymentList))]
        public IHttpActionResult GetpaymentList(int id)
        {
            paymentList paymentList = db.paymentLists.Find(id);
            if (paymentList == null)
            {
                return NotFound();
            }

            return Ok(paymentList);
        }

        // PUT: api/paymentLists/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutpaymentList(int id, paymentList paymentList)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != paymentList.pL_Id)
            {
                return BadRequest();
            }

            db.Entry(paymentList).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!paymentListExists(id))
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

        // POST: api/paymentLists
        [ResponseType(typeof(paymentList))]
        public IHttpActionResult PostpaymentList(paymentList paymentList)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.paymentLists.Add(paymentList);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = paymentList.pL_Id }, paymentList);
        }

        // DELETE: api/paymentLists/5
        [ResponseType(typeof(paymentList))]
        public IHttpActionResult DeletepaymentList(int id)
        {
            paymentList paymentList = db.paymentLists.Find(id);
            if (paymentList == null)
            {
                return NotFound();
            }

            db.paymentLists.Remove(paymentList);
            db.SaveChanges();

            return Ok(paymentList);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool paymentListExists(int id)
        {
            return db.paymentLists.Count(e => e.pL_Id == id) > 0;
        }
    }
}