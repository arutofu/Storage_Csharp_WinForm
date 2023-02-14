namespace Main
{
    partial class TovarOtchet
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
            this.tovarBack = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.PostTovara = new System.Windows.Forms.ListBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tovarBack
            // 
            this.tovarBack.Location = new System.Drawing.Point(6, 222);
            this.tovarBack.Name = "tovarBack";
            this.tovarBack.Size = new System.Drawing.Size(75, 23);
            this.tovarBack.TabIndex = 0;
            this.tovarBack.Text = "Назад";
            this.tovarBack.UseVisualStyleBackColor = true;
            this.tovarBack.Click += new System.EventHandler(this.tovarBack_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.PostTovara);
            this.groupBox1.Controls.Add(this.tovarBack);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(275, 251);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Товары поставщика";
            // 
            // PostTovara
            // 
            this.PostTovara.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.PostTovara.FormattingEnabled = true;
            this.PostTovara.ItemHeight = 16;
            this.PostTovara.Location = new System.Drawing.Point(6, 19);
            this.PostTovara.Name = "PostTovara";
            this.PostTovara.Size = new System.Drawing.Size(263, 196);
            this.PostTovara.TabIndex = 2;
            // 
            // TovarOtchet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(299, 268);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "TovarOtchet";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button tovarBack;
        private System.Windows.Forms.GroupBox groupBox1;
        internal System.Windows.Forms.ListBox PostTovara;
    }
}