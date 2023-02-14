namespace Main
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
            this.GridTovar = new System.Windows.Forms.DataGridView();
            this.CountTovar = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TovarProv = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Phone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Kategoria = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GridPost = new System.Windows.Forms.DataGridView();
            this.CountProd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GridIndex = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TovarProd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Producer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Obiem = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button2 = new System.Windows.Forms.Button();
            this.DelProd = new System.Windows.Forms.Button();
            this.AddPost = new System.Windows.Forms.Button();
            this.SearchPost = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SearchTovar = new System.Windows.Forms.Button();
            this.MinusPost = new System.Windows.Forms.Button();
            this.AddTovar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.GridTovar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridPost)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // GridTovar
            // 
            this.GridTovar.AllowUserToAddRows = false;
            this.GridTovar.AllowUserToDeleteRows = false;
            this.GridTovar.AllowUserToResizeColumns = false;
            this.GridTovar.AllowUserToResizeRows = false;
            this.GridTovar.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.GridTovar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GridTovar.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CountTovar,
            this.TovarProv,
            this.Phone,
            this.Kategoria});
            this.GridTovar.Location = new System.Drawing.Point(6, 19);
            this.GridTovar.Name = "GridTovar";
            this.GridTovar.ReadOnly = true;
            this.GridTovar.Size = new System.Drawing.Size(437, 293);
            this.GridTovar.TabIndex = 0;
            // 
            // CountTovar
            // 
            this.CountTovar.HeaderText = "";
            this.CountTovar.Name = "CountTovar";
            this.CountTovar.ReadOnly = true;
            this.CountTovar.Width = 25;
            // 
            // TovarProv
            // 
            this.TovarProv.HeaderText = "Товар";
            this.TovarProv.Name = "TovarProv";
            this.TovarProv.ReadOnly = true;
            this.TovarProv.Width = 143;
            // 
            // Phone
            // 
            this.Phone.HeaderText = "Поставщик";
            this.Phone.Name = "Phone";
            this.Phone.ReadOnly = true;
            this.Phone.Width = 143;
            // 
            // Kategoria
            // 
            this.Kategoria.HeaderText = "Объем";
            this.Kategoria.Name = "Kategoria";
            this.Kategoria.ReadOnly = true;
            this.Kategoria.Width = 65;
            // 
            // GridPost
            // 
            this.GridPost.AllowUserToAddRows = false;
            this.GridPost.AllowUserToDeleteRows = false;
            this.GridPost.AllowUserToResizeColumns = false;
            this.GridPost.AllowUserToResizeRows = false;
            this.GridPost.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.GridPost.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.GridPost.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GridPost.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CountProd,
            this.GridIndex,
            this.TovarProd,
            this.Producer,
            this.Obiem});
            this.GridPost.Location = new System.Drawing.Point(6, 19);
            this.GridPost.Name = "GridPost";
            this.GridPost.ReadOnly = true;
            this.GridPost.Size = new System.Drawing.Size(437, 293);
            this.GridPost.TabIndex = 1;
            // 
            // CountProd
            // 
            this.CountProd.HeaderText = "";
            this.CountProd.Name = "CountProd";
            this.CountProd.ReadOnly = true;
            this.CountProd.Width = 25;
            // 
            // GridIndex
            // 
            this.GridIndex.HeaderText = "Индекс";
            this.GridIndex.Name = "GridIndex";
            this.GridIndex.ReadOnly = true;
            this.GridIndex.Width = 50;
            // 
            // TovarProd
            // 
            this.TovarProd.HeaderText = "Поставщик";
            this.TovarProd.Name = "TovarProd";
            this.TovarProd.ReadOnly = true;
            this.TovarProd.Width = 145;
            // 
            // Producer
            // 
            this.Producer.HeaderText = "Телефон";
            this.Producer.Name = "Producer";
            this.Producer.ReadOnly = true;
            this.Producer.Width = 90;
            // 
            // Obiem
            // 
            this.Obiem.HeaderText = "Категория";
            this.Obiem.Name = "Obiem";
            this.Obiem.ReadOnly = true;
            this.Obiem.Width = 65;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.DelProd);
            this.groupBox1.Controls.Add(this.AddPost);
            this.groupBox1.Controls.Add(this.SearchPost);
            this.groupBox1.Controls.Add(this.GridPost);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(450, 378);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Поставщики";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(6, 347);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 5;
            this.button2.Text = "Отчет";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.PostOtchet_Click);
            // 
            // DelProd
            // 
            this.DelProd.Location = new System.Drawing.Point(168, 318);
            this.DelProd.Name = "DelProd";
            this.DelProd.Size = new System.Drawing.Size(75, 23);
            this.DelProd.TabIndex = 5;
            this.DelProd.Text = "Удалить";
            this.DelProd.UseVisualStyleBackColor = true;
            this.DelProd.Click += new System.EventHandler(this.DelProd_Click);
            // 
            // AddPost
            // 
            this.AddPost.Location = new System.Drawing.Point(87, 318);
            this.AddPost.Name = "AddPost";
            this.AddPost.Size = new System.Drawing.Size(75, 23);
            this.AddPost.TabIndex = 4;
            this.AddPost.Text = "Добавить";
            this.AddPost.UseVisualStyleBackColor = true;
            this.AddPost.Click += new System.EventHandler(this.AddPost_Click);
            // 
            // SearchPost
            // 
            this.SearchPost.Location = new System.Drawing.Point(6, 318);
            this.SearchPost.Name = "SearchPost";
            this.SearchPost.Size = new System.Drawing.Size(75, 23);
            this.SearchPost.TabIndex = 6;
            this.SearchPost.Text = "Поиск";
            this.SearchPost.UseVisualStyleBackColor = true;
            this.SearchPost.Click += new System.EventHandler(this.SearchPost_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Controls.Add(this.SearchTovar);
            this.groupBox2.Controls.Add(this.MinusPost);
            this.groupBox2.Controls.Add(this.AddTovar);
            this.groupBox2.Controls.Add(this.GridTovar);
            this.groupBox2.Location = new System.Drawing.Point(468, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(450, 378);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Товары";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(6, 347);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "Отчет";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.TovarOtchet_Click);
            // 
            // SearchTovar
            // 
            this.SearchTovar.Location = new System.Drawing.Point(6, 318);
            this.SearchTovar.Name = "SearchTovar";
            this.SearchTovar.Size = new System.Drawing.Size(75, 23);
            this.SearchTovar.TabIndex = 8;
            this.SearchTovar.Text = "Поиск";
            this.SearchTovar.UseVisualStyleBackColor = true;
            this.SearchTovar.Click += new System.EventHandler(this.SearchProv_Click);
            // 
            // MinusPost
            // 
            this.MinusPost.Location = new System.Drawing.Point(168, 318);
            this.MinusPost.Name = "MinusPost";
            this.MinusPost.Size = new System.Drawing.Size(75, 23);
            this.MinusPost.TabIndex = 6;
            this.MinusPost.Text = "Удалить";
            this.MinusPost.UseVisualStyleBackColor = true;
            this.MinusPost.Click += new System.EventHandler(this.MinusTovar);
            // 
            // AddTovar
            // 
            this.AddTovar.Location = new System.Drawing.Point(87, 318);
            this.AddTovar.Name = "AddTovar";
            this.AddTovar.Size = new System.Drawing.Size(75, 23);
            this.AddTovar.TabIndex = 7;
            this.AddTovar.Text = "Добавить";
            this.AddTovar.UseVisualStyleBackColor = true;
            this.AddTovar.Click += new System.EventHandler(this.AddProv_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(930, 402);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.GridTovar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridPost)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button DelProd;
        private System.Windows.Forms.Button AddPost;
        private System.Windows.Forms.Button SearchPost;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button SearchTovar;
        private System.Windows.Forms.Button MinusPost;
        private System.Windows.Forms.Button AddTovar;
        private System.Windows.Forms.DataGridViewTextBoxColumn CountTovar;
        private System.Windows.Forms.DataGridViewTextBoxColumn TovarProv;
        private System.Windows.Forms.DataGridViewTextBoxColumn Phone;
        private System.Windows.Forms.DataGridViewTextBoxColumn Kategoria;
        protected internal System.Windows.Forms.DataGridView GridTovar;
        protected internal System.Windows.Forms.DataGridView GridPost;
        private System.Windows.Forms.DataGridViewTextBoxColumn CountProd;
        private System.Windows.Forms.DataGridViewTextBoxColumn GridIndex;
        private System.Windows.Forms.DataGridViewTextBoxColumn TovarProd;
        private System.Windows.Forms.DataGridViewTextBoxColumn Producer;
        private System.Windows.Forms.DataGridViewTextBoxColumn Obiem;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
    }
}

