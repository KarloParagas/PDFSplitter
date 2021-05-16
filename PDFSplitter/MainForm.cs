using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PDFSplitter
{
    public partial class MainForm : Form
    {
        public string FilePath { get; set; }

        public MainForm()
        {
            InitializeComponent();
            FileTxtBox.ReadOnly = true;
            PageCountTxt.Enabled = false;
            SplitBtn.Enabled = false;
        }

        /// <summary>
        /// Opens up file explorer to browse files.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BrowseBtn_Click(object sender, EventArgs e)
        {
            // Open up file explorer
            OpenFileDialog fileExplorer = new OpenFileDialog();
            if (fileExplorer.ShowDialog() == DialogResult.OK) 
            {
                // If user selects a PDF file
                if (fileExplorer.FileName.Substring(fileExplorer.FileName.Length - 4).Contains(".pdf")) 
                {
                    // Enable the next button
                    PageCountTxt.Enabled = true;
                }

                // Assign the file path to the FilePath field
                FilePath = fileExplorer.FileName;

                // Display the file path text in the text field
                FileTxtBox.Text = fileExplorer.FileName;
            }
        }

        private void SplitBtn_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Enables the split button to be clicked whenever something 
        /// is inputted in the text field.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PageCountTxt_TextChanged(object sender, EventArgs e)
        {
            // If the text field isn't empty
            if (!string.IsNullOrEmpty(PageCountTxt.Text)) 
            {
                // Enable the split button
                SplitBtn.Enabled = true;
            }
            else // If the text field is empty
            {
                // Disable the split button
                SplitBtn.Enabled = false;
            }
        }
    }
}
