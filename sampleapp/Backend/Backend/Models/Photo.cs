namespace Backend.Models
{
    public class Photo
    {
        public int Id { get; set; }
        public int AlbumId { get; set; }
        public string ThumbnailUrl { get; set; }
    }
}