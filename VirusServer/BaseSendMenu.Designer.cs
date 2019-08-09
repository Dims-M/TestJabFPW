namespace VirusServer
{
    partial class BaseSendMenu
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.FirstParameterTextBox = new System.Windows.Forms.TextBox();
            this.SecondParameterTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // SendButton
            // 
            this.SendButton.Location = new System.Drawing.Point(99, 231);
            this.SendButton.Name = "SendButton";
            this.SendButton.Size = new System.Drawing.Size(295, 47);
            this.SendButton.TabIndex = 0;
            this.SendButton.Text = "Send";
            this.SendButton.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(114, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "festParameter";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(96, 118);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "secondParameter";
            this.label2.Click += new System.EventHandler(this.Label2_Click);
            // 
            // FirstParameterTextBox
            // 
            this.FirstParameterTextBox.Location = new System.Drawing.Point(186, 54);
            this.FirstParameterTextBox.Name = "FirstParameterTextBox";
            this.FirstParameterTextBox.Size = new System.Drawing.Size(208, 20);
            this.FirstParameterTextBox.TabIndex = 3;
            // 
            // SecondParameterTextBox
            // 
            this.SecondParameterTextBox.Location = new System.Drawing.Point(186, 118);
            this.SecondParameterTextBox.Name = "SecondParameterTextBox";
            this.SecondParameterTextBox.Size = new System.Drawing.Size(208, 20);
            this.SecondParameterTextBox.TabIndex = 4;
            // 
            // BaseSendMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(555, 324);
            this.Controls.Add(this.SecondParameterTextBox);
            this.Controls.Add(this.FirstParameterTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.SendButton);
            this.Name = "BaseSendMenu";
            this.Text = "BaseSendMenu";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button SendButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox FirstParameterTextBox;
        private System.Windows.Forms.TextBox SecondParameterTextBox;
    }
}