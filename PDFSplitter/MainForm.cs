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

            // Allows for custom encoding
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

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
            // Get the number of pages the user wants to split by
            int pagesPerPDF;

            // If user doesn't enter a valid number
            if (!int.TryParse(PageCountTxt.Text, out pagesPerPDF))
            {
                MessageBox.Show("Please enter a valid number.");
                return;
            }
            else 
            {
                pagesPerPDF = Convert.ToInt32(PageCountTxt.Text);
            }

            // Open the file
            PdfDocument inputDocument = PdfReader.Open(FullPath, PdfDocumentOpenMode.Import);

            // Get the direcroty path only
            string directoryPath = Path.GetDirectoryName(FullPath);

            // Get the file name only
            string filename = Path.GetFileNameWithoutExtension(FileName);

            // Get total pages in the PDF
            int inputDocumentTotalPages = inputDocument.PageCount;

            int fileCount = 1;

            try
            {
                // Itarate through the whole PDF document
                for (int i = 0; i < inputDocumentTotalPages; i += pagesPerPDF)
                {
                    // Create a new PDF document
                    PdfDocument outputDocument = new PdfDocument();

                    // Add only the pages specified
                    for (int j = i; j < i + pagesPerPDF; j++)
                    {
                        // Add a specific page
                        outputDocument.AddPage(inputDocument.Pages[j]);
                    }

                    // Save the PDF document
                    string outputPDFFilePath = Path.Combine(directoryPath + "\\" + filename + $"_{fileCount}.pdf");
                    outputDocument.Save(outputPDFFilePath);
                    fileCount++;
                }

                MessageBox.Show("Split complete!");

                // Reset the form
                PageCountTxt.Text = "";
                PageCountTxt.Enabled = false;
                FileTxtBox.Text = "";
            }
            catch (Exception)
            {
                MessageBox.Show("Something went wrong with the split process. Please make sure the pages you specified does not exceed the total pages in the PDF.");
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
