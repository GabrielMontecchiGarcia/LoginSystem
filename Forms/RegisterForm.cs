using LoginSystem.Context;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Linq;
using LoginSystem.Models;

namespace LoginSystem.Forms
{
    public partial class RegisterForm : Form
    {
        public RegisterForm()
        {
            InitializeComponent();
            LoadRoles();
        }
        private void LoadRoles()
        {
            using var db = new AppDBcontext();
            var roles = db.Roles.Tolist();
            cmbRole.DataSource = roles;
            cmbRole.DisplayMember = "Name";
            cmbRole.ValueMember = "Id";
        }

        private void RegisterForm_Load(object sender, EventArgs e)
        {

        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string email = txtEmail.Text.Trim();
            string password = txtPassword.Text.Trim();
            string confirm = txtConfirm.Text.Trim();
            string selectedRole = (cmbRole.SelectedItem as Role)?.Name;

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Todos os campos são obrigatórios");
                return;
            }
            bool success = AuthService.registerUser(username, email, password, selectedRole);
            if (success)
            {
                MessageBox.Show("Usuário cadastrado com sucesso! Faça Login");
                this.Close();
            }
            else
            {
                MessageBox.Show("Nome de usuário ou e-mail já existente");
            }
        }
    }
}
