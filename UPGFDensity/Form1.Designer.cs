namespace UPGFDensity
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
            this.label16 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.txtPi = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtPrevRel = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtRelNum = new System.Windows.Forms.TextBox();
            this.txtEffDate = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPrevRelDir = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtOutputPath = new System.Windows.Forms.TextBox();
            this.txtCanRatesFile = new System.Windows.Forms.TextBox();
            this.txtUSRatesFile = new System.Windows.Forms.TextBox();
            this.txtRBNtableFile = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(348, 664);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Run";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.ForeColor = System.Drawing.Color.Red;
            this.label16.Location = new System.Drawing.Point(273, 203);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(74, 13);
            this.label16.TabIndex = 48;
            this.label16.Text = "(Number Only)";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(98, 203);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(66, 13);
            this.label14.TabIndex = 47;
            this.label14.Text = "PI - Number:";
            // 
            // txtPi
            // 
            this.txtPi.Location = new System.Drawing.Point(170, 200);
            this.txtPi.MaxLength = 5;
            this.txtPi.Name = "txtPi";
            this.txtPi.Size = new System.Drawing.Size(100, 20);
            this.txtPi.TabIndex = 46;
            this.txtPi.Text = "12345";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(252, 177);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(95, 13);
            this.label12.TabIndex = 45;
            this.label12.Text = "Previous Rel Num:";
            // 
            // txtPrevRel
            // 
            this.txtPrevRel.Location = new System.Drawing.Point(353, 174);
            this.txtPrevRel.MaxLength = 3;
            this.txtPrevRel.Name = "txtPrevRel";
            this.txtPrevRel.Size = new System.Drawing.Size(51, 20);
            this.txtPrevRel.TabIndex = 44;
            this.txtPrevRel.Text = "08";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(113, 177);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 13);
            this.label4.TabIndex = 43;
            this.label4.Text = "Rel Num:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(61, 151);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(103, 13);
            this.label3.TabIndex = 42;
            this.label3.Text = "New Effective Date:";
            // 
            // txtRelNum
            // 
            this.txtRelNum.Location = new System.Drawing.Point(170, 174);
            this.txtRelNum.MaxLength = 3;
            this.txtRelNum.Name = "txtRelNum";
            this.txtRelNum.Size = new System.Drawing.Size(51, 20);
            this.txtRelNum.TabIndex = 41;
            this.txtRelNum.Text = "99";
            // 
            // txtEffDate
            // 
            this.txtEffDate.Location = new System.Drawing.Point(170, 148);
            this.txtEffDate.MaxLength = 8;
            this.txtEffDate.Name = "txtEffDate";
            this.txtEffDate.Size = new System.Drawing.Size(100, 20);
            this.txtEffDate.TabIndex = 40;
            this.txtEffDate.Text = "20200101";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(26, 125);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(138, 13);
            this.label2.TabIndex = 39;
            this.label2.Text = "Previous Release Directory:";
            // 
            // txtPrevRelDir
            // 
            this.txtPrevRelDir.Location = new System.Drawing.Point(170, 122);
            this.txtPrevRelDir.Name = "txtPrevRelDir";
            this.txtPrevRelDir.Size = new System.Drawing.Size(518, 20);
            this.txtPrevRelDir.TabIndex = 38;
            this.txtPrevRelDir.Text = "C:\\UPGF\\202211";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(231, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(274, 33);
            this.label1.TabIndex = 37;
            this.label1.Text = "UPGF 580 Density";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(99, 631);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(67, 13);
            this.label6.TabIndex = 50;
            this.label6.Text = "Output Path:";
            // 
            // txtOutputPath
            // 
            this.txtOutputPath.Location = new System.Drawing.Point(172, 628);
            this.txtOutputPath.Name = "txtOutputPath";
            this.txtOutputPath.Size = new System.Drawing.Size(518, 20);
            this.txtOutputPath.TabIndex = 49;
            this.txtOutputPath.Text = "C:\\UPGF";
            // 
            // txtCanRatesFile
            // 
            this.txtCanRatesFile.Location = new System.Drawing.Point(172, 517);
            this.txtCanRatesFile.Name = "txtCanRatesFile";
            this.txtCanRatesFile.Size = new System.Drawing.Size(518, 20);
            this.txtCanRatesFile.TabIndex = 51;
            this.txtCanRatesFile.Text = "U:\\UPGF_UPSFreight\\580\\ProgramExamplesFiles\\Can.csv";
            // 
            // txtUSRatesFile
            // 
            this.txtUSRatesFile.Location = new System.Drawing.Point(172, 459);
            this.txtUSRatesFile.Name = "txtUSRatesFile";
            this.txtUSRatesFile.Size = new System.Drawing.Size(518, 20);
            this.txtUSRatesFile.TabIndex = 52;
            this.txtUSRatesFile.Text = "U:\\UPGF_UPSFreight\\580\\ProgramExamplesFiles\\US.csv";
            // 
            // txtRBNtableFile
            // 
            this.txtRBNtableFile.Location = new System.Drawing.Point(172, 569);
            this.txtRBNtableFile.Name = "txtRBNtableFile";
            this.txtRBNtableFile.Size = new System.Drawing.Size(518, 20);
            this.txtRBNtableFile.TabIndex = 53;
            this.txtRBNtableFile.Text = "U:\\UPGF_UPSFreight\\580\\ProgramExamplesFiles\\DF_Fnl_SMC_RBNTbl.csv";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(86, 520);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(80, 13);
            this.label5.TabIndex = 54;
            this.label5.Text = "CANRates.csv:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(93, 462);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(73, 13);
            this.label7.TabIndex = 55;
            this.label7.Text = "USRates.csv:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(96, 572);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(70, 13);
            this.label8.TabIndex = 56;
            this.label8.Text = "RBN_tbl.csv:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Tai Le", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Red;
            this.label9.Location = new System.Drawing.Point(214, 441);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(247, 16);
            this.label9.TabIndex = 57;
            this.label9.Text = "RBN Less Than 500000 are US/US rates.";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Tai Le", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.Red;
            this.label10.Location = new System.Drawing.Point(214, 498);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(332, 16);
            this.label10.TabIndex = 58;
            this.label10.Text = "RBN Equal or Greater Than 500000 are CAN/US rates.";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Tai Le", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.Black;
            this.label11.Location = new System.Drawing.Point(86, 313);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(554, 16);
            this.label11.TabIndex = 59;
            this.label11.Text = "***If The rates come in on 1 file. Please split accordingly into two files based " +
    "on RBN.***";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Tai Le", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.Black;
            this.label13.Location = new System.Drawing.Point(12, 282);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(727, 16);
            this.label13.TabIndex = 60;
            this.label13.Text = "***If the customer sends in lane adjustmnts, Please refer to \"U:\\UPGF_UPSFreight\\" +
    "580\\Adjustment UPS 580.mdb\".***";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.Color.Black;
            this.label15.Location = new System.Drawing.Point(128, 67);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(490, 22);
            this.label15.TabIndex = 61;
            this.label15.Text = "***Program creates entire Rateware folder and Dataset. ***";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Tai Le", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.ForeColor = System.Drawing.Color.Black;
            this.label17.Location = new System.Drawing.Point(99, 349);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(525, 16);
            this.label17.TabIndex = 62;
            this.label17.Text = "***Please refer to file formats @ U:\\UPGF_UPSFreight\\580\\ProgramExamplesFiles***";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(759, 722);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtRBNtableFile);
            this.Controls.Add(this.txtUSRatesFile);
            this.Controls.Add(this.txtCanRatesFile);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtOutputPath);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.txtPi);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.txtPrevRel);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtRelNum);
            this.Controls.Add(this.txtEffDate);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtPrevRelDir);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "UPGF Density";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtPi;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtPrevRel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtRelNum;
        private System.Windows.Forms.TextBox txtEffDate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtPrevRelDir;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtOutputPath;
        private System.Windows.Forms.TextBox txtCanRatesFile;
        private System.Windows.Forms.TextBox txtUSRatesFile;
        private System.Windows.Forms.TextBox txtRBNtableFile;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label17;
    }
}

