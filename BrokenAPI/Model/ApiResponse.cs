namespace BrokenAPI.Model
{
    
    public class User
    {
        public string uid { get; set; }
        public string name { get; set; }
        public string url { get; set; }
    }

    public class ApiResponse
    {
        public string message { get; set; }
        public int total_records { get; set; }
        public int total_pages { get; set; }
        public object previous { get; set; }
        public object next { get; set; }
        public List<User> results { get; set; }
    }
}
