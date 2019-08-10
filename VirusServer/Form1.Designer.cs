namespace VirusServer
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.clientTable = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.clientTable)).BeginInit();
            this.SuspendLayout();
            // 
            // clientTable
            // 
            this.clientTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.clientTable.Location = new System.Drawing.Point(12, 12);
            this.clientTable.Name = "clientTable";
            this.clientTable.Size = new System.Drawing.Size(542, 179);
            this.clientTable.TabIndex = 0;
            this.clientTable.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ClientTable_CellContentClick);
            this.clientTable.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ClientTable_CellContentDoubleClick);
            this.clientTable.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ClientTable_CellDoubleClick);
            this.clientTable.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.ClientTable_CellMouseDoubleClick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(566, 238);
            this.Controls.Add(this.clientTable);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.clientTable)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.DataGridView clientTable;
    }
}

