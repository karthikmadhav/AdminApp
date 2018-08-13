using Admin.App.Common.Interface;
using Admin.App.Common.Models;
using Admin.App.DataAccessLayer.Interface;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Admin.App.DataAccessLayer.Provider
{
   public class UserAuthenticationProvider : IUserAuthentication
    {
        IConnectionFactory _connectionFactory = new ConnectionFactory();
        IDbConnection dbConnection;
        public SqlConnection con;
        #region Stored Procedures
        public string valUser = "usp_ValidateUser";
        public string userAuthByName = "usp_GetUserAuthByName";
        #endregion
        public UserAuthenticationProvider()
        {
            dbConnection = _connectionFactory.GetConnection();
            con = _connectionFactory.GetDBConnection();
        }
        public LoginDetails GetUserAuthentication(LoginDetails userCred)
        {
            LoginDetails userAuth = new LoginDetails();

            try
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@UserName", userCred.UserName);
                param.Add("@Password", userCred.Password);
                return userAuth = dbConnection.Query<LoginDetails>(valUser, param, commandType: CommandType.StoredProcedure).SingleOrDefault();
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {

            }
        }
        public LoginDetails GetAuthenticationByName(int userID)
        {
            LoginDetails userAuth = new LoginDetails();
            try
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@UserID", userID);
                return userAuth = dbConnection.Query<LoginDetails>(userAuthByName, param, commandType: CommandType.StoredProcedure).SingleOrDefault();
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {

            }
        }
    }
}
