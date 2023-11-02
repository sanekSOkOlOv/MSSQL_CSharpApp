using Microsoft.EntityFrameworkCore;

namespace DB_Sale
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public class Bike
        {
            public int Id { get; set; }
            public string Model { get; set; }
            public int Speed { get; set; }
            public int Cost { get; set; }
            public int Wheel_Size { get; set; }
        }

        public class BikeContext : DbContext
        {
            public DbSet<Bike> Bikes { get; set; }
        }
        private void Form1_Load(object sender, EventArgs e)
        { 
            
        }
    }
}