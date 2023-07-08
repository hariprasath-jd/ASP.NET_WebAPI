using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI_Main.Models;

namespace WebAPI_Main.Controllers
{
    [RoutePrefix("api/User")]
    public class UserController : ApiController
    {
        Models.AppContext context = new Models.AppContext();
        List<Sample> samples = new List<Sample>();
        // GET api/<controller>
        public HttpResponseMessage Get()
        {
            //Sample sam = new Sample() { Name="hari",Description="good",Age=18};
            //Sample sam1 = new Sample() { Name="arun",Description="good",Age=20};
            //LoginData data1 = new LoginData() { Id=1,Username="hari",Password="1234",Roles = "Admin"};
            //LoginData data2 = new LoginData() { Id=1,Username="arun",Password="1234",Roles = "Staff"};
            //context.Samples.Add(sam);
            //context.LoginDatas.Add(data1);
            //context.LoginDatas.Add(data2);
            //context.SaveChanges();
            //samples.Add(sam1);
            //samples.Add(sam);


            return Request.CreateResponse(HttpStatusCode.OK,samples);
        }

        //Returns all admin data
        [Auth_Valid.Authenticate]
        [Auth_Valid.Authorize(Roles ="Admin")]
        [Route("GetAdmin")]
        public List<LoginData> GetAdmin()
        {
            return context.LoginDatas.Where(data => data.Roles.Equals("Admin")).ToList();
        }

        //returns all user data
        [Auth_Valid.Authenticate]
        [Auth_Valid.Authorize(Roles ="Staff")]
        [Route("GetUser")]
        public List<LoginData> GetUser()
        {
            return context.LoginDatas.Where(data => data.Roles.Equals("Staff")).ToList();
        }

        // POST api/<controller>
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}
#if false
hello world;
#endif