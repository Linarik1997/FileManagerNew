using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManagerL.Core.data
{
    public class FileSysTree: Tree<FileSysData>
    {
        public FileSysTree(FileSysNode root) : base(root) { }

        internal FileSysNode AddItem(FileSysNode node)
        {
            node.Parent.Children.Add(node);
            return node;
        }

    }
}
