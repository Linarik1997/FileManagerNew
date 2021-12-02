using FileManagerL.Core;
using FileManagerL.Core.cmnd;
using FileManagerL.Core.data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileManagerL
{
    public partial class Form1 : Form
    {
        public static Form1 _form1;
        public Form1()
        {
            InitializeComponent();
            _form1 = this;
        }


        private static readonly FileManagerL.Core.cmnd.CommandLinePattern commandLinePattern = Command.WithName("ls")
                                                .HasParameter("CommandName")
                                                .HasParameter("PathName");

        public void ExecuteListing(FileSysTree tree)
        {
            treeView1.Nodes.Clear();
            treeView1.BeginUpdate();
            treeView1.Nodes.Add(new TreeNode
            {
                Text = tree.RootNode.Value.Adress,
                Tag = tree.RootNode.Value,
                ImageIndex = (tree.RootNode.Value.Define == Definition.directory || tree.RootNode.Value.Define == Definition.drive) ? 1 : 0,
                SelectedImageIndex = (tree.RootNode.Value.Define == Definition.directory || tree.RootNode.Value.Define == Definition.drive) ? 1 : 0
            });
            foreach (var node in tree.RootNode.Children)
            {
                treeView1.Nodes[0].Nodes.Add(new TreeNode
                {
                    Text = node.Value.Adress.Remove(0, node.Value.Adress.LastIndexOf("\\") + 1),
                    Tag = node.Value,
                    ImageIndex = (node.Value.Define == Definition.directory || node.Value.Define == Definition.drive) ? 1 : 0,
                    SelectedImageIndex = (node.Value.Define == Definition.directory || node.Value.Define == Definition.drive) ? 1 : 0
                });
            }
            treeView1.SelectedNode = treeView1.Nodes[0];
            on_Node_label.Text = $"On node:{treeView1.SelectedNode.Text}";
            treeView1.EndUpdate();
            treeView1.ExpandAll();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var fs = new FileSysInfo();
            var tree = fs.TraverseDirectory((@"C:\Users\l.khamitov\Desktop\Linar"));
            treeView1.ImageList = icons;
            treeView1.Nodes.Clear();
            treeView1.Nodes.Add(new TreeNode {
                Text = tree.RootNode.Value.Adress,
                Tag = tree.RootNode.Value,
                ImageIndex = (tree.RootNode.Value.Define == Definition.directory || tree.RootNode.Value.Define == Definition.drive) ? 1 : 0,
                SelectedImageIndex = (tree.RootNode.Value.Define == Definition.directory || tree.RootNode.Value.Define == Definition.drive) ? 1 : 0
            });
            foreach(var node in tree.RootNode.Children)
            {
                treeView1.Nodes[0].Nodes.Add(new TreeNode
                {
                    Text = node.Value.Adress.Remove(0, node.Value.Adress.LastIndexOf("\\") + 1),
                    Tag = node.Value,
                    ImageIndex = (node.Value.Define == Definition.directory || node.Value.Define == Definition.drive) ? 1 : 0,
                    SelectedImageIndex = (node.Value.Define == Definition.directory || node.Value.Define == Definition.drive) ? 1 : 0
                });
            }
            treeView1.SelectedNode = treeView1.Nodes[0];
            on_Node_label.Text = $"On node:{treeView1.SelectedNode.Text}";
            treeView1.ExpandAll();
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            treeView1.SelectedNode = e.Node;
            on_Node_label.Text = $"On node:{treeView1.SelectedNode.Text}";
        }

        private void treeView2_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }

        private void lst_view_Paint(object sender, PaintEventArgs e)
        {

        }

        private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            var fs = new FileSysInfo();           
            treeView1.SelectedNode = e.Node;
            var adress = ((FileSysData)(treeView1.SelectedNode.Tag)).Adress;
            var expand = fs.TraverseDirectory(adress);
            if (treeView1.SelectedNode.Nodes.Count == 0)
            {
                treeView1.BeginUpdate();
                treeView1.SelectedNode.Nodes.Clear();
                foreach (var node in expand.RootNode.Children)
                {
                    treeView1.SelectedNode.Nodes.Add(new TreeNode
                    {
                        Text = node.Value.Adress.Remove(0,node.Value.Adress.LastIndexOf("\\") + 1),
                        Tag = node.Value,
                        ImageIndex = (node.Value.Define == Core.data.Definition.directory || node.Value.Define == Core.data.Definition.drive) ? 1 : 0,
                        SelectedImageIndex = (node.Value.Define == Core.data.Definition.directory || node.Value.Define == Core.data.Definition.drive) ? 1 : 0
                    });
                }
                treeView1.SelectedNode.Expand();
                treeView1.EndUpdate();
            }

            else
            {
                if (treeView1.SelectedNode.Nodes.Count == expand.RootNode.Children.Count)
                {
                    var hs1 = new HashSet<string>();
                    foreach(var v in treeView1.SelectedNode.Nodes)
                    {
                        hs1.Add(v.ToString().Substring(10));
                    }
                    HashSet<string> hs2 = expand.RootNode.Children.Select(c => c.Value.Name).ToHashSet<string>();
                    if (hs1.SetEquals(hs2))
                    {
                        return;
                    }
                    else
                    {
                        treeView1.BeginUpdate();
                        treeView1.SelectedNode.Nodes.Clear();
                        foreach (var n in expand.RootNode.Children)
                        {
                            treeView1.SelectedNode.Nodes.Add(new TreeNode
                            {
                                Text = n.Value.Adress.Remove(0, n.Value.Adress.LastIndexOf("\\") + 1),
                                Tag = n.Value,
                                ImageIndex = (n.Value.Define == Core.data.Definition.directory || n.Value.Define == Core.data.Definition.drive) ? 1 : 0,
                                SelectedImageIndex = (n.Value.Define == Core.data.Definition.directory || n.Value.Define == Core.data.Definition.drive) ? 1 : 0
                            });
                        }
                        treeView1.SelectedNode.Expand();
                        treeView1.EndUpdate();
                    }
                }
            }            
        }

        private void get_node_info_Click(object sender, EventArgs e)
        {
            var size = ((FileSysData)(treeView1.SelectedNode.Tag)).Size;
            var path = ((FileSysData)(treeView1.SelectedNode.Tag)).Adress;
            node_info.Text = $"Path:{path}\r\nSize:{size / 1024} Kbytes";
        }

        private void execute_Click(object sender, EventArgs e)
        {

            var line = cmnd_line.Text.Split();

            try
            {
                var command = commandLinePattern.Parse(line);
                command.Execute();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
