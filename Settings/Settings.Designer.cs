namespace Obser
{
    partial class Settings
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Settings));
            this.Menubar_2 = new System.Windows.Forms.Panel();
            this.PanelROOT = new System.Windows.Forms.Panel();
            this.Menu = new System.Windows.Forms.FlowLayoutPanel();
            this.SideBar = new System.Windows.Forms.Panel();
            this.botBar = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.Close = new System.Windows.Forms.Button();
            this.Modifiy = new System.Windows.Forms.Button();
            this.Home = new System.Windows.Forms.Button();
            this.Apperance = new System.Windows.Forms.Button();
            this.Arrangement = new System.Windows.Forms.Button();
            this.Update = new System.Windows.Forms.Button();
            this.Menubar_2.SuspendLayout();
            this.PanelROOT.SuspendLayout();
            this.Menu.SuspendLayout();
            this.SuspendLayout();
            // 
            // Menubar_2
            // 
            this.Menubar_2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(2)))), ((int)(((byte)(2)))));
            this.Menubar_2.Controls.Add(this.Close);
            this.Menubar_2.Controls.Add(this.Modifiy);
            this.Menubar_2.Controls.Add(this.Home);
            this.Menubar_2.Location = new System.Drawing.Point(0, 1);
            this.Menubar_2.Name = "Menubar_2";
            this.Menubar_2.Size = new System.Drawing.Size(241, 30);
            this.Menubar_2.TabIndex = 37;
            this.Menubar_2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MenuBar_MouseDown);
            this.Menubar_2.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MenuBar_MouseMove);
            this.Menubar_2.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MenuBar_MouseUp);
            // 
            // PanelROOT
            // 
            this.PanelROOT.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(2)))), ((int)(((byte)(2)))));
            this.PanelROOT.Controls.Add(this.Menu);
            this.PanelROOT.Cursor = System.Windows.Forms.Cursors.Default;
            this.PanelROOT.Location = new System.Drawing.Point(5, 31);
            this.PanelROOT.Name = "PanelROOT";
            this.PanelROOT.Size = new System.Drawing.Size(231, 333);
            this.PanelROOT.TabIndex = 26;
            // 
            // Menu
            // 
            this.Menu.Controls.Add(this.Apperance);
            this.Menu.Controls.Add(this.Arrangement);
            this.Menu.Controls.Add(this.Update);
            this.Menu.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.Menu.ImeMode = System.Windows.Forms.ImeMode.AlphaFull;
            this.Menu.Location = new System.Drawing.Point(55, 58);
            this.Menu.Name = "Menu";
            this.Menu.Size = new System.Drawing.Size(122, 218);
            this.Menu.TabIndex = 46;
            // 
            // SideBar
            // 
            this.SideBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(2)))), ((int)(((byte)(2)))));
            this.SideBar.Location = new System.Drawing.Point(236, 1);
            this.SideBar.Name = "SideBar";
            this.SideBar.Size = new System.Drawing.Size(5, 364);
            this.SideBar.TabIndex = 39;
            // 
            // botBar
            // 
            this.botBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(2)))), ((int)(((byte)(2)))));
            this.botBar.Location = new System.Drawing.Point(0, 363);
            this.botBar.Name = "botBar";
            this.botBar.Size = new System.Drawing.Size(241, 5);
            this.botBar.TabIndex = 40;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(2)))), ((int)(((byte)(2)))));
            this.panel1.Location = new System.Drawing.Point(0, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(5, 360);
            this.panel1.TabIndex = 41;
            // 
            // Close
            // 
            this.Close.BackgroundImage = global::Obser.Properties.Resources.circle_16_1_;
            this.Close.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.Close.FlatAppearance.BorderSize = 0;
            this.Close.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.Close.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Close.ForeColor = System.Drawing.Color.White;
            this.Close.Location = new System.Drawing.Point(214, 4);
            this.Close.Name = "Close";
            this.Close.Size = new System.Drawing.Size(18, 20);
            this.Close.TabIndex = 45;
            this.Close.UseVisualStyleBackColor = true;
            this.Close.Click += new System.EventHandler(this.Close_Click);
            this.Close.MouseEnter += new System.EventHandler(this.Close_MouseEnter);
            this.Close.MouseLeave += new System.EventHandler(this.Close_MouseLeave);
            // 
            // Modifiy
            // 
            this.Modifiy.BackgroundImage = global::Obser.Properties.Resources.play_button_1_;
            this.Modifiy.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.Modifiy.Enabled = false;
            this.Modifiy.FlatAppearance.BorderSize = 0;
            this.Modifiy.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.Modifiy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Modifiy.ForeColor = System.Drawing.Color.White;
            this.Modifiy.Location = new System.Drawing.Point(59, 5);
            this.Modifiy.Name = "Modifiy";
            this.Modifiy.Size = new System.Drawing.Size(38, 23);
            this.Modifiy.TabIndex = 44;
            this.Modifiy.UseVisualStyleBackColor = true;
            this.Modifiy.Click += new System.EventHandler(this.Modifiy_Click);
            this.Modifiy.MouseHover += new System.EventHandler(this.Modifiy_MouseHover);
            // 
            // Home
            // 
            this.Home.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.Home.FlatAppearance.BorderSize = 0;
            this.Home.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.Home.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Home.ForeColor = System.Drawing.Color.White;
            this.Home.Location = new System.Drawing.Point(5, 4);
            this.Home.Name = "Home";
            this.Home.Size = new System.Drawing.Size(46, 24);
            this.Home.TabIndex = 43;
            this.Home.UseVisualStyleBackColor = true;
            this.Home.Click += new System.EventHandler(this.BTNs_Clicked);
            // 
            // Apperance
            // 
            this.Apperance.BackgroundImage = global::Obser.Properties.Resources.painter_palette;
            this.Apperance.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.Apperance.FlatAppearance.BorderSize = 0;
            this.Apperance.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.Apperance.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Apperance.ForeColor = System.Drawing.Color.White;
            this.Apperance.Location = new System.Drawing.Point(3, 3);
            this.Apperance.Name = "Apperance";
            this.Apperance.Size = new System.Drawing.Size(114, 66);
            this.Apperance.TabIndex = 42;
            this.Apperance.Text = "Apperance, Colour";
            this.Apperance.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Apperance.UseVisualStyleBackColor = true;
            this.Apperance.Click += new System.EventHandler(this.BTNs_Clicked);
            // 
            // Arrangement
            // 
            this.Arrangement.BackgroundImage = global::Obser.Properties.Resources.square;
            this.Arrangement.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.Arrangement.FlatAppearance.BorderSize = 0;
            this.Arrangement.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.Arrangement.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Arrangement.ForeColor = System.Drawing.Color.White;
            this.Arrangement.Location = new System.Drawing.Point(3, 75);
            this.Arrangement.Name = "Arrangement";
            this.Arrangement.Size = new System.Drawing.Size(114, 66);
            this.Arrangement.TabIndex = 41;
            this.Arrangement.Text = "Layout, Orientation";
            this.Arrangement.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Arrangement.UseVisualStyleBackColor = true;
            this.Arrangement.Click += new System.EventHandler(this.BTNs_Clicked);
            // 
            // Update
            // 
            this.Update.BackgroundImage = global::Obser.Properties.Resources.update_arrows;
            this.Update.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.Update.FlatAppearance.BorderSize = 0;
            this.Update.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.Update.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Update.ForeColor = System.Drawing.Color.White;
            this.Update.Location = new System.Drawing.Point(3, 147);
            this.Update.Name = "Update";
            this.Update.Size = new System.Drawing.Size(114, 66);
            this.Update.TabIndex = 44;
            this.Update.Text = "Updates, About";
            this.Update.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Update.UseVisualStyleBackColor = true;
            this.Update.Click += new System.EventHandler(this.BTNs_Clicked);
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(241, 370);
            this.Controls.Add(this.Menubar_2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.botBar);
            this.Controls.Add(this.SideBar);
            this.Controls.Add(this.PanelROOT);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Settings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.Settings_Load);
            this.Menubar_2.ResumeLayout(false);
            this.PanelROOT.ResumeLayout(false);
            this.Menu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel Menubar_2;
        private System.Windows.Forms.Panel SideBar;
        private System.Windows.Forms.Panel botBar;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel PanelROOT;
        private System.Windows.Forms.FlowLayoutPanel Menu;
        private System.Windows.Forms.Button Apperance;
        private System.Windows.Forms.Button Arrangement;
        private System.Windows.Forms.Button Update;
        private System.Windows.Forms.Button Modifiy;
        private System.Windows.Forms.Button Close;
        private System.Windows.Forms.Button Home;
    }
}