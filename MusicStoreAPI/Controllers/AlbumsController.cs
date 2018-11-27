using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MusicStoreAPI.Models;

namespace MusicStoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlbumsController : ControllerBase
    {
        //db
        private MusicStoreModel db;

        public AlbumsController(MusicStoreModel db)
        {
            this.db = db;
        }

        //GET: api/albums
        [HttpGet]
        public IEnumerable<Album> Get()
        {
            return db.Albums.OrderBy(a => a.Title.ToList());
        }

        //GET: api/albums/4
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            Album album = db.Albums.SingleOrDefault(a => a.AlbumId == id);
            if(album == null)
            {
                return NotFound();
            }
            return Ok(album);
        }

        //POST: api/albums
        [HttpPost]
        public ActionResult Post([FromBody] Album album)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Albums.Add(album);
            db.SaveChanges();
            return CreatedAtAction("Post", new { id = album.AlbumId });
        }

        //Put: api/albums/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Album album)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Entry(album).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            db.SaveChanges();
            return AcceptedAtAction("Put", album);
        }

        //DELETE api/albums/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            Album album = db.Albums.SingleOrDefault(a => a.AlbumId == id);

            if(album == null)
            {
                return NotFound();
            }

            db.Albums.Remove(album);
            db.SaveChanges();
            return Ok();
        }
    }
}