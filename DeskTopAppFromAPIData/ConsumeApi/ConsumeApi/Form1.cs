using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConsumeApi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async Task getdata()
        {
           
                // The base URL of your API
                string apiUrl = "https://localhost:7233/api/Product/GetAll";

                using (HttpClient client = new HttpClient())
                {
                    try
                    {
                        // Make a GET request to fetch employee data from API
                        HttpResponseMessage response = await client.GetAsync(apiUrl);

                        if (response.IsSuccessStatusCode)
                        {
                            // Deserialize the response into a list of Employee objects
                            var employeeData = await response.Content.ReadAsAsync<List<Product>>();

                            // Bind the data to DataGridView
                            grid.DataSource = employeeData;
                        }
                        else
                        {
                            MessageBox.Show("Error fetching data from API");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"An error occurred: {ex.Message}");
                    }
                }
            

        }

        private void button1_Click(object sender, EventArgs e)
        {
            getdata();
        }
    }
}
