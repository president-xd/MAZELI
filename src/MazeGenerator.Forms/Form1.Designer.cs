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
            this.GenerateBtn = new System.Windows.Forms.Button();
            this.SolveBtn = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.mazePicBox)).BeginInit();
            this.SuspendLayout();
            // 
            // mazePicBox
            // 
            this.mazePicBox.Location = new System.Drawing.Point(13, 13);
            this.mazePicBox.Margin = new System.Windows.Forms.Padding(5);
            this.mazePicBox.Name = "mazePicBox";
            this.mazePicBox.Size = new System.Drawing.Size(500, 500);
            this.mazePicBox.TabIndex = 0;
            this.mazePicBox.TabStop = false;
            this.mazePicBox.Paint += new System.Windows.Forms.PaintEventHandler(this.mazePicBox_Paint);
            // 
            // GenerateBtn
            // 
            this.GenerateBtn.Location = new System.Drawing.Point(13, 521);
            this.GenerateBtn.Name = "GenerateBtn";
            this.GenerateBtn.Size = new System.Drawing.Size(75, 29);
            this.GenerateBtn.TabIndex = 1;
            this.GenerateBtn.Text = "Generate";
            this.GenerateBtn.UseVisualStyleBackColor = true;
            this.GenerateBtn.Click += new System.EventHandler(this.GenerateBtn_Click);
            // 
            // SolveBtn
            // 
            this.SolveBtn.Location = new System.Drawing.Point(94, 521);
            this.SolveBtn.Name = "SolveBtn";
            this.SolveBtn.Size = new System.Drawing.Size(75, 29);
            this.SolveBtn.TabIndex = 2;
            this.SolveBtn.Text = "Solve";
            this.SolveBtn.UseVisualStyleBackColor = true;
            this.SolveBtn.Click += new System.EventHandler(this.SolveBtn_Click);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ClientSize = new System.Drawing.Size(534, 561);
            this.Controls.Add(this.SolveBtn);
            this.Controls.Add(this.GenerateBtn);
            this.Controls.Add(this.mazePicBox);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Shown += new System.EventHandler(this.Form1_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.mazePicBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox mazePicBox;
        private System.Windows.Forms.Button GenerateBtn;
        private System.Windows.Forms.Button SolveBtn;
        private System.Windows.Forms.Timer timer1;
    }
}

