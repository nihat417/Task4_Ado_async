namespace Task3_Ado_async
{
    partial class NewAsync
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.CategoryCmbx = new System.Windows.Forms.ComboBox();
            this.AuthorsCmbx = new System.Windows.Forms.ComboBox();
            this.ExecuteBtn = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // CategoryCmbx
            // 
            this.CategoryCmbx.FormattingEnabled = true;
            this.CategoryCmbx.Location = new System.Drawing.Point(31, 57);
            this.CategoryCmbx.Name = "CategoryCmbx";
            this.CategoryCmbx.Size = new System.Drawing.Size(151, 28);
            this.CategoryCmbx.TabIndex = 0;
            this.CategoryCmbx.SelectedIndexChanged += new System.EventHandler(this.CategoryCmbx_SelectedIndexChanged);
            // 
            // AuthorsCmbx
            // 
            this.AuthorsCmbx.FormattingEnabled = true;
            this.AuthorsCmbx.Location = new System.Drawing.Point(224, 57);
            this.AuthorsCmbx.Name = "AuthorsCmbx";
            this.AuthorsCmbx.Size = new System.Drawing.Size(151, 28);
            this.AuthorsCmbx.TabIndex = 1;
            // 
            // ExecuteBtn
            // 
            this.ExecuteBtn.Location = new System.Drawing.Point(576, 57);
            this.ExecuteBtn.Name = "ExecuteBtn";
            this.ExecuteBtn.Size = new System.Drawing.Size(94, 29);
            this.ExecuteBtn.TabIndex = 2;
            this.ExecuteBtn.Text = "Execute";
            this.ExecuteBtn.UseVisualStyleBackColor = true;
            this.ExecuteBtn.Click += new System.EventHandler(this.ExecuteBtn_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(22, 106);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 29;
            this.dataGridView1.Size = new System.Drawing.Size(751, 332);
            this.dataGridView1.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(44, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "Category";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(224, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 20);
            this.label2.TabIndex = 5;
            this.label2.Text = "Authors";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(402, 13);
            this.label3.Margin = new System.Windows.Forms.Padding(4);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 20);
            this.label3.TabIndex = 11;
            this.label3.Text = "NewAsync";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.ExecuteBtn);
            this.Controls.Add(this.AuthorsCmbx);
            this.Controls.Add(this.CategoryCmbx);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ComboBox CategoryCmbx;
        private ComboBox AuthorsCmbx;
        private Button ExecuteBtn;
        private DataGridView dataGridView1;
        private Label label1;
        private Label label2;
        private Label label3;
    }
}