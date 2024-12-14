namespace MazeGenerator.Forms
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
            this.components = new System.ComponentModel.Container();
            this.mazePicBox = new System.Windows.Forms.PictureBox();
            this.SolveBtn = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.GenerateBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.mazePicBox)).BeginInit();
            this.SuspendLayout();
            // 
            // mazePicBox
            // 
            this.mazePicBox.BackColor = System.Drawing.Color.Black;
            this.mazePicBox.Location = new System.Drawing.Point(26, 83);
            this.mazePicBox.Margin = new System.Windows.Forms.Padding(10);
            this.mazePicBox.Name = "mazePicBox";
            this.mazePicBox.Size = new System.Drawing.Size(1000, 904);
            this.mazePicBox.TabIndex = 0;
            this.mazePicBox.TabStop = false;
            this.mazePicBox.Paint += new System.Windows.Forms.PaintEventHandler(this.mazePicBox_Paint);
            // 
            // SolveBtn
            // 
            this.SolveBtn.AutoSize = true;
            this.SolveBtn.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.SolveBtn.ForeColor = System.Drawing.Color.Green;
            this.SolveBtn.Location = new System.Drawing.Point(242, 1002);
            this.SolveBtn.Margin = new System.Windows.Forms.Padding(6);
            this.SolveBtn.Name = "SolveBtn";
            this.SolveBtn.Size = new System.Drawing.Size(211, 56);
            this.SolveBtn.TabIndex = 2;
            this.SolveBtn.Text = "Solve the Riddle";
            this.SolveBtn.UseVisualStyleBackColor = false;
            this.SolveBtn.Click += new System.EventHandler(this.SolveBtn_Click);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // GenerateBtn
            // 
            this.GenerateBtn.AutoSize = true;
            this.GenerateBtn.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.GenerateBtn.ForeColor = System.Drawing.Color.Green;
            this.GenerateBtn.Location = new System.Drawing.Point(26, 1002);
            this.GenerateBtn.Margin = new System.Windows.Forms.Padding(6);
            this.GenerateBtn.Name = "GenerateBtn";
            this.GenerateBtn.Size = new System.Drawing.Size(206, 56);
            this.GenerateBtn.TabIndex = 1;
            this.GenerateBtn.Text = "Generate the Maze";
            this.GenerateBtn.UseVisualStyleBackColor = false;
            this.GenerateBtn.Click += new System.EventHandler(this.GenerateBtn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(1068, 1079);
            this.Controls.Add(this.SolveBtn);
            this.Controls.Add(this.GenerateBtn);
            this.Controls.Add(this.mazePicBox);
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "Form1";
            this.Text = "HAVELI Maze Solver";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Shown += new System.EventHandler(this.Form1_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.mazePicBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox mazePicBox;
        private System.Windows.Forms.Button SolveBtn;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button GenerateBtn;
    }
}

