using System;
using System.Collections.Generic;

namespace MusicLibraryBackend.Models
{
    public class UserProfile
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string ProfilePictureUrl { get; set; }
        public string Bio { get; set; }
        public DateTime JoinDate { get; set; }
        public List<Playlist> Playlists { get; set; }
        public List<Song> FavoriteSongs { get; set; }
        public List<Album> FavoriteAlbums { get; set; }
        public List<Artist> FavoriteArtists { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
} 