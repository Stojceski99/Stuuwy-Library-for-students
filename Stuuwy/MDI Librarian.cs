﻿using FontAwesome.Sharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http.Headers;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Stuuwy
{
    public partial class MDI_Librarian : Form
    {
        private IconButton currentBtn;
        private Panel leftBoarderBtn;
        private Form CurrentChildForm;
        public MDI_Librarian()
        {
            InitializeComponent();
            leftBoarderBtn = new Panel();
            leftBoarderBtn.Size = new Size(7, 60);
            panelMenu.Controls.Add(leftBoarderBtn);
            //Form > control buttons
            this.Text = string.Empty;
            this.ControlBox = false;
            this.DoubleBuffered = true;
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
        }
        //Strukturi
        private struct RGBColors
        {
            public static Color color1 = Color.FromArgb(172, 126, 241);
            public static Color color2 = Color.FromArgb(249, 118, 176);
            public static Color color3 = Color.FromArgb(253, 138, 114);
            public static Color color4 = Color.FromArgb(95, 77, 221);
            public static Color color5 = Color.FromArgb(249, 88, 155);
            public static Color color6 = Color.FromArgb(24, 161, 251);
            public static Color color7 = Color.FromArgb(102, 34, 204);
        }

        //Metodi

        private void ActivateButton(object senderBtn, Color color)
        {
            if (senderBtn != null)
            {
                DisableButton();
                //Button
                currentBtn = (IconButton)senderBtn;
                currentBtn.BackColor = Color.FromArgb(37, 36, 81);
                currentBtn.ForeColor = color;
                currentBtn.TextAlign = ContentAlignment.MiddleCenter;
                currentBtn.IconColor = color;
                currentBtn.TextImageRelation = TextImageRelation.TextBeforeImage;
                currentBtn.ImageAlign = ContentAlignment.MiddleRight;
                //Left border button
                leftBoarderBtn.BackColor = color;
                leftBoarderBtn.Location = new Point(0, currentBtn.Location.Y);
                leftBoarderBtn.Visible = true;
                leftBoarderBtn.BringToFront();
                //Icon Current Child form
                iconCurrentChildForm.IconChar = currentBtn.IconChar;
                iconCurrentChildForm.IconColor = color;

            }
        }

        private void DisableButton()
        {
            if (currentBtn != null)
            {
                //Button
                currentBtn.BackColor = Color.FromArgb(31, 30, 68);
                currentBtn.ForeColor = Color.Gainsboro;
                currentBtn.TextAlign = ContentAlignment.MiddleLeft;
                currentBtn.IconColor = Color.Gainsboro;
                currentBtn.TextImageRelation = TextImageRelation.ImageBeforeText;
                currentBtn.ImageAlign = ContentAlignment.MiddleLeft;
            }
        }
        private void Reset()
        {
            DisableButton();
            leftBoarderBtn.Visible = false;
            iconCurrentChildForm.IconChar = IconChar.Desktop;
            iconCurrentChildForm.IconColor = Color.MediumPurple;
            lblTitleChildForm.Text = "Home";
        }
        private void OpenChildForm(Form childForm)
        {
            if (CurrentChildForm != null)
            {
                CurrentChildForm.Close();
            }
            CurrentChildForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelDesktop.Controls.Add(childForm);
            panelDesktop.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
            lblTitleChildForm.Text = childForm.Text;
        }
        private void BtnAddNewBook_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color1);
            OpenChildForm(new add_books());
        }

        private void BtnIssueBook_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color2);
            OpenChildForm(new Issue_Books());
        }

        private void BtnBookRecord_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color3);
            OpenChildForm(new Book_Record());
        }

        private void BtnBookReport_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color4);
            OpenChildForm(new Report_for_Books());
        }

        private void BtnAddStudent_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color5);
            OpenChildForm(new add_Student_info());
        }

        private void BtnViewStudentInfo_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color6);
            OpenChildForm(new View_Student_Information());
        }
        private void BtnUpdateBookInfo_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color7);
            OpenChildForm(new Update_Book_Info());
        }
        private void BtnHome_Click(object sender, EventArgs e)
        {
            CurrentChildForm.Close();
            Reset();
        }
        // Drag Form
        // DLL -dynamic link library [Inheritance > Object > Attribute > DllImportAttribute]
        // extern = modifikator koj se koristi za deklariranje metod koj e implementiran externally[nadvor od nasiot kod] - vo ovaj slucaj so DllImport mora da se deklarira static 
        // entryPoint = ja identifikuva lokacijata na funkcijata vo eden DLL
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMSH, int wParam, int lParam);

        private void panelTitleBar_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void iconButton3_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void iconButton2_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
            {
                WindowState = FormWindowState.Maximized;
            }
            else
                WindowState = FormWindowState.Normal;
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void BtnLogout_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color3);
            loginForm lf = new loginForm();
            lf.Show();
            this.Hide();
        }
    }
}
