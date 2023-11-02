using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

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

                try
                {
                    var query = from client in context.Clients
                                join sale in context.Sales on client.Sale_Id equals sale.id
                                select new
                                {
                                    client.Name,
                                    client.Surname,
                                    Expr1 = sale.Name,
                                    sale.Percent_Sale
                                };

                    // Выполните запрос и установите результаты в DataGridView
                    dataGridView5.DataSource = query.ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Произошла ошибка: " + ex.Message);
                }
                try
                {
                    var query = from rent in context.Rents
                                join bike in context.Bikes on rent.Bike_id equals bike.id
                                join client in context.Clients on rent.Client_id equals client.id
                                join sale in context.Sales on client.Sale_Id equals sale.id
                                select new
                                {
                                    Day = rent.Day,
                                    Percent_Sale = sale.Percent_Sale,
                                    Name = client.Name,
                                    Model = bike.Model,
                                    Cost = bike.Cost,
                                    RentTotal = rent.Day * bike.Cost
                                };


                    // Выполните запрос и установите результаты в DataGridView
                    dataGridView6.DataSource = query.ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Произошла ошибка: " + ex.Message);
                }
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string model = textBox1.Text;
            int price = int.Parse(textBox2.Text);
            int speed = int.Parse(textBox3.Text);
            int wheelSize = int.Parse(textBox4.Text);

            var newBike = new Bikes
            {
                Model = model,
                Cost = price,
                Speed = speed,
                Wheel_Size = wheelSize
            };

            using (var context = new MSSQLContext())
            {

                context.Bikes.Add(newBike);
                context.SaveChanges();

                var bikes = context.Bikes.ToList();
                dataGridView1.DataSource = bikes;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string model = textBox1.Text;
            int price = int.Parse(textBox2.Text);
            int speed = int.Parse(textBox3.Text);
            int wheelSize = int.Parse(textBox4.Text);

            var newBike = new Bikes
            {
                Model = model,
                Cost = price,
                Speed = speed,
                Wheel_Size = wheelSize
            };
            using (var context = new MSSQLContext())
            {
                int bikeId = int.Parse(textBox5.Text);
                var bikeToUpdate = context.Bikes.FirstOrDefault(b => b.id == bikeId);
                if (bikeToUpdate != null)
                {
                    bikeToUpdate.Model = model;
                    bikeToUpdate.Cost = price;
                    bikeToUpdate.Speed = speed;
                    bikeToUpdate.Wheel_Size = wheelSize;
                    context.SaveChanges();

                    var bikes = context.Bikes.ToList();
                    dataGridView1.DataSource = bikes;
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int bikeId = int.Parse(textBox5.Text);

            using (var context = new MSSQLContext())
            {
                var bikeToDelete = context.Bikes.FirstOrDefault(b => b.id == bikeId);
                if (bikeToDelete != null)
                {
                    context.Bikes.Remove(bikeToDelete);
                    context.SaveChanges();

                    var bikes = context.Bikes.ToList();
                    dataGridView1.DataSource = bikes;
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            using (var context = new MSSQLContext())
            {
                var bikes = context.Bikes.ToList();
                string bikesInfo = string.Join(Environment.NewLine, bikes.Select(bike =>
                     $"ID: {bike.id}, Model: {bike.Model}, Price: {bike.Cost:C}, Speed: {bike.Speed} km/h, Wheel Size: {bike.Wheel_Size}\""));


                label7.Text = bikesInfo;
            }
        }
    }


}