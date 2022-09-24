namespace SmplSolutionsTech
{
    public class Config
    {
        public EmailSettings EmailSettings { get; set; }
    }

    public class EmailSettings
    {
        public string User { get; set; }
        public string Password { get; set; }
        public string Host { get; set; }
        public int Port { get; set; }
    }
}
