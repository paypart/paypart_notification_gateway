using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace paypart_notification_gateway.Models
{
    public class Settings
    {
        public int redisCancellationToken;
        public string emailFromAddress;
        public string emailHost;
        public bool emailEnableSSL;
        public int emailPort;
        public bool UseDefaultCredential;
    }
}
