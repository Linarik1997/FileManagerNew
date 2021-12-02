using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManagerL.Core.data
{
    public class FileSysNode: TreeNode<FileSysData>
    {
        public FileSysNode(object obj) : base(new FileSysData(obj)) { }
        public FileSysNode(object obj, FileSysNode parent) : base(new FileSysData(obj),parent) { }
        public DirectoryInfo GetDirectoryInfo()
        {
            var adress = this.Value.Adress;
            if (Directory.Exists(adress))
            {
                return new DirectoryInfo(adress);
            }
            else throw new Exception();
        }
        public FileInfo GetFileInfo()
        {
            var adress = this.Value.Adress;
            if (File.Exists(adress))
            {
                return new FileInfo(adress);
            }
            else throw new Exception();
        }
    }
}
