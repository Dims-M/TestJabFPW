namespace VirusServer
{
    partial class SendMenu
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
            this.SendButton = new System.Windows.Forms.Button();
            this.firsrParameterLabel = new System.Windows.Forms.Label();
            this.secondParameterLabel = new System.Windows.Forms.Label();
            this.firstParameter = new System.Windows.Forms.TextBox();
            this.secontParameter = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // SendButton
            // 
            this.SendButton.Location = new System.Drawing.Point(181, 257);
            this.SendButton.Name = "SendButton";
            this.SendButton.Size = new System.Drawing.Size(188, 63);
            this.SendButton.TabIndex = 0;
            this.SendButton.Text = "Send";
            this.SendButton.UseVisualStyleBackColor = true;
            this.SendButton.Click += new System.EventHandler(this.SendButton_Click);
            // 
            // firsrParameterLabel
            // 
            this.firsrParameterLabel.AutoSize = true;
            this.firsrParameterLabel.Location = new System.Drawing.Point(81, 54);
            this.firsrParameterLabel.Name = "firsrParameterLabel";
            this.firsrParameterLabel.Size = new System.Drawing.Size(35, 13);
            this.firsrParameterLabel.TabIndex = 1;
            this.firsrParameterLabel.Text = "label1";
            // 
            // secondParameterLabel
            // 
            this.secondParameterLabel.AutoSize = true;
            this.secondParameterLabel.Location = new System.Drawing.Point(81, 146);
            this.secondParameterLabel.Name = "secondParameterLabel";
            this.secondParameterLabel.Size = new System.Drawing.Size(35, 13);
            this.secondParameterLabel.TabIndex = 2;
            this.secondParameterLabel.Text = "label2";
            // 
            // firstParameter
            // 
            this.firstParameter.Location = new System.Drawing.Point(181, 51);
            this.firstParameter.Name = "firstParameter";
            this.firstParameter.Size = new System.Drawing.Size(188, 20);
            this.firstParameter.TabIndex = 3;
            // 
            // secontParameter
            // 
            this.secontParameter.Location = new System.Drawing.Point(181, 146);
            this.secontParameter.Name = "secontParameter";
            this.secontParameter.Size = new System.Drawing.Size(188, 20);
            this.secontParameter.TabIndex = 4;
            // 
            // SendMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(605, 345);
            this.Controls.Add(this.secontParameter);
            this.Controls.Add(this.firstParameter);
            this.Controls.Add(this.secondParameterLabel);
            this.Controls.Add(this.firsrParameterLabel);
            this.Controls.Add(this.SendButton);
            this.Name = "SendMenu";
            this.Text = "SendMenu";
            this.Load += new System.EventHandler(this.SendMenu_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button SendButton;
        private System.Windows.Forms.Label firsrParameterLabel;
        private System.Windows.Forms.Label secondParameterLabel;
        private System.Windows.Forms.TextBox firstParameter;
        private System.Windows.Forms.TextBox secontParameter;
    }
}