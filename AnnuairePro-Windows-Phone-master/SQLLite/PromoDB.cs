using SQLite;

namespace AnnuairePro.SQLLite
{
    [Table("PromoDB")]
    public class PromoDB
    {
            [PrimaryKey]
            [AutoIncrement]
            public int ID { get; set; }

            public string Nom { get; set; }
            public string MailDiffusion { get; set; }
    }
}
