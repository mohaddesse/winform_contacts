using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormMyContact.Services;
using WinFormMyContact.Repository;


namespace WinFormMyContact
{
    public partial class frmAddOrEdit : Form
    {
        IContactRepositoy contactRepositoy;
        public int ContactID = 0;
        public frmAddOrEdit()
        {
            InitializeComponent();
            contactRepositoy = new ContactRepository();
        }

        private void frmAddOrEdit_Load(object sender, EventArgs e)
        {
            if(ContactID == 0)
            {
                this.Text = "Add A Person";
            }
            else
            {
                this.Text = "Edit A Person";
                DataTable dt=contactRepositoy.SellectRow(ContactID);
                txtFName.Text = dt.Rows[0][1].ToString();
                txtLName.Text = dt.Rows[0][2].ToString();
                txtMobile.Text = dt.Rows[0][3].ToString();
                txtEmail.Text = dt.Rows[0][4].ToString();
                txtAge.Text = dt.Rows[0][5].ToString();

            }
        }

        bool ValidateInputs()
        {
            if (txtFName.Text == "") {
                MessageBox.Show("Enter your First Name!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;}
            if (txtLName.Text == "")
            {
                MessageBox.Show("Enter your Last Name!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (txtMobile.Text == "")
            {
                MessageBox.Show("Enter your Phone number!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (ValidateInputs())
            {
                bool isSuccess = false;
                if (ContactID==0) isSuccess= contactRepositoy.Insert(txtFName.Text, txtLName.Text, txtMobile.Text, txtEmail.Text, (int)txtAge.Value);
                else  isSuccess= contactRepositoy.Update(ContactID,txtFName.Text, txtLName.Text, txtMobile.Text, txtEmail.Text, (int)txtAge.Value);
                if (isSuccess)
                {
                    MessageBox.Show("Data Recieved Successfuly", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DialogResult = DialogResult.OK;
                }
                else
                {
                    MessageBox.Show("Unseccessful","Error",MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
