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
        #region City / State Country

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

        public static IEnumerable<StateModel> GetStates(int countryId)
        {
            DataSet ds = new DataSet();
            using (IDbConnection connection = OpenConnection())
            {
                IEnumerable<StateModel> result = connection.Query<StateModel>("usp_GetStateDetail_General", new { CountryId = countryId },
                    commandType: CommandType.StoredProcedure).AsEnumerable();

                if (result != null && result.Count() > 0)
                    return result;
            }

            return null;
        }

        public static IEnumerable<CountryModel> GetCountries()
        {
            DataSet ds = new DataSet();
            using (IDbConnection connection = OpenConnection())
            {
                IEnumerable<CountryModel> result = connection.Query<CountryModel>("usp_GetCountryDetail_General",
                    commandType: CommandType.StoredProcedure).AsEnumerable();

                if (result != null && result.Count() > 0)
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

        public static bool UpdateUser(AccountModel model)
        {
            DataSet ds = new DataSet();
            using (IDbConnection connection = OpenConnection())
            {
                var p = new DynamicParameters();
                p.Add("@Id", model.Id);
                p.Add("@FirstName", model.FirstName);
                p.Add("@MiddleName", model.MiddleName);
                p.Add("@LastName", model.LastName);
                p.Add("@MotherMaidenName", model.MotherMaidenName);
                p.Add("@Phone", model.Phone);
                p.Add("@Mobile", model.Mobile);
                p.Add("@GenderId", model.GenderId);
                p.Add("@DOB", model.DOB);
                p.Add("@Zip", model.Zip);
                p.Add("@CountryId", model.CountryId);
                p.Add("@StateId", model.StateId);
                p.Add("@CityId", model.CityId);

                var success = connection.Query<bool>("usp_Update_UserAccount_General", p,
                    commandType: CommandType.StoredProcedure).First();

                return success;
            }
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

        public static bool DeleteUser(int userId)
        {
            DataSet ds = new DataSet();
            using (IDbConnection connection = OpenConnection())
            {
                var success = connection.Query<bool>("Usp_Delete_UserAccount_General", new { Id = userId },
                    commandType: CommandType.StoredProcedure).First();

                return success;
            }
        }

        #endregion


        #region Gender

        public static IEnumerable<GenderModel> GetGender()
        {
            DataSet ds = new DataSet();
            using (IDbConnection connection = OpenConnection())
            {
                IEnumerable<GenderModel> result = connection.Query<GenderModel>("usp_GetGenderDetail_General",
                    commandType: CommandType.StoredProcedure).AsEnumerable();

                if (result != null && result.Count() > 0)
                    return result;
            }

            return null;
        }

        #endregion


        #region App Config / Culture

        public static IEnumerable<AppConfigModel> GetAppConfigSettings()
        {
            DataSet ds = new DataSet();
            using (IDbConnection connection = OpenConnection())
            {
                IEnumerable<AppConfigModel> result = connection.Query<AppConfigModel>("usp_Get_AppConfigSettings_General",
                    commandType: CommandType.StoredProcedure).AsEnumerable();

                if (result != null && result.Count() > 0)
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
