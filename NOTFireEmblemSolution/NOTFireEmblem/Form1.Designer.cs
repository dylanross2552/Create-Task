namespace NOTFireEmblem
{
    partial class Titlescreen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Titlescreen));
            this.StartButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.ExitButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.P1NameBox = new System.Windows.Forms.TextBox();
            this.P2NameBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // StartButton
            // 
            this.StartButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("StartButton.BackgroundImage")));
            this.StartButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.StartButton.Font = new System.Drawing.Font("Segoe Script", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StartButton.Location = new System.Drawing.Point(12, 536);
            this.StartButton.Name = "StartButton";
            this.StartButton.Size = new System.Drawing.Size(238, 64);
            this.StartButton.TabIndex = 0;
            this.StartButton.Text = "Begin!";
            this.StartButton.UseVisualStyleBackColor = true;
            this.StartButton.Click += new System.EventHandler(this.StartButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe Script", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(25, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(580, 76);
            this.label1.TabIndex = 1;
            this.label1.Text = "Turn-Based Strategy!";
            // 
            // ExitButton
            // 
            this.ExitButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("ExitButton.BackgroundImage")));
            this.ExitButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ExitButton.Font = new System.Drawing.Font("Segoe Script", 12F, System.Drawing.FontStyle.Italic);
            this.ExitButton.Location = new System.Drawing.Point(384, 536);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(238, 64);
            this.ExitButton.TabIndex = 2;
            this.ExitButton.Text = "Exit";
            this.ExitButton.UseVisualStyleBackColor = true;
            this.ExitButton.Click += new System.EventHandler(this.ExitButton_Click_1);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Segoe Script", 12F, System.Drawing.FontStyle.Italic);
            this.label2.Location = new System.Drawing.Point(12, 453);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 25);
            this.label2.TabIndex = 3;
            this.label2.Text = "Player 1:";
            // 
            // P1NameBox
            // 
            this.P1NameBox.Font = new System.Drawing.Font("Segoe Script", 12F, System.Drawing.FontStyle.Italic);
            this.P1NameBox.Location = new System.Drawing.Point(111, 450);
            this.P1NameBox.Name = "P1NameBox";
            this.P1NameBox.Size = new System.Drawing.Size(139, 33);
            this.P1NameBox.TabIndex = 4;
            this.P1NameBox.Text = "Player 1";
            // 
            // P2NameBox
            // 
            this.P2NameBox.Font = new System.Drawing.Font("Segoe Script", 12F, System.Drawing.FontStyle.Italic);
            this.P2NameBox.Location = new System.Drawing.Point(111, 489);
            this.P2NameBox.Name = "P2NameBox";
            this.P2NameBox.Size = new System.Drawing.Size(139, 33);
            this.P2NameBox.TabIndex = 6;
            this.P2NameBox.Text = "Player 2";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Segoe Script", 12F, System.Drawing.FontStyle.Italic);
            this.label3.Location = new System.Drawing.Point(12, 492);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 25);
            this.label3.TabIndex = 5;
            this.label3.Text = "Player 2";
            // 
            // Titlescreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(634, 612);
            this.Controls.Add(this.P2NameBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.P1NameBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ExitButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.StartButton);
            this.Name = "Titlescreen";
            this.Text = "TotallyNotFireEmblem";
            this.Load += new System.EventHandler(this.Titlescreen_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button StartButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button ExitButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.TextBox P1NameBox;
        public System.Windows.Forms.TextBox P2NameBox;
    }
}

