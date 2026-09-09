using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Text.Json;

namespace CodeStream20
{
    public class DataManager
    {
        public static List<Playlist> SongLibrary { get; set; } = new List<Playlist>();
        public static List<Playlist> UserPlaylists { get; set; } = new List<Playlist>();

        // Methods to handle  Serialization / File Persistence
        public static void SaveData(string filePath)
        {
            string json = JsonSerializer.Serialize(UserPlaylists);
            File.WriteAllText(filePath, json);
        }

        public static void LoadData(string filePath)
        {
            if (File.Exists(filePath))
            {
                string json = File.ReadAllText(filePath);
                UserPlaylists = JsonSerializer.Deserialize<List<Playlist>>(json) ?? new List<Playlist>();
            }
        }
    }
}
    

