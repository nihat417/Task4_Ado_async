namespace Task3_Ado_async
{
    partial class OldAsync
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.ExecuteBtn = new System.Windows.Forms.Button();
            this.AuthorsCmbx = new System.Windows.Forms.ComboBox();
            this.CategoryCmbx = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(24, 117);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 29;
            this.dataGridView1.Size = new System.Drawing.Size(751, 332);
            this.dataGridView1.TabIndex = 7;
            // 
            // ExecuteBtn
            // 
            this.ExecuteBtn.Location = new System.Drawing.Point(491, 68);
            this.ExecuteBtn.Name = "ExecuteBtn";
            this.ExecuteBtn.Size = new System.Drawing.Size(94, 29);
            this.ExecuteBtn.TabIndex = 6;
            this.ExecuteBtn.Text = "Execute";
            this.ExecuteBtn.UseVisualStyleBackColor = true;
            this.ExecuteBtn.Click += new System.EventHandler(this.ExecuteBtn_Click);
            // 
            // AuthorsCmbx
            // 
            this.AuthorsCmbx.FormattingEnabled = true;
            this.AuthorsCmbx.Location = new System.Drawing.Point(226, 68);
            this.AuthorsCmbx.Name = "AuthorsCmbx";
            this.AuthorsCmbx.Size = new System.Drawing.Size(151, 28);
            this.AuthorsCmbx.TabIndex = 5;
            // 
            // CategoryCmbx
            // 
            this.CategoryCmbx.FormattingEnabled = true;
            this.CategoryCmbx.Location = new System.Drawing.Point(33, 68);
            this.CategoryCmbx.Name = "CategoryCmbx";
            this.CategoryCmbx.Size = new System.Drawing.Size(151, 28);
            this.CategoryCmbx.TabIndex = 4;
            this.CategoryCmbx.SelectedIndexChanged += new System.EventHandler(this.CategoryCmbx_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(274, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 20);
            this.label2.TabIndex = 9;
            this.label2.Text = "Authors";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(94, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 20);
            this.label1.TabIndex = 8;
            this.label1.Text = "Category";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(383, 9);
            this.label3.Margin = new System.Windows.Forms.Padding(4);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 20);
            this.label3.TabIndex = 10;
            this.label3.Text = "OldAsync";
            // 
            // OldAsync
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
            this.Name = "OldAsync";
            this.Text = "OldAsync";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DataGridView dataGridView1;
        private Button ExecuteBtn;
        private ComboBox AuthorsCmbx;
        private ComboBox CategoryCmbx;
        private Label label2;
        private Label label1;
        private Label label3;
    }
}