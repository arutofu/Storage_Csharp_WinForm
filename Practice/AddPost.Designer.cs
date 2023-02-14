namespace Main
{
    partial class AddPost
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
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.AddButton = new System.Windows.Forms.Button();
            this.AddPhone = new System.Windows.Forms.TextBox();
            this.AddKat = new System.Windows.Forms.TextBox();
            this.AddPostBox2 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 98);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "Категория";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Телефон";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Поставщик";
            // 
            // AddButton
            // 
            this.AddButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.AddButton.Location = new System.Drawing.Point(12, 161);
            this.AddButton.Name = "AddButton";
            this.AddButton.Size = new System.Drawing.Size(75, 23);
            this.AddButton.TabIndex = 3;
            this.AddButton.Text = "Ok";
            this.AddButton.UseVisualStyleBackColor = true;
            // 
            // AddPhone
            // 
            this.AddPhone.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.AddPhone.Location = new System.Drawing.Point(12, 73);
            this.AddPhone.Name = "AddPhone";
            this.AddPhone.Size = new System.Drawing.Size(144, 22);
            this.AddPhone.TabIndex = 1;
            // 
            // AddKat
            // 
            this.AddKat.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.AddKat.Location = new System.Drawing.Point(12, 114);
            this.AddKat.Name = "AddKat";
            this.AddKat.Size = new System.Drawing.Size(144, 22);
            this.AddKat.TabIndex = 2;
            // 
            // AddPostBox2
            // 
            this.AddPostBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.AddPostBox2.Location = new System.Drawing.Point(12, 32);
            this.AddPostBox2.Name = "AddPostBox2";
            this.AddPostBox2.Size = new System.Drawing.Size(144, 22);
            this.AddPostBox2.TabIndex = 0;
            // 
            // AddPost
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(179, 196);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.AddButton);
            this.Controls.Add(this.AddPhone);
            this.Controls.Add(this.AddKat);
            this.Controls.Add(this.AddPostBox2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "AddPost";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button AddButton;
        protected internal System.Windows.Forms.TextBox AddPhone;
        protected internal System.Windows.Forms.TextBox AddKat;
        protected internal System.Windows.Forms.TextBox AddPostBox2;
    }
}