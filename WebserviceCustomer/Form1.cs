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

namespace WebserviceCustomer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void FubonacciButton_Click(object sender, EventArgs e)
        {
            using (BusyForm busyForm = new BusyForm())
            {
                
                
                busyForm.Show(this);

                var result = FibonacciService.CallFubonacciWebService(10).Result;
                Thread.Sleep(1000);
                busyForm.Close();
                MessageBox.Show(result.ToString());

            }
        }
    }
}
