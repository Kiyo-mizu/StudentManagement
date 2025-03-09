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
    public partial class EditPage : Form
    {
        // Properties to hold student data
        public string StudentName { get; set; }
        public int StudentAge { get; set; }
        public string Address { get; set; }
        public string Contact { get; set; }
        public string Email { get; set; }
        public string Guardian { get; set; }
        public string GuardianContact { get; set; }
        public string Course { get; set; }
        public string YearLevel { get; set; }
        public string Hobbies { get; set; }
        public string Nickname { get; set; }


        public EditPage(string name, int age, string address, string contact, string email, string guardian, string guardianContact, string course, string year,string hobbies, string nickname)
        {
            InitializeComponent();
            PopulateDropdowns();

            // Assign values to controls
            nameTxt.Text = name;
            ageTxt.Text = age.ToString();
            addressTxt.Text = address;
            contactTxt.Text = contact;
            emailTxt.Text = email;
            guardianTxt.Text = guardian;
            guardianContactTxt.Text = guardianContact;
            courseCmb.SelectedItem = course;
            yearCmb.SelectedItem = year;
            hobbiesTxt.Text = hobbies;
            nicknameTxt.Text = nickname;


        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            // Validate fields (same as before)
            if (string.IsNullOrWhiteSpace(nameTxt.Text) ||
                string.IsNullOrWhiteSpace(ageTxt.Text) ||
                string.IsNullOrWhiteSpace(addressTxt.Text) ||
                string.IsNullOrWhiteSpace(contactTxt.Text) ||
                string.IsNullOrWhiteSpace(emailTxt.Text) ||
                string.IsNullOrWhiteSpace(guardianTxt.Text) ||
                string.IsNullOrWhiteSpace(hobbiesTxt.Text) ||
                string.IsNullOrWhiteSpace(nicknameTxt.Text) ||
                string.IsNullOrWhiteSpace(guardianContactTxt.Text))
            {
                MessageBox.Show("All required fields must be filled!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(ageTxt.Text.Trim(), out int age) ||
                !long.TryParse(contactTxt.Text.Trim(), out long contactNumber) ||
                !long.TryParse(guardianContactTxt.Text.Trim(), out long guardianContact))
            {
                MessageBox.Show("Age and Contact Numbers must contain only numbers!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Store the updated values
            StudentName = nameTxt.Text;
            StudentAge = age;
            Address = addressTxt.Text;
            Contact = contactTxt.Text;
            Email = emailTxt.Text;
            Guardian = guardianTxt.Text;
            GuardianContact = guardianContactTxt.Text;
            Hobbies = hobbiesTxt.Text;
            Nickname = nicknameTxt.Text;
            Course = courseCmb.SelectedItem.ToString();
            YearLevel = yearCmb.SelectedItem.ToString();

            // Set DialogResult to OK to indicate successful update
            this.DialogResult = DialogResult.OK;
            this.Close();
        }



        private void PopulateDropdowns()
        {
            // Populate the Course dropdown
            courseCmb.Items.AddRange(new string[] { "ABEL", "BSBA", "BSIT", "BPA" });

            // Populate the Year dropdown
            yearCmb.Items.AddRange(new string[] { "First", "Second", "Third", "Fourth" });

            // Set default selections (optional)
            courseCmb.SelectedIndex = 0;
            yearCmb.SelectedIndex = 0;
        }


    }
}
