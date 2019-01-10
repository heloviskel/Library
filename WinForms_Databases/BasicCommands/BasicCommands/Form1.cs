using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BasicCommands
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void customersBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.customersBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.northwindDataSet);

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'northwindDataSet.Customers' table. You can move, or remove it, as needed.
            this.customersTableAdapter.Fill(this.northwindDataSet.Customers);

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            customersBindingSource.EndEdit();
            customersTableAdapter.Update(northwindDataSet);
            Console.WriteLine("Базу даних успiшно оновлено!!!");
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            this.northwindDataSet.Customers.AddCustomersRow(this.northwindDataSet.Customers.NewCustomersRow());
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {

        }
    }
}
