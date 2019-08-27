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
        public Customer[] CustomerArray = new Customer[10];
        public int CustomerArrayIndex = 0;

        public Form1()
        {
            InitializeComponent();
        }
            
        private void CreateCustomer_Click(object sender, EventArgs e)
        {
            CustomerArray[CustomerArrayIndex] = new Customer(CusNewFirstName.Text, CusNewLastName.Text,
                                        20);

            CustomerArray[CustomerArrayIndex].Address = CusNewAdress.Text;
            CustomerArray[CustomerArrayIndex].Description = CusNewDescription.Text;

            CustomerList.Items.Add(CustomerArray[CustomerArrayIndex].FirstName);
            CustomerArrayIndex++;
            
            
        }

        //public void ShowDetails(Customer cus)
        //{
        //    CusFullName.Text = cus.FullName;
        //    CusAge.Text = cus.Age.ToString();
        //    CusAdress.Text = cus.Address;
        //    CusDescription.Text = cus.Description;
            
        //}

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
