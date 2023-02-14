namespace Main
{
    partial class AddTovar
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
            this.AddTovarBox = new System.Windows.Forms.TextBox();
            this.AddPostBox = new System.Windows.Forms.TextBox();
            this.AddObiemBox = new System.Windows.Forms.TextBox();
            this.AddButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // AddTovarBox
            // 
            this.AddTovarBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.AddTovarBox.Location = new System.Drawing.Point(12, 32);
            this.AddTovarBox.Name = "AddTovarBox";
            this.AddTovarBox.Size = new System.Drawing.Size(144, 22);
            this.AddTovarBox.TabIndex = 0;
            // 
            // AddPostBox
            // 
            this.AddPostBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.AddPostBox.Location = new System.Drawing.Point(12, 73);
            this.AddPostBox.Name = "AddPostBox";
            this.AddPostBox.Size = new System.Drawing.Size(144, 22);
            this.AddPostBox.TabIndex = 1;
            // 
            // AddObiemBox
            // 
            this.AddObiemBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.AddObiemBox.Location = new System.Drawing.Point(12, 114);
            this.AddObiemBox.Name = "AddObiemBox";
            this.AddObiemBox.Size = new System.Drawing.Size(144, 22);
            this.AddObiemBox.TabIndex = 2;
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Товар";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Поставщик";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 98);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Объем";
            // 
            // AddTovar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(179, 196);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.AddButton);
            this.Controls.Add(this.AddObiemBox);
            this.Controls.Add(this.AddPostBox);
            this.Controls.Add(this.AddTovarBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "AddTovar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button AddButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        protected internal System.Windows.Forms.TextBox AddPostBox;
        protected internal System.Windows.Forms.TextBox AddObiemBox;
        protected internal System.Windows.Forms.TextBox AddTovarBox;
    }
}