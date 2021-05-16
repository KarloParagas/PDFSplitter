
namespace PDFSplitter
{
    partial class MainForm
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
            this.BrowseBtn = new System.Windows.Forms.Button();
            this.FileTxtBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SplitBtn = new System.Windows.Forms.Button();
            this.PageCountTxt = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // BrowseBtn
            // 
            this.BrowseBtn.Location = new System.Drawing.Point(970, 69);
            this.BrowseBtn.Name = "BrowseBtn";
            this.BrowseBtn.Size = new System.Drawing.Size(188, 58);
            this.BrowseBtn.TabIndex = 0;
            this.BrowseBtn.Text = "Browse";
            this.BrowseBtn.UseVisualStyleBackColor = true;
            this.BrowseBtn.Click += new System.EventHandler(this.BrowseBtn_Click);
            // 
            // FileTxtBox
            // 
            this.FileTxtBox.Location = new System.Drawing.Point(83, 75);
            this.FileTxtBox.Name = "FileTxtBox";
            this.FileTxtBox.Size = new System.Drawing.Size(845, 47);
            this.FileTxtBox.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(297, 194);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(202, 41);
            this.label1.TabIndex = 5;
            this.label1.Text = "Pages per file:";
            // 
            // SplitBtn
            // 
            this.SplitBtn.Location = new System.Drawing.Point(703, 188);
            this.SplitBtn.Name = "SplitBtn";
            this.SplitBtn.Size = new System.Drawing.Size(188, 58);
            this.SplitBtn.TabIndex = 4;
            this.SplitBtn.Text = "Split";
            this.SplitBtn.UseVisualStyleBackColor = true;
            this.SplitBtn.Click += new System.EventHandler(this.SplitBtn_Click);
            // 
            // PageCountTxt
            // 
            this.PageCountTxt.Location = new System.Drawing.Point(505, 194);
            this.PageCountTxt.Name = "PageCountTxt";
            this.PageCountTxt.Size = new System.Drawing.Size(173, 47);
            this.PageCountTxt.TabIndex = 3;
            this.PageCountTxt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.PageCountTxt.TextChanged += new System.EventHandler(this.PageCountTxt_TextChanged);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(17F, 41F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1208, 321);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.SplitBtn);
            this.Controls.Add(this.PageCountTxt);
            this.Controls.Add(this.FileTxtBox);
            this.Controls.Add(this.BrowseBtn);
            this.Name = "MainForm";
            this.Text = "Split My PDF";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BrowseBtn;
        private System.Windows.Forms.TextBox FileTxtBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button SplitBtn;
        private System.Windows.Forms.TextBox PageCountTxt;
    }
}

