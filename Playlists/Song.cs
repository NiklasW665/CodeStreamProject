using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace CodeStream20.Playlists
{
    //this class represents a song object with properties for title, artist, album, genre, and file path.
    //Playlists now hold list<Song> instead of list<string> for better data management and to allow for more detailed song information.
    [Serializable]
    public class Song
    {
        //Song Individual properties
        public string Title { get; set; }
        public string Artist { get; set; }
        public string Album { get; set; }
        public string Genre { get; set; }
        public string FilePath { get; set; }

        //Default Constructor to easily instantiate a new song object
        public Song() { }

        //Parameterized Constructor to easily instantiate a new song object with all properties
        public Song(string title, string artist, string album, string genre, string filePath)
        {
            Title = title;
            Artist = artist;
            Album = album;
            Genre = genre;
            FilePath = filePath;
        }
    }
}
