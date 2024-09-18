namespace JsonToExcel
{
    public class JsonClassObj
    {
        public Jsonroot[] JsonRoot { get; set; }
    }

    public class Jsonroot
    {
        public _Id _id { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public Audit[] Audit { get; set; }
    }

    public class _Id
    {
        public string oid { get; set; }
    }

    public class Audit
    {
        public string SystemVersion { get; set; }
        public string ProductName { get; set; }
        public string DataSheetName { get; set; }
        public int ExternalArgusId { get; set; }
        public string EffectiveVersion { get; set; }
        public string EffectiveDate { get; set; }
        public string ReceivedDate { get; set; }
        public int CreatedBy { get; set; }
        public string CreatedByUserName { get; set; }
        public string Action { get; set; }
        public Creationdate CreationDate { get; set; }
        public string DictionaryVersion { get; set; }
        public string Status { get; set; }
        public string VerificationRejectionComment { get; set; }
        public object Comment { get; set; }
        public string qcComment { get; set; }
        public string approverComment { get; set; }
    }

    public class Creationdate
    {
        public DateTime date { get; set; }
    }

}
