namespace MusicLibraryBackend.Models
{
    public class Song
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Duration { get; set; }
        public string Genre { get; set; }
        public string AudioUrl { get; set; }
        public string Lyrics { get; set; }
        public int TrackNumber { get; set; }
        public int AlbumId { get; set; }
        public Album Album { get; set; }
        public int ArtistId { get; set; }
        public Artist Artist { get; set; }
        public ICollection<Playlist> Playlists { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
} 