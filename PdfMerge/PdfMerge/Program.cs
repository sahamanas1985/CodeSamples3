
using iTextSharp.text;
using iTextSharp.text.pdf;

// Replace "sourceFolder" with the path to your folder containing PDFs
string sourceFolder = @"C:\Users\2080527\Desktop\Print";

// Replace "outputFile" with the desired output filename
string outputFile = @"Merged.pdf";

MergePdfs(sourceFolder, outputFile);


static void MergePdfs(string sourceFolder, string outputFile)
{
    string OutputFileName = Path.Combine(sourceFolder, outputFile);
    
    // List to store all PDF files
    List<string> pdfFiles = new List<string>();

    // Get all PDF files from the source folder
    foreach (string file in Directory.GetFiles(sourceFolder, "*.pdf"))
    {
        pdfFiles.Add(file);
    }

    // Create a new document
    Document document = new Document();

    // Create a PdfCopy writer for the merged PDF
    PdfCopy writer = new PdfCopy(document, new FileStream(OutputFileName, FileMode.Create));

    // Open the document
    document.Open();

    // Loop through each PDF file
    foreach (string filePath in pdfFiles)
    {
        PdfReader reader = new PdfReader(filePath);
        PdfReader.unethicalreading = true;

        // Add each page to the merged document
        for (int i = 1; i <= reader.NumberOfPages; i++)
        {
            PdfImportedPage page = writer.GetImportedPage(reader, i);
            writer.AddPage(page);
        }

        reader.Close();
    }

    // Close the writer and document
    writer.Close();
    document.Close();

    Console.WriteLine("PDFs merged successfully!");
}

