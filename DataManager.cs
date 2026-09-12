using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;

namespace CodeStream20
{
    
    public class DataManager
    {
        private static readonly string[] IconExtensions = new[] { ".png", ".jpg", ".jpeg", ".gif", ".ico" };

        public static List<Playlist> SongLibrary { get; set; } = new List<Playlist>();
        public static List<Playlist> UserPlaylists { get; set; } = new List<Playlist>();

        // Methods to handle Serialization / File Persistence
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
        public static string GetPlaylistFolder(string username, bool isShared)
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
            return folderPath;
        } // this function only returns the path to the playlist file, not the folder. If you want to get the folder path, you can modify it to return just the folder without appending the playlist name and ".json".
        public static string GetPlaylistFilePath(Playlist playlist)
        {
            string folderPath = GetPlaylistFolder(playlist.Owner, playlist.IsShared);
            return Path.Combine(folderPath, $"{playlist.Title}.json");
        }//this function return the excat.json file path

        //save a playlist to the correct folder structure
        public static void savePlaylist(Playlist playlist)
        {
            string path = GetPlaylistFilePath(playlist);
            string json = JsonSerializer.Serialize(playlist);// Serialize the playlist to JSON
            File.WriteAllText(path, json);// Save the playlist to the file
        }

        public static void deletePlaylist(Playlist playlist)
        {
            string folder = GetPlaylistFolder(playlist.Owner, playlist.IsShared);
            string path = Path.Combine(folder, playlist.Title + ".json");
            if (File.Exists(path))
            {
                File.Delete(path);
            }

            for (int i = 0; i < IconExtensions.Length; i++)
            {
                string iconPath = Path.Combine(folder, playlist.Title + IconExtensions[i]);
                if (File.Exists(iconPath))
                {
                    File.Delete(iconPath);
                }
            try
                {
                    if (File.Exists(path)) File.Delete(path);
                    foreach (var ext in IconExtensions)
                    {
                       
                        if (File.Exists(iconPath)) File.Delete(iconPath);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Failed to delete playlist: {ex.Message}");
                }

            }
        }

        //load a playlist from the correct folder structure
        public static List<Playlist> loadUserPlaylists(string username)
        {
            List<Playlist> playlists = new List<Playlist>();
            string ownFolder = GetPlaylistFolder(username, false);
            string sharedFolder = GetPlaylistFolder(username, true);

            loadPlaylistsFromFolder(ownFolder, playlists);
            loadPlaylistsFromFolder(sharedFolder, playlists);
            UserPlaylists = playlists;
            return playlists;
        }
        public static void loadPlaylistsFromFolder(string folderPath, List<Playlist> playlists)
        {
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            string[] files = Directory.GetFiles(folderPath, "*.json");
            foreach (string file in files)
            {
                try
                {
                    string json = File.ReadAllText(file);
                    Playlist? playlist = JsonSerializer.Deserialize<Playlist>(json);
                    if (playlist != null)
                    {
                        playlists.Add(playlist);
                    }
                }
                catch (Exception)
                {
                    continue;
                } 
            }
        }
        // load cover art
        //returns the path to the cover art if it exists, otherwise returns null
        public static string? GetPlaylistIconPath(Playlist playlist)
        {
            // GetPlaylistFolder currently returns the playlist file path (folder + "<name>.json"),
            // so take its directory as the folder to search for icons.
            string folderPath = GetPlaylistFolder(playlist.Owner, playlist.IsShared);
            if (!Directory.Exists(folderPath))
                return null;

            foreach (var ext in IconExtensions)
            {
                string iconPath = Path.Combine(folderPath, playlist.Title + ext);
                if (File.Exists(iconPath))
                    return iconPath;
            }

            return null;
        }
        public static void SavePlaylistIcon(Playlist playlist, string iconFilePath)
        {
            string folderPath = GetPlaylistFolder(playlist.Owner, playlist.IsShared);
            string extension = Path.GetExtension(iconFilePath);
            if (Array.Exists(IconExtensions, ext => ext.Equals(extension, StringComparison.OrdinalIgnoreCase)))
            {
                string destinationPath = Path.Combine(folderPath, playlist.Title + extension);
                File.Copy(iconFilePath, destinationPath, true); // Overwrite if exists
            }
        }
    }
}
    

