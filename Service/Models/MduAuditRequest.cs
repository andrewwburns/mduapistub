using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDUClasses
{
    public class MduAuditRequest
    {
        public string FunctionName { get;  set; }

        // That's the way, uh-huh uh-huh, I ...
        public string PartyID { get; set; }
        public string SessionEGUID { get; set; }
        public string PlatformID { get; set; }
        public string RequestReceivedDateTime { get; set; }
        public string RequestReturnDateTime { get; set; }
        public string InputParameters { get; set; }
        public string ReturnObjects { get; set; }
        public string ValidationCode { get; set; }
        public string ValidationDescription { get; set; }
        public string SourceIPAddress { get; set; }
        public string ActionDate { get; set; }
        public string ActionBy { get; set; }
        
    }
}
