using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")] //https://localhost:5001/api/members
    public class MembersController(AppDbContext context) : ControllerBase
    {
            [HttpGet]  //synchronous uses thread 

        // public ActionResult<IReadOnlyList<AppUser>> GetMembers()
        //{
            //   var members = context.Users.ToList();

            //   return members;
        // }


// so we use asynchronous using asyn uses task
        public async Task<ActionResult<IReadOnlyList<AppUser>>> GetMembers()
        {
              var members = await context.Users.ToListAsync();

               return members;
        }

        [HttpGet("{id}")] //https://localhost:5001/api/members/harshitha-id

       // public ActionResult<AppUser> GetMember(string id)
       // {
       //     var member = context.Users.Find(id);

       //     if(member == null) return NotFound();

       //     return member;

       // }


          public async Task<ActionResult<AppUser>> GetMember(string id)
        {
            var member = await context.Users.FindAsync(id);

            if(member == null) return NotFound();

            return member;

        }
        
    }
}