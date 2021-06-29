
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;

using API.Data;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase // click on UsersController and select quik fix then create a constructor for UsersController
    // it will generate  public class UsersController : ControllerBase (DataContext context){}
    //but we click on context then quick fix then choose create a field for a parameter to create the block of code below automatically
    {
        private readonly DataContext _context; // 

        public UsersController(DataContext context) // this is created automatically by step No **
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AppUser>>>GetUsers() // Inumerable -- must using system.collections;
        {
            /*
            var users = _context.Users.ToList(); // ToList() -- must using system.Linq ;
            return users;
            --------------------------------------------------------------
            Note : we can reduce this code to  return _context.Users.ToList(); as below: 
            */
            return await _context.Users.ToListAsync();
        }


        // api/users/3  :for example we will write this in the browser to get data for user id No.3 
        [HttpGet("{id}")]
        public async Task<ActionResult<AppUser>>GetUser(int id) // Inumerable -- must using system.collections;
        {
            /*
            var user = _context.Users.Find(id); 
            return user;
            ------------------------------------------------
            Note : we can reduce this code to  return _context.Users.Find(id); as below: 
            */
            return await  _context.Users.FindAsync(id);

        }

    }
}