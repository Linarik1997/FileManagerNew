
namespace FileManagerL
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.cmnd_line = new System.Windows.Forms.TextBox();
            this.execute = new System.Windows.Forms.Button();
            this.cmnd_input = new System.Windows.Forms.Panel();
            this.lst_view = new System.Windows.Forms.Panel();
            this.on_Node_label = new System.Windows.Forms.Label();
            this.get_node_info = new System.Windows.Forms.Button();
            this.node_info = new System.Windows.Forms.TextBox();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.icons = new System.Windows.Forms.ImageList(this.components);
            this.cmnd_input.SuspendLayout();
            this.lst_view.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmnd_line
            // 
            this.cmnd_line.Location = new System.Drawing.Point(12, 37);
            this.cmnd_line.Name = "cmnd_line";
            this.cmnd_line.Size = new System.Drawing.Size(633, 22);
            this.cmnd_line.TabIndex = 0;
            // 
            // execute
            // 
            this.execute.Location = new System.Drawing.Point(723, 32);
            this.execute.Name = "execute";
            this.execute.Size = new System.Drawing.Size(172, 33);
            this.execute.TabIndex = 1;
            this.execute.Text = "Execute";
            this.execute.UseVisualStyleBackColor = true;
            this.execute.Click += new System.EventHandler(this.execute_Click);
            // 
            // cmnd_input
            // 
            this.cmnd_input.Controls.Add(this.execute);
            this.cmnd_input.Controls.Add(this.cmnd_line);
            this.cmnd_input.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.cmnd_input.Location = new System.Drawing.Point(0, 477);
            this.cmnd_input.Name = "cmnd_input";
            this.cmnd_input.Size = new System.Drawing.Size(1119, 85);
            this.cmnd_input.TabIndex = 2;
            // 
            // lst_view
            // 
            this.lst_view.Controls.Add(this.on_Node_label);
            this.lst_view.Controls.Add(this.get_node_info);
            this.lst_view.Controls.Add(this.node_info);
            this.lst_view.Controls.Add(this.treeView1);
            this.lst_view.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lst_view.Location = new System.Drawing.Point(0, 0);
            this.lst_view.Name = "lst_view";
            this.lst_view.Size = new System.Drawing.Size(1119, 477);
            this.lst_view.TabIndex = 3;
            this.lst_view.Paint += new System.Windows.Forms.PaintEventHandler(this.lst_view_Paint);
            // 
            // on_Node_label
            // 
            this.on_Node_label.AutoSize = true;
            this.on_Node_label.Location = new System.Drawing.Point(571, 136);
            this.on_Node_label.Name = "on_Node_label";
            this.on_Node_label.Size = new System.Drawing.Size(65, 17);
            this.on_Node_label.TabIndex = 2;
            this.on_Node_label.Text = "On Node";
            // 
            // get_node_info
            // 
            this.get_node_info.Location = new System.Drawing.Point(574, 168);
            this.get_node_info.Name = "get_node_info";
            this.get_node_info.Size = new System.Drawing.Size(172, 33);
            this.get_node_info.TabIndex = 2;
            this.get_node_info.Text = "Node Info";
            this.get_node_info.UseVisualStyleBackColor = true;
            this.get_node_info.Click += new System.EventHandler(this.get_node_info_Click);
            // 
            // node_info
            // 
            this.node_info.Location = new System.Drawing.Point(574, 12);
            this.node_info.Multiline = true;
            this.node_info.Name = "node_info";
            this.node_info.ReadOnly = true;
            this.node_info.Size = new System.Drawing.Size(533, 111);
            this.node_info.TabIndex = 1;
            // 
            // treeView1
            // 
            this.treeView1.Location = new System.Drawing.Point(12, 12);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(547, 439);
            this.treeView1.TabIndex = 0;
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            this.treeView1.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeView1_NodeMouseClick);
            // 
            // icons
            // 
            this.icons.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("icons.ImageStream")));
            this.icons.TransparentColor = System.Drawing.Color.Transparent;
            this.icons.Images.SetKeyName(0, "file.ico");
            this.icons.Images.SetKeyName(1, "8bit folder.png");
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1119, 562);
            this.Controls.Add(this.lst_view);
            this.Controls.Add(this.cmnd_input);
            this.Name = "Form1";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.RightToLeftLayout = true;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.cmnd_input.ResumeLayout(false);
            this.cmnd_input.PerformLayout();
            this.lst_view.ResumeLayout(false);
            this.lst_view.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox cmnd_line;
        private System.Windows.Forms.Button execute;
        private System.Windows.Forms.Panel cmnd_input;
        private System.Windows.Forms.Panel lst_view;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.ImageList icons;
        private System.Windows.Forms.TextBox node_info;
        private System.Windows.Forms.Button get_node_info;
        private System.Windows.Forms.Label on_Node_label;
    }
}

