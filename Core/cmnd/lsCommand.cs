using FileManagerL.Core.data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManagerL.Core
{
    public class lsCommand : ICommand
    {
        public string CommandName { get; set; }
        public string PathName { get; set; }
        private FileSysInfo _fs { get; } = new FileSysInfo();
        public void Execute()
        {
            if(CommandName == "dir")
            {
                if (Directory.Exists(PathName))
                {
                    var tree = _fs.getDirectoryTree(PathName);
                    Form1._form1.ExecuteListing(tree);
                }
                else
                {
                    throw new DirectoryNotFoundException();
                }
            }
            if(CommandName == "/")
            {

            }

        }
    }
}
