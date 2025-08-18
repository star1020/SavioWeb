namespace SavioWeb.Models
{
    public class ApiConfig
    {
        public string endpoint { get; set; }
        public UserEndpoints user { get; set; }
        public AdminEndpoints admin { get; set; }
    }

    public class UserEndpoints
    {
        public string getAll { get; set; }
        public string create { get; set; }
    }

    public class AdminEndpoints
    {
        public string getAll { get; set; }
    }

}
