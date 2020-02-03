using System;
namespace Youtube_PLL
{
    class Playlist
    {
        public string keyword { get; set; }
        public string channelId { get; set; }
        public string playlistId { get; set; }
        public string profile { get; set; }
        public DateTime createdAt { get; set; }

        public Playlist(string keyword, string channelId, string playlistId, string profile)
        {
            this.keyword = keyword;
            this.channelId = channelId;
            this.playlistId = playlistId;
            this.profile = profile;
            this.createdAt = DateTime.Now;
        }

        public Playlist(string keyword, string channelId, string playlistId, string profile, DateTime datetime)
        {
            this.keyword = keyword;
            this.channelId = channelId;
            this.playlistId = playlistId;
            this.profile = profile;
            this.createdAt = datetime;
        }
    }
}
