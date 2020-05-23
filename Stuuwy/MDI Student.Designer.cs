namespace Stuuwy
{
    partial class mdi_user
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(mdi_user));
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.panelMenu = new System.Windows.Forms.Panel();
            this.BtnLogout = new FontAwesome.Sharp.IconButton();
            this.BtnReturnBook = new FontAwesome.Sharp.IconButton();
            this.BtnViewBook = new FontAwesome.Sharp.IconButton();
            this.panelLogo = new System.Windows.Forms.Panel();
            this.BtnHome = new System.Windows.Forms.PictureBox();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.panelTitleBar = new System.Windows.Forms.Panel();
            this.iconButton3 = new FontAwesome.Sharp.IconButton();
            this.iconButton2 = new FontAwesome.Sharp.IconButton();
            this.iconButton1 = new FontAwesome.Sharp.IconButton();
            this.lblTitleChildForm = new System.Windows.Forms.Label();
            this.iconCurrentChildForm = new FontAwesome.Sharp.IconPictureBox();
            this.panelShadow = new System.Windows.Forms.Panel();
            this.panelDesktop = new System.Windows.Forms.Panel();
            this.panelMenu.SuspendLayout();
            this.panelLogo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BtnHome)).BeginInit();
            this.panelTitleBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconCurrentChildForm)).BeginInit();
            this.SuspendLayout();
            // 
            // panelMenu
            // 
            this.panelMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(30)))), ((int)(((byte)(68)))));
            this.panelMenu.Controls.Add(this.BtnLogout);
            this.panelMenu.Controls.Add(this.BtnReturnBook);
            this.panelMenu.Controls.Add(this.BtnViewBook);
            this.panelMenu.Controls.Add(this.panelLogo);
            this.panelMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelMenu.Location = new System.Drawing.Point(0, 0);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Size = new System.Drawing.Size(220, 686);
            this.panelMenu.TabIndex = 4;
            // 
            // BtnLogout
            // 
            this.BtnLogout.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.BtnLogout.FlatAppearance.BorderSize = 0;
            this.BtnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnLogout.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.BtnLogout.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.BtnLogout.ForeColor = System.Drawing.Color.Gainsboro;
            this.BtnLogout.IconChar = FontAwesome.Sharp.IconChar.ArrowAltCircleLeft;
            this.BtnLogout.IconColor = System.Drawing.Color.Gainsboro;
            this.BtnLogout.IconSize = 32;
            this.BtnLogout.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnLogout.Location = new System.Drawing.Point(0, 626);
            this.BtnLogout.Name = "BtnLogout";
            this.BtnLogout.Padding = new System.Windows.Forms.Padding(10, 0, 20, 0);
            this.BtnLogout.Rotation = 0D;
            this.BtnLogout.Size = new System.Drawing.Size(220, 60);
            this.BtnLogout.TabIndex = 5;
            this.BtnLogout.Text = "Logout";
            this.BtnLogout.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnLogout.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BtnLogout.UseVisualStyleBackColor = true;
            this.BtnLogout.Click += new System.EventHandler(this.BtnLogout_Click);
            // 
            // BtnReturnBook
            // 
            this.BtnReturnBook.Dock = System.Windows.Forms.DockStyle.Top;
            this.BtnReturnBook.FlatAppearance.BorderSize = 0;
            this.BtnReturnBook.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnReturnBook.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.BtnReturnBook.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.BtnReturnBook.ForeColor = System.Drawing.Color.Gainsboro;
            this.BtnReturnBook.IconChar = FontAwesome.Sharp.IconChar.ExchangeAlt;
            this.BtnReturnBook.IconColor = System.Drawing.Color.Gainsboro;
            this.BtnReturnBook.IconSize = 32;
            this.BtnReturnBook.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnReturnBook.Location = new System.Drawing.Point(0, 200);
            this.BtnReturnBook.Name = "BtnReturnBook";
            this.BtnReturnBook.Padding = new System.Windows.Forms.Padding(10, 0, 20, 0);
            this.BtnReturnBook.Rotation = 0D;
            this.BtnReturnBook.Size = new System.Drawing.Size(220, 60);
            this.BtnReturnBook.TabIndex = 2;
            this.BtnReturnBook.Text = "Return Books";
            this.BtnReturnBook.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnReturnBook.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BtnReturnBook.UseVisualStyleBackColor = true;
            this.BtnReturnBook.Click += new System.EventHandler(this.BtnReturnBook_Click);
            // 
            // BtnViewBook
            // 
            this.BtnViewBook.Dock = System.Windows.Forms.DockStyle.Top;
            this.BtnViewBook.FlatAppearance.BorderSize = 0;
            this.BtnViewBook.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnViewBook.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.BtnViewBook.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.BtnViewBook.ForeColor = System.Drawing.Color.Gainsboro;
            this.BtnViewBook.IconChar = FontAwesome.Sharp.IconChar.Book;
            this.BtnViewBook.IconColor = System.Drawing.Color.Gainsboro;
            this.BtnViewBook.IconSize = 32;
            this.BtnViewBook.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnViewBook.Location = new System.Drawing.Point(0, 140);
            this.BtnViewBook.Name = "BtnViewBook";
            this.BtnViewBook.Padding = new System.Windows.Forms.Padding(10, 0, 20, 0);
            this.BtnViewBook.Rotation = 0D;
            this.BtnViewBook.Size = new System.Drawing.Size(220, 60);
            this.BtnViewBook.TabIndex = 1;
            this.BtnViewBook.Text = "View Books";
            this.BtnViewBook.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnViewBook.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BtnViewBook.UseVisualStyleBackColor = true;
            this.BtnViewBook.Click += new System.EventHandler(this.BtnViewBook_Click);
            // 
            // panelLogo
            // 
            this.panelLogo.Controls.Add(this.BtnHome);
            this.panelLogo.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelLogo.Location = new System.Drawing.Point(0, 0);
            this.panelLogo.Name = "panelLogo";
            this.panelLogo.Size = new System.Drawing.Size(220, 140);
            this.panelLogo.TabIndex = 0;
            // 
            // BtnHome
            // 
            this.BtnHome.Image = ((System.Drawing.Image)(resources.GetObject("BtnHome.Image")));
            this.BtnHome.Location = new System.Drawing.Point(-217, 0);
            this.BtnHome.Name = "BtnHome";
            this.BtnHome.Size = new System.Drawing.Size(484, 140);
            this.BtnHome.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.BtnHome.TabIndex = 0;
            this.BtnHome.TabStop = false;
            this.BtnHome.Click += new System.EventHandler(this.BtnHome_Click);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Text = "notifyIcon1";
            this.notifyIcon1.Visible = true;
            // 
            // panelTitleBar
            // 
            this.panelTitleBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(25)))), ((int)(((byte)(62)))));
            this.panelTitleBar.Controls.Add(this.iconButton3);
            this.panelTitleBar.Controls.Add(this.iconButton2);
            this.panelTitleBar.Controls.Add(this.iconButton1);
            this.panelTitleBar.Controls.Add(this.lblTitleChildForm);
            this.panelTitleBar.Controls.Add(this.iconCurrentChildForm);
            this.panelTitleBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTitleBar.Location = new System.Drawing.Point(220, 0);
            this.panelTitleBar.Name = "panelTitleBar";
            this.panelTitleBar.Size = new System.Drawing.Size(1070, 80);
            this.panelTitleBar.TabIndex = 6;
            this.panelTitleBar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelTitleBar_MouseDown);
            // 
            // iconButton3
            // 
            this.iconButton3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.iconButton3.FlatAppearance.BorderSize = 0;
            this.iconButton3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iconButton3.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.iconButton3.IconChar = FontAwesome.Sharp.IconChar.WindowMinimize;
            this.iconButton3.IconColor = System.Drawing.Color.MediumSlateBlue;
            this.iconButton3.IconSize = 16;
            this.iconButton3.Location = new System.Drawing.Point(986, 0);
            this.iconButton3.Name = "iconButton3";
            this.iconButton3.Rotation = 0D;
            this.iconButton3.Size = new System.Drawing.Size(34, 30);
            this.iconButton3.TabIndex = 4;
            this.iconButton3.UseVisualStyleBackColor = true;
            this.iconButton3.Click += new System.EventHandler(this.iconButton3_Click);
            // 
            // iconButton2
            // 
            this.iconButton2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.iconButton2.FlatAppearance.BorderSize = 0;
            this.iconButton2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iconButton2.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.iconButton2.IconChar = FontAwesome.Sharp.IconChar.WindowRestore;
            this.iconButton2.IconColor = System.Drawing.Color.MediumSlateBlue;
            this.iconButton2.IconSize = 16;
            this.iconButton2.Location = new System.Drawing.Point(1013, 0);
            this.iconButton2.Name = "iconButton2";
            this.iconButton2.Rotation = 0D;
            this.iconButton2.Size = new System.Drawing.Size(34, 30);
            this.iconButton2.TabIndex = 3;
            this.iconButton2.UseVisualStyleBackColor = true;
            this.iconButton2.Click += new System.EventHandler(this.iconButton2_Click);
            // 
            // iconButton1
            // 
            this.iconButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.iconButton1.FlatAppearance.BorderSize = 0;
            this.iconButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iconButton1.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.iconButton1.IconChar = FontAwesome.Sharp.IconChar.Times;
            this.iconButton1.IconColor = System.Drawing.Color.MediumSlateBlue;
            this.iconButton1.IconSize = 16;
            this.iconButton1.Location = new System.Drawing.Point(1036, 0);
            this.iconButton1.Name = "iconButton1";
            this.iconButton1.Rotation = 0D;
            this.iconButton1.Size = new System.Drawing.Size(34, 30);
            this.iconButton1.TabIndex = 2;
            this.iconButton1.UseVisualStyleBackColor = true;
            this.iconButton1.Click += new System.EventHandler(this.iconButton1_Click);
            // 
            // lblTitleChildForm
            // 
            this.lblTitleChildForm.AutoSize = true;
            this.lblTitleChildForm.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblTitleChildForm.ForeColor = System.Drawing.Color.Gainsboro;
            this.lblTitleChildForm.Location = new System.Drawing.Point(53, 38);
            this.lblTitleChildForm.Name = "lblTitleChildForm";
            this.lblTitleChildForm.Size = new System.Drawing.Size(45, 16);
            this.lblTitleChildForm.TabIndex = 1;
            this.lblTitleChildForm.Text = "Home";
            // 
            // iconCurrentChildForm
            // 
            this.iconCurrentChildForm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(25)))), ((int)(((byte)(62)))));
            this.iconCurrentChildForm.ForeColor = System.Drawing.Color.MediumPurple;
            this.iconCurrentChildForm.IconChar = FontAwesome.Sharp.IconChar.Desktop;
            this.iconCurrentChildForm.IconColor = System.Drawing.Color.MediumPurple;
            this.iconCurrentChildForm.Location = new System.Drawing.Point(15, 28);
            this.iconCurrentChildForm.Name = "iconCurrentChildForm";
            this.iconCurrentChildForm.Size = new System.Drawing.Size(32, 32);
            this.iconCurrentChildForm.TabIndex = 0;
            this.iconCurrentChildForm.TabStop = false;
            // 
            // panelShadow
            // 
            this.panelShadow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(24)))), ((int)(((byte)(58)))));
            this.panelShadow.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelShadow.Location = new System.Drawing.Point(220, 80);
            this.panelShadow.Name = "panelShadow";
            this.panelShadow.Size = new System.Drawing.Size(1070, 9);
            this.panelShadow.TabIndex = 7;
            // 
            // panelDesktop
            // 
            this.panelDesktop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(33)))), ((int)(((byte)(74)))));
            this.panelDesktop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDesktop.Location = new System.Drawing.Point(220, 89);
            this.panelDesktop.Name = "panelDesktop";
            this.panelDesktop.Size = new System.Drawing.Size(1070, 597);
            this.panelDesktop.TabIndex = 8;
            // 
            // mdi_user
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1290, 686);
            this.Controls.Add(this.panelDesktop);
            this.Controls.Add(this.panelShadow);
            this.Controls.Add(this.panelTitleBar);
            this.Controls.Add(this.panelMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.Name = "mdi_user";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Stuuwy Student";
            this.panelMenu.ResumeLayout(false);
            this.panelLogo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.BtnHome)).EndInit();
            this.panelTitleBar.ResumeLayout(false);
            this.panelTitleBar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconCurrentChildForm)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion

        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.Panel panelMenu;
        private System.Windows.Forms.Panel panelLogo;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private FontAwesome.Sharp.IconButton BtnLogout;
        private FontAwesome.Sharp.IconButton BtnReturnBook;
        private FontAwesome.Sharp.IconButton BtnViewBook;
        private System.Windows.Forms.PictureBox BtnHome;
        private System.Windows.Forms.Panel panelTitleBar;
        private System.Windows.Forms.Label lblTitleChildForm;
        private FontAwesome.Sharp.IconPictureBox iconCurrentChildForm;
        private System.Windows.Forms.Panel panelShadow;
        private System.Windows.Forms.Panel panelDesktop;
        private FontAwesome.Sharp.IconButton iconButton3;
        private FontAwesome.Sharp.IconButton iconButton2;
        private FontAwesome.Sharp.IconButton iconButton1;
    }
}



