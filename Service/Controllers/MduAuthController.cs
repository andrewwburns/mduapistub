using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using Service.Models.Response;
using Service.Models.Request;

namespace Service.Controllers
{



    [System.Web.Http.RoutePrefix("api")]
    public class MduAuthController : ApiController
    {

        public MduAuthController() : base()
        {
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
            _refreshResults.Add(_validSessions[0], MakeRefreshResult("Alice", "Aaronson", _validSessions[0]));
            _refreshResults.Add(_validSessions[1], MakeRefreshResult("Bob", "Brown", _validSessions[0]));
            _refreshResults.Add(_validSessions[2], MakeRefreshResult("Charles", "Charlesworthy", _validSessions[0]));
            _refreshResults.Add(_validSessions[3], MakeRefreshResult("Doris", "Day", _validSessions[0]));
            _refreshResults.Add(_validSessions[4], MakeRefreshResult("Eve", "Edwards", _validSessions[0]));
            _refreshResults.Add(_validSessions[5], MakeRefreshResult("Fred", "Flinstone", _validSessions[0]));

        }



        #region Creative_data_imagining

        private string PadNumber(int length)
        {
            Random r = new Random();
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
            Random r = new Random();
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

        private RefreshAccountResult MakeRefreshResult(string name, string surname, Guid sessionid)
        {
            Random r = new Random();
            RefreshAccountResult rfsh = new RefreshAccountResult();

            rfsh.MemberDetails.UserName = name;
            rfsh.MemberDetails.Password = null;
            rfsh.MemberDetails.SessionId = sessionid;
            rfsh.MemberDetails.PartyId = PadNumber(7);
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
            rfsh.MemberDetails.Segment = "GP";
            rfsh.MemberDetails.SubSegment = "NOPR";
            rfsh.MemberDetails.MemberStatus = "";
            rfsh.MemberDetails.MembershipStatus = rfsh.MemberDetails.MemberStatus;
            rfsh.MemberDetails.ElligibleForCQC = (r.Next(2) == 1);
            rfsh.MemberDetails.Groups = "";
            rfsh.MemberDetails.GroupBenefits = "";
            rfsh.MemberDetails.IsMember = (r.Next(2) == 1);
            rfsh.MemberDetails.ValidationCode = "0";
            rfsh.MemberDetails.ValidationDescription = "Quite what this is for escapes me.";
            rfsh.MemberDetails.Successful = true;

            rfsh.MduSessionObject.Valid = true;
            rfsh.MduSessionObject.SessionGuid = sessionid;
            rfsh.MduSessionObject.PartyId = rfsh.MemberDetails.PartyId;
            rfsh.MduSessionObject.Username = name;
            rfsh.MduSessionObject.ValidationCode = rfsh.MemberDetails.ValidationCode;
            rfsh.MduSessionObject.ValidationDescription = rfsh.MemberDetails.ValidationDescription;
            rfsh.MduSessionObject.Successful = rfsh.MemberDetails.Successful;

            return rfsh;
        }

        #endregion

        List<Guid> _validSessions;
        Dictionary<string, BaseResult> _basicResults;
        Dictionary<Guid, RefreshAccountResult> _refreshResults;



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
            if (_refreshResults.ContainsKey(model.AuthToken))
            {
                return Json(_refreshResults[model.AuthToken]);
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

            if (sessionObject == null)
            {
                return NotFound();
            }
            return Ok(sessionObject);
        }
    }
}