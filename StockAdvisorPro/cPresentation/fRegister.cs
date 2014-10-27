using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StockAdvisorPro
{
    public partial class fRegister : Form
    {
        public fRegister()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Event handler for the Register button. Will attempt to contact database to create an account
        /// </summary>
        /// <param name="sender">required param</param>
        /// <param name="e">event arguements upon button press</param>
        private void btnRegister_Click(object sender, EventArgs e)
        {
            if (txtUsername.Text.Length < 6)
            {
                MessageBox.Show("Username too short.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (txtPasswordOne.Text != txtPasswordTwo.Text)
            {
                MessageBox.Show("Password do not match!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (txtPasswordOne.Text.Length < 6)
            {
                MessageBox.Show("Password too short.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {   //create account
                cAccess access = new cAccess();
                string hashedPass = generateHash(txtPasswordOne.Text.ToString());
                if (access.registerUser(txtUsername.Text.ToString(), hashedPass)) //successful insert
                    this.Close();   //return to login form
                else
                    MessageBox.Show("Account creation failed!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        /// <summary>
        /// This function takes a string and performs an md5 hash on it in order to
        /// secure passwords.
        /// </summary>
        /// <param name="pass">The password to be hashed for security.</param>
        /// <returns>Returns a string containing the password's md5 hash</returns>
        public static string generateHash(string pass)
        {
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            byte[] tmpSource;
            byte[] tmpHash;
    
            tmpSource = ASCIIEncoding.ASCII.GetBytes(pass);
            tmpHash = md5.ComputeHash(tmpSource);

            StringBuilder sOutput = new StringBuilder(tmpHash.Length);
            for (int i = 0; i < tmpHash.Length; i++)
            {
                sOutput.Append(tmpHash[i].ToString("X2"));  // X2 formats to hexadecimal
            }
            return sOutput.ToString();
        }
    }
}
