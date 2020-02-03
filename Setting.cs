namespace Youtube_PLL
{
    public class Setting
    {
        public MyProxy proxy { get; set; }
        public bool useProxy { get; set; }
    }

    public class MyProxy
    {
        public string schema { get; set; }
        public string host { get; set; }
        public int port { get; set; }
        public string username { get; set; }
        public string password { get; set; }
    }
}