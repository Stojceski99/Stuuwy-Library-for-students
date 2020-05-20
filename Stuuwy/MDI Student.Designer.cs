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
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.bookToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addNewBookToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewBooksToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.issueBookToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.returnBookToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bookRecordToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bookReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.studentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addStudentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewStudentInformationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
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
            this.menuStrip.SuspendLayout();
            this.panelMenu.SuspendLayout();
            this.panelLogo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BtnHome)).BeginInit();
            this.panelTitleBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconCurrentChildForm)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bookToolStripMenuItem,
            this.studentToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(1183, 24);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "MenuStrip";
            // 
            // bookToolStripMenuItem
            // 
            this.bookToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addNewBookToolStripMenuItem,
            this.viewBooksToolStripMenuItem,
            this.issueBookToolStripMenuItem,
            this.returnBookToolStripMenuItem,
            this.bookRecordToolStripMenuItem,
            this.bookReportToolStripMenuItem});
            this.bookToolStripMenuItem.Name = "bookToolStripMenuItem";
            this.bookToolStripMenuItem.Size = new System.Drawing.Size(46, 20);
            this.bookToolStripMenuItem.Text = "Book";
            // 
            // addNewBookToolStripMenuItem
            // 
            this.addNewBookToolStripMenuItem.Name = "addNewBookToolStripMenuItem";
            this.addNewBookToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.addNewBookToolStripMenuItem.Text = "Add New Book";
            this.addNewBookToolStripMenuItem.Click += new System.EventHandler(this.addNewBookToolStripMenuItem_Click);
            // 
            // viewBooksToolStripMenuItem
            // 
            this.viewBooksToolStripMenuItem.Name = "viewBooksToolStripMenuItem";
            this.viewBooksToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.viewBooksToolStripMenuItem.Text = "View Books";
            this.viewBooksToolStripMenuItem.Click += new System.EventHandler(this.viewBooksToolStripMenuItem_Click);
            // 
            // issueBookToolStripMenuItem
            // 
            this.issueBookToolStripMenuItem.Name = "issueBookToolStripMenuItem";
            this.issueBookToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.issueBookToolStripMenuItem.Text = "Issue Book";
            this.issueBookToolStripMenuItem.Click += new System.EventHandler(this.issueBookToolStripMenuItem_Click);
            // 
            // returnBookToolStripMenuItem
            // 
            this.returnBookToolStripMenuItem.Name = "returnBookToolStripMenuItem";
            this.returnBookToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.returnBookToolStripMenuItem.Text = "Return Book";
            this.returnBookToolStripMenuItem.Click += new System.EventHandler(this.returnBookToolStripMenuItem_Click);
            // 
            // bookRecordToolStripMenuItem
            // 
            this.bookRecordToolStripMenuItem.Name = "bookRecordToolStripMenuItem";
            this.bookRecordToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.bookRecordToolStripMenuItem.Text = "Book Record";
            this.bookRecordToolStripMenuItem.Click += new System.EventHandler(this.bookRecordToolStripMenuItem_Click);
            // 
            // bookReportToolStripMenuItem
            // 
            this.bookReportToolStripMenuItem.Name = "bookReportToolStripMenuItem";
            this.bookReportToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.bookReportToolStripMenuItem.Text = "Book Report";
            this.bookReportToolStripMenuItem.Click += new System.EventHandler(this.bookReportToolStripMenuItem_Click);
            // 
            // studentToolStripMenuItem
            // 
            this.studentToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addStudentToolStripMenuItem,
            this.viewStudentInformationToolStripMenuItem});
            this.studentToolStripMenuItem.Name = "studentToolStripMenuItem";
            this.studentToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.studentToolStripMenuItem.Text = "Student";
            // 
            // addStudentToolStripMenuItem
            // 
            this.addStudentToolStripMenuItem.Name = "addStudentToolStripMenuItem";
            this.addStudentToolStripMenuItem.Size = new System.Drawing.Size(209, 22);
            this.addStudentToolStripMenuItem.Text = "Add Student";
            this.addStudentToolStripMenuItem.Click += new System.EventHandler(this.addStudentToolStripMenuItem_Click);
            // 
            // viewStudentInformationToolStripMenuItem
            // 
            this.viewStudentInformationToolStripMenuItem.Name = "viewStudentInformationToolStripMenuItem";
            this.viewStudentInformationToolStripMenuItem.Size = new System.Drawing.Size(209, 22);
            this.viewStudentInformationToolStripMenuItem.Text = "View Student Information";
            this.viewStudentInformationToolStripMenuItem.Click += new System.EventHandler(this.viewStudentInformationToolStripMenuItem_Click);
            // 
            // panelMenu
            // 
            this.panelMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(30)))), ((int)(((byte)(68)))));
            this.panelMenu.Controls.Add(this.BtnLogout);
            this.panelMenu.Controls.Add(this.BtnReturnBook);
            this.panelMenu.Controls.Add(this.BtnViewBook);
            this.panelMenu.Controls.Add(this.panelLogo);
            this.panelMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelMenu.Location = new System.Drawing.Point(0, 24);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Size = new System.Drawing.Size(220, 509);
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
            this.BtnLogout.Location = new System.Drawing.Point(0, 449);
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
            this.panelTitleBar.Location = new System.Drawing.Point(220, 24);
            this.panelTitleBar.Name = "panelTitleBar";
            this.panelTitleBar.Size = new System.Drawing.Size(963, 80);
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
            this.iconButton3.Location = new System.Drawing.Point(879, 0);
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
            this.iconButton2.Location = new System.Drawing.Point(906, 0);
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
            this.iconButton1.Location = new System.Drawing.Point(929, 0);
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
            this.panelShadow.Location = new System.Drawing.Point(220, 104);
            this.panelShadow.Name = "panelShadow";
            this.panelShadow.Size = new System.Drawing.Size(963, 9);
            this.panelShadow.TabIndex = 7;
            // 
            // panelDesktop
            // 
            this.panelDesktop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(33)))), ((int)(((byte)(74)))));
            this.panelDesktop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDesktop.Location = new System.Drawing.Point(220, 113);
            this.panelDesktop.Name = "panelDesktop";
            this.panelDesktop.Size = new System.Drawing.Size(963, 420);
            this.panelDesktop.TabIndex = 8;
            // 
            // mdi_user
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1183, 533);
            this.Controls.Add(this.panelDesktop);
            this.Controls.Add(this.panelShadow);
            this.Controls.Add(this.panelTitleBar);
            this.Controls.Add(this.panelMenu);
            this.Controls.Add(this.menuStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip;
            this.Name = "mdi_user";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Student";
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.panelMenu.ResumeLayout(false);
            this.panelLogo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.BtnHome)).EndInit();
            this.panelTitleBar.ResumeLayout(false);
            this.panelTitleBar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconCurrentChildForm)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion


        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.ToolStripMenuItem bookToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addNewBookToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewBooksToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem studentToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addStudentToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewStudentInformationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem issueBookToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem returnBookToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bookRecordToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bookReportToolStripMenuItem;
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



