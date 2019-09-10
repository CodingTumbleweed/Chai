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
                p.Add("@CultureId", model.CultureId);
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
                p.Add("@Code", model.Code, DbType.Int32, ParameterDirection.Output);
                p.Add("@Message", model.Message, DbType.String, ParameterDirection.Output);

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
                p.Add("@CultureId", model.CultureId);
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
                p.Add("@Code", model.Code, DbType.Int32, ParameterDirection.Output);
                p.Add("@Message", model.Message, DbType.String, ParameterDirection.Output);

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

        public static bool DeleteUser(AccountModel model)
        {
            DataSet ds = new DataSet();
            using (IDbConnection connection = OpenConnection())
            {
                var p = new DynamicParameters();
                p.Add("@CultureId", model.CultureId);
                p.Add("@id", model.Id);
                p.Add("@Code", model.Code, DbType.Int32, ParameterDirection.Output);
                p.Add("@Message", model.Message, DbType.String, ParameterDirection.Output);

                var success = connection.Query<bool>("Usp_Delete_UserAccount_General", p,
                    commandType: CommandType.StoredProcedure).First();

                return success;
            }
        }

        public static PasswordRecoveryModel InitiatePasswordRecovery(string email)
        {
            DataSet ds = new DataSet();
            using (IDbConnection connection = OpenConnection())
            {
                var result = connection.Query<PasswordRecoveryModel>("usp_Create_PasswordRecovery_General", new { Email = email },
                    commandType: CommandType.StoredProcedure).FirstOrDefault();

                return result;
            }
        }

        public static bool ValidatePasswordRecovery(PasswordRecoveryModel model)
        {
            DataSet ds = new DataSet();
            using (IDbConnection connection = OpenConnection())
            {
                var p = new DynamicParameters();
                p.Add("@Password", model.Password);
                p.Add("@RecoveryCode", model.Code);

                var success = connection.Query<bool>("usp_Reset_Password_General", p,
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

        #region Agency / Agency Status

        public static int AddAgency(AgencyModel model)
        {
            DataSet ds = new DataSet();
            using (IDbConnection connection = OpenConnection())
            {
                var p = new DynamicParameters();
                p.Add("@CultureId", model.CultureId);
                p.Add("@AgencyCode", model.AgencyCode);
                p.Add("@Name", model.Name);
                p.Add("@AgencyStatusId", model.AgencyStatusId);
                p.Add("@AgencyBalance", model.AgencyBalance);
                p.Add("@BalancePaymentMethodId", model.BalancePaymentMethodId);
                p.Add("@Address", model.Address);
                p.Add("@Email", model.Email);
                p.Add("@Phone", model.Phone);
                p.Add("@Mobile", model.Mobile);
                p.Add("@CountryId", model.CountryId);
                p.Add("@StateId", model.StateId);
                p.Add("@CityId", model.CityId);
                p.Add("@Zip", model.Zip);
                p.Add("@BankAccountId", model.BankAccountId);
                p.Add("@Code", model.Code, DbType.Int32, ParameterDirection.Output);
                p.Add("@Message", model.Message, DbType.String, ParameterDirection.Output);

                var result = connection.Query<AccountModel>("usp_Create_Agency_General", p,
                    commandType: CommandType.StoredProcedure).First();

                if (result != null)
                    return result.Id;
            }

            return 0;
        }

        public static bool UpdateAgency(AgencyModel model)
        {
            DataSet ds = new DataSet();
            using (IDbConnection connection = OpenConnection())
            {
                var p = new DynamicParameters();
                p.Add("@CultureId", model.CultureId);
                p.Add("@id", model.Id);
                p.Add("@AgencyCode", model.AgencyCode);
                p.Add("@Name", model.Name);
                p.Add("@AgencyStatusId", model.AgencyStatusId);
                p.Add("@AgencyBalance", model.AgencyBalance);
                p.Add("@BalancePaymentMethodId", model.BalancePaymentMethodId);
                p.Add("@Address", model.Address);
                p.Add("@Email", model.Email);
                p.Add("@Phone", model.Phone);
                p.Add("@Mobile", model.Mobile);
                p.Add("@CountryId", model.CountryId);
                p.Add("@StateId", model.StateId);
                p.Add("@CityId", model.CityId);
                p.Add("@Zip", model.Zip);
                p.Add("@BankAccountId", model.BankAccountId);
                p.Add("@Code", model.Code, DbType.Int32, ParameterDirection.Output);
                p.Add("@Message", model.Message, DbType.String, ParameterDirection.Output);

                var success = connection.Query<bool>("usp_Update_Agency_General", p,
                    commandType: CommandType.StoredProcedure).First();

                return success;
            }
        }

        public static bool DeleteAgency(AgencyModel model)
        {
            DataSet ds = new DataSet();
            using (IDbConnection connection = OpenConnection())
            {
                var p = new DynamicParameters();
                p.Add("@CultureId", model.CultureId);
                p.Add("@id", model.Id);
                p.Add("@Code", model.Code, DbType.Int32, ParameterDirection.Output);
                p.Add("@Message", model.Message, DbType.String, ParameterDirection.Output);

                var success = connection.Query<bool>("usp_Delete_Agency_General", p,
                    commandType: CommandType.StoredProcedure).First();

                return success;
            }
        }

        public static IEnumerable<AgencyModel> GetAgency(AgencyModel model)
        {
            DataSet ds = new DataSet();
            using (IDbConnection connection = OpenConnection())
            {
                var p = new DynamicParameters();
                p.Add("@CultureId", model.CultureId);
                p.Add("@id", model.Id);
                p.Add("@Code", model.Code, DbType.Int32, ParameterDirection.Output);
                p.Add("@Message", model.Message, DbType.String, ParameterDirection.Output);

                var result = connection.Query<AgencyModel>("usp_GetAgency_General", p,
                    commandType: CommandType.StoredProcedure).ToList();

                if (result != null && result.Count() > 0)
                    return result;
            }
            return null;
        }

        public static int AddAgencyStatus(AgencyStatusModel model)
        {
            DataSet ds = new DataSet();
            using (IDbConnection connection = OpenConnection())
            {
                var p = new DynamicParameters();
                p.Add("@CultureId", model.CultureId);
                p.Add("@Description", model.Description);
                p.Add("@Code", model.Code, DbType.Int32, ParameterDirection.Output);
                p.Add("@Message", model.Message, DbType.String, ParameterDirection.Output);

                var result = connection.Query<AccountModel>("usp_Create_AgencyStatus_General", p,
                    commandType: CommandType.StoredProcedure).First();

                if (result != null)
                    return result.Id;
            }

            return 0;
        }

        public static bool UpdateAgencyStatus(AgencyStatusModel model)
        {
            DataSet ds = new DataSet();
            using (IDbConnection connection = OpenConnection())
            {
                var p = new DynamicParameters();
                p.Add("@CultureId", model.CultureId);
                p.Add("@id", model.Id);
                p.Add("@Description", model.Description);
                p.Add("@Code", model.Code, DbType.Int32, ParameterDirection.Output);
                p.Add("@Message", model.Message, DbType.String, ParameterDirection.Output);

                var success = connection.Query<bool>("usp_Update_AgencyStatus_General", p,
                    commandType: CommandType.StoredProcedure).First();

                return success;
            }
        }

        public static bool DeleteAgencyStatus(AgencyStatusModel model)
        {
            DataSet ds = new DataSet();
            using (IDbConnection connection = OpenConnection())
            {
                var p = new DynamicParameters();
                p.Add("@CultureId", model.CultureId);
                p.Add("@id", model.Id);
                p.Add("@Code", model.Code, DbType.Int32, ParameterDirection.Output);
                p.Add("@Message", model.Message, DbType.String, ParameterDirection.Output);

                var success = connection.Query<bool>("usp_Delete_AgencyStatus_General", p,
                    commandType: CommandType.StoredProcedure).First();

                return success;
            }
        }

        public static IEnumerable<AgencyStatusModel> GetAgencyStatus(AgencyStatusModel model)
        {
            DataSet ds = new DataSet();
            using (IDbConnection connection = OpenConnection())
            {
                var p = new DynamicParameters();
                p.Add("@CultureId", model.CultureId);
                p.Add("@id", model.Id);
                p.Add("@Code", model.Code, DbType.Int32, ParameterDirection.Output);
                p.Add("@Message", model.Message, DbType.String, ParameterDirection.Output);

                var result = connection.Query<AgencyStatusModel>("usp_GetAgencyStatus_General", p,
                    commandType: CommandType.StoredProcedure).ToList();

                if (result != null && result.Count() > 0)
                    return result;
            }
            return null;
        }

        #endregion


        #region Bank / Payment Methods

        public static int AddBank(BankModel model)
        {
            DataSet ds = new DataSet();
            using (IDbConnection connection = OpenConnection())
            {
                var p = new DynamicParameters();
                p.Add("@CultureId", model.CultureId);
                p.Add("@BankCode", model.BankCode);
                p.Add("@Name", model.Name);
                p.Add("@Address", model.Address);
                p.Add("@Phone", model.Phone);
                p.Add("@Fax", model.Fax);
                p.Add("@IBAN", model.IBAN);
                p.Add("@SwiftCode", model.SwiftCode);
                p.Add("@RoutingNumber", model.RoutingNumber);
                p.Add("@Code", model.Code, DbType.Int32, ParameterDirection.Output);
                p.Add("@Message", model.Message, DbType.String, ParameterDirection.Output);

                var result = connection.Query<AccountModel>("usp_Create_Bank_General", p,
                    commandType: CommandType.StoredProcedure).First();

                if (result != null)
                    return result.Id;
            }

            return 0;
        }

        public static bool UpdateBank(BankModel model)
        {
            DataSet ds = new DataSet();
            using (IDbConnection connection = OpenConnection())
            {
                var p = new DynamicParameters();
                p.Add("@CultureId", model.CultureId);
                p.Add("@id", model.Id);
                p.Add("@BankCode", model.BankCode);
                p.Add("@Name", model.Name);
                p.Add("@Address", model.Address);
                p.Add("@Phone", model.Phone);
                p.Add("@Fax", model.Fax);
                p.Add("@IBAN", model.IBAN);
                p.Add("@SwiftCode", model.SwiftCode);
                p.Add("@RoutingNumber", model.RoutingNumber);
                p.Add("@Code", model.Code, DbType.Int32, ParameterDirection.Output);
                p.Add("@Message", model.Message, DbType.String, ParameterDirection.Output);

                var success = connection.Query<bool>("usp_Update_Bank_General", p,
                    commandType: CommandType.StoredProcedure).First();

                return success;
            }
        }

        public static bool DeleteBank(BankModel model)
        {
            DataSet ds = new DataSet();
            using (IDbConnection connection = OpenConnection())
            {
                var p = new DynamicParameters();
                p.Add("@CultureId", model.CultureId);
                p.Add("@id", model.Id);
                p.Add("@Code", model.Code, DbType.Int32, ParameterDirection.Output);
                p.Add("@Message", model.Message, DbType.String, ParameterDirection.Output);

                var success = connection.Query<bool>("usp_Delete_Bank_General", p,
                    commandType: CommandType.StoredProcedure).First();

                return success;
            }
        }

        public static IEnumerable<BankModel> GetBank(BankModel model)
        {
            DataSet ds = new DataSet();
            using (IDbConnection connection = OpenConnection())
            {
                var p = new DynamicParameters();
                p.Add("@CultureId", model.CultureId);
                p.Add("@id", model.Id);
                p.Add("@Code", model.Code, DbType.Int32, ParameterDirection.Output);
                p.Add("@Message", model.Message, DbType.String, ParameterDirection.Output);

                var result = connection.Query<BankModel>("usp_GetBank_General", p,
                    commandType: CommandType.StoredProcedure).ToList();

                if (result != null && result.Count() > 0)
                    return result;
            }
            return null;
        }

        public static int AddPaymentMethod(PaymentMethodModel model)
        {
            DataSet ds = new DataSet();
            using (IDbConnection connection = OpenConnection())
            {
                var p = new DynamicParameters();
                p.Add("@CultureId", model.CultureId);
                p.Add("@Name", model.Name);
                p.Add("@Description", model.Description);
                p.Add("@Code", model.Code, DbType.Int32, ParameterDirection.Output);
                p.Add("@Message", model.Message, DbType.String, ParameterDirection.Output);

                var result = connection.Query<AccountModel>("usp_Create_PaymentMethod_General", p,
                    commandType: CommandType.StoredProcedure).First();

                if (result != null)
                    return result.Id;
            }

            return 0;
        }

        public static bool UpdatePaymentMethod(PaymentMethodModel model)
        {
            DataSet ds = new DataSet();
            using (IDbConnection connection = OpenConnection())
            {
                var p = new DynamicParameters();
                p.Add("@CultureId", model.CultureId);
                p.Add("@id", model.Id);
                p.Add("@Name", model.Name);
                p.Add("@Description", model.Description);
                p.Add("@Code", model.Code, DbType.Int32, ParameterDirection.Output);
                p.Add("@Message", model.Message, DbType.String, ParameterDirection.Output);

                var success = connection.Query<bool>("usp_Update_PaymentMethod_General", p,
                    commandType: CommandType.StoredProcedure).First();

                return success;
            }
        }

        public static bool DeletePaymentMethod(PaymentMethodModel model)
        {
            DataSet ds = new DataSet();
            using (IDbConnection connection = OpenConnection())
            {
                var p = new DynamicParameters();
                p.Add("@CultureId", model.CultureId);
                p.Add("@id", model.Id);
                p.Add("@Code", model.Code, DbType.Int32, ParameterDirection.Output);
                p.Add("@Message", model.Message, DbType.String, ParameterDirection.Output);

                var success = connection.Query<bool>("usp_Delete_PaymentMethod_General", p,
                    commandType: CommandType.StoredProcedure).First();

                return success;
            }
        }

        public static IEnumerable<PaymentMethodModel> GetPaymentMethod(PaymentMethodModel model)
        {
            DataSet ds = new DataSet();
            using (IDbConnection connection = OpenConnection())
            {
                var p = new DynamicParameters();
                p.Add("@CultureId", model.CultureId);
                p.Add("@id", model.Id);
                p.Add("@Code", model.Code, DbType.Int32, ParameterDirection.Output);
                p.Add("@Message", model.Message, DbType.String, ParameterDirection.Output);

                var result = connection.Query<PaymentMethodModel>("usp_Delete_PaymentMethod_General", p,
                    commandType: CommandType.StoredProcedure).ToList();

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
