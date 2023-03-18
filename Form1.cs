using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace task
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
        }

        private async void button1_Click(object sender, EventArgs e)
        {

            txtMain.Text = string.Empty;
            txtFlow.Text = string.Empty; 
            txtTask1.Text = string.Empty; 
            txtTask2.Text = string.Empty;  

            var task1 = new Task(()=>
            {
                Thread.Sleep(5000);
                txtTask1.Text = "finalizacion task1 (5 segundos)";
            });
            task1.Start();


            var task2 = new Task(() =>
            {
                Thread.Sleep(3000);
                txtTask2.Text = "finalizacion task2 (3 segundos)";
            });
            task2.Start();

            txtFlow.Text = "realizando tareas";

            await task1;
            await task2;

            txtMain.Text = "fin tarea general";

        }


    }
}
