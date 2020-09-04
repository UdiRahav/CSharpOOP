namespace B19_Ex02
{
    partial class ColorsPickWindow
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
            this.RedButton = new System.Windows.Forms.Button();
            this.GreenButton = new System.Windows.Forms.Button();
            this.AzureButton = new System.Windows.Forms.Button();
            this.WhiteButton = new System.Windows.Forms.Button();
            this.BrownButton = new System.Windows.Forms.Button();
            this.YellowButton = new System.Windows.Forms.Button();
            this.BlueButton = new System.Windows.Forms.Button();
            this.PurpleButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // RedButton
            // 
            this.RedButton.BackColor = System.Drawing.Color.Red;
            this.RedButton.Location = new System.Drawing.Point(65, 12);
            this.RedButton.Name = "RedButton";
            this.RedButton.Size = new System.Drawing.Size(47, 44);
            this.RedButton.TabIndex = 1;
            this.RedButton.UseVisualStyleBackColor = false;
            this.RedButton.Click += new System.EventHandler(this.ColorButtonPick_Click);
            // 
            // GreenButton
            // 
            this.GreenButton.BackColor = System.Drawing.Color.Lime;
            this.GreenButton.Location = new System.Drawing.Point(118, 12);
            this.GreenButton.Name = "GreenButton";
            this.GreenButton.Size = new System.Drawing.Size(47, 44);
            this.GreenButton.TabIndex = 2;
            this.GreenButton.UseVisualStyleBackColor = false;
            this.GreenButton.Click += new System.EventHandler(this.ColorButtonPick_Click);
            // 
            // AzureButton
            // 
            this.AzureButton.BackColor = System.Drawing.Color.Aqua;
            this.AzureButton.Location = new System.Drawing.Point(171, 12);
            this.AzureButton.Name = "AzureButton";
            this.AzureButton.Size = new System.Drawing.Size(47, 44);
            this.AzureButton.TabIndex = 3;
            this.AzureButton.UseVisualStyleBackColor = false;
            this.AzureButton.Click += new System.EventHandler(this.ColorButtonPick_Click);
            // 
            // WhiteButton
            // 
            this.WhiteButton.BackColor = System.Drawing.Color.White;
            this.WhiteButton.Location = new System.Drawing.Point(171, 62);
            this.WhiteButton.Name = "WhiteButton";
            this.WhiteButton.Size = new System.Drawing.Size(47, 44);
            this.WhiteButton.TabIndex = 7;
            this.WhiteButton.UseVisualStyleBackColor = false;
            this.WhiteButton.Click += new System.EventHandler(this.ColorButtonPick_Click);
            // 
            // BrownButton
            // 
            this.BrownButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.BrownButton.ForeColor = System.Drawing.Color.CadetBlue;
            this.BrownButton.Location = new System.Drawing.Point(118, 62);
            this.BrownButton.Name = "BrownButton";
            this.BrownButton.Size = new System.Drawing.Size(47, 44);
            this.BrownButton.TabIndex = 6;
            this.BrownButton.UseVisualStyleBackColor = false;
            this.BrownButton.Click += new System.EventHandler(this.ColorButtonPick_Click);
            // 
            // YellowButton
            // 
            this.YellowButton.BackColor = System.Drawing.Color.Yellow;
            this.YellowButton.Location = new System.Drawing.Point(65, 62);
            this.YellowButton.Name = "YellowButton";
            this.YellowButton.Size = new System.Drawing.Size(47, 44);
            this.YellowButton.TabIndex = 5;
            this.YellowButton.UseVisualStyleBackColor = false;
            this.YellowButton.Click += new System.EventHandler(this.ColorButtonPick_Click);
            // 
            // BlueButton
            // 
            this.BlueButton.BackColor = System.Drawing.Color.Blue;
            this.BlueButton.Location = new System.Drawing.Point(12, 62);
            this.BlueButton.Name = "BlueButton";
            this.BlueButton.Size = new System.Drawing.Size(47, 44);
            this.BlueButton.TabIndex = 4;
            this.BlueButton.UseVisualStyleBackColor = false;
            this.BlueButton.Click += new System.EventHandler(this.ColorButtonPick_Click);
            // 
            // PurpleButton
            // 
            this.PurpleButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.PurpleButton.Location = new System.Drawing.Point(12, 12);
            this.PurpleButton.Name = "PurpleButton";
            this.PurpleButton.Size = new System.Drawing.Size(47, 44);
            this.PurpleButton.TabIndex = 8;
            this.PurpleButton.UseVisualStyleBackColor = false;
            this.PurpleButton.Click += new System.EventHandler(this.ColorButtonPick_Click);
            // 
            // ColorsPickWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(225, 110);
            this.Controls.Add(this.PurpleButton);
            this.Controls.Add(this.WhiteButton);
            this.Controls.Add(this.BrownButton);
            this.Controls.Add(this.YellowButton);
            this.Controls.Add(this.BlueButton);
            this.Controls.Add(this.AzureButton);
            this.Controls.Add(this.GreenButton);
            this.Controls.Add(this.RedButton);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ColorsPickWindow";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Pick A Color:";
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button RedButton;
        private System.Windows.Forms.Button GreenButton;
        private System.Windows.Forms.Button AzureButton;
        private System.Windows.Forms.Button WhiteButton;
        private System.Windows.Forms.Button BrownButton;
        private System.Windows.Forms.Button YellowButton;
        private System.Windows.Forms.Button BlueButton;
        private System.Windows.Forms.Button PurpleButton;
    }
}