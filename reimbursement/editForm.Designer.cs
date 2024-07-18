namespace reimbursement
{
    partial class Изменить
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
            this.dateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.compensationsTextBox = new System.Windows.Forms.TextBox();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.editBtn = new System.Windows.Forms.Button();
            this.DateLabel = new System.Windows.Forms.Label();
            this.CompensationLabel = new System.Windows.Forms.Label();
            this.nameLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // dateTimePicker
            // 
            this.dateTimePicker.Location = new System.Drawing.Point(169, 67);
            this.dateTimePicker.Name = "dateTimePicker";
            this.dateTimePicker.Size = new System.Drawing.Size(619, 20);
            this.dateTimePicker.TabIndex = 13;
            // 
            // compensationsTextBox
            // 
            this.compensationsTextBox.Location = new System.Drawing.Point(169, 38);
            this.compensationsTextBox.Name = "compensationsTextBox";
            this.compensationsTextBox.Size = new System.Drawing.Size(619, 20);
            this.compensationsTextBox.TabIndex = 12;
            // 
            // nameTextBox
            // 
            this.nameTextBox.Location = new System.Drawing.Point(169, 12);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(619, 20);
            this.nameTextBox.TabIndex = 11;
            // 
            // editBtn
            // 
            this.editBtn.Location = new System.Drawing.Point(12, 93);
            this.editBtn.Name = "editBtn";
            this.editBtn.Size = new System.Drawing.Size(776, 23);
            this.editBtn.TabIndex = 10;
            this.editBtn.Text = "Изменить";
            this.editBtn.UseVisualStyleBackColor = true;
            this.editBtn.Click += new System.EventHandler(this.EditBtn_Click);
            // 
            // DateLabel
            // 
            this.DateLabel.AutoSize = true;
            this.DateLabel.Location = new System.Drawing.Point(92, 67);
            this.DateLabel.Name = "DateLabel";
            this.DateLabel.Size = new System.Drawing.Size(71, 13);
            this.DateLabel.TabIndex = 9;
            this.DateLabel.Text = "Дата подачи";
            // 
            // CompensationLabel
            // 
            this.CompensationLabel.AutoSize = true;
            this.CompensationLabel.Location = new System.Drawing.Point(33, 41);
            this.CompensationLabel.Name = "CompensationLabel";
            this.CompensationLabel.Size = new System.Drawing.Size(130, 13);
            this.CompensationLabel.TabIndex = 8;
            this.CompensationLabel.Text = "Стоимость возмещения";
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Location = new System.Drawing.Point(12, 15);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(151, 13);
            this.nameLabel.TabIndex = 7;
            this.nameLabel.Text = "Наименование возмещения";
            // 
            // Изменить
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 122);
            this.Controls.Add(this.dateTimePicker);
            this.Controls.Add(this.compensationsTextBox);
            this.Controls.Add(this.nameTextBox);
            this.Controls.Add(this.editBtn);
            this.Controls.Add(this.DateLabel);
            this.Controls.Add(this.CompensationLabel);
            this.Controls.Add(this.nameLabel);
            this.Name = "Изменить";
            this.Text = "editForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dateTimePicker;
        private System.Windows.Forms.TextBox compensationsTextBox;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.Button editBtn;
        private System.Windows.Forms.Label DateLabel;
        private System.Windows.Forms.Label CompensationLabel;
        private System.Windows.Forms.Label nameLabel;
    }
}