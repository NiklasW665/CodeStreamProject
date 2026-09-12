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
        //for homepage
        //per user/ shared playlists in the playlist folder
        //playlslist/shared/playlistname.json or playlist/username/playlistname.json
        //playlist objects (playlist + list<song>) serialized to json
        //create the correct folder structure for the playlists and shared playlists
        public static string GetPlaylistFolder(string username, string playlistName, bool isShared)
        {
            string folderPath = isShared ? "Playlists/Shared" : $"Playlists/{username}";
            //Directory.CreateDirectory(folderPath); // Ensure the directory exists
            try
            {
                if(!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                }
            }
            catch (Exception)
            {
                // Handle the exception (e.g., log it, show a message to the user, etc.)
                throw; // Rethrow the exception for now
            }
            return Path.Combine(folderPath, $"{playlistName}.json");
        }

        //save a playlist to the correct folder structure
        public static void savePlaylist(Playlist playlist)
        {
            string folder = GetPlaylistFolder(playlist.Owner, playlist.Title, playlist.IsShared);
            string path = Path.Combine(folder, $"{playlist.Title}.json");
            string json = JsonSerializer.Serialize(playlist);// Serialize the playlist to JSON
            File.WriteAllText(path, json);// Save the playlist to the file
        }

        //load a playlist from the correct folder structure
        public static List<Playlist> loadUserPlaylists(string username, bool isShared)
        {
            string folder = isShared ? "Playlists/Shared" : $"Playlists/{username}";
            List<Playlist> playlists = new List<Playlist>();
            string ownFolder = GetPlaylistFolder(username, folder, isShared);
            string sharedFolder = GetPlaylistFolder(username, folder, isShared);
            
            loadPlaylistsFromFolder(ownFolder, playlists);
            loadPlaylistsFromFolder(sharedFolder, playlists); 
            
            return playlists;
        }

        public static void deletePlaylist(string folder, Playlist playlist)
        {
            string nfolder = GetPlaylistFolder(playlist.Owner, folder, playlist.IsShared);
            string path = Path.Combine(folder, playlist.Title + ".json");
            if(File.Exists(path))
            {
                File.Delete(path);
            }
        }
        public static void loadPlaylistsFromFolder(string folderPath, List<Playlist> playlists)
        {
            try
            {
                if (Directory.Exists(folderPath))
                {
                    string[] files = Directory.GetFiles(folderPath, "*.json");
                    foreach (string file in files)
                    {
                        string json = File.ReadAllText(file);
                        Playlist playlist = JsonSerializer.Deserialize<Playlist>(json);
                        if (playlist != null)
                        {
                            playlists.Add(playlist);
                        }
                    }
                }
            }
            catch (Exception ex) 
            { 
                
            }

        }
    }
}
    

