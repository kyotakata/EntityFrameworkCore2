namespace WinFormsApp2
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
            dg = new DataGridView();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            button5 = new Button();
            button6 = new Button();
            button7 = new Button();
            button8 = new Button();
            button9 = new Button();
            button10 = new Button();
            button11 = new Button();
            button12 = new Button();
            button13 = new Button();
            button14 = new Button();
            button15 = new Button();
            button16 = new Button();
            button17 = new Button();
            ((System.ComponentModel.ISupportInitialize)dg).BeginInit();
            SuspendLayout();
            // 
            // dg
            // 
            dg.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dg.Location = new Point(21, 21);
            dg.Name = "dg";
            dg.RowHeadersWidth = 51;
            dg.Size = new Size(437, 297);
            dg.TabIndex = 0;
            // 
            // button1
            // 
            button1.Location = new Point(21, 336);
            button1.Name = "button1";
            button1.Size = new Size(94, 29);
            button1.TabIndex = 1;
            button1.Text = "EF";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(21, 371);
            button2.Name = "button2";
            button2.Size = new Size(94, 29);
            button2.TabIndex = 2;
            button2.Text = "where";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Location = new Point(21, 406);
            button3.Name = "button3";
            button3.Size = new Size(94, 29);
            button3.TabIndex = 3;
            button3.Text = "orderby";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button4
            // 
            button4.Location = new Point(21, 441);
            button4.Name = "button4";
            button4.Size = new Size(316, 29);
            button4.TabIndex = 4;
            button4.Text = "orderby 複数 失敗例";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // button5
            // 
            button5.Location = new Point(21, 476);
            button5.Name = "button5";
            button5.Size = new Size(316, 29);
            button5.TabIndex = 5;
            button5.Text = "orderby 複数 成功例";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // button6
            // 
            button6.Location = new Point(21, 511);
            button6.Name = "button6";
            button6.Size = new Size(316, 29);
            button6.TabIndex = 6;
            button6.Text = "orderby 複数 降順";
            button6.UseVisualStyleBackColor = true;
            button6.Click += button6_Click;
            // 
            // button7
            // 
            button7.Location = new Point(21, 546);
            button7.Name = "button7";
            button7.Size = new Size(316, 29);
            button7.TabIndex = 7;
            button7.Text = "orderby 複数 昇順 降順";
            button7.UseVisualStyleBackColor = true;
            button7.Click += button7_Click;
            // 
            // button8
            // 
            button8.Location = new Point(404, 336);
            button8.Name = "button8";
            button8.Size = new Size(94, 29);
            button8.TabIndex = 8;
            button8.Text = "Find";
            button8.UseVisualStyleBackColor = true;
            button8.Click += button8_Click;
            // 
            // button9
            // 
            button9.Location = new Point(404, 371);
            button9.Name = "button9";
            button9.Size = new Size(218, 29);
            button9.TabIndex = 9;
            button9.Text = "FirstOrDefault";
            button9.UseVisualStyleBackColor = true;
            button9.Click += button9_Click;
            // 
            // button10
            // 
            button10.Location = new Point(404, 406);
            button10.Name = "button10";
            button10.Size = new Size(218, 29);
            button10.TabIndex = 10;
            button10.Text = "Last";
            button10.UseVisualStyleBackColor = true;
            button10.Click += button10_Click;
            // 
            // button11
            // 
            button11.Location = new Point(404, 441);
            button11.Name = "button11";
            button11.Size = new Size(218, 29);
            button11.TabIndex = 11;
            button11.Text = "Single";
            button11.UseVisualStyleBackColor = true;
            button11.Click += button11_Click;
            // 
            // button12
            // 
            button12.Location = new Point(404, 476);
            button12.Name = "button12";
            button12.Size = new Size(218, 29);
            button12.TabIndex = 12;
            button12.Text = "クエリ構文";
            button12.UseVisualStyleBackColor = true;
            button12.Click += button12_Click;
            // 
            // button13
            // 
            button13.Location = new Point(404, 511);
            button13.Name = "button13";
            button13.Size = new Size(218, 29);
            button13.TabIndex = 13;
            button13.Text = "Like ％";
            button13.UseVisualStyleBackColor = true;
            button13.Click += button13_Click;
            // 
            // button14
            // 
            button14.Location = new Point(404, 546);
            button14.Name = "button14";
            button14.Size = new Size(218, 29);
            button14.TabIndex = 14;
            button14.Text = "Like _";
            button14.UseVisualStyleBackColor = true;
            button14.Click += button14_Click;
            // 
            // button15
            // 
            button15.Location = new Point(502, 21);
            button15.Name = "button15";
            button15.Size = new Size(218, 29);
            button15.TabIndex = 15;
            button15.Text = "orders";
            button15.UseVisualStyleBackColor = true;
            button15.Click += button15_Click;
            // 
            // button16
            // 
            button16.Location = new Point(502, 67);
            button16.Name = "button16";
            button16.Size = new Size(218, 29);
            button16.TabIndex = 16;
            button16.Text = "order items";
            button16.UseVisualStyleBackColor = true;
            button16.Click += button16_Click;
            // 
            // button17
            // 
            button17.Location = new Point(502, 114);
            button17.Name = "button17";
            button17.Size = new Size(218, 29);
            button17.TabIndex = 17;
            button17.Text = "join";
            button17.UseVisualStyleBackColor = true;
            button17.Click += button17_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 600);
            Controls.Add(button17);
            Controls.Add(button16);
            Controls.Add(button15);
            Controls.Add(button14);
            Controls.Add(button13);
            Controls.Add(button12);
            Controls.Add(button11);
            Controls.Add(button10);
            Controls.Add(button9);
            Controls.Add(button8);
            Controls.Add(button7);
            Controls.Add(button6);
            Controls.Add(button5);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(dg);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)dg).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dg;
        private Button button1;
        private Button button2;
        private Button button3;
        private Button button4;
        private Button button5;
        private Button button6;
        private Button button7;
        private Button button8;
        private Button button9;
        private Button button10;
        private Button button11;
        private Button button12;
        private Button button13;
        private Button button14;
        private Button button15;
        private Button button16;
        private Button button17;
    }
}
