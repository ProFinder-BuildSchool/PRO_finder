using Dapper;
using PRO_finder.Models.ViewModels.APIModels.APIBase;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PRO_finder.APIControllers
{
    public class StudioController : ApiController
    {

        static string connString = ConfigurationManager.ConnectionStrings["ProFinderContext"].ConnectionString;
        public APIResult FavorInsertorDelete(int MemberID, int TalentID, DateTime time, int StaffID, bool AddorRemove)
        {
            int affectedRow = 0; //
            string result = "";

            using (SqlConnection conn = new SqlConnection(connString))
            {
                if (AddorRemove)
                {
                    string sql = "Insert into SaveStaff(MemberID, SavedTalentID, SavedDate, SaveStaffID)values( @MemberID, @TalentID, @time, @StaffID)";
                    affectedRow = conn.Execute(sql, new { MemberID, TalentID, time, StaffID });
                }
                else
                {
                    string sql = "DELETE FROM SaveStaff WHERE MemberID = @MemberID and SavedTalentID = @SavedTalentID and SaveStaffID=@SaveStaffID";
                    affectedRow = conn.Execute(sql, new { MemberID = MemberID, SavedTalentID = TalentID, SaveStaffID = StaffID });

                    //remove from DB
                }
            }
            try
            {
                return new APIResult (APIStatus.Success, string.Empty, result); //new EmptyResult();
            }
            catch (Exception ex)
            {
                return new APIResult (APIStatus.Fail, string.Empty, result); //new EmptyResult();
            }
        }

        // GET api/<controller>
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}