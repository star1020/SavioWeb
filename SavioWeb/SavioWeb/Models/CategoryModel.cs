using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SavioWeb.Models
{
    public class CategoryModel
    {
        public int id { get; set; }
        public string icon { get; set; }
        public string name { get; set; }
        public string action { get; set; }
        public DateTime? created_at { get; set; }
        public DateTime? updated_at { get; set; }
    }
    public class CategoryResponse
    {
        public int Code { get; set; }
        public string Message { get; set; }
        public List<CategoryModel> Category { get; set; }
    }
}
