using Microsoft.AspNetCore.Mvc;
using MusicLibrarySystem.Models;
using System.Collections.Generic;

namespace MusicLibrarySystem.Controllers
{
    public class LibraryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Albums()
        {
            var albums = new List<Album>
            {
                new Album { Id = 1, Title = "Thriller", ArtistName = "Michael Jackson", CoverImageUrl = "https://picsum.photos/id/1/300/300", ReleaseYear = 1982, SongCount = 9 },
                new Album { Id = 2, Title = "Back in Black", ArtistName = "AC/DC", CoverImageUrl = "https://picsum.photos/id/2/300/300", ReleaseYear = 1980, SongCount = 10 },
                new Album { Id = 3, Title = "The Dark Side of the Moon", ArtistName = "Pink Floyd", CoverImageUrl = "https://picsum.photos/id/3/300/300", ReleaseYear = 1973, SongCount = 10 },
                new Album { Id = 4, Title = "Abbey Road", ArtistName = "The Beatles", CoverImageUrl = "https://picsum.photos/id/4/300/300", ReleaseYear = 1969, SongCount = 17 }
            };

            return View(albums);
        }

        public IActionResult Artists()
        {
            var artists = new List<Artist>
            {
                new Artist { Id = 1, Name = "Michael Jackson", ImageUrl = "https://picsum.photos/id/5/300/300", NumAlbums = 10, NumSongs = 120 },
                new Artist { Id = 2, Name = "AC/DC", ImageUrl = "https://picsum.photos/id/6/300/300", NumAlbums = 17, NumSongs = 185 },
                new Artist { Id = 3, Name = "Pink Floyd", ImageUrl = "https://picsum.photos/id/7/300/300", NumAlbums = 15, NumSongs = 167 },
                new Artist { Id = 4, Name = "The Beatles", ImageUrl = "https://picsum.photos/id/8/300/300", NumAlbums = 13, NumSongs = 213 }
            };

            return View(artists);
        }

        public IActionResult Songs()
        {
            var songs = new List<Song>
            {
                new Song { Id = 1, Title = "Billie Jean", ArtistName = "Michael Jackson", AlbumTitle = "Thriller", Duration = "4:54", CoverImageUrl = "https://picsum.photos/id/9/300/300" },
                new Song { Id = 2, Title = "Back in Black", ArtistName = "AC/DC", AlbumTitle = "Back in Black", Duration = "4:15", CoverImageUrl = "https://picsum.photos/id/10/300/300" },
                new Song { Id = 3, Title = "Money", ArtistName = "Pink Floyd", AlbumTitle = "The Dark Side of the Moon", Duration = "6:22", CoverImageUrl = "https://picsum.photos/id/11/300/300" },
                new Song { Id = 4, Title = "Come Together", ArtistName = "The Beatles", AlbumTitle = "Abbey Road", Duration = "4:19", CoverImageUrl = "https://picsum.photos/id/12/300/300" }
            };

            return View(songs);
        }
    }
}