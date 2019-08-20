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
        public int Result = 0;
        public bool isNewNum = true;

        public Calculator()
        {
            InitializeComponent();
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
            int sub = number1 - number2;
            return sub;
        }

        private void button1_Click(object sender, EventArgs e)
        {               
            SetNum("1");
        }

        public void SetNum(string num)
        {
            if (isNewNum)
            {
                NumScreen.Text = num;
                isNewNum = false;
            }
            else if (NumScreen.Text == "0")
            {
                NumScreen.Text = num;
            }
            else
            {
                NumScreen.Text = NumScreen.Text + num;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SetNum("2");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //첫번째 변수 = 0;
            //숫자입력
            //case1 더하기버튼 - 두번쨰 숫자 완성, 두번째 변수에 저장, 첫번째 변수와 두번째 변수를 합, 겨로가를 첫번째 변수ㅜ에 다시 저장 

            //case2 더하기 버튼 - 숫자완성, 변수와 숫자 합, 결과를 변수에 다시 저장 

            int num = int.Parse(NumScreen.Text);
            Result += num;

            NumScreen.Text = Result.ToString();
            isNewNum = true;

        }
    }
}
