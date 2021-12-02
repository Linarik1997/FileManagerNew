using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManagerL.Core
{
    public class Tree<T> : ITree<T>
    {
        public TreeNode<T> RootNode { get; set; }




        public Tree(){}
        public Tree(T rootValue)
        {
            var root = new TreeNode<T>(rootValue, null);
            RootNode = root;
        }
        public Tree(TreeNode<T> root)
        {
            RootNode = root;
        }
        public TreeNode<T> AddItem(T value, TreeNode<T> Node)
        {
            var node = new TreeNode<T>(value);
            node.Parent = Node;
            Node.Children.Add(node);
            return node;
        }

        public TreeNode<T> GetNodeByValue(T value)
        {
            return BFSearch(value);
        }

        public TreeNode<T> GetRoot()
        {
            return RootNode;
        }
        public void PrintTree()
        {
            RootNode.PrintNodes("",true);
        }
        private TreeNode<T> BFSearch(T searchValue)
        {
            var root = RootNode;
            Queue<TreeNode<T>> q = new Queue<TreeNode<T>>();
            q.Enqueue(root);
            Console.WriteLine($"Добавлен в очередь узел с Value:{RootNode.Value}");
            while (q.Count>0)
            {
                var node = q.Dequeue();
                Console.WriteLine($"Вытащили из очередь узел с Value:{node.Value}");
                if (node.Value.Equals(searchValue))
                {
                    Console.WriteLine($"Найден искомый узел с Value:{node.Value}");
                    return node;
                }
                else
                {
                    foreach(var child in node.Children)
                    {
                        q.Enqueue(child);
                        Console.WriteLine($"Добавлен в очередь узел с Value:{node.Value}");
                    }
                }
            }
            Console.WriteLine($"Искомый узел с Value: {searchValue} не найден");
            return null;
        }
        private TreeNode<T> DFSearch(T searchValue)
        {
            Stack<TreeNode<T>> s = new Stack<TreeNode<T>>();
            var root = RootNode;
            s.Push(root);
            Console.WriteLine($"Добавлен в стэк узел с Value:{root.Value}");
            while (s.Count > 0)
            {
                var node = s.Pop();
                Console.WriteLine($"Вытащили из стэка узел с Value:{node.Value}");
                if (node.Value.Equals(searchValue))
                {
                    Console.WriteLine($"Найден искомый узел с Value:{node.Value}");
                    return node;
                }
                else
                {
                    foreach (var child in node.Children)
                    {
                        s.Push(child);
                        Console.WriteLine($"Добавлен в очередь узел с Value:{node.Value}");
                    }
                }
            }
            Console.WriteLine($"Искомый узел с Value: {searchValue} не найден");
            return null;

        }

    }
}
