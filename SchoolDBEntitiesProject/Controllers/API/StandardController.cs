using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SchoolDBEntitiesProject.Models;
namespace SchoolDBEntitiesProject.Controllers.API
{
    [RoutePrefix("api/standard")]
    public class StandardController : ApiController
    {
        private SchoolDBEntitiesEntities foEntities = new SchoolDBEntitiesEntities();
        // GET: api/Standard
        public IHttpActionResult Get()
        {
            try
            {
                var foResults = foEntities.Standards.SqlQuery("SELECT * FROM Standard ORDER BY StandardName ASC").ToList();
                var result = new { Standard = foResults, Status = true, Message = "Standards are found", StatusCode = 200 };
                return Json(result);
            }catch(Exception ex)
            {
                var result = new { Status = false, Message = ex.ToString(), StatusCode = 500 };
                return Json(result);
            }
        }

        // GET: api/Standard/5
        public IHttpActionResult Get(int id)
        {
            try
            {
                var foResults = foEntities.Standards.SqlQuery("SELECT * FROM Standard WHERE StandardId = " + id).ToList();
                var result = new { Standard = foResults, Status = true, Message = "Standards are found", StatusCode = 200 };
                return Json(result);
            }
            catch (Exception ex) {
                var result = new { Status = false, Message = ex.ToString(), StatusCode = 500 };
                return Json(result);
            }
        }

        // POST: api/Standard
        public IHttpActionResult Post(Standard foStandard)
        {
            int x = 0;
            try
            {
                using (var ctx = new SchoolDBEntitiesEntities()) {
                    var lsStandard = new Standard()
                    {
                        StandardName = foStandard.StandardName,
                        Description = foStandard.Description
                    };
                    ctx.Standards.Add(lsStandard);
                    x = ctx.SaveChanges();
                }
                if(x > 0)
                {
                    var result = new { Status = true, Message = "Standard saved successfully", StatusCode = 200 };
                    return Json(result);
                }
                else
                {
                    var result = new { Status = false, Message = "Something went wrong", StatusCode = 500 };
                    return Json(result);
                }

            }
            catch (Exception ex) {
                var result = new { Status = false, Message = ex.ToString(), StatusCode = 500 };
                return Json(result);
            }
        }

        // PUT: api/Standard/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Standard/5
        public IHttpActionResult Delete(int id)
        {
            int y = 0;
            try
            {
                var lsStandard = foEntities.Standards.Where(x => x.StandardId == id).FirstOrDefault();
                foEntities.Standards.Remove(lsStandard);
                foEntities.Entry(lsStandard).State = System.Data.Entity.EntityState.Deleted;
                y = foEntities.SaveChanges();
                if(y > 0)
                {
                    var result = new { Status = true, Message = "Stanfard us deleted", StatusCode = 200};
                    return Json(result);
                }
                else
                {
                    var result = new { Status = false, Message = "Something went wrong", StatusCode = 500 };
                    return Json(result);
                }
            }
            catch (Exception ex) {
                var result = new { Status = false, Message = ex.ToString(), StatusCode = 500 };
                return Json(result);
            }
        }
    }
}
