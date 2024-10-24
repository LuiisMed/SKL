namespace SKL.Models
{
    public class Mailrequest
    {
        public string ToEmail { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }

        public string Accion {  get; set; }
        public string Fase { get; set; }
        public DateTime EndDate { get; set; }

    }
}
