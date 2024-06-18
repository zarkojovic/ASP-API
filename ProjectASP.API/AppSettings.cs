namespace ProjectASP.API
{
    public class AppSettings
    {
        public string ConnectionString { get; set; }
        public JwtSettings Jwt { get; set; }
        public SmtpSettings Smtp { get; set; }
    }

    public class JwtSettings
    {
        public string SecretKey { get; set; }
        public string Issuer { get; set; }
        public int Seconds { get; set; }
    }

    public class SmtpSettings
    {
        public string Server { get; set; }
        public int Port { get; set; }
        public string SenderName { get; set; }
        public string SenderEmail { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public bool UseSsl { get; set; }
    }
}
