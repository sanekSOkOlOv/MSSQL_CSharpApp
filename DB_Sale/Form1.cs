using Microsoft.EntityFrameworkCore;
using System.Text;
using System.Xml;

namespace DB_Sale
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            using (var context = new MSSQLContext())
            {
                var bikes = context.Bikes.ToList();
                var sales = context.Sales.ToList();
                var clients = context.Clients.Include(c => c.Sales).ToList();
                var rents = context.Rents.ToList();

                dataGridView1.DataSource = bikes;
                dataGridView2.DataSource = sales;
                dataGridView3.DataSource = clients;
                dataGridView4.DataSource = rents;
            }


        }
    }


}