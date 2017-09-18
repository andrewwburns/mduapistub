using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using Service.Models.Response;
using Service.Models.Request;
using System.IO;
using Newtonsoft.Json;

namespace Service.Controllers
{



    [System.Web.Http.RoutePrefix("api")]
    public class MduAuthController : ApiController
    {

        public MduAuthController() : base()
        {
            _roles = new List<Guid>();
            _roles.Add(new Guid("{A327CB59-318D-4A11-8707-F3466FEF7454}"));
            _roles.Add(new Guid("{9BB8E0B0-EB3F-45DB-B1EC-291FD39E8B51}"));
            _roles.Add(new Guid("{A20C7706-FEF4-41BA-9832-B319C5194734}"));
            _roles.Add(new Guid("{BD6BA6DE-2ED2-4FA9-94A1-A25790D53334}"));
            _roles.Add(new Guid("{32BF5E2F-AF85-415E-995F-C3EA6B7A0E68}"));
            _roles.Add(new Guid("{166BEE1C-D11E-4B59-834D-73302D5FC8A3}"));
            _roles.Add(new Guid("{3A05FBA1-D0C9-42CE-9B1E-E0020D4602F4}"));

            _regions = new List<Guid>();
            _regions.Add(new Guid("{90CCA8F1-C8CC-40D0-8575-28840EE4C810}"));
            _regions.Add(new Guid("{3CE55F66-C700-45CE-AC6A-6BCBE8F74E22}"));
            _regions.Add(new Guid("{DA840D7B-45ED-436D-936E-592F9B698418}"));
            _regions.Add(new Guid("{E0E8F6CD-8271-4AA6-B8C0-C355AC06294D}"));


            _validSessions = new List<Guid>();
            _validSessions.Add(new Guid("ABBABABE-ABBA-BABE-ABBA-BABEABBABABE"));
            _validSessions.Add(new Guid("BADC0FFE-E0DD-F00D-BADC-0FFEE0DDF00D"));
            _validSessions.Add(new Guid("CAFED00D-CAFE-D00D-CAFE-D00DCAFED00D"));
            _validSessions.Add(new Guid("DEADBEEF-DEAD-BEEF-DEAD-BEEFDEADBEEF"));
            _validSessions.Add(new Guid("EA5ED15E-A5EE-A5ED-15EA-5EEA5ED15EA5"));
            _validSessions.Add(new Guid("FADEDEAD-FADE-DEAD-FADE-DEADFADEDEAD"));


            _basicResults = new Dictionary<string, BaseResult>();
            _basicResults.Add("alice-password", new BaseResult { SessionGuid = _validSessions[0], ValidationCode = "0", ValidationDescription = "Is Valid", Successful = true });
            _basicResults.Add("bob-password", new BaseResult { SessionGuid = _validSessions[1], ValidationCode = "0", ValidationDescription = "Is Valid", Successful = true });
            _basicResults.Add("charles-password", new BaseResult { SessionGuid = _validSessions[2], ValidationCode = "0", ValidationDescription = "Is Valid", Successful = true });
            _basicResults.Add("doris-password", new BaseResult { SessionGuid = _validSessions[3], ValidationCode = "0", ValidationDescription = "Is Valid", Successful = true });
            _basicResults.Add("eve-password", new BaseResult { SessionGuid = _validSessions[4], ValidationCode = "0", ValidationDescription = "Is Valid", Successful = true });
            _basicResults.Add("fred-password", new BaseResult { SessionGuid = _validSessions[5], ValidationCode = "0", ValidationDescription = "Is Valid", Successful = true });

            _refreshResults = new Dictionary<Guid, RefreshAccountResult>();
            _refreshResults.Add(_validSessions[0], MakeRefreshResult("Alice", "Aaronson", "GP", _validSessions[0]));
            _refreshResults.Add(_validSessions[1], MakeRefreshResult("Bob", "Brown", null, _validSessions[1]));
            _refreshResults.Add(_validSessions[2], MakeRefreshResult("Charles", "Charlesworthy", "MSTU", _validSessions[2]));
            _refreshResults.Add(_validSessions[3], MakeRefreshResult("Doris", "Day", "ZZZ" ,_validSessions[3]));
            _refreshResults.Add(_validSessions[4], MakeRefreshResult("Eve", "Edwards", "DSTU", _validSessions[4]));
            _refreshResults.Add(_validSessions[5], MakeRefreshResult("Fred", "Flinstone", "BRK", _validSessions[5]));


        }



        #region Creative_data_imagining

        private string PadNumber(int length)
        {
            Random r = new Random(DateTime.Now.Day);
            string s = "";
            for (int i = 0; i < length; i++)
            {
                s += r.Next(10).ToString();
            }
            return s;
        }
        private string[] _titles = { "Mr", "Mrs", "Miss", "Dr", "Dr", "Prof", "Dr", "Dr", "Emperor" };
        private string[] _street1 = { "High", "West", "Main", "Market", "Green", "Gillette", "Leonardo", "London" };
        private string[] _street2 = { "Street", "Drive", "Way", "Lane" };
        private string[] _city = { "London", "Birmingham", "Reading", "Manchester" };
        private string[] _vip = { "Peon", "Pleb", "Prole", "Important!" };

        private string Postcode()
        {
            Random r = new Random(DateTime.Now.Day);
            string s = "";
            s += (char)(r.Next(26) + 65);
            s += (char)(r.Next(26) + 65);
            s += r.Next(20).ToString();
            s += " ";
            s += r.Next(10).ToString();
            s += (char)(r.Next(26) + 65);
            s += (char)(r.Next(26) + 65);
            
            return s;
        }

        private RefreshAccountResult MakeRefreshResult(string name, string surname, string segment, Guid sessionid)
        {
            Random r = new Random(DateTime.Now.Day);
            RefreshAccountResult rfsh = new RefreshAccountResult();

            rfsh.MemberDetails.UserName = name;
            rfsh.MemberDetails.Password = null;
            rfsh.MemberDetails.SessionId = sessionid;
            rfsh.MemberDetails.MduNumber = PadNumber(6) + name[0];
            rfsh.MemberDetails.Title = _titles[r.Next(_titles.Length)];
            rfsh.MemberDetails.Forename = name;
            rfsh.MemberDetails.Surname = surname;
            rfsh.MemberDetails.PreferredEmailAddress = $"{name}@example.com".ToLower();
            rfsh.MemberDetails.AddressLine1 = PadNumber(2) + " " + _street1[r.Next(_street1.Length)] + " " + _street2[r.Next(_street2.Length)];
            rfsh.MemberDetails.City = _city[r.Next(_city.Length)];
            rfsh.MemberDetails.County = "";
            rfsh.MemberDetails.Postcode = Postcode();
            rfsh.MemberDetails.PhoneNumber = "07" + PadNumber(8);
            rfsh.MemberDetails.VIPStatus = _vip[r.Next(_vip.Length)];
            rfsh.MemberDetails.QualifyingSchoolName = "";
            rfsh.MemberDetails.MemberStatus = "";
            rfsh.MemberDetails.MembershipStatus = rfsh.MemberDetails.MemberStatus;
            rfsh.MemberDetails.ElligibleForCQC = (r.Next(2) == 1);
            rfsh.MemberDetails.Groups = "";
            rfsh.MemberDetails.GroupBenefits = "";
            
            rfsh.MemberDetails.ValidationCode = "0";
            rfsh.MemberDetails.ValidationDescription = "Ok";
            rfsh.MemberDetails.Successful = true;

            rfsh.MduSessionObject.Valid = true;
            rfsh.MduSessionObject.SessionGuid = sessionid;

            rfsh.MduSessionObject.Username = name;

            rfsh.MemberDetails.IsMember = !string.IsNullOrEmpty(segment);

            if (!rfsh.MemberDetails.IsMember)
            {
                rfsh.MemberDetails.Segment = null;
                rfsh.MemberDetails.SubSegment = null;
                rfsh.MemberDetails.PartyId = null;
                rfsh.MemberDetails.Role = _roles.ElementAt(r.Next(_roles.Count)).ToString("B");
                rfsh.MemberDetails.Region = _regions.ElementAt(r.Next(_regions.Count)).ToString("B");

                rfsh.MduSessionObject.PartyId = null;

            }
            else 
            {
                rfsh.MemberDetails.Segment = segment;
                rfsh.MemberDetails.SubSegment = "NOPR";
                rfsh.MemberDetails.PartyId = PadNumber(7);
                rfsh.MemberDetails.Role = null; //GetRole(segment)?.ToString("B");
                rfsh.MemberDetails.Region = null;

                rfsh.MduSessionObject.PartyId = rfsh.MemberDetails.PartyId;
            }

            rfsh.MduSessionObject.ValidationCode = rfsh.MemberDetails.ValidationCode;
            rfsh.MduSessionObject.ValidationDescription = rfsh.MemberDetails.ValidationDescription;
            rfsh.MduSessionObject.Successful = rfsh.MemberDetails.Successful;


            return rfsh;
        }

