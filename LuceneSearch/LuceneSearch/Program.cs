using Lucene.Net.Analysis;
using Lucene.Net.Analysis.Core;
using Lucene.Net.Analysis.Standard;
using Lucene.Net.Documents;
using Lucene.Net.Index;
using Lucene.Net.QueryParsers.Classic;
using Lucene.Net.Search;
using Lucene.Net.Store;
using Lucene.Net.Util;
using System.Text;
using LuceneDirectory = Lucene.Net.Store.Directory;

// Specify where txt files are present.
string docpath = @"C:\Manas\books";

// Specify the compatibility version we want
const LuceneVersion luceneVersion = LuceneVersion.LUCENE_48;

//Open the Directory using a Lucene Directory class
string indexPath = Path.Combine(docpath, "books_search_index");

using LuceneDirectory indexDir = FSDirectory.Open(indexPath);

// Create an analyzer to process the text 
Analyzer standardAnalyzer = new StandardAnalyzer(luceneVersion);

//WhitespaceAnalyzer standardAnalyzer = new WhitespaceAnalyzer(luceneVersion);


//Create an index writer
IndexWriterConfig indexConfig = new IndexWriterConfig(luceneVersion, standardAnalyzer);
indexConfig.OpenMode = OpenMode.CREATE;                             // create/overwrite index
IndexWriter writer = new IndexWriter(indexDir, indexConfig);

// Iterate through the folder and add book content in the index.

DirectoryInfo d = new DirectoryInfo(docpath);

foreach (var txtfile in d.GetFiles("*.txt"))
{
    Document doc = new Document();
    doc.Add(new TextField("title", txtfile.Name, Field.Store.YES));
    doc.Add(new StringField("size", txtfile.Length + " bytes", Field.Store.YES));
    doc.Add(new TextField("content", File.ReadAllText(txtfile.FullName, Encoding.UTF8), Field.Store.YES));
    writer.AddDocument(doc);

    Console.WriteLine("Index added for " + txtfile.Name); 
}

//Flush and commit the index data to the directory
writer.Commit();



using DirectoryReader reader = writer.GetReader(applyAllDeletes: true);
IndexSearcher searcher = new IndexSearcher(reader);

string SearchText = "\"It is not cold which makes me shiver\"";

QueryParser parser = new QueryParser(luceneVersion, "content", standardAnalyzer);
Query query = parser.Parse(SearchText);
TopDocs results = searcher.Search(query, n: 10);  //indicate we want the first 3 results


Console.WriteLine($"Matching results: {results.TotalHits}");

foreach(ScoreDoc ScoreDoc in results.ScoreDocs)
{
    Document resultDoc = searcher.Doc(ScoreDoc.Doc);
    string title = resultDoc.Get("title");
    Console.WriteLine($"Matching Title : {title} - Score : {ScoreDoc.Score:P2}");

    // Get few lines of matching text
    string content = resultDoc.Get("content");
    string[] lines = content.Split(new[] {Environment.NewLine}, StringSplitOptions.RemoveEmptyEntries);

    foreach(string line in lines)
    {
        if(line.Contains(SearchText))
        {
            Console.WriteLine(line);
        }
    }


}




