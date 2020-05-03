using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Compression;
using System.IO;
using PlugIn;
using System.Text.RegularExpressions;

namespace Plugin1
{
    public class Plugin1 : IPlugin
    {
        public string Name
        {
            get { return "Deflate"; }
        }

        public string Extension
        {
            get { return ".gg"; }
        }
        public void Compress(string sourceFile)
        {

            Regex regex = new Regex(@"(\.[\w]+)*$");
            MatchCollection matches = regex.Matches(sourceFile);
            string compressedFile = sourceFile + ".gg";
            using (FileStream sourceStream = new FileStream(sourceFile, FileMode.OpenOrCreate))
            {
                using (FileStream targetStream = File.Create(compressedFile))
                {
          
                    using (DeflateStream compressionStream = new DeflateStream(targetStream, CompressionMode.Compress))
                    {
                        sourceStream.CopyTo(compressionStream);
                    }
                }
            }
            File.Delete(sourceFile);
        }
        public string Decompress(string compressedFile)
        {
            Regex regex = new Regex(@"(\.[\w]+){0,1}$");
            MatchCollection matches = regex.Matches(compressedFile);
            string targetFile = "";
            if (matches.Count == 1)
            {
                targetFile = compressedFile;
            }
            else
            {
                targetFile = compressedFile;
                targetFile = targetFile.Replace(matches[0].Groups[0].Value, "");
            }
            using (FileStream sourceStream = new FileStream(compressedFile, FileMode.OpenOrCreate))
            {
                using (FileStream targetStream = File.Create(targetFile))
                {
                    using (DeflateStream decompressionStream = new DeflateStream(sourceStream, CompressionMode.Decompress))
                    {
                        decompressionStream.CopyTo(targetStream);
                    }
                }
            }
            return targetFile;
        }
    }
}
