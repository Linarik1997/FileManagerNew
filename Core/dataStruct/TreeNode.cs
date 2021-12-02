using System;
using System.Collections.Generic;

namespace FileManagerL.Core
{
    public class TreeNode<T>
    {
        public T Value { get; set; }
        public TreeNode<T> Parent { get; set; }
        public List<TreeNode<T>> Children { get; set; }
        public TreeNode() { }
        public TreeNode(T value)
        {
            Value = value;
            Children = new List<TreeNode<T>>();
        }
        public TreeNode(T value, TreeNode<T> parent)
        {
            Value = value;
            Parent = parent;
            Children = new List<TreeNode<T>>();
        }
        internal void PrintNodes(string indent, bool last)
        {
            Console.Write(indent);
            if (last)
            {
                Console.Write("└─");
                indent += "  ";
            }
            else
            {
                Console.Write("├─");
                indent += "| ";
            }
            var stringValue = Value.ToString();
            Console.WriteLine(stringValue);
            if(this.Children.Count>0)
            {
                for(int i = 0; i < Children.Count; i++)
                {
                    if(i == Children.Count - 1)
                    {
                        Children[Children.Count - 1].PrintNodes(indent, true);
                    }
                    else
                    {
                        Children[i].PrintNodes(indent, false);
                    }
                }
            }
        }

    }
}