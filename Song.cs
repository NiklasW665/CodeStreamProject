using System;
using System.Collections.Generic;
using System.Text;

namespace CodeStream20
{
    public class Song
    {
        public string Name { get; set; } = string.Empty;
        public string Artist { get; set; } = string.Empty;
        public string Album { get; set; } = string.Empty;
        public string Genre { get; set; } = string.Empty;
        public string FilePath { get; set; } = string.Empty;

        // Empty constructor - lets you create a blank song and fill in details later
        public Song()
        {
        }

        // Simple constructor - just a name, used for quick/basic song creation
        public Song(string name)
        {
            Name = name;
        }

        // Full constructor - sets every property at once
        public Song(string name, string artist, string album, string genre, string filePath)
        {
            Name = name;
            Artist = artist;
            Album = album;
            Genre = genre;
            FilePath = filePath;
        }

        // Overload used when we have a duration (TimeSpan) instead of an album name.
        // Song doesn't currently store duration, so we just set Album to a default value here.
        public Song(string name, string artist, string genre, TimeSpan duration, string filePath)
        {
            Name = name;
            Artist = artist;
            Genre = genre;
            Album = "Unknown Album";
            FilePath = filePath;
        }
    }
}