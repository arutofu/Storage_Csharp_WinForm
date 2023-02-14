namespace Main
{
    partial class PostOtchet
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.TovaryPost = new System.Windows.Forms.ListBox();
            this.tovarBack = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.TovaryPost);
            this.groupBox1.Controls.Add(this.tovarBack);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(192, 251);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Поставщики товара";
            // 
            // TovaryPost
            // 
            this.TovaryPost.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.TovaryPost.FormattingEnabled = true;
            this.TovaryPost.ItemHeight = 16;
            this.TovaryPost.Location = new System.Drawing.Point(6, 19);
            this.TovaryPost.Name = "TovaryPost";
            this.TovaryPost.Size = new System.Drawing.Size(180, 196);
            this.TovaryPost.TabIndex = 5;
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
            // PostOtchet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(216, 268);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "PostOtchet";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button tovarBack;
        internal System.Windows.Forms.ListBox TovaryPost;
    }
}