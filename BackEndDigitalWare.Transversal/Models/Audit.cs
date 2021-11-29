namespace BackEndDigitalWare.Transversal.Models
{
    public class Audit
    {
        public string BusinessMessage { get; set; }
        public string Class { get; set; }
        public string Method { get; set; }
        public string DescripctionMethod { get;  set; }
        public object SentParameters { get; set; }
        public object ResultParameters { get; set; }
        public string ErrorMessage { get; set; }
        public string ExceptionMessage { get; set; }
        public object UserData { get; set; }
    }
}
