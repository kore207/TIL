namespace HelloCSharpWin
{
    partial class Calculator
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
            this.HelloLable = new System.Windows.Forms.Label();
            this.Sum1 = new System.Windows.Forms.TextBox();
            this.Sum2 = new System.Windows.Forms.TextBox();
            this.SumNumbers = new System.Windows.Forms.Button();
            this.SumResult = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // HelloLable
            // 
            this.HelloLable.AutoSize = true;
            this.HelloLable.Cursor = System.Windows.Forms.Cursors.Hand;
            this.HelloLable.Location = new System.Drawing.Point(29, 34);
            this.HelloLable.Name = "HelloLable";
            this.HelloLable.Size = new System.Drawing.Size(105, 12);
            this.HelloLable.TabIndex = 0;
            this.HelloLable.Text = "여기를 클릭하세요";
            this.HelloLable.Click += new System.EventHandler(this.HelloLable_Click);
            // 
            // Sum1
            // 
            this.Sum1.Location = new System.Drawing.Point(15, 72);
            this.Sum1.Name = "Sum1";
            this.Sum1.Size = new System.Drawing.Size(100, 21);
            this.Sum1.TabIndex = 1;
            // 
            // Sum2
            // 
            this.Sum2.Location = new System.Drawing.Point(137, 72);
            this.Sum2.Name = "Sum2";
            this.Sum2.Size = new System.Drawing.Size(100, 21);
            this.Sum2.TabIndex = 2;
            // 
            // SumNumbers
            // 
            this.SumNumbers.Location = new System.Drawing.Point(243, 72);
            this.SumNumbers.Name = "SumNumbers";
            this.SumNumbers.Size = new System.Drawing.Size(75, 23);
            this.SumNumbers.TabIndex = 3;
            this.SumNumbers.Text = "=";
            this.SumNumbers.UseVisualStyleBackColor = true;
            this.SumNumbers.Click += new System.EventHandler(this.SumNumbers_Click);
            // 
            // SumResult
            // 
            this.SumResult.Location = new System.Drawing.Point(325, 73);
            this.SumResult.Name = "SumResult";
            this.SumResult.Size = new System.Drawing.Size(100, 21);
            this.SumResult.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(121, 77);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(11, 12);
            this.label1.TabIndex = 5;
            this.label1.Text = "+";
            // 
            // Calculator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(455, 377);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.SumResult);
            this.Controls.Add(this.SumNumbers);
            this.Controls.Add(this.Sum2);
            this.Controls.Add(this.Sum1);
            this.Controls.Add(this.HelloLable);
            this.Name = "Calculator";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label HelloLable;
        private System.Windows.Forms.TextBox Sum1;
        private System.Windows.Forms.TextBox Sum2;
        private System.Windows.Forms.Button SumNumbers;
        private System.Windows.Forms.TextBox SumResult;
        private System.Windows.Forms.Label label1;
    }
}

