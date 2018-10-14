using MusicCollection.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;


namespace MusicCollection.DAL
{
    /// <summary>
    /// This is Context Class. Used to standardize 
    /// and package DB operation classes and the major goal is to realize the operation factorization of all kinds of DB.
    /// </summary>
    public class MusicCollectionContext : DbContext
    {

        public DbSet<Track> Tracks { get; set; }
        public DbSet<BandCD> BandCDs { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}