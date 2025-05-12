using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Music_Library_System.Models
{
    public class UserProfile
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Username is required")]
        [StringLength(50, ErrorMessage = "Username cannot be longer than 50 characters")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        public string Email { get; set; }

        public string ProfilePictureUrl { get; set; }

        [StringLength(500, ErrorMessage = "Bio cannot be longer than 500 characters")]
        public string Bio { get; set; }

        public DateTime JoinDate { get; set; }
        
        // Navigation properties
        public List<Playlist> Playlists { get; set; }
        public List<Song> FavoriteSongs { get; set; }
        public List<Album> FavoriteAlbums { get; set; }
        public List<Artist> FavoriteArtists { get; set; }
        
        // Additional properties
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
