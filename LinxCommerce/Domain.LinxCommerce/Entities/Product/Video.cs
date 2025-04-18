namespace Domain.LinxCommerce.Entities.Product
{
    public class Video
    {
        public DateTime lastupdateon { get; set; }
        public string? Title { get; set; }
        public string? Url { get; set; }
        public Int32? MediaID { get; set; }

        public Video() { }

        public Video(Video video, Int32? mediaID)
        {
            this.lastupdateon = DateTime.Now;
            this.MediaID = mediaID;
            this.Title = video.Title;
            this.Url = video.Url;
        }
    }
}
