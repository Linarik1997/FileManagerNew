using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManagerL.Core
{
    interface ITree<T>
    {
        TreeNode<T> GetRoot();
        TreeNode<T> AddItem(T value, TreeNode<T> Node);
        TreeNode<T> GetNodeByValue(T value);
        void PrintTree();
    }
}
