using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicStoreAPI.Models
{
    public class MusicStoreModel : DbContext
    {
        public MusicStoreModel(DbContextOptions<MusicStoreModel>options): base(options)
        {

        }

        public DbSet<Album> Albums { get; set; }
    }
}
