using PdfSharp.Pdf;
using PdfSharp.Pdf.IO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PDFSplitter
{
    public partial class MainForm : Form
    {
        public string FullPath { get; set; }
        public string FileName { get; set; }

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

                // Assign the file path to the FilePath property
                FullPath = fileExplorer.FileName;

                // Assign the file name to the FileName property
                FileName = fileExplorer.SafeFileName;

                // Display the file name in the text field
                FileTxtBox.Text = FileName;
            }
        }

        private void SplitBtn_Click(object sender, EventArgs e)
        {
            // Open the file
            PdfDocument inputDocument = PdfReader.Open(FullPath, PdfDocumentOpenMode.Import);

            // Get the file name without the extension
            string directoryPath = Path.GetDirectoryName(FullPath);
            string filename = Path.GetFileNameWithoutExtension(FileName);

            // Get total pages in the PDF
            int inputDocumentTotalPages = inputDocument.PageCount;

            for (int i = 1; i <= inputDocumentTotalPages; i++) 
            {
                // Create a new PDF document
                PdfDocument outputDocument = new PdfDocument();

                // Add a specific page
                outputDocument.AddPage(inputDocument.Pages[inputDocumentTotalPages - 1]);

                // Save the PDF document
                string outputPDFFilePath = Path.Combine(directoryPath + "\\" + filename + $"_{i}");
                outputDocument.Save(outputPDFFilePath);
            }
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
