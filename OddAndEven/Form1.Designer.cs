namespace OddAndEven
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            listEven = new ListBox();
            listOdd = new ListBox();
            textBox1 = new TextBox();
            btnAdd = new Button();
            btnOddToEven = new Button();
            btnOddToEvenAll = new Button();
            btnEvenToOdd = new Button();
            btnEvenToOddAll = new Button();
            btnAscending = new Button();
            btnDescending = new Button();
            SuspendLayout();
            // 
            // listEven
            // 
            listEven.FormattingEnabled = true;
            listEven.ItemHeight = 20;
            listEven.Location = new Point(44, 24);
            listEven.Name = "listEven";
            listEven.Size = new Size(170, 244);
            listEven.TabIndex = 0;
            listEven.Click += ListBox_Click;
            // 
            // listOdd
            // 
            listOdd.FormattingEnabled = true;
            listOdd.ItemHeight = 20;
            listOdd.Location = new Point(342, 24);
            listOdd.Name = "listOdd";
            listOdd.Size = new Size(170, 244);
            listOdd.TabIndex = 1;
            listOdd.Click += ListBox_Click;

            // 
            // textBox1
            // 
            textBox1.Location = new Point(44, 360);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(328, 27);
            textBox1.TabIndex = 2;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(418, 360);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(94, 29);
            btnAdd.TabIndex = 3;
            btnAdd.Text = "Add";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnOddToEven
            // 
            btnOddToEven.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point);
            btnOddToEven.Location = new Point(230, 47);
            btnOddToEven.Name = "btnOddToEven";
            btnOddToEven.Size = new Size(94, 29);
            btnOddToEven.TabIndex = 4;
            btnOddToEven.Text = "<-";
            btnOddToEven.UseVisualStyleBackColor = true;
            btnOddToEven.Click += btnOddToEven_Click;
            // 
            // btnOddToEvenAll
            // 
            btnOddToEvenAll.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point);
            btnOddToEvenAll.Location = new Point(230, 101);
            btnOddToEvenAll.Name = "btnOddToEvenAll";
            btnOddToEvenAll.Size = new Size(94, 29);
            btnOddToEvenAll.TabIndex = 5;
            btnOddToEvenAll.Text = "<- <-";
            btnOddToEvenAll.UseVisualStyleBackColor = true;
            btnOddToEvenAll.Click += btnOddToEvenAll_Click;
            // 
            // btnEvenToOdd
            // 
            btnEvenToOdd.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point);
            btnEvenToOdd.Location = new Point(230, 153);
            btnEvenToOdd.Name = "btnEvenToOdd";
            btnEvenToOdd.Size = new Size(94, 29);
            btnEvenToOdd.TabIndex = 6;
            btnEvenToOdd.Text = "->";
            btnEvenToOdd.UseVisualStyleBackColor = true;
            btnEvenToOdd.Click += btnEvenToOdd_Click;
            // 
            // btnEvenToOddAll
            // 
            btnEvenToOddAll.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point);
            btnEvenToOddAll.Location = new Point(230, 212);
            btnEvenToOddAll.Name = "btnEvenToOddAll";
            btnEvenToOddAll.Size = new Size(94, 29);
            btnEvenToOddAll.TabIndex = 7;
            btnEvenToOddAll.Text = "-> ->";
            btnEvenToOddAll.UseVisualStyleBackColor = true;
            btnEvenToOddAll.Click += btnEvenToOddAll_Click;
            // 
            // btnAscending
            // 
            btnAscending.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btnAscending.Location = new Point(552, 47);
            btnAscending.Name = "btnAscending";
            btnAscending.Size = new Size(114, 48);
            btnAscending.TabIndex = 8;
            btnAscending.Text = "Sort Ascending";
            btnAscending.UseVisualStyleBackColor = true;
            btnAscending.Click += btnAscending_Click;
            // 
            // btnDescending
            // 
            btnDescending.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btnDescending.Location = new Point(552, 101);
            btnDescending.Name = "btnDescending";
            btnDescending.Size = new Size(114, 48);
            btnDescending.TabIndex = 9;
            btnDescending.Text = "Sort Descending";
            btnDescending.UseVisualStyleBackColor = true;
            btnDescending.Click += btnDescending_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnDescending);
            Controls.Add(btnAscending);
            Controls.Add(btnEvenToOddAll);
            Controls.Add(btnEvenToOdd);
            Controls.Add(btnOddToEvenAll);
            Controls.Add(btnOddToEven);
            Controls.Add(btnAdd);
            Controls.Add(textBox1);
            Controls.Add(listOdd);
            Controls.Add(listEven);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListBox listEven;
        private ListBox listOdd;
        private TextBox textBox1;
        private Button btnAdd;
        private Button btnOddToEven;
        private Button btnOddToEvenAll;
        private Button btnEvenToOdd;
        private Button btnEvenToOddAll;
        private Button btnAscending;
        private Button btnDescending;
    }
}