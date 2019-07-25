using Chai.Models.POCO;
using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chai.DataService.DataProvider
{
    internal class DBContext
    {
        #region City

        public static IEnumerable<CityModel> GetCities(int stateId)
        {
            DataSet ds = new DataSet();
            using (IDbConnection connection = OpenConnection())
            {
                IEnumerable<CityModel> result = connection.Query<CityModel>("usp_GetCityDetail_General", new { StateId = stateId },
                    commandType: CommandType.StoredProcedure).AsEnumerable();

                if(result != null && result.Count() > 0)
                    return result;
            }

            return null;
        }

        #endregion

        #region User Account

        public static int AddUser(AccountModel model)
        {
            DataSet ds = new DataSet();
            using (IDbConnection connection = OpenConnection())
            {
                var p = new DynamicParameters();
                p.Add("@FirstName", model.FirstName);
                p.Add("@MiddleName", model.MiddleName);
                p.Add("@LastName", model.LastName);
                p.Add("@MotherMaidenName", model.MotherMaidenName);
                p.Add("@Email", model.Email);
                p.Add("@Password", model.Password);
                p.Add("@Phone", model.Phone);
                p.Add("@Mobile", model.Mobile);
                p.Add("@GenderId", model.GenderId);
                p.Add("@DOB", model.DOB);
                p.Add("@Zip", model.Zip);
                p.Add("@CountryId", model.CountryId);
                p.Add("@StateId", model.StateId);
                p.Add("@CityId", model.CityId);

                var result = connection.Query<AccountModel>("usp_Create_UserAccount_General", p,
                    commandType: CommandType.StoredProcedure).First();

                if (result != null)
                    return result.Id;
            }

            return 0;
        }

        public static AccountModel LoginUser(AccountModel model)
        {
            DataSet ds = new DataSet();
            using (IDbConnection connection = OpenConnection())
            {
                var p = new DynamicParameters();
                p.Add("@Email", model.Email);
                p.Add("@Mobile", model.Mobile);
                p.Add("@Password", model.Password);

                var result = connection.Query<AccountModel>("usp_Login_User_General", p,
                    commandType: CommandType.StoredProcedure).FirstOrDefault();

                if (result != null)
                    return result;
            }

            return null;
        }

        #endregion

        #region Global function

        internal static IDbConnection OpenConnection()
        {
            string connectionSettings = ConfigurationManager.ConnectionStrings["Chai_Dev"].ConnectionString;
            IDbConnection connection = new SqlConnection(connectionSettings);

            connection.Open();

            return connection;
        }

        #endregion 
    }
}
