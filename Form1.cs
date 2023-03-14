using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormMyContact.Repository;
using WinFormMyContact.Services;

namespace WinFormMyContact
{
    public partial class Form1 : Form
    {
        IContactRepositoy repository;
        public Form1()
        {
            repository = new ContactRepository();
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            BindGrid();

 
        }
        private void BindGrid()
        {
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = repository.SellectAll();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            BindGrid();
        }

        private void btnNewContact_Click(object sender, EventArgs e)
        {
            frmAddOrEdit frm = new frmAddOrEdit();
            frm.ShowDialog();
            if(frm.DialogResult== DialogResult.OK)
            {
                BindGrid();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if(dataGridView1.CurrentRow!=null)
            {
                string FullName = dataGridView1.CurrentRow.Cells[1].Value.ToString() + " " + dataGridView1.CurrentRow.Cells[2].Value;
                if(MessageBox.Show($"Are you sure to delete {FullName} ","Attention", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    int Id =(int) dataGridView1.CurrentRow.Cells[0].Value;
                    repository.Delete(Id);
                    BindGrid();

                }
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow!=null)
            {
                frmAddOrEdit frm = new frmAddOrEdit();
                var id = (int)dataGridView1.CurrentRow.Cells[0].Value;
                frm.ContactID = id;
                if(frm.ShowDialog()==DialogResult.OK)
                {
                    BindGrid();
                }
            }
        }

        private void txtSearh_TextChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource=repository.Search(txtSearh.Text);
        }
    }
}
