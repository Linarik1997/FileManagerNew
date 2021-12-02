using FileManagerL.Core.data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManagerL.Core
{
    public class FileSysInfo
    {
        public FileSysTree getDriveTree(string drive)
        {
            var drivers = Environment.GetLogicalDrives();
            if (drivers.Contains(drive))
            {
                var tree = TraverseDrive(drive);
                tree.RootNode.Value.Define = Definition.drive;
                return tree;
            }
            else
            {
                throw new Exception();
            }
        }
        public FileSysTree TraverseDirectory(string directory)
        {
            DirectoryInfo dirInfo = new DirectoryInfo(directory);
            var root = new FileSysNode(dirInfo);
            FileSysTree fileSysTree = new FileSysTree(root);

            FileInfo[] files = null;
            DirectoryInfo[] subDirs = null;

            try
            {
                files = dirInfo.GetFiles("*.*");
            }
            catch (UnauthorizedAccessException e)
            {
                Console.WriteLine(e.Message);
            }

            catch (System.IO.DirectoryNotFoundException e)
            {
                Console.WriteLine(e.Message);
            }
            catch
            {

            }

            if (files != null)
            {
                foreach (System.IO.FileInfo file in files)
                {
                    fileSysTree.AddItem(new FileSysData(file), root);
                }
                subDirs = dirInfo.GetDirectories();
                foreach(var subdir in subDirs)
                {
                    fileSysTree.AddItem(new FileSysData(subdir), root);
                }
            }
            return fileSysTree;
        }
        
        public FileSysTree getDirectoryTree(string directory)
        {
            return TraverseDrive(directory);
        }

        private FileSysTree TraverseDrive(string drive)
        {
            DirectoryInfo dirInfo = new DirectoryInfo(drive);
            var root = new FileSysNode(dirInfo);
            FileSysTree fileSysTree = new FileSysTree(root);

            Stack<FileSysNode> dirs = new Stack<FileSysNode>();
            if (!Directory.Exists(drive))
            {
                throw new ArgumentException();
            }
            dirs.Push(root);

            while (dirs.Count > 0)
            {
                var currentDir = dirs.Pop();
                DirectoryInfo[] subdirs;
                try
                {
                    subdirs = currentDir.GetDirectoryInfo().GetDirectories();
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
                    files = currentDir.GetDirectoryInfo().GetFiles();
                }

                catch (UnauthorizedAccessException e)
                {

                    Console.WriteLine(e.Message);
                    continue;
                }

                catch (System.IO.DirectoryNotFoundException e)
                {
                    Console.WriteLine(e.Message);
                    continue;
                }


                foreach(var file in files)
                {                    
                    try
                    {
                        fileSysTree.AddItem(new FileSysData(file), currentDir);
                    }
                    catch (System.IO.FileNotFoundException e)
                    {
                        Console.WriteLine(e.Message);
                        continue;
                    }
                }
                foreach (var subdir in subdirs)
                {
                    dirs.Push(
                        fileSysTree.AddItem(
                            new FileSysNode(subdir, currentDir))); 
                }
            }
            return fileSysTree;
        }
    }
}
