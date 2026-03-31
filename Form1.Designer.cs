namespace SimpleCalculator
{
    partial class frmCalculator
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 리소스를 정리합니다.
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
            lblSimpleCalculator = new Label();
            txtInputWindow = new TextBox();
            txtOutputWindow = new TextBox();
            btnEditCE = new Button();
            btnEditC = new Button();
            btnEditDel = new Button();
            btnOpDiv = new Button();
            btnNum7 = new Button();
            btnNum8 = new Button();
            btnNum9 = new Button();
            btnOpMul = new Button();
            btnNum4 = new Button();
            btnNum5 = new Button();
            btnNum6 = new Button();
            btnOpSub = new Button();
            btnNum1 = new Button();
            btnNum2 = new Button();
            btnNum3 = new Button();
            btnOpAdd = new Button();
            btnFuncPlus = new Button();
            btnNum0 = new Button();
            btnFuncDot = new Button();
            btnOpEql = new Button();
            SuspendLayout();
            // 
            // lblSimpleCalculator
            // 
            lblSimpleCalculator.AutoSize = true;
            lblSimpleCalculator.Font = new Font("맑은 고딕", 28F, FontStyle.Regular, GraphicsUnit.Point);
            lblSimpleCalculator.ForeColor = Color.Red;
            lblSimpleCalculator.Location = new Point(78, 20);
            lblSimpleCalculator.Name = "lblSimpleCalculator";
            lblSimpleCalculator.Size = new Size(306, 51);
            lblSimpleCalculator.TabIndex = 0;
            lblSimpleCalculator.Text = "Simple Calculator";
            // 
            // txtInputWindow
            // 
            txtInputWindow.Font = new Font("맑은 고딕", 14F, FontStyle.Regular, GraphicsUnit.Point);
            txtInputWindow.Location = new Point(30, 92);
            txtInputWindow.Name = "txtInputWindow";
            txtInputWindow.ReadOnly = true;
            txtInputWindow.Size = new Size(440, 32);
            txtInputWindow.TabIndex = 1;
            // 
            // txtOutputWindow
            // 
            txtOutputWindow.BackColor = Color.Lime;
            txtOutputWindow.Font = new Font("맑은 고딕", 16F, FontStyle.Bold, GraphicsUnit.Point);
            txtOutputWindow.Location = new Point(30, 137);
            txtOutputWindow.Name = "txtOutputWindow";
            txtOutputWindow.ReadOnly = true;
            txtOutputWindow.Size = new Size(440, 36);
            txtOutputWindow.TabIndex = 2;
            // 
            // btnEditCE
            // 
            btnEditCE.BackColor = Color.FromArgb(255, 255, 128);
            btnEditCE.Font = new Font("맑은 고딕", 16F, FontStyle.Regular, GraphicsUnit.Point);
            btnEditCE.Location = new Point(40, 200);
            btnEditCE.Name = "btnEditCE";
            btnEditCE.Size = new Size(90, 44);
            btnEditCE.TabIndex = 3;
            btnEditCE.Text = "CE";
            btnEditCE.UseVisualStyleBackColor = false;
            // 
            // btnEditC
            // 
            btnEditC.BackColor = Color.FromArgb(255, 255, 128);
            btnEditC.Font = new Font("맑은 고딕", 16F, FontStyle.Regular, GraphicsUnit.Point);
            btnEditC.Location = new Point(150, 200);
            btnEditC.Name = "btnEditC";
            btnEditC.Size = new Size(90, 44);
            btnEditC.TabIndex = 4;
            btnEditC.Text = "C";
            btnEditC.UseVisualStyleBackColor = false;
            // 
            // btnEditDel
            // 
            btnEditDel.BackColor = Color.FromArgb(255, 255, 128);
            btnEditDel.Font = new Font("맑은 고딕", 16F, FontStyle.Regular, GraphicsUnit.Point);
            btnEditDel.Location = new Point(260, 200);
            btnEditDel.Name = "btnEditDel";
            btnEditDel.Size = new Size(90, 44);
            btnEditDel.TabIndex = 5;
            btnEditDel.Text = "Del";
            btnEditDel.UseVisualStyleBackColor = false;
            // 
            // btnOpDiv
            // 
            btnOpDiv.BackColor = Color.FromArgb(255, 128, 255);
            btnOpDiv.Font = new Font("맑은 고딕", 16F, FontStyle.Regular, GraphicsUnit.Point);
            btnOpDiv.Location = new Point(370, 200);
            btnOpDiv.Name = "btnOpDiv";
            btnOpDiv.Size = new Size(90, 44);
            btnOpDiv.TabIndex = 6;
            btnOpDiv.Text = "÷";
            btnOpDiv.UseVisualStyleBackColor = false;
            // 
            // btnNum7
            // 
            btnNum7.BackColor = Color.FromArgb(128, 255, 128);
            btnNum7.Font = new Font("맑은 고딕", 16F, FontStyle.Regular, GraphicsUnit.Point);
            btnNum7.Location = new Point(40, 256);
            btnNum7.Name = "btnNum7";
            btnNum7.Size = new Size(90, 44);
            btnNum7.TabIndex = 7;
            btnNum7.Text = "7";
            btnNum7.UseVisualStyleBackColor = false;
            // 
            // btnNum8
            // 
            btnNum8.BackColor = Color.FromArgb(128, 255, 128);
            btnNum8.Font = new Font("맑은 고딕", 16F, FontStyle.Regular, GraphicsUnit.Point);
            btnNum8.Location = new Point(150, 256);
            btnNum8.Name = "btnNum8";
            btnNum8.Size = new Size(90, 44);
            btnNum8.TabIndex = 8;
            btnNum8.Text = "8";
            btnNum8.UseVisualStyleBackColor = false;
            // 
            // btnNum9
            // 
            btnNum9.BackColor = Color.FromArgb(128, 255, 128);
            btnNum9.Font = new Font("맑은 고딕", 16F, FontStyle.Regular, GraphicsUnit.Point);
            btnNum9.Location = new Point(260, 256);
            btnNum9.Name = "btnNum9";
            btnNum9.Size = new Size(90, 44);
            btnNum9.TabIndex = 9;
            btnNum9.Text = "9";
            btnNum9.UseVisualStyleBackColor = false;
            // 
            // btnOpMul
            // 
            btnOpMul.BackColor = Color.FromArgb(255, 128, 255);
            btnOpMul.Font = new Font("맑은 고딕", 16F, FontStyle.Regular, GraphicsUnit.Point);
            btnOpMul.Location = new Point(370, 256);
            btnOpMul.Name = "btnOpMul";
            btnOpMul.Size = new Size(90, 44);
            btnOpMul.TabIndex = 10;
            btnOpMul.Text = "×";
            btnOpMul.UseVisualStyleBackColor = false;
            // 
            // btnNum4
            // 
            btnNum4.BackColor = Color.FromArgb(128, 255, 128);
            btnNum4.Font = new Font("맑은 고딕", 16F, FontStyle.Regular, GraphicsUnit.Point);
            btnNum4.Location = new Point(40, 312);
            btnNum4.Name = "btnNum4";
            btnNum4.Size = new Size(90, 44);
            btnNum4.TabIndex = 11;
            btnNum4.Text = "4";
            btnNum4.UseVisualStyleBackColor = false;
            // 
            // btnNum5
            // 
            btnNum5.BackColor = Color.FromArgb(128, 255, 128);
            btnNum5.Font = new Font("맑은 고딕", 16F, FontStyle.Regular, GraphicsUnit.Point);
            btnNum5.Location = new Point(150, 312);
            btnNum5.Name = "btnNum5";
            btnNum5.Size = new Size(90, 44);
            btnNum5.TabIndex = 12;
            btnNum5.Text = "5";
            btnNum5.UseVisualStyleBackColor = false;
            // 
            // btnNum6
            // 
            btnNum6.BackColor = Color.FromArgb(128, 255, 128);
            btnNum6.Font = new Font("맑은 고딕", 16F, FontStyle.Regular, GraphicsUnit.Point);
            btnNum6.Location = new Point(260, 312);
            btnNum6.Name = "btnNum6";
            btnNum6.Size = new Size(90, 44);
            btnNum6.TabIndex = 13;
            btnNum6.Text = "6";
            btnNum6.UseVisualStyleBackColor = false;
            // 
            // btnOpSub
            // 
            btnOpSub.BackColor = Color.FromArgb(255, 128, 255);
            btnOpSub.Font = new Font("맑은 고딕", 16F, FontStyle.Regular, GraphicsUnit.Point);
            btnOpSub.Location = new Point(370, 312);
            btnOpSub.Name = "btnOpSub";
            btnOpSub.Size = new Size(90, 44);
            btnOpSub.TabIndex = 14;
            btnOpSub.Text = "-";
            btnOpSub.UseVisualStyleBackColor = false;
            // 
            // btnNum1
            // 
            btnNum1.BackColor = Color.FromArgb(128, 255, 128);
            btnNum1.Font = new Font("맑은 고딕", 16F, FontStyle.Regular, GraphicsUnit.Point);
            btnNum1.Location = new Point(40, 368);
            btnNum1.Name = "btnNum1";
            btnNum1.Size = new Size(90, 44);
            btnNum1.TabIndex = 15;
            btnNum1.Text = "1";
            btnNum1.UseVisualStyleBackColor = false;
            // 
            // btnNum2
            // 
            btnNum2.BackColor = Color.FromArgb(128, 255, 128);
            btnNum2.Font = new Font("맑은 고딕", 16F, FontStyle.Regular, GraphicsUnit.Point);
            btnNum2.Location = new Point(150, 368);
            btnNum2.Name = "btnNum2";
            btnNum2.Size = new Size(90, 44);
            btnNum2.TabIndex = 16;
            btnNum2.Text = "2";
            btnNum2.UseVisualStyleBackColor = false;
            // 
            // btnNum3
            // 
            btnNum3.BackColor = Color.FromArgb(128, 255, 128);
            btnNum3.Font = new Font("맑은 고딕", 16F, FontStyle.Regular, GraphicsUnit.Point);
            btnNum3.Location = new Point(260, 368);
            btnNum3.Name = "btnNum3";
            btnNum3.Size = new Size(90, 44);
            btnNum3.TabIndex = 17;
            btnNum3.Text = "3";
            btnNum3.UseVisualStyleBackColor = false;
            // 
            // btnOpAdd
            // 
            btnOpAdd.BackColor = Color.FromArgb(255, 128, 255);
            btnOpAdd.Font = new Font("맑은 고딕", 16F, FontStyle.Regular, GraphicsUnit.Point);
            btnOpAdd.Location = new Point(370, 368);
            btnOpAdd.Name = "btnOpAdd";
            btnOpAdd.Size = new Size(90, 44);
            btnOpAdd.TabIndex = 18;
            btnOpAdd.Text = "+";
            btnOpAdd.UseVisualStyleBackColor = false;
            // 
            // btnFuncPlus
            // 
            btnFuncPlus.BackColor = Color.FromArgb(128, 128, 255);
            btnFuncPlus.Font = new Font("맑은 고딕", 16F, FontStyle.Regular, GraphicsUnit.Point);
            btnFuncPlus.Location = new Point(40, 424);
            btnFuncPlus.Name = "btnFuncPlus";
            btnFuncPlus.Size = new Size(90, 44);
            btnFuncPlus.TabIndex = 19;
            btnFuncPlus.Text = "+/-";
            btnFuncPlus.UseVisualStyleBackColor = false;
            // 
            // btnNum0
            // 
            btnNum0.BackColor = Color.FromArgb(128, 255, 128);
            btnNum0.Font = new Font("맑은 고딕", 16F, FontStyle.Regular, GraphicsUnit.Point);
            btnNum0.Location = new Point(150, 424);
            btnNum0.Name = "btnNum0";
            btnNum0.Size = new Size(90, 44);
            btnNum0.TabIndex = 20;
            btnNum0.Text = "0";
            btnNum0.UseVisualStyleBackColor = false;
            // 
            // btnFuncDot
            // 
            btnFuncDot.BackColor = Color.FromArgb(128, 128, 255);
            btnFuncDot.Font = new Font("맑은 고딕", 16F, FontStyle.Regular, GraphicsUnit.Point);
            btnFuncDot.Location = new Point(260, 424);
            btnFuncDot.Name = "btnFuncDot";
            btnFuncDot.Size = new Size(90, 44);
            btnFuncDot.TabIndex = 21;
            btnFuncDot.Text = ".";
            btnFuncDot.UseVisualStyleBackColor = false;
            // 
            // btnOpEql
            // 
            btnOpEql.BackColor = Color.FromArgb(255, 128, 255);
            btnOpEql.Font = new Font("맑은 고딕", 16F, FontStyle.Regular, GraphicsUnit.Point);
            btnOpEql.Location = new Point(370, 424);
            btnOpEql.Name = "btnOpEql";
            btnOpEql.Size = new Size(90, 44);
            btnOpEql.TabIndex = 22;
            btnOpEql.Text = "=";
            btnOpEql.UseVisualStyleBackColor = false;
            // 
            // frmCalculator
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Gainsboro;
            ClientSize = new Size(505, 500);
            Controls.Add(btnOpEql);
            Controls.Add(btnFuncDot);
            Controls.Add(btnNum0);
            Controls.Add(btnFuncPlus);
            Controls.Add(btnOpAdd);
            Controls.Add(btnNum3);
            Controls.Add(btnNum2);
            Controls.Add(btnNum1);
            Controls.Add(btnOpSub);
            Controls.Add(btnNum6);
            Controls.Add(btnNum5);
            Controls.Add(btnNum4);
            Controls.Add(btnOpMul);
            Controls.Add(btnNum9);
            Controls.Add(btnNum8);
            Controls.Add(btnNum7);
            Controls.Add(btnOpDiv);
            Controls.Add(btnEditDel);
            Controls.Add(btnEditC);
            Controls.Add(btnEditCE);
            Controls.Add(txtOutputWindow);
            Controls.Add(txtInputWindow);
            Controls.Add(lblSimpleCalculator);
            Name = "frmCalculator";
            Text = "Calculator v1.0";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblSimpleCalculator;
        private TextBox txtInputWindow;
        private TextBox txtOutputWindow;
        private Button btnEditCE;
        private Button btnEditC;
        private Button btnEditDel;
        private Button btnOpDiv;
        private Button btnNum7;
        private Button btnNum8;
        private Button btnNum9;
        private Button btnOpMul;
        private Button btnNum4;
        private Button btnNum5;
        private Button btnNum6;
        private Button btnOpSub;
        private Button btnNum1;
        private Button btnNum2;
        private Button btnNum3;
        private Button btnOpAdd;
        private Button btnFuncPlus;
        private Button btnNum0;
        private Button btnFuncDot;
        private Button btnOpEql;
    }
}
