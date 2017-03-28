namespace Sorting
{
    partial class Form1
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
            this.generate = new System.Windows.Forms.Button();
            this.sort = new System.Windows.Forms.Button();
            this.quickSort = new System.Windows.Forms.TextBox();
            this.bubbleSort = new System.Windows.Forms.TextBox();
            this.mergeSort = new System.Windows.Forms.TextBox();
            this.heapSort = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // generate
            // 
            this.generate.Location = new System.Drawing.Point(13, 13);
            this.generate.Name = "generate";
            this.generate.Size = new System.Drawing.Size(107, 23);
            this.generate.TabIndex = 0;
            this.generate.Text = "Generate";
            this.generate.UseVisualStyleBackColor = true;
            this.generate.Click += new System.EventHandler(this.generate_Click);
            // 
            // sort
            // 
            this.sort.Location = new System.Drawing.Point(126, 13);
            this.sort.Name = "sort";
            this.sort.Size = new System.Drawing.Size(75, 23);
            this.sort.TabIndex = 1;
            this.sort.Text = "Sort";
            this.sort.UseVisualStyleBackColor = true;
            this.sort.Click += new System.EventHandler(this.sort_Click);
            // 
            // quickSort
            // 
            this.quickSort.Enabled = false;
            this.quickSort.Location = new System.Drawing.Point(13, 53);
            this.quickSort.Multiline = true;
            this.quickSort.Name = "quickSort";
            this.quickSort.Size = new System.Drawing.Size(493, 325);
            this.quickSort.TabIndex = 2;
            // 
            // bubbleSort
            // 
            this.bubbleSort.Enabled = false;
            this.bubbleSort.Location = new System.Drawing.Point(527, 53);
            this.bubbleSort.Multiline = true;
            this.bubbleSort.Name = "bubbleSort";
            this.bubbleSort.Size = new System.Drawing.Size(493, 325);
            this.bubbleSort.TabIndex = 3;
            // 
            // mergeSort
            // 
            this.mergeSort.Enabled = false;
            this.mergeSort.Location = new System.Drawing.Point(13, 395);
            this.mergeSort.Multiline = true;
            this.mergeSort.Name = "mergeSort";
            this.mergeSort.Size = new System.Drawing.Size(493, 325);
            this.mergeSort.TabIndex = 4;
            // 
            // heapSort
            // 
            this.heapSort.Enabled = false;
            this.heapSort.Location = new System.Drawing.Point(527, 395);
            this.heapSort.Multiline = true;
            this.heapSort.Name = "heapSort";
            this.heapSort.Size = new System.Drawing.Size(493, 325);
            this.heapSort.TabIndex = 5;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1037, 730);
            this.Controls.Add(this.heapSort);
            this.Controls.Add(this.mergeSort);
            this.Controls.Add(this.bubbleSort);
            this.Controls.Add(this.quickSort);
            this.Controls.Add(this.sort);
            this.Controls.Add(this.generate);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button generate;
        private System.Windows.Forms.Button sort;
        private System.Windows.Forms.TextBox quickSort;
        private System.Windows.Forms.TextBox bubbleSort;
        private System.Windows.Forms.TextBox mergeSort;
        private System.Windows.Forms.TextBox heapSort;
    }
}

