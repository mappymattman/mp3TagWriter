using System;
using System.IO;

namespace mp3TagWriter
{
    class Program
    {
        static void Main(string[] args)
        {
            //Folder Path
            string folderPath = @"E:\YTDL\Downloads\GS";
            string[] files = Directory.GetFiles(folderPath);
            TagLib.File mp3 = null;
            string updatedPath = string.Empty;
            int trackNum = 1;
            foreach (string file in files)
            {
                string title = Path.GetFileNameWithoutExtension(file);

                //Replace special characters/extra spaces from title
                string updatedTitle = title.Replace("\t", " ");
                while (updatedTitle.IndexOf("  ") > 0)
                {
                    updatedTitle = updatedTitle.Replace("  ", " ");
                }

                foreach (char invalidChar in Path.GetInvalidFileNameChars())
                {
                    updatedTitle = updatedTitle.Replace(invalidChar.ToString(), String.Empty);
                }

                using (TagLib.File f = TagLib.File.Create(file))
                {
                    f.Tag.Title = updatedTitle.Trim();
                    f.Tag.Track = (uint)trackNum;
                    f.Tag.Album = "Golf Story";
                    f.Tag.Year = 2018;
                    //string[] albumArtists = new string[1];
                    //albumArtists[0] = "The Legend of Zelda";
                    //f.Tag.AlbumArtists = albumArtists;
                    //f.Tag.Album = "Breath of the Wild";
                    //f.Tag.Performers = albumArtists;
                    //f.Tag.Year = 2017;
                    f.Save();
                }

                trackNum = trackNum + 1;

            }
            Console.WriteLine("DONE");
            Console.ReadLine();
        }
    }
}
