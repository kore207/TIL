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
    public enum Operators { Add, Multi, Sub, Div }
    
    public partial class Calculator : Form
    {
        public int Result = 0;
        public bool isNewNum = true;
        public Operators Opt = Operators.Add;

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

        private void button1_Click(object sender, EventArgs e) //object 는 범용적인 변수 (클래스를 포함한 모든 변수를 받을수있음)
        {  
            Button numButton = (Button)sender;
            SetNum(numButton.Text) ;
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
       
        private void button3_Click(object sender, EventArgs e) //+
        {
            //첫번째 변수 = 0;
            //숫자입력
            //case1 더하기버튼 - 두번쨰 숫자 완성, 두번째 변수에 저장, 첫번째 변수와 두번째 변수를 합, 겨로가를 첫번째 변수ㅜ에 다시 저장 

            //case2 더하기 버튼 - 숫자완성, 변수와 숫자 합, 결과를 변수에 다시 저장 

            //int num = int.Parse(NumScreen.Text);
            //Result += num;
            
            if (isNewNum == false) //중복입력 방지 
            {
                int num = int.Parse(NumScreen.Text);
                if (Opt == Operators.Add)
                    Result += num;
                else if (Opt == Operators.Sub)
                    Result -= num;

                NumScreen.Text = Result.ToString();
                isNewNum = true;
            }

            Button optButton = (Button)sender;
            if (optButton.Text == "+")
                Opt = Operators.Add;
            else if (optButton.Text == "-")
                Opt = Operators.Sub;
        }      
    }
}
