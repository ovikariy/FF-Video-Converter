using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;

namespace FFVideoConverter
{

    public partial class App : Application
    {
        public App()
        {
            if (!TryFindPath(out var ffmpegDirectoryPath))
                throw new FileNotFoundException("ffmpeg path not found");
            Unosquare.FFME.Library.FFmpegDirectory = ffmpegDirectoryPath;
        }

        static bool TryFindPath(out string path)
        {
            var paths = new List<string>{
                Path.GetDirectoryName (typeof(App).Assembly.Location),
                Environment.CurrentDirectory,
            };
            paths.AddRange(Environment.GetEnvironmentVariable("PATH").Split(';'));
            foreach (var p in paths)
            {
                if (!File.Exists(Path.Combine(p, "ffmpeg.exe")))
                    continue;
                path = p;
                return true;
            }

            path = null;
            return false;
        }
    }
}
