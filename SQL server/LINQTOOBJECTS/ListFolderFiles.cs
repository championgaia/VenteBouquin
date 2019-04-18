using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoLinq
{
    public class ListFolderFiles
    {
        internal List<FileInfo> ShowLargeFilesWithoutLINQ(string path)
        {
            DirectoryInfo directory = new DirectoryInfo(path);

            FileInfo[] files = directory.GetFiles();
            var comparer = new FileInfoComparer();

            Array.Sort(files, comparer);

            var listResultats = new List<FileInfo>();

            //ne recuperer que les 5 premiers fichiers
            for (int i=0;i< 5;i++ )
            {
                System.Diagnostics.Debug.WriteLine(files[i].Name + " " + files[i].Length);
                listResultats.Add(files[i]);
            }
            return listResultats;
        }
        internal List<FileInfo> ShowLargeFilesWithLINQ(string path)
        {
            DirectoryInfo directory = new DirectoryInfo(path);
            FileInfo[] files = directory.GetFiles();
            var results = files.OrderByDescending(f => f.Length).Take(5).ToList();

            //seconde syntaxe
            //var results = (from file in new DirectoryInfo(path).GetFiles()
            //            orderby file.Length descending
            //            select file).Take(5).ToList();

            foreach (var file in results)
            {
                System.Diagnostics.Debug.WriteLine(file.Name + " " + file.Length);
            }
            return results;
        }
        public class FileInfoComparer : IComparer<FileInfo>
        {
            public int Compare(FileInfo x, FileInfo y)
            {
                if (y.Length > x.Length)
                    return 1;
                if (y.Length < x.Length)
                    return -1;
                return 0;
            }
        }


    }
 
}
