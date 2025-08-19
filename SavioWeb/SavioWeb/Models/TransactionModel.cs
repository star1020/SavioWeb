using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SavioWeb.Models
{
    public class TransactionModel
    {
        public int id { get; set; }
        public int user_id { get; set; }
        public int category_id { get; set; }
        public string type { get; set; }
        public int member_id { get; set; }
        public decimal value { get; set; }
        public DateTime? record_date { get; set; }
        public string action { get; set; }
        public DateTime? created_at { get; set; }
        public DateTime? updated_at { get; set; }
    }
    public class TransactionResponse
    {
        public int Code { get; set; }
        public string Message { get; set; }
        public List<TransactionModel> Transaction { get; set; }
    }
}
