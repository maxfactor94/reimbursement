namespace reimbursement
{
    partial class addForm
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
            this.nameLabel = new System.Windows.Forms.Label();
            this.CompensationLabel = new System.Windows.Forms.Label();
            this.DateLabel = new System.Windows.Forms.Label();
            this.addBtn = new System.Windows.Forms.Button();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.compensationsTextBox = new System.Windows.Forms.TextBox();
            this.dateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Location = new System.Drawing.Point(12, 9);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(151, 13);
            this.nameLabel.TabIndex = 0;
            this.nameLabel.Text = "Наименование возмещения";
            // 
            // CompensationLabel
            // 
            this.CompensationLabel.AutoSize = true;
            this.CompensationLabel.Location = new System.Drawing.Point(33, 35);
            this.CompensationLabel.Name = "CompensationLabel";
            this.CompensationLabel.Size = new System.Drawing.Size(130, 13);
            this.CompensationLabel.TabIndex = 1;
            this.CompensationLabel.Text = "Стоимость возмещения";
            // 
            // DateLabel
            // 
            this.DateLabel.AutoSize = true;
            this.DateLabel.Location = new System.Drawing.Point(92, 61);
            this.DateLabel.Name = "DateLabel";
            this.DateLabel.Size = new System.Drawing.Size(71, 13);
            this.DateLabel.TabIndex = 2;
            this.DateLabel.Text = "Дата подачи";
            // 
            // addBtn
            // 
            this.addBtn.Location = new System.Drawing.Point(12, 87);
            this.addBtn.Name = "addBtn";
            this.addBtn.Size = new System.Drawing.Size(776, 23);
            this.addBtn.TabIndex = 3;
            this.addBtn.Text = "Добавить";
            this.addBtn.UseVisualStyleBackColor = true;
            this.addBtn.Click += new System.EventHandler(this.AddBtn_Click);
            // 
            // nameTextBox
            // 
            this.nameTextBox.Location = new System.Drawing.Point(169, 6);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(619, 20);
            this.nameTextBox.TabIndex = 4;
            // 
            // compensationsTextBox
            // 
            this.compensationsTextBox.Location = new System.Drawing.Point(169, 32);
            this.compensationsTextBox.Name = "compensationsTextBox";
            this.compensationsTextBox.Size = new System.Drawing.Size(619, 20);
            this.compensationsTextBox.TabIndex = 5;
            // 
            // dateTimePicker
            // 
            this.dateTimePicker.Location = new System.Drawing.Point(169, 61);
            this.dateTimePicker.Name = "dateTimePicker";
            this.dateTimePicker.Size = new System.Drawing.Size(619, 20);
            this.dateTimePicker.TabIndex = 6;
            // 
            // addForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(800, 126);
            this.Controls.Add(this.dateTimePicker);
            this.Controls.Add(this.compensationsTextBox);
            this.Controls.Add(this.nameTextBox);
            this.Controls.Add(this.addBtn);
            this.Controls.Add(this.DateLabel);
            this.Controls.Add(this.CompensationLabel);
            this.Controls.Add(this.nameLabel);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "addForm";
            this.Text = "Добавить";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.Label CompensationLabel;
        private System.Windows.Forms.Label DateLabel;
        private System.Windows.Forms.Button addBtn;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.TextBox compensationsTextBox;
        private System.Windows.Forms.DateTimePicker dateTimePicker;
    }
}