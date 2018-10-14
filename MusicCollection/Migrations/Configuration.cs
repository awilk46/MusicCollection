namespace MusicCollection.Migrations
{
    using MusicCollection.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    /// <summary>
    /// This is Configuration Class. Used to create values to database by migrations.
    /// </summary>
    internal sealed class Configuration : DbMigrationsConfiguration<MusicCollection.DAL.MusicCollectionContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }
        protected override void Seed(MusicCollection.DAL.MusicCollectionContext context)
        {

            var bandCD = new List<BandCD> {

                 new BandCD { BandName = "Arctic Monkeys",
                     AlbumName = "Tranquility Base Hotel & Casino"},
                 new BandCD { BandName = "Arctic Monkeys",
                     AlbumName = "AM"},
                 new BandCD { BandName = "Arctic Monkeys",
                     AlbumName = "Suck It And See"},
                 new BandCD { BandName = "Arctic Monkeys",
                     AlbumName = "Humbug"},
                 new BandCD { BandName = "Arctic Monkeys",
                     AlbumName = "Favourite Worst Nightmare"},
                 new BandCD { BandName = "Arctic Monkeys",
                     AlbumName = "Whatever People Say I Am, That's What I'm Not"},
                 new BandCD { BandName = "Imagine Dragons",
                     AlbumName = "Night Visions"},
                 new BandCD { BandName = "Imagine Dragons",
                     AlbumName = "Smoke + Mirrors"},
                 new BandCD { BandName = "Imagine Dragons",
                     AlbumName = "Evolve"},
            };

            bandCD.ForEach(b => context.BandCDs.AddOrUpdate(p => p.BandName, b));
            bandCD.ForEach(a => context.BandCDs.AddOrUpdate(p => p.AlbumName, a));
            context.SaveChanges();

            var tracks = new List<Track> {
                new Track { BandCDId=bandCD.Single(a => a.AlbumName ==
                "Tranquility Base Hotel & Casino").BandCDId, TrackName = "Star Treatment"},
                new Track { BandCDId=bandCD.Single(a => a.AlbumName ==
                "Tranquility Base Hotel & Casino").BandCDId, TrackName = "One Point Perspective"},
                new Track { BandCDId=bandCD.Single(a => a.AlbumName ==
                "Tranquility Base Hotel & Casino").BandCDId, TrackName = "Golden Trunks"},
                new Track { BandCDId=bandCD.Single(a => a.AlbumName ==
                "Tranquility Base Hotel & Casino").BandCDId, TrackName = "The World's First Ever" +
                " Monster Truck Front Flip"},
                 new Track { BandCDId=bandCD.Single(a => a.AlbumName ==
                "Night Visions").BandCDId, TrackName = "Round and Round"},
                 new Track { BandCDId=bandCD.Single(a => a.AlbumName ==
                "Night Visions").BandCDId, TrackName = "Radioactive"},
                 new Track { BandCDId=bandCD.Single(a => a.AlbumName ==
                "Night Visions").BandCDId, TrackName = "Tiptoe"},
                 new Track { BandCDId=bandCD.Single(a => a.AlbumName ==
                "Night Visions").BandCDId, TrackName = "Demons"},
            };

            foreach (Track t in tracks)
            {
                var cdTracksInDataBase = context.Tracks.Where(
                    m => m.BandCD.BandCDId == t.BandCDId).SingleOrDefault();
                if (cdTracksInDataBase == null)
                {
                    context.Tracks.Add(t);
                }
            }
            context.SaveChanges();
        }
   
    }
}
