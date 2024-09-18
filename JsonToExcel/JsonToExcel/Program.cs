
using JsonToExcel;
using System.Data;
using System.Text;
using System.Text.Json;

Console.WriteLine("Reading file");

string InputJsonPath = @"C:\Manas\Python\JsonToExcel\input.json";
string OutputCSVPath = @"C:\Manas\Python\JsonToExcel\output.csv";

string JsonContent = File.ReadAllText(InputJsonPath);

JsonClassObj JsonObj = JsonSerializer.Deserialize<JsonClassObj>(JsonContent);

Console.WriteLine("Deserialized successful");

// Prepare dataset

DataTable dt = new DataTable();

dt.Columns.Add("ProductId", typeof(int));
dt.Columns.Add("ProductName", typeof(string));
dt.Columns.Add("SystemVersion", typeof(string));
dt.Columns.Add("DataSheetName", typeof(string));
dt.Columns.Add("ExternalArgusId", typeof(string));
dt.Columns.Add("EffectiveVersion", typeof(string));
dt.Columns.Add("EffectiveDate", typeof(string));
dt.Columns.Add("ReceivedDate", typeof(string));
dt.Columns.Add("CreatedBy", typeof(int));
dt.Columns.Add("CreatedByUserName", typeof(string));
dt.Columns.Add("Action", typeof(string));
dt.Columns.Add("CreationDate", typeof(string));
dt.Columns.Add("DictionaryVersion", typeof(string));

dt.Columns.Add("Status", typeof(string));
dt.Columns.Add("VerificationRejectionComment", typeof(string));
dt.Columns.Add("Comment", typeof(string));
dt.Columns.Add("qcComment", typeof(string));
dt.Columns.Add("approverComment", typeof(string));

// Populate datatable

List<Jsonroot> JsonRootList = JsonObj.JsonRoot.ToList();

foreach(Jsonroot jr in JsonRootList)
{
    List<Audit> AuditList = jr.Audit.ToList();
    foreach(Audit au in AuditList)
    {
        DataRow dr = dt.NewRow();

        dr["ProductId"] = jr.ProductId;
        dr["ProductName"] = jr.ProductName;
        dr["SystemVersion"] = au.SystemVersion;
        dr["DataSheetName"] = au.DataSheetName;
        dr["ExternalArgusId"] = au.ExternalArgusId;
        dr["EffectiveVersion"] = au.EffectiveVersion;
        dr["EffectiveDate"] = au.EffectiveDate;
        dr["ReceivedDate"] = au.ReceivedDate;
        dr["CreatedBy"] = au.CreatedBy;
        dr["CreatedByUserName"] = au.CreatedByUserName;
        dr["Action"] = au.Action;
        dr["CreationDate"] = au.CreationDate.date;
        dr["DictionaryVersion"] = au.DictionaryVersion;

        dr["Status"] = au.Status;
        dr["VerificationRejectionComment"] = au.VerificationRejectionComment;
        dr["Comment"] = au.Comment;
        dr["qcComment"] = au.qcComment;
        dr["approverComment"] = au.approverComment;

        dt.Rows.Add(dr);
    }
}

// Save datatbale as CSV

StringBuilder sb = new StringBuilder();

IEnumerable<string> columnNames = dt.Columns.Cast<DataColumn>().
                                  Select(column => column.ColumnName);
sb.AppendLine(string.Join(",", columnNames));

foreach (DataRow row in dt.Rows)
{
    IEnumerable<string> fields = row.ItemArray.Select(field =>
      string.Concat("\"", field.ToString().Replace("\"", "\"\""), "\""));
    sb.AppendLine(string.Join(",", fields));
}

File.WriteAllText(OutputCSVPath, sb.ToString());
Console.WriteLine("CSV Generated");
