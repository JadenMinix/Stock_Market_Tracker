using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StockAdvisorPro
{
    public partial class fLogin : Form
    {
        public fLogin()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Event handler for the Login button. Will validate credentials 
        /// input into username & password boxes
        /// </summary>
        /// <param name="sender">required param</param>
        /// <param name="e">event arguements upon button press</param>
        private void btnLogin_Click(object sender, EventArgs e)
        {
            cAccess access = new cAccess();

            string hashedPass = fRegister.generateHash(txtPassword.Text.ToString());

            int login_success = access.validateUser(txtUserName.Text.ToString(), hashedPass);
            if (login_success > 0)
			{
				//save that the user has logged in
                //set dialog result to OK to pop off primary window
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else    //invalid credentials
            {
                MessageBox.Show("Invalid credentials!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Event handler for the Register button. Will open the Register form to 
        /// allow user to create an account.
        /// </summary>
        /// <param name="sender">required param</param>
        /// <param name="e">event arguements upon button press</param>
        private void btnRegister_Click(object sender, EventArgs e)
        {
            //pop register form
            fRegister reg_form = new fRegister();
            reg_form.ShowDialog();
        }
    }
}
