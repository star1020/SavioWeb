namespace SavioWeb.Models
{
    public class ApiConfig
    {
        public string endpoint { get; set; }
        public UserEndpoints user { get; set; }
        public AdminEndpoints admin { get; set; }
        public EndpointGroup transaction { get; set; }
        public EndpointGroup category { get; set; }
        public EndpointGroup notification { get; set; }
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
    public class EndpointGroup
    {
        public string getAllWithData { get; set; }
        public string addEdit { get; set; }
        public string delete { get; set; }
    }

}
