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
    public class accountBalancesController : ApiController
    {
        private DBModel db = new DBModel();

        // GET: api/accountBalances
        public IQueryable<accountBalance> GetaccountBalances()
        {
            return db.accountBalances;
        }

        // GET: api/accountBalances/5
        [ResponseType(typeof(accountBalance))]
        public IHttpActionResult GetaccountBalance(int id)
        {
            accountBalance accountBalance = db.accountBalances.Find(id);
            if (accountBalance == null)
            {
                return NotFound();
            }

            return Ok(accountBalance);
        }

        // PUT: api/accountBalances/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutaccountBalance(int id, accountBalance accountBalance)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != accountBalance.aB_Id)
            {
                return BadRequest();
            }

            db.Entry(accountBalance).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!accountBalanceExists(id))
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

        // POST: api/accountBalances
        [ResponseType(typeof(accountBalance))]
        public IHttpActionResult PostaccountBalance(accountBalance accountBalance)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.accountBalances.Add(accountBalance);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = accountBalance.aB_Id }, accountBalance);
        }

        // DELETE: api/accountBalances/5
        [ResponseType(typeof(accountBalance))]
        public IHttpActionResult DeleteaccountBalance(int id)
        {
            accountBalance accountBalance = db.accountBalances.Find(id);
            if (accountBalance == null)
            {
                return NotFound();
            }

            db.accountBalances.Remove(accountBalance);
            db.SaveChanges();

            return Ok(accountBalance);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool accountBalanceExists(int id)
        {
            return db.accountBalances.Count(e => e.aB_Id == id) > 0;
        }
    }
}