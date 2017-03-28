namespace SortComparison
{
    partial class frmMain
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
            this.cmdSort = new System.Windows.Forms.Button();
            this.pnlSort1 = new System.Windows.Forms.PictureBox();
            this.pnlSort2 = new System.Windows.Forms.PictureBox();
            this.pnlSort3 = new System.Windows.Forms.PictureBox();
            this.pnlSort4 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pnlSort1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlSort2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlSort3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlSort4)).BeginInit();
            this.SuspendLayout();
            // 
            // cmdSort
            // 
            this.cmdSort.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.cmdSort.Location = new System.Drawing.Point(458, 589);
            this.cmdSort.Margin = new System.Windows.Forms.Padding(4);
            this.cmdSort.Name = "cmdSort";
            this.cmdSort.Size = new System.Drawing.Size(100, 28);
            this.cmdSort.TabIndex = 5;
            this.cmdSort.Text = "Sort";
            this.cmdSort.UseVisualStyleBackColor = true;
            this.cmdSort.Click += new System.EventHandler(this.cmdSort_Click);
            // 
            // pnlSort1
            // 
            this.pnlSort1.BackColor = System.Drawing.Color.White;
            this.pnlSort1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlSort1.Location = new System.Drawing.Point(17, 38);
            this.pnlSort1.Margin = new System.Windows.Forms.Padding(4);
            this.pnlSort1.Name = "pnlSort1";
            this.pnlSort1.Size = new System.Drawing.Size(266, 246);
            this.pnlSort1.TabIndex = 6;
            this.pnlSort1.TabStop = false;
            // 
            // pnlSort2
            // 
            this.pnlSort2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.pnlSort2.BackColor = System.Drawing.Color.White;
            this.pnlSort2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlSort2.Location = new System.Drawing.Point(292, 38);
            this.pnlSort2.Margin = new System.Windows.Forms.Padding(4);
            this.pnlSort2.Name = "pnlSort2";
            this.pnlSort2.Size = new System.Drawing.Size(266, 246);
            this.pnlSort2.TabIndex = 7;
            this.pnlSort2.TabStop = false;
            // 
            // pnlSort3
            // 
            this.pnlSort3.BackColor = System.Drawing.Color.White;
            this.pnlSort3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlSort3.Location = new System.Drawing.Point(17, 328);
            this.pnlSort3.Margin = new System.Windows.Forms.Padding(4);
            this.pnlSort3.Name = "pnlSort3";
            this.pnlSort3.Size = new System.Drawing.Size(266, 246);
            this.pnlSort3.TabIndex = 8;
            this.pnlSort3.TabStop = false;
            // 
            // pnlSort4
            // 
            this.pnlSort4.BackColor = System.Drawing.Color.White;
            this.pnlSort4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlSort4.Location = new System.Drawing.Point(292, 328);
            this.pnlSort4.Margin = new System.Windows.Forms.Padding(4);
            this.pnlSort4.Name = "pnlSort4";
            this.pnlSort4.Size = new System.Drawing.Size(266, 246);
            this.pnlSort4.TabIndex = 9;
            this.pnlSort4.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 17);
            this.label1.TabIndex = 10;
            this.label1.Text = "Bubble Sort";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(292, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 17);
            this.label2.TabIndex = 11;
            this.label2.Text = "Quick Sort";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 304);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 17);
            this.label3.TabIndex = 12;
            this.label3.Text = "Heap Sort";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(295, 303);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 17);
            this.label4.TabIndex = 13;
            this.label4.Text = "Merge Sort";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(579, 639);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pnlSort4);
            this.Controls.Add(this.pnlSort3);
            this.Controls.Add(this.pnlSort2);
            this.Controls.Add(this.cmdSort);
            this.Controls.Add(this.pnlSort1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximumSize = new System.Drawing.Size(13327, 12297);
            this.MinimumSize = new System.Drawing.Size(594, 464);
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sort Comparison";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.pnlSort1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlSort2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlSort3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlSort4)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button cmdSort;
        private System.Windows.Forms.PictureBox pnlSort1;
        private System.Windows.Forms.PictureBox pnlSort2;
        private System.Windows.Forms.PictureBox pnlSort3;
        private System.Windows.Forms.PictureBox pnlSort4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}

