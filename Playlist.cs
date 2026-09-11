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
        public string Title { get; set; }
        public string Artist { get; set; }
        public string Genre { get; set; }
        public TimeSpan Duration { get; set; }
        public string FilePath { get; set; }
        //songs inside the playlist
        public List<Song> Songs { get; set; } //Tamia- i created class Song.cs to hold more detailed song information, but for now, we will keep the list of songs as a list of strings.
        //i also added the owner var to see who created the playlist, but we can remove it if we want to keep the playlist more generic
        public string Owner { get; set; }
        //true or false var if user what others to see their playlist or not
        public bool IsShared { get; set; }

        //constructor to easily insantiate a new playlist object
        public Playlist(string title, string artist, string genre, TimeSpan duration, string filePath)
        {
            Title = title;
            Artist = artist;
            Genre = genre;
            Duration = duration;
            FilePath = filePath;
            //create a new empty list of songs
            Songs = new List<Song>();//update this to List<Song> instead of List<string> to hold more detailed song information
        }

        //Method to add a song to the playlist
        public void AddSong(Song songTitle)//changed the parameter type from string to Song to hold more detailed song information
        {
            Songs.Add(songTitle);
        }
        public void RemoveSong(Song songTitle)//changed the parameter type from string to Song to hold more detailed song information
        {
            Songs.Remove(songTitle);
        }
    }
}
