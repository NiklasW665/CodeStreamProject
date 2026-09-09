using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace CodeStream20
{
    [Serializable]
    public class Playlist
    {
        // Properties for individual Playlist attributes
        public string Title { get; set; }
        public string Artist { get; set; }
        public string Genre { get; set; }
        public TimeSpan Duration { get; set; }
        public string FilePath { get; set; }

        //constructor to easily insantiate a new playlist object
        public Playlist(string title, string artist, string genre, TimeSpan duration, string filePath)
        {
            Title = title;
            Artist = artist;
            Genre = genre;
            Duration = duration;
            FilePath = filePath;
        }
    }
}
