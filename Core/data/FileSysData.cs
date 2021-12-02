using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManagerL.Core.data
{
    public enum Definition
    {
        file,
        directory,
        drive,
        unknown
    }
    public class FileSysData
    {
        public Definition Define { get; set; }
        public string Name { get; set; }
        public string Adress { get; set; }
        public long Size
        {
            get
            {
                switch (Define)
                {
                    case Definition.file:
                        return GetSizeOfFile();
                    default:
                        return GetSizeOfDir();
                }
            }
        }

        //public FileSysData(string name, Definition def)
        //{
        //    Name = name;
        //    Define = def;
        //}
        public FileSysData(object obj)
        {
            
            if(obj.GetType() == typeof(FileInfo))
            {
                this.Name = (obj as FileInfo).Name;
                this.Adress = (obj as FileInfo).FullName;
                this.Define = Definition.file;
            }
            else if(obj.GetType() == typeof(DirectoryInfo))
            {
                this.Name = (obj as DirectoryInfo).Name;
                this.Adress = (obj as DirectoryInfo).FullName;
                this.Define = Definition.directory;
            }
            else
            {
                Name = obj.ToString();
                Define = Definition.unknown;
            }
        }
        public override string ToString()
        {
            return $"{Define} {Name}";
        }
        private long GetSizeOfFile()
        {
            long size = -1;
            try
            {
                FileInfo file = new FileInfo(Adress);
                size = file.Length;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return size;
        }
        private long GetSizeOfDir()
        {
            long size = -1;
            try
            {
                DirectoryInfo di = new DirectoryInfo(Adress);
                size = Traverse(di);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return size;
        }
        private long Traverse(DirectoryInfo directory)
        {
            long size = 0;
            Stack<DirectoryInfo> dirs = new Stack<DirectoryInfo>();
            if (!directory.Exists)
            {
                throw new ArgumentException();
            }
            dirs.Push(directory);

            while (dirs.Count > 0)
            {
                var currentDir = dirs.Pop();
                DirectoryInfo[] subdirs;
                try
                {
                    subdirs = currentDir.GetDirectories();
                }
                catch (UnauthorizedAccessException e)
                {
                    Console.WriteLine(e.Message);
                    continue;
                }
                catch (DirectoryNotFoundException e)
                {
                    Console.WriteLine(e.Message);
                    continue;
                }


                FileInfo[] files = null;
                try
                {
                    files = currentDir.GetFiles();
                }

                catch (UnauthorizedAccessException e)
                {

                    Console.WriteLine(e.Message);
                    continue;
                }

                catch (DirectoryNotFoundException e)
                {
                    Console.WriteLine(e.Message);
                    continue;
                }


                foreach (var file in files)
                {
                    try
                    {
                        size += file.Length;
                    }
                    catch (FileNotFoundException e)
                    {
                        Console.WriteLine(e.Message);
                        continue;
                    }
                }
                foreach (var subdir in subdirs)
                {
                    dirs.Push(subdir);
                }
            }
            return size;
        }
    }
}
