using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace paypart_notification_gateway.Models
{
    public class EmailMetaData
    {
        public string fromname { get; set; }
        public string fromaddress { get; set; }
        public string toaddress { get; set; }
        public string subject { get; set; }
        public string body { get; set; }
        public int retries { get; set; }
        public string isprocessed { get; set; }
        public string appname { get; set; }
        public string hasattachment { get; set; }
        public string bcc { get; set; }
        public DateTime datesubmitted { get; set; }
        public string cc { get; set; }
        public string banner { get; set; }
        public string footer { get; set; }
        public int imgcount { get; set; }
        public string uname { get; set; }
        public string peeword { get; set; }
        public bool isHtml { get; set; }
        public Smtp protocol { get; set; }
    }
    public class Smtp
    {
        public string host { get; set; }
        public int port { get; set; }
        public bool usedefaultcredential { get; set; }
        public bool enablessl { get; set; }

    }
}
