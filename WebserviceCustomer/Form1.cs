using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
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
                var url = "https://localhost:44369/FibonacciService.asmx";
                var result = WebserviceHelper.CallFubonacciWebService(url, "calcul", 10).ContinueWith(t =>
                {
                    busyForm.Close();
                }).ConfigureAwait(false);
                busyForm.ShowDialog();
               
                busyForm.Hide();
                //MessageBox.Show(result);

            }
        }
    }
}
