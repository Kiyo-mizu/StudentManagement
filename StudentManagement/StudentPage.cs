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
    public partial class StudentPage : Form
    {
        public StudentPage()
        {
            InitializeComponent();
            PopulateDropdowns();
        }

        private void PopulateDropdowns()
        {
            // Populate the Course dropdown
            courseCmb.Items.AddRange(new string[] { "ABEL", "BSBA", "BSIT", "BPA" });

            // Populate the Year dropdown
            yearCmb.Items.AddRange(new string[] { "First", "Second", "Third", "Fourth" });

            // Set default values (optional)
            courseCmb.SelectedIndex = 0;
            yearCmb.SelectedIndex = 0;
        }

        // Placeholder for adding an image (not functional for now)
        private void addImgBtn_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Feature not implemented yet.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // Placeholder for changing an image (not functional for now)
        private void changeImgBtn_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Feature not implemented yet.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // Open the Edit Page
        private void editBtn_Click(object sender, EventArgs e)
        {
            // Get current student details from input fields
            string name = nameTxt.Text;
            int age = int.TryParse(ageTxt.Text, out int parsedAge) ? parsedAge : 0;
            string address = addressTxt.Text;
            string contact = contactTxt.Text;
            string email = emailTxt.Text;
            string guardian = guardianTxt.Text;
            string guardianContact = guardianContactTxt.Text;
            string course = courseCmb.SelectedItem.ToString();
            string year = yearCmb.SelectedItem.ToString();
            string hobbies = hobbiesTxt.Text;
            string nickname = nicknameTxt.Text;

            // Open EditPage with existing data
            EditPage editPage = new EditPage(name, age, address, contact, email, guardian, guardianContact, course, year, hobbies,nickname);

            // If user clicks Save, update the fields in StudentPage
            if (editPage.ShowDialog() == DialogResult.OK)
            {
                nameTxt.Text = editPage.StudentName;
                ageTxt.Text = editPage.StudentAge.ToString();
                addressTxt.Text = editPage.Address;
                contactTxt.Text = editPage.Contact;
                emailTxt.Text = editPage.Email;
                guardianTxt.Text = editPage.Guardian;
                guardianContactTxt.Text = editPage.GuardianContact;
                courseCmb.SelectedItem = editPage.Course;
                yearCmb.SelectedItem = editPage.YearLevel;
                hobbiesTxt.Text = editPage.Hobbies;
                nicknameTxt.Text = editPage.Nickname;

            }
        }


        private void StudentPage_Load(object sender, EventArgs e)
        {
            // Any initialization code here (or leave empty if not needed)

        }

    }
}
