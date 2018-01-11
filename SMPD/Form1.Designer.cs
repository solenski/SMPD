namespace SMPD
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.progressBar2 = new System.Windows.Forms.ProgressBar();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.maskedTextBox1 = new System.Windows.Forms.MaskedTextBox();
            this.Classifiers = new System.Windows.Forms.GroupBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.label13 = new System.Windows.Forms.Label();
            this.nMeanResult = new System.Windows.Forms.TextBox();
            this.nMeanExecute = new System.Windows.Forms.Button();
            this.nMeanTrain = new System.Windows.Forms.Button();
            this.label14 = new System.Windows.Forms.Label();
            this.nMSamplePercent = new System.Windows.Forms.MaskedTextBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.label12 = new System.Windows.Forms.Label();
            this.textBox9 = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.textBox8 = new System.Windows.Forms.TextBox();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.maskedTextBox3 = new System.Windows.Forms.MaskedTextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.maskedTextBox2 = new System.Windows.Forms.MaskedTextBox();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.crossvalidatecombo = new System.Windows.Forms.ComboBox();
            this.crossvalidatebutton = new System.Windows.Forms.Button();
            this.crossvalidateresult = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.crossvalidationparts = new System.Windows.Forms.TextBox();
            this.crossvalidp = new System.Windows.Forms.Label();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.label16 = new System.Windows.Forms.Label();
            this.bootsrapcount = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.bootstrapresult = new System.Windows.Forms.TextBox();
            this.bootsrapttest = new System.Windows.Forms.Button();
            this.bootstrapcombo = new System.Windows.Forms.ComboBox();
            this.label18 = new System.Windows.Forms.Label();
            this.bootstrapparts = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.Classifiers.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(464, 42);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Run";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.fisher_click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(6, 42);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(452, 23);
            this.progressBar1.TabIndex = 1;
            this.progressBar1.Click += new System.EventHandler(this.progressBar1_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.textBox5);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.textBox2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.progressBar1);
            this.groupBox1.Location = new System.Drawing.Point(9, 48);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(551, 75);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Fisher";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(346, 19);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(74, 13);
            this.label6.TabIndex = 7;
            this.label6.Text = "Criterion value";
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(421, 16);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(118, 20);
            this.textBox5.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Time";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(42, 16);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 20);
            this.textBox2.TabIndex = 4;
            this.textBox2.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(148, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Best features";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(223, 16);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(118, 20);
            this.textBox1.TabIndex = 2;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.textBox6);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.textBox3);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.textBox4);
            this.groupBox2.Controls.Add(this.button2);
            this.groupBox2.Controls.Add(this.progressBar2);
            this.groupBox2.Location = new System.Drawing.Point(9, 144);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(551, 75);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Sequential Forward Selection";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(346, 19);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(74, 13);
            this.label7.TabIndex = 7;
            this.label7.Text = "Criterion value";
            // 
            // textBox6
            // 
            this.textBox6.Location = new System.Drawing.Point(421, 16);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(118, 20);
            this.textBox6.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(30, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Time";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(42, 16);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(100, 20);
            this.textBox3.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(148, 19);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Best features";
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(223, 16);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(118, 20);
            this.textBox4.TabIndex = 2;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(464, 42);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 0;
            this.button2.Text = "Run";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.sfs_click);
            // 
            // progressBar2
            // 
            this.progressBar2.Location = new System.Drawing.Point(6, 42);
            this.progressBar2.Name = "progressBar2";
            this.progressBar2.Size = new System.Drawing.Size(452, 23);
            this.progressBar2.TabIndex = 1;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.maskedTextBox1);
            this.groupBox3.Controls.Add(this.groupBox1);
            this.groupBox3.Controls.Add(this.groupBox2);
            this.groupBox3.Location = new System.Drawing.Point(12, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(571, 235);
            this.groupBox3.TabIndex = 6;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Feature Selection";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(129, 22);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(97, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Number of features";
            // 
            // maskedTextBox1
            // 
            this.maskedTextBox1.Location = new System.Drawing.Point(232, 19);
            this.maskedTextBox1.Name = "maskedTextBox1";
            this.maskedTextBox1.Size = new System.Drawing.Size(118, 20);
            this.maskedTextBox1.TabIndex = 7;
            // 
            // Classifiers
            // 
            this.Classifiers.Controls.Add(this.groupBox6);
            this.Classifiers.Controls.Add(this.groupBox5);
            this.Classifiers.Controls.Add(this.groupBox4);
            this.Classifiers.Location = new System.Drawing.Point(12, 253);
            this.Classifiers.Name = "Classifiers";
            this.Classifiers.Size = new System.Drawing.Size(571, 303);
            this.Classifiers.TabIndex = 7;
            this.Classifiers.TabStop = false;
            this.Classifiers.Text = "Classifiers";
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.label13);
            this.groupBox6.Controls.Add(this.nMeanResult);
            this.groupBox6.Controls.Add(this.nMeanExecute);
            this.groupBox6.Controls.Add(this.nMeanTrain);
            this.groupBox6.Controls.Add(this.label14);
            this.groupBox6.Controls.Add(this.nMSamplePercent);
            this.groupBox6.Location = new System.Drawing.Point(9, 162);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(266, 137);
            this.groupBox6.TabIndex = 14;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "NM";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(22, 74);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(37, 13);
            this.label13.TabIndex = 13;
            this.label13.Text = "Result";
            // 
            // nMeanResult
            // 
            this.nMeanResult.Location = new System.Drawing.Point(65, 71);
            this.nMeanResult.Name = "nMeanResult";
            this.nMeanResult.Size = new System.Drawing.Size(178, 20);
            this.nMeanResult.TabIndex = 12;
            // 
            // nMeanExecute
            // 
            this.nMeanExecute.Location = new System.Drawing.Point(168, 42);
            this.nMeanExecute.Name = "nMeanExecute";
            this.nMeanExecute.Size = new System.Drawing.Size(75, 23);
            this.nMeanExecute.TabIndex = 11;
            this.nMeanExecute.Text = "Execute";
            this.nMeanExecute.UseVisualStyleBackColor = true;
            this.nMeanExecute.Click += new System.EventHandler(this.nMeanExecute_Click);
            // 
            // nMeanTrain
            // 
            this.nMeanTrain.Location = new System.Drawing.Point(87, 42);
            this.nMeanTrain.Name = "nMeanTrain";
            this.nMeanTrain.Size = new System.Drawing.Size(75, 23);
            this.nMeanTrain.TabIndex = 10;
            this.nMeanTrain.Text = "Train";
            this.nMeanTrain.UseVisualStyleBackColor = true;
            this.nMeanTrain.Click += new System.EventHandler(this.nMeanTrain_Click);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(6, 19);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(53, 13);
            this.label14.TabIndex = 9;
            this.label14.Text = "% Sample";
            // 
            // nMSamplePercent
            // 
            this.nMSamplePercent.Location = new System.Drawing.Point(65, 16);
            this.nMSamplePercent.Name = "nMSamplePercent";
            this.nMSamplePercent.Size = new System.Drawing.Size(178, 20);
            this.nMSamplePercent.TabIndex = 9;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.label12);
            this.groupBox5.Controls.Add(this.textBox9);
            this.groupBox5.Controls.Add(this.label10);
            this.groupBox5.Controls.Add(this.textBox8);
            this.groupBox5.Controls.Add(this.button5);
            this.groupBox5.Controls.Add(this.button6);
            this.groupBox5.Controls.Add(this.label11);
            this.groupBox5.Controls.Add(this.maskedTextBox3);
            this.groupBox5.Location = new System.Drawing.Point(292, 19);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(268, 137);
            this.groupBox5.TabIndex = 14;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "kNN";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(27, 23);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(45, 13);
            this.label12.TabIndex = 14;
            this.label12.Text = "param k";
            // 
            // textBox9
            // 
            this.textBox9.Location = new System.Drawing.Point(78, 19);
            this.textBox9.Name = "textBox9";
            this.textBox9.Size = new System.Drawing.Size(178, 20);
            this.textBox9.TabIndex = 8;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(35, 106);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(37, 13);
            this.label10.TabIndex = 13;
            this.label10.Text = "Result";
            // 
            // textBox8
            // 
            this.textBox8.Location = new System.Drawing.Point(78, 103);
            this.textBox8.Name = "textBox8";
            this.textBox8.Size = new System.Drawing.Size(178, 20);
            this.textBox8.TabIndex = 12;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(181, 74);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(75, 23);
            this.button5.TabIndex = 11;
            this.button5.Text = "Execute";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(100, 74);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(75, 23);
            this.button6.TabIndex = 10;
            this.button6.Text = "Train";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(19, 51);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(53, 13);
            this.label11.TabIndex = 9;
            this.label11.Text = "% Sample";
            // 
            // maskedTextBox3
            // 
            this.maskedTextBox3.Location = new System.Drawing.Point(78, 48);
            this.maskedTextBox3.Name = "maskedTextBox3";
            this.maskedTextBox3.Size = new System.Drawing.Size(178, 20);
            this.maskedTextBox3.TabIndex = 9;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label9);
            this.groupBox4.Controls.Add(this.textBox7);
            this.groupBox4.Controls.Add(this.button4);
            this.groupBox4.Controls.Add(this.button3);
            this.groupBox4.Controls.Add(this.label8);
            this.groupBox4.Controls.Add(this.maskedTextBox2);
            this.groupBox4.Location = new System.Drawing.Point(9, 19);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(266, 137);
            this.groupBox4.TabIndex = 0;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "NN";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(22, 74);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(37, 13);
            this.label9.TabIndex = 13;
            this.label9.Text = "Result";
            // 
            // textBox7
            // 
            this.textBox7.Location = new System.Drawing.Point(65, 71);
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new System.Drawing.Size(178, 20);
            this.textBox7.TabIndex = 12;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(168, 42);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 11;
            this.button4.Text = "Execute";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(87, 42);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 10;
            this.button3.Text = "Train";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 19);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 13);
            this.label8.TabIndex = 9;
            this.label8.Text = "% Sample";
            // 
            // maskedTextBox2
            // 
            this.maskedTextBox2.Location = new System.Drawing.Point(65, 16);
            this.maskedTextBox2.Name = "maskedTextBox2";
            this.maskedTextBox2.Size = new System.Drawing.Size(178, 20);
            this.maskedTextBox2.TabIndex = 9;
            this.maskedTextBox2.MaskInputRejected += new System.Windows.Forms.MaskInputRejectedEventHandler(this.maskedTextBox2_MaskInputRejected);
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.crossvalidp);
            this.groupBox7.Controls.Add(this.crossvalidationparts);
            this.groupBox7.Controls.Add(this.label15);
            this.groupBox7.Controls.Add(this.crossvalidateresult);
            this.groupBox7.Controls.Add(this.crossvalidatebutton);
            this.groupBox7.Controls.Add(this.crossvalidatecombo);
            this.groupBox7.Location = new System.Drawing.Point(21, 562);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(266, 114);
            this.groupBox7.TabIndex = 8;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Crossvalidation";
            // 
            // crossvalidatecombo
            // 
            this.crossvalidatecombo.FormattingEnabled = true;
            this.crossvalidatecombo.Items.AddRange(new object[] {
            "NN",
            "kNN",
            "NM"});
            this.crossvalidatecombo.Location = new System.Drawing.Point(9, 19);
            this.crossvalidatecombo.Name = "crossvalidatecombo";
            this.crossvalidatecombo.Size = new System.Drawing.Size(234, 21);
            this.crossvalidatecombo.TabIndex = 0;
            // 
            // crossvalidatebutton
            // 
            this.crossvalidatebutton.Location = new System.Drawing.Point(168, 44);
            this.crossvalidatebutton.Name = "crossvalidatebutton";
            this.crossvalidatebutton.Size = new System.Drawing.Size(75, 23);
            this.crossvalidatebutton.TabIndex = 1;
            this.crossvalidatebutton.Text = "Test";
            this.crossvalidatebutton.UseVisualStyleBackColor = true;
            this.crossvalidatebutton.Click += new System.EventHandler(this.crossvalidatebutton_Click);
            // 
            // crossvalidateresult
            // 
            this.crossvalidateresult.Location = new System.Drawing.Point(49, 73);
            this.crossvalidateresult.Name = "crossvalidateresult";
            this.crossvalidateresult.Size = new System.Drawing.Size(194, 20);
            this.crossvalidateresult.TabIndex = 2;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(6, 76);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(37, 13);
            this.label15.TabIndex = 9;
            this.label15.Text = "Result";
            // 
            // crossvalidationparts
            // 
            this.crossvalidationparts.Location = new System.Drawing.Point(49, 46);
            this.crossvalidationparts.Name = "crossvalidationparts";
            this.crossvalidationparts.Size = new System.Drawing.Size(113, 20);
            this.crossvalidationparts.TabIndex = 10;
            // 
            // crossvalidp
            // 
            this.crossvalidp.AutoSize = true;
            this.crossvalidp.Location = new System.Drawing.Point(6, 49);
            this.crossvalidp.Name = "crossvalidp";
            this.crossvalidp.Size = new System.Drawing.Size(31, 13);
            this.crossvalidp.TabIndex = 11;
            this.crossvalidp.Text = "Parts";
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.bootstrapparts);
            this.groupBox8.Controls.Add(this.label18);
            this.groupBox8.Controls.Add(this.label16);
            this.groupBox8.Controls.Add(this.bootsrapcount);
            this.groupBox8.Controls.Add(this.label17);
            this.groupBox8.Controls.Add(this.bootstrapresult);
            this.groupBox8.Controls.Add(this.bootsrapttest);
            this.groupBox8.Controls.Add(this.bootstrapcombo);
            this.groupBox8.Location = new System.Drawing.Point(294, 562);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(289, 114);
            this.groupBox8.TabIndex = 12;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "Bootstrap";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(6, 49);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(35, 13);
            this.label16.TabIndex = 11;
            this.label16.Text = "Count";
            // 
            // bootsrapcount
            // 
            this.bootsrapcount.Location = new System.Drawing.Point(49, 46);
            this.bootsrapcount.Name = "bootsrapcount";
            this.bootsrapcount.Size = new System.Drawing.Size(33, 20);
            this.bootsrapcount.TabIndex = 10;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(6, 76);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(37, 13);
            this.label17.TabIndex = 9;
            this.label17.Text = "Result";
            // 
            // bootstrapresult
            // 
            this.bootstrapresult.Location = new System.Drawing.Point(49, 73);
            this.bootstrapresult.Name = "bootstrapresult";
            this.bootstrapresult.Size = new System.Drawing.Size(194, 20);
            this.bootstrapresult.TabIndex = 2;
            // 
            // bootsrapttest
            // 
            this.bootsrapttest.Location = new System.Drawing.Point(168, 44);
            this.bootsrapttest.Name = "bootsrapttest";
            this.bootsrapttest.Size = new System.Drawing.Size(75, 23);
            this.bootsrapttest.TabIndex = 1;
            this.bootsrapttest.Text = "Test";
            this.bootsrapttest.UseVisualStyleBackColor = true;
            this.bootsrapttest.Click += new System.EventHandler(this.bootsrapttest_Click);
            // 
            // bootstrapcombo
            // 
            this.bootstrapcombo.FormattingEnabled = true;
            this.bootstrapcombo.Items.AddRange(new object[] {
            "NN",
            "kNN",
            "NM"});
            this.bootstrapcombo.Location = new System.Drawing.Point(9, 19);
            this.bootstrapcombo.Name = "bootstrapcombo";
            this.bootstrapcombo.Size = new System.Drawing.Size(234, 21);
            this.bootstrapcombo.TabIndex = 0;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(85, 49);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(31, 13);
            this.label18.TabIndex = 12;
            this.label18.Text = "Parts";
            // 
            // bootstrapparts
            // 
            this.bootstrapparts.Location = new System.Drawing.Point(122, 46);
            this.bootstrapparts.Name = "bootstrapparts";
            this.bootstrapparts.Size = new System.Drawing.Size(40, 20);
            this.bootstrapparts.TabIndex = 12;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(615, 710);
            this.Controls.Add(this.groupBox8);
            this.Controls.Add(this.groupBox7);
            this.Controls.Add(this.Classifiers);
            this.Controls.Add(this.groupBox3);
            this.Name = "Form1";
            this.Text = "Form1";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.Classifiers.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ProgressBar progressBar2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.MaskedTextBox maskedTextBox1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.GroupBox Classifiers;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox textBox9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox textBox8;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.MaskedTextBox maskedTextBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textBox7;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.MaskedTextBox maskedTextBox2;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox nMeanResult;
        private System.Windows.Forms.Button nMeanExecute;
        private System.Windows.Forms.Button nMeanTrain;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.MaskedTextBox nMSamplePercent;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox crossvalidateresult;
        private System.Windows.Forms.Button crossvalidatebutton;
        private System.Windows.Forms.ComboBox crossvalidatecombo;
        private System.Windows.Forms.Label crossvalidp;
        private System.Windows.Forms.TextBox crossvalidationparts;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox bootsrapcount;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox bootstrapresult;
        private System.Windows.Forms.Button bootsrapttest;
        private System.Windows.Forms.ComboBox bootstrapcombo;
        private System.Windows.Forms.TextBox bootstrapparts;
        private System.Windows.Forms.Label label18;
    }
}