        #endregion

        List<Guid> _validSessions;
        Dictionary<string, BaseResult> _basicResults;
        Dictionary<Guid, RefreshAccountResult> _refreshResults;
        List<Guid> _roles;
        List<Guid> _regions;



        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("ExtLogin")]
        public IHttpActionResult ExtLogin([FromUri] LoginRequest model)
        {
            string key = $"{model.UserName}-{model.Password}".ToLower();

            if(_basicResults.ContainsKey(key))
            {
                return Json(_basicResults[key]);
            }
            else
            {
                var result = new LoginResult()
                {
                    SessionGuid = Guid.Empty,
                    ValidationCode = 1.ToString(),
                    ValidationDescription = "Not a valid user",
                    Successful = false
                };

                return Json(result);
            }            
        }

        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("RegisterNonMember")]
        public IHttpActionResult RegisterNonMember([FromBody] RegisterRequest model)
        {
            string key = $"{model.Username}-{model.Password}".ToLower();

            if (_basicResults.ContainsKey(key))
            {
                return Json(_basicResults[key]);
            }
            else
            {
                var result = new RegistrationResult()
                {
                    SessionGuid = Guid.Empty,
                    ValidationCode = 1.ToString(),
                    ValidationDescription = "User could not be registered for some arbitrary reason.",
                    Successful = false
                };

                return Json(result);
            }
        }

        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("RefreshAccountInfo")]
        public IHttpActionResult RefreshAccountInfo([FromBody] RefreshAccountRequest model)
        {
            if (_refreshResults.ContainsKey(model.SessionGuid))
            {
                return Json(_refreshResults[model.SessionGuid]);
            }
            else
            {
                return Json(new RefreshAccountResult());
            }
        }

        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("Audit")]
        public IHttpActionResult Audit(AuditRequest audit)
        {
            if (!ModelState.IsValid) // if Audit is invalid
            {
                return BadRequest();
            }
            var sessionObject = new AuditResponse()
            {
                AuditRequestResult = true
            };

            string fullSavePath = HttpContext.Current.Server.MapPath($"~/App_Data/Log_{DateTime.Now.ToString("yyyyMMdd")}.txt");

            File.AppendAllText(fullSavePath, $"{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")} - {JsonConvert.SerializeObject(audit)}\n");

            if (sessionObject == null)
            {
                return NotFound();
            }
            return Ok(sessionObject);
        }

        public Guid? GetRole(string segmentId)
        {
            switch (segmentId.ToUpper())
            {
                case "GP":
                case "BUSP":
                case "NURS":
                case "OMP":
                case "SUST":
                    return new Guid("{A327CB59-318D-4A11-8707-F3466FEF7454}"); 

                case "CONS":
                case "COSP":
                    return new Guid("{9BB8E0B0-EB3F-45DB-B1EC-291FD39E8B51}"); ;

                case "FTDC":
                case "TGDC":

                    return new Guid("{A20C7706-FEF4-41BA-9832-B319C5194734}");

                case "HDOC":
                    return new Guid("{BD6BA6DE-2ED2-4FA9-94A1-A25790D53334}");

                case "MSTU":
                    return new Guid("{32BF5E2F-AF85-415E-995F-C3EA6B7A0E68}");

                case "DENT":
                case "DCP":
                case "ODP":
                    return new Guid("{166BEE1C-D11E-4B59-834D-73302D5FC8A3}");

                case "DSTU":
                case "DTG":
                    return new Guid("{3A05FBA1-D0C9-42CE-9B1E-E0020D4602F4}");

                default:
                    return null;
            }
        }
    }
}