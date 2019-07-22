using CHAI.DataService.Model;
using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CHAI.DataService.DataProvider
{
    internal class DBContext
    {
        #region City Data Access

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
