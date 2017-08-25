using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace Service.Models.Response
{
    public class RefreshAccountResult
    {

        public RefreshAccountResult()
        {
            MemberDetails = new MemberDetailsLayer();
            MduSessionObject = new MduSessionObjectLayer();

            MduSessionObject.Valid = false;
            MduSessionObject.ValidationCode = "1";
            MduSessionObject.ValidationDescription = "Something Went Wrong.";
            MduSessionObject.Successful = false;

            MemberDetails.ValidationCode = MduSessionObject.ValidationCode;
            MemberDetails.ValidationDescription = MduSessionObject.ValidationDescription;
            MemberDetails.Successful = MduSessionObject.Successful;
        }

        public MemberDetailsLayer MemberDetails { get; set; }

        public MduSessionObjectLayer MduSessionObject { get; set; }

        public class MemberDetailsLayer
        {
            [JsonProperty(PropertyName = "Username")]
            public string UserName { get; set; }
            public string Password { get; set; }
            public Guid SessionId { get; set; }
            public string PartyId { get; set; }
            [JsonProperty(PropertyName = "MDUNumber")]
            public string MduNumber { get; set; }
            public string Title { get; set; }
            public string Forename { get; set; }
            public string Surname { get; set; }
            public string PreferredEmailAddress { get; set; }
            public string AddressLine1 { get; set; }
            public string AddressLine2 { get; set; }
            public string AddressLine3 { get; set; }
            public string City { get; set; }
            public string County { get; set; }
            public string Postcode { get; set; }
            public string PhoneNumber { get; set; }
            public string VIPStatus { get; set; }
            public string QualifyingSchoolName { get; set; }
            public string Segment { get; set; }  //e.g. GP
            public string SubSegment { get; set; } // e.g. NOPR
            public string MemberStatus { get; set; }
            public string MembershipStatus { get; set; } // how are these different?
            public bool ElligibleForCQC { get; set; }
            public string Groups { get; set; }
            public string GroupBenefits { get; set; }
            public bool IsMember { get; set; }
            public string ValidationCode { get; set; }
            public string ValidationDescription { get; set; }
            public bool Successful { get; set; }


        }

        public class MduSessionObjectLayer
        {
            [JsonProperty(PropertyName = "Valid")]
            public bool Valid { get; set; }
            [JsonProperty(PropertyName = "SessionGuid")]
            public Guid SessionGuid { get; set; }
            [JsonProperty(PropertyName = "PartyId")]
            public string PartyId { get; set; }
            [JsonProperty(PropertyName = "Username")]
            public string Username { get; set; }
            [JsonProperty(PropertyName = "ValidationCode")]
            public string ValidationCode { get; set; }
            [JsonProperty(PropertyName = "ValidationDescription")]
            public string ValidationDescription { get; set; }
            [JsonProperty(PropertyName = "Successful")]
            public bool Successful { get; set; }
        }
    }
}