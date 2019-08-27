namespace AnimalShelter
{
    partial class Form1
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.CreateCustomer = new System.Windows.Forms.Button();
            this.CusDetailPanel = new System.Windows.Forms.Panel();
            this.CusDescription = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.CusAdress = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.CusAge = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.CusFullName = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.CusNewLastName = new System.Windows.Forms.TextBox();
            this.CusNewFirstName = new System.Windows.Forms.TextBox();
            this.CusNewBirthday = new System.Windows.Forms.TextBox();
            this.CusNewAdress = new System.Windows.Forms.TextBox();
            this.CusNewDescription = new System.Windows.Forms.TextBox();
            this.CustomerList = new System.Windows.Forms.ListBox();
            this.CusDetailPanel.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // CreateCustomer
            // 
            this.CreateCustomer.Location = new System.Drawing.Point(224, 89);
            this.CreateCustomer.Name = "CreateCustomer";
            this.CreateCustomer.Size = new System.Drawing.Size(194, 65);
            this.CreateCustomer.TabIndex = 0;
            this.CreateCustomer.Text = "입양자 생성";
            this.CreateCustomer.UseVisualStyleBackColor = true;
            this.CreateCustomer.Click += new System.EventHandler(this.CreateCustomer_Click);
            // 
            // CusDetailPanel
            // 
            this.CusDetailPanel.Controls.Add(this.CusDescription);
            this.CusDetailPanel.Controls.Add(this.label6);
            this.CusDetailPanel.Controls.Add(this.CusAdress);
            this.CusDetailPanel.Controls.Add(this.label5);
            this.CusDetailPanel.Controls.Add(this.CusAge);
            this.CusDetailPanel.Controls.Add(this.label4);
            this.CusDetailPanel.Controls.Add(this.CusFullName);
            this.CusDetailPanel.Controls.Add(this.label3);
            this.CusDetailPanel.Location = new System.Drawing.Point(534, 70);
            this.CusDetailPanel.Name = "CusDetailPanel";
            this.CusDetailPanel.Size = new System.Drawing.Size(425, 407);
            this.CusDetailPanel.TabIndex = 1;
            // 
            // CusDescription
            // 
            this.CusDescription.AutoSize = true;
            this.CusDescription.Location = new System.Drawing.Point(78, 127);
            this.CusDescription.Name = "CusDescription";
            this.CusDescription.Size = new System.Drawing.Size(63, 12);
            this.CusDescription.TabIndex = 9;
            this.CusDescription.Text = "LastName";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(27, 127);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 12);
            this.label6.TabIndex = 8;
            this.label6.Text = "설명";
            // 
            // CusAdress
            // 
            this.CusAdress.AutoSize = true;
            this.CusAdress.Location = new System.Drawing.Point(78, 100);
            this.CusAdress.Name = "CusAdress";
            this.CusAdress.Size = new System.Drawing.Size(63, 12);
            this.CusAdress.TabIndex = 7;
            this.CusAdress.Text = "LastName";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(27, 100);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 12);
            this.label5.TabIndex = 6;
            this.label5.Text = "주소";
            // 
            // CusAge
            // 
            this.CusAge.AutoSize = true;
            this.CusAge.Location = new System.Drawing.Point(78, 72);
            this.CusAge.Name = "CusAge";
            this.CusAge.Size = new System.Drawing.Size(63, 12);
            this.CusAge.TabIndex = 5;
            this.CusAge.Text = "LastName";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(27, 72);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 4;
            this.label4.Text = "나이";
            // 
            // CusFullName
            // 
            this.CusFullName.AutoSize = true;
            this.CusFullName.Location = new System.Drawing.Point(78, 45);
            this.CusFullName.Name = "CusFullName";
            this.CusFullName.Size = new System.Drawing.Size(59, 12);
            this.CusFullName.TabIndex = 3;
            this.CusFullName.Text = "FullName";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(27, 45);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "이름";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.CusNewDescription);
            this.panel1.Controls.Add(this.CusNewAdress);
            this.panel1.Controls.Add(this.CusNewBirthday);
            this.panel1.Controls.Add(this.CusNewFirstName);
            this.panel1.Controls.Add(this.CusNewLastName);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(224, 170);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(270, 307);
            this.panel1.TabIndex = 2;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(16, 138);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(37, 12);
            this.label9.TabIndex = 7;
            this.label9.Text = "설명 :";
            this.label9.Click += new System.EventHandler(this.label9_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(16, 110);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(37, 12);
            this.label8.TabIndex = 6;
            this.label8.Text = "주소 :";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(16, 87);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(37, 12);
            this.label7.TabIndex = 5;
            this.label7.Text = "생일 :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "이름 :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(25, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "성 :";
            // 
            // CusNewLastName
            // 
            this.CusNewLastName.Location = new System.Drawing.Point(69, 24);
            this.CusNewLastName.Name = "CusNewLastName";
            this.CusNewLastName.Size = new System.Drawing.Size(100, 21);
            this.CusNewLastName.TabIndex = 8;
            // 
            // CusNewFirstName
            // 
            this.CusNewFirstName.Location = new System.Drawing.Point(69, 54);
            this.CusNewFirstName.Name = "CusNewFirstName";
            this.CusNewFirstName.Size = new System.Drawing.Size(100, 21);
            this.CusNewFirstName.TabIndex = 9;
            // 
            // CusNewBirthday
            // 
            this.CusNewBirthday.Location = new System.Drawing.Point(69, 84);
            this.CusNewBirthday.Name = "CusNewBirthday";
            this.CusNewBirthday.Size = new System.Drawing.Size(100, 21);
            this.CusNewBirthday.TabIndex = 10;
            // 
            // CusNewAdress
            // 
            this.CusNewAdress.Location = new System.Drawing.Point(69, 111);
            this.CusNewAdress.Name = "CusNewAdress";
            this.CusNewAdress.Size = new System.Drawing.Size(100, 21);
            this.CusNewAdress.TabIndex = 11;
            // 
            // CusNewDescription
            // 
            this.CusNewDescription.Location = new System.Drawing.Point(69, 138);
            this.CusNewDescription.Multiline = true;
            this.CusNewDescription.Name = "CusNewDescription";
            this.CusNewDescription.Size = new System.Drawing.Size(185, 152);
            this.CusNewDescription.TabIndex = 12;
            this.CusNewDescription.TextChanged += new System.EventHandler(this.textBox5_TextChanged);
            // 
            // CustomerList
            // 
            this.CustomerList.FormattingEnabled = true;
            this.CustomerList.ItemHeight = 12;
            this.CustomerList.Location = new System.Drawing.Point(13, 89);
            this.CustomerList.Name = "CustomerList";
            this.CustomerList.Size = new System.Drawing.Size(185, 388);
            this.CustomerList.TabIndex = 3;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(992, 552);
            this.Controls.Add(this.CustomerList);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.CusDetailPanel);
            this.Controls.Add(this.CreateCustomer);
            this.Name = "Form1";
            this.CusDetailPanel.ResumeLayout(false);
            this.CusDetailPanel.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button CreateCustomer;
        private System.Windows.Forms.Panel CusDetailPanel;
        private System.Windows.Forms.Label CusDescription;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label CusAdress;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label CusAge;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label CusFullName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox CusNewDescription;
        private System.Windows.Forms.TextBox CusNewAdress;
        private System.Windows.Forms.TextBox CusNewBirthday;
        private System.Windows.Forms.TextBox CusNewFirstName;
        private System.Windows.Forms.TextBox CusNewLastName;
        private System.Windows.Forms.ListBox CustomerList;
    }
}

