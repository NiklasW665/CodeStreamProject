using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using CodeStream20.Playlists;

namespace CodeStream20
{
    [Serializable]
    public class Playlist
    {
        // Properties for individual Playlist attributes
        public string Title { get; set; } = string.Empty;
        public string Artist { get; set; } = string.Empty;
        public string Genre { get; set; } = string.Empty;
        public TimeSpan Duration { get; set; }
        public string FilePath { get; set; } = string.Empty;

        // Songs inside the playlist
        public List<Song> Songs { get; set; } = new List<Song>();

        // Owner of the playlist
        public string Owner { get; set; } = string.Empty;

        // True if the playlist is shared
        public bool IsShared { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;

        //constructor to easily insantiate a new playlist object
        public Playlist(string title, string artist, string genre, TimeSpan duration, string filePath)
        {
            Title = title;
            Artist = artist;
            Genre = genre;
            Duration = duration;
            FilePath = filePath;
        }

        //Method to add a song to the playlist
        public void AddSong(Song song)//changed the parameter type from string to Song to hold more detailed song information
        {
            Songs.Add(song);
        }
        public void RemoveSong(Song song)//changed the parameter type from string to Song to hold more detailed song information
        {
            Songs.Remove(song);
        }
    }
}
