using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Random
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
             string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\stefa\\Documents\\Quest.mdf;Integrated Security=True;Connect Timeout=30";

            RandomRecordRetriever recordRetriever = new RandomRecordRetriever(connectionString);

            (int, string, string) randomRecord1 = recordRetriever.GetRandomRecordFromDatabase();

            if (randomRecord1 == (null, null, null))
            {
                Console.WriteLine("Не удалось получить случайную запись из базы данных.");
            }
            else
            {
                label1.Text = $"Билет № {Convert.ToString(randomRecord1.Item1)}";
                label2.Text = $"Задание № 1 {randomRecord1.Item2}";
                label3.Text = $"Задание № 2  {randomRecord1.Item3}";
            }
        }
    }
}
