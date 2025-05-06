using Microsoft.AspNetCore.Mvc;
using Music_Library_System.Models;
using System.Collections.Generic;
using System.Linq;

namespace Music_Library_System.Controllers
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
                new Album { 
                    Id = 1, 
                    Title = "Thriller", 
                    Description = "Michael Jackson's iconic album",
                    CoverImageUrl = "https://picsum.photos/id/1/300/300", 
                    ReleaseDate = new DateTime(1982, 11, 30),
                    Genre = "Pop",
                    Artist = new Artist { Id = 1, Name = "Michael Jackson" },
                    Songs = new List<Song>()
                },
                new Album { 
                    Id = 2, 
                    Title = "Back in Black", 
                    Description = "AC/DC's legendary album",
                    CoverImageUrl = "https://picsum.photos/id/2/300/300", 
                    ReleaseDate = new DateTime(1980, 7, 25),
                    Genre = "Rock",
                    Artist = new Artist { Id = 2, Name = "AC/DC" },
                    Songs = new List<Song>()
                },
                new Album { 
                    Id = 3, 
                    Title = "The Dark Side of the Moon", 
                    Description = "Pink Floyd's masterpiece",
                    CoverImageUrl = "https://picsum.photos/id/3/300/300", 
                    ReleaseDate = new DateTime(1973, 3, 1),
                    Genre = "Progressive Rock",
                    Artist = new Artist { Id = 3, Name = "Pink Floyd" },
                    Songs = new List<Song>()
                },
                new Album { 
                    Id = 4, 
                    Title = "Abbey Road", 
                    Description = "The Beatles' final album",
                    CoverImageUrl = "https://picsum.photos/id/4/300/300", 
                    ReleaseDate = new DateTime(1969, 9, 26),
                    Genre = "Rock",
                    Artist = new Artist { Id = 4, Name = "The Beatles" },
                    Songs = new List<Song>()
                }
            };

            return View(albums);
        }

        public IActionResult Artists()
        {
            var artists = new List<Artist>
            {
                new Artist { 
                    Id = 1, 
                    Name = "Michael Jackson", 
                    Biography = "The King of Pop",
                    ImageUrl = "https://picsum.photos/id/5/300/300", 
                    Genre = "Pop",
                    Country = "USA",
                    BirthDate = new DateTime(1958, 8, 29),
                    Albums = new List<Album>(),
                    Songs = new List<Song>()
                },
                new Artist { 
                    Id = 2, 
                    Name = "AC/DC", 
                    Biography = "Australian rock band",
                    ImageUrl = "https://picsum.photos/id/6/300/300", 
                    Genre = "Rock",
                    Country = "Australia",
                    Albums = new List<Album>(),
                    Songs = new List<Song>()
                },
                new Artist { 
                    Id = 3, 
                    Name = "Pink Floyd", 
                    Biography = "English progressive rock band",
                    ImageUrl = "https://picsum.photos/id/7/300/300", 
                    Genre = "Progressive Rock",
                    Country = "UK",
                    Albums = new List<Album>(),
                    Songs = new List<Song>()
                },
                new Artist { 
                    Id = 4, 
                    Name = "The Beatles", 
                    Biography = "English rock band",
                    ImageUrl = "https://picsum.photos/id/8/300/300", 
                    Genre = "Rock",
                    Country = "UK",
                    Albums = new List<Album>(),
                    Songs = new List<Song>()
                }
            };

            return View(artists);
        }

        public IActionResult Songs(string genre = null, string search = null)
        {
            var allSongs = new List<Song>
            {
                new Song { 
                    Id = 1, 
                    Title = "Billie Jean", 
                    Duration = "4:54", 
                    Genre = "Pop",
                    AudioUrl = "https://example.com/songs/billie-jean.mp3",
                    Lyrics = "She was more like a beauty queen...",
                    TrackNumber = 1,
                    Artist = new Artist { Id = 1, Name = "Michael Jackson" },
                    Album = new Album { Id = 1, Title = "Thriller", CoverImageUrl = "https://picsum.photos/id/1/400/400" }
                },
                new Song { 
                    Id = 2, 
                    Title = "Back in Black", 
                    Duration = "4:15", 
                    Genre = "Rock",
                    AudioUrl = "https://example.com/songs/back-in-black.mp3",
                    Lyrics = "Back in black...",
                    TrackNumber = 1,
                    Artist = new Artist { Id = 2, Name = "AC/DC" },
                    Album = new Album { Id = 2, Title = "Back in Black", CoverImageUrl = "https://picsum.photos/id/2/400/400" }
                },
                new Song { 
                    Id = 3, 
                    Title = "Money", 
                    Duration = "6:22", 
                    Genre = "Progressive Rock",
                    AudioUrl = "https://example.com/songs/money.mp3",
                    Lyrics = "Money, get away...",
                    TrackNumber = 6,
                    Artist = new Artist { Id = 3, Name = "Pink Floyd" },
                    Album = new Album { Id = 3, Title = "The Dark Side of the Moon", CoverImageUrl = "https://picsum.photos/id/3/400/400" }
                },
                new Song { 
                    Id = 4, 
                    Title = "Come Together", 
                    Duration = "4:19", 
                    Genre = "Rock",
                    AudioUrl = "https://example.com/songs/come-together.mp3",
                    Lyrics = "Here come old flat top...",
                    TrackNumber = 1,
                    Artist = new Artist { Id = 4, Name = "The Beatles" },
                    Album = new Album { Id = 4, Title = "Abbey Road", CoverImageUrl = "https://picsum.photos/id/4/400/400" }
                },
                new Song { 
                    Id = 5, 
                    Title = "Summer Vibes", 
                    Duration = "3:45", 
                    Genre = "Electronic",
                    AudioUrl = "https://example.com/songs/summer-vibes.mp3",
                    Lyrics = "Summer vibes...",
                    TrackNumber = 1,
                    Artist = new Artist { Id = 5, Name = "DJ Cool" },
                    Album = new Album { Id = 5, Title = "Summer Hits", CoverImageUrl = "https://picsum.photos/id/5/400/400" }
                },
                new Song { 
                    Id = 6, 
                    Title = "Midnight Dreams", 
                    Duration = "4:20", 
                    Genre = "Ambient",
                    AudioUrl = "https://example.com/songs/midnight-dreams.mp3",
                    Lyrics = "Midnight dreams...",
                    TrackNumber = 2,
                    Artist = new Artist { Id = 6, Name = "Ambient Master" },
                    Album = new Album { Id = 6, Title = "Night Sounds", CoverImageUrl = "https://picsum.photos/id/6/400/400" }
                }
            };

            // Always get all genres for the filter buttons
            ViewBag.Genres = allSongs.Select(s => s.Genre).Distinct().ToList();

            var songs = allSongs;
            if (!string.IsNullOrEmpty(genre))
            {
                songs = songs.Where(s => s.Genre.Equals(genre, System.StringComparison.OrdinalIgnoreCase)).ToList();
            }
            if (!string.IsNullOrEmpty(search))
            {
                songs = songs.Where(s =>
                    s.Title.Contains(search, System.StringComparison.OrdinalIgnoreCase) ||
                    s.Artist.Name.Contains(search, System.StringComparison.OrdinalIgnoreCase) ||
                    s.Album.Title.Contains(search, System.StringComparison.OrdinalIgnoreCase)
                ).ToList();
            }

            ViewBag.SelectedGenre = genre;
            ViewBag.Search = search;
            return View(songs);
        }

        public IActionResult FilterSongsByGenre(string genre, string search = null)
        {
            var allSongs = new List<Song>
            {
                new Song { 
                    Id = 1, 
                    Title = "Billie Jean", 
                    Duration = "4:54", 
                    Genre = "Pop",
                    AudioUrl = "https://example.com/songs/billie-jean.mp3",
                    Lyrics = "She was more like a beauty queen...",
                    TrackNumber = 1,
                    Artist = new Artist { Id = 1, Name = "Michael Jackson" },
                    Album = new Album { Id = 1, Title = "Thriller", CoverImageUrl = "https://picsum.photos/id/1/400/400" }
                },
                new Song { 
                    Id = 2, 
                    Title = "Back in Black", 
                    Duration = "4:15", 
                    Genre = "Rock",
                    AudioUrl = "https://example.com/songs/back-in-black.mp3",
                    Lyrics = "Back in black...",
                    TrackNumber = 1,
                    Artist = new Artist { Id = 2, Name = "AC/DC" },
                    Album = new Album { Id = 2, Title = "Back in Black", CoverImageUrl = "https://picsum.photos/id/2/400/400" }
                },
                new Song { 
                    Id = 3, 
                    Title = "Money", 
                    Duration = "6:22", 
                    Genre = "Progressive Rock",
                    AudioUrl = "https://example.com/songs/money.mp3",
                    Lyrics = "Money, get away...",
                    TrackNumber = 6,
                    Artist = new Artist { Id = 3, Name = "Pink Floyd" },
                    Album = new Album { Id = 3, Title = "The Dark Side of the Moon", CoverImageUrl = "https://picsum.photos/id/3/400/400" }
                },
                new Song { 
                    Id = 4, 
                    Title = "Come Together", 
                    Duration = "4:19", 
                    Genre = "Rock",
                    AudioUrl = "https://example.com/songs/come-together.mp3",
                    Lyrics = "Here come old flat top...",
                    TrackNumber = 1,
                    Artist = new Artist { Id = 4, Name = "The Beatles" },
                    Album = new Album { Id = 4, Title = "Abbey Road", CoverImageUrl = "https://picsum.photos/id/4/400/400" }
                },
                new Song { 
                    Id = 5, 
                    Title = "Summer Vibes", 
                    Duration = "3:45", 
                    Genre = "Electronic",
                    AudioUrl = "https://example.com/songs/summer-vibes.mp3",
                    Lyrics = "Summer vibes...",
                    TrackNumber = 1,
                    Artist = new Artist { Id = 5, Name = "DJ Cool" },
                    Album = new Album { Id = 5, Title = "Summer Hits", CoverImageUrl = "https://picsum.photos/id/5/400/400" }
                },
                new Song { 
                    Id = 6, 
                    Title = "Midnight Dreams", 
                    Duration = "4:20", 
                    Genre = "Ambient",
                    AudioUrl = "https://example.com/songs/midnight-dreams.mp3",
                    Lyrics = "Midnight dreams...",
                    TrackNumber = 2,
                    Artist = new Artist { Id = 6, Name = "Ambient Master" },
                    Album = new Album { Id = 6, Title = "Night Sounds", CoverImageUrl = "https://picsum.photos/id/6/400/400" }
                }
            };

            var songs = allSongs;
            if (!string.IsNullOrEmpty(genre))
            {
                songs = songs.Where(s => s.Genre.Equals(genre, System.StringComparison.OrdinalIgnoreCase)).ToList();
            }
            if (!string.IsNullOrEmpty(search))
            {
                songs = songs.Where(s =>
                    s.Title.Contains(search, System.StringComparison.OrdinalIgnoreCase) ||
                    s.Artist.Name.Contains(search, System.StringComparison.OrdinalIgnoreCase) ||
                    s.Album.Title.Contains(search, System.StringComparison.OrdinalIgnoreCase)
                ).ToList();
            }

            return PartialView("_SongsTablePartial", songs);
        }
    }
}