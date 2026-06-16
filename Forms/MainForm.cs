using LoginSystem.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace LoginSystem.Forms
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            lblWelcome.Text = $"Bem-Vindo, {Session.LoggedUser.Username}!";
            if (AuthService.IsInRole(Session.LoggedUser, "Admin"))
            {
                btnAdmin.Visible = true;
            }
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            Session.LoggedUser = null;
            this.Close();
            Application.Restart();
        }

        private void btnAdmin_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Área administrativa (você pode listar usuários, etc.)");
        }
    }
}
