using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HelloCSharpWin
{
    public partial class Calculator : Form
    {
        public Calculator()
        {
            InitializeComponent();
        }

        private void HelloLable_Click(object sender, EventArgs e)
        {
            HelloLable.Text = "Hello C#";

            int num1 = 1 ;
            int num2 = 2 ;

            int sum = num1 + num2 ;
            HelloLable.Text = sum.ToString() ;
        }

        private void SumNumbers_Click(object sender, EventArgs e)
        {
            int number1 = 0;
            int number2 = 0;


            if (String.IsNullOrWhiteSpace(Sum1.Text))
            {
                MessageBox.Show("Sum1에 숫자를 입력해주세요.");
                Sum1.SelectAll();
                Sum1.Focus();
                return;
            }

            if (String.IsNullOrWhiteSpace(Sum2.Text))
            {
                MessageBox.Show("Sum2에 숫자를 입력해주세요.");
                Sum2.SelectAll();
                Sum2.Focus();
                return;
            }

            if (int.TryParse(Sum1.Text, out number1) == false) //문자를 숫자로 바꾼다. (out 인자를 통해 첫번째 매개변수의 값을 받아온다 )
            {
                MessageBox.Show("Sum1에 문자가 들어왔습니다. 숫자를 입력해주세요 .");
                Sum1.SelectAll();
                Sum1.Focus();
                return;
            }

            if (int.TryParse(Sum2.Text, out number2) == false) 
            {
                MessageBox.Show("Sum2에 문자가 들어왔습니다. 숫자를 입력해주세요 .");
                Sum2.SelectAll();
                Sum2.Focus();
                return;
            }
            number1 = Convert.ToInt32(Sum1.Text) ;
            number2 = Convert.ToInt32(Sum2.Text) ;

            int sum = Add(number1, number2) ;

            SumResult.Text = sum.ToString() ;
        }

        public int Add(int number1, int number2)
        {
            int sum = number1 + number2 ;
            return sum ;
        }

        public float Add(float number1, float number2)
        {
            float sum = number1 + number2;
            return sum;
        }

        public int Sub(int number1, int number2)
        {
            int sum = number1 - number2;
            return sum;
        }

    }
}
