using Admin.App.Common.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Admin.App.Common.Models;
using Admin.App.DataAccessLayer.Interface;
using System.Data.SqlClient;
using Dapper;
using System.Data;
using Admin.App.DataAccessLayer.DataModel;

namespace Admin.App.DataAccessLayer.Provider
{
   public class RoleProvider : IRoleProvider
    {
        IConnectionFactory _connectionFactory=new ConnectionFactory();
        IDbConnection dbConnection;
        public SqlConnection con;
        #region Stored Procedures
        public string getAllRoles = "usp_GetAllRoles";
        public string saveNewRoles = "usp_SaveRoles";

        #endregion
        public RoleProvider()
        {
            dbConnection = _connectionFactory.GetConnection();
            con = _connectionFactory.GetDBConnection();
        }
        public  List<RoleDetails> GetAllRoles()
        {
            con.Open();
            IList<RoleDetails> roleList = SqlMapper.Query<RoleDetails>(
                                  con, getAllRoles).ToList();
            con.Close();
            return roleList.ToList();
        }
        public bool SaveRole(RoleDetails roleDetails)
        {
            bool res = false;
            using (var context = new AdminAppEntities())
            {
                Role roleDet = new Role
                {
                    Name = roleDetails.Name,
                    Active = true,
                    RoleId = roleDetails.RoleId
                };

                context.Roles.Add(roleDet);
                context.SaveChanges();
                res = true;
            }
            return res;
        }
        public bool UpdateRole(RoleDetails roleDetails)
        {
            bool res = false;
            using (var context = new AdminAppEntities())
            {
                Role roleDet = new Role
                {
                    Name = roleDetails.Name,
                    Active = true,
                    RoleId = roleDetails.RoleId
                };
                Role updateRole = context.Roles.Where(x => x.RoleId == roleDetails.RoleId).FirstOrDefault();
                context.Entry(updateRole).CurrentValues.SetValues(roleDet);
                context.SaveChanges();
                res= true;
            }
            return res;
        }

        public async Task<IEnumerable<RoleDetails>> GetAllBlogByPageIndex(int pageIndex, int pageSize)
        {
            var query = "usp_GetAllBlogPostByPageIndex";
            var param = new DynamicParameters();
            param.Add("@PageIndex", pageIndex);
            param.Add("@PageSize", pageSize);
            var list = await SqlMapper.QueryAsync<RoleDetails>(_connectionFactory.GetConnection(), query,param, commandType: CommandType.StoredProcedure);
            return list;
        }

        

       
    }
}
