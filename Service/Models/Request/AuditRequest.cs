using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Service.Models.Request
{
    public class AuditRequest
    {
        public string FunctionName { get; set; }
        public int PartyID { get; set; }
        public Guid SessionEGUID { get; set; }
        public Guid PlatformID { get; set; }
        public DateTime RequestReceivedDateTime { get; set; }
        public DateTime RequestReturnDateTime { get; set; }
        public string InputParameters { get; set; }
        public string ReturnObjects { get; set; }
        public string ValidationCode { get; set; }
        public string ValidationDescription { get; set; }
        public string SourceIPAddress { get; set; }
        public DateTime ActionDate { get; set; }
        public string ActionBy { get; set; }
    }
}