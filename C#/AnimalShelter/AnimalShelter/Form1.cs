using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AnimalShelter
{
    public partial class Form1 : Form //partial 이 붙으면 클래스의 정의가 여러군데 있다
    {
        public Form1()
        {
            InitializeComponent();
        }
            
        private void CreateCustomer_Click(object sender, EventArgs e)
        {
            Customer cus = new Customer("A", "Na", 10);
            cus.Address = "dunsan";

            CusFullName.Text = cus.FullName;
            
            CusAge.Text = cus.Age.ToString();
            CusAdress.Text = cus.Address;
            CusDescription.Text = cus.Description;

            bool test = cus.IsQualified;

            DateTime date = new DateTime(2016,2,5);
            
        }

   
    }
}
