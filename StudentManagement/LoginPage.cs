using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudentManagement
{
    public partial class LoginPage : Form
    {
        private int attempts = 0;
        private const int maxAttempts = 5;
        private string mockUsername = "admin";
        private string mockPassword = "password123";

        public LoginPage()
        {
            InitializeComponent();
            resetLink.Visible = false; // Hide reset link initially
        }


        private void LoginPage_Load(object sender, EventArgs e)
        {
            // This method can be empty or have initial settings
        }

        private void loginBtn_Click(object sender, EventArgs e)
        {
            string username = usernameTxt.Text;
            string password = passwordTxt.Text;

            if (username == mockUsername && password == mockPassword)
            {
                MessageBox.Show("Login Successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Open StudentPage and close LoginPage
                StudentPage studentPage = new StudentPage();
                studentPage.Show();
                this.Hide();
            }
            else
            {
                attempts++;
                int attemptsLeft = maxAttempts - attempts;

                if (attempts >= maxAttempts)
                {
                    MessageBox.Show("Too many failed attempts! Please reset your password.", "Locked Out", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    resetLink.Visible = true; // Show reset link
                    loginBtn.Enabled = false; // Disable login button
                }
                else
                {
                    MessageBox.Show($"Invalid Username or Password. Attempts left: {attemptsLeft}", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void resetLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("This is a display-only reset link. Functionality not implemented.", "Reset Password", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}