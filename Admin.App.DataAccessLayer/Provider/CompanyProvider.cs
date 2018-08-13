using Admin.App.Common.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Admin.App.Common.Models;
using Admin.App.DataAccessLayer.Interface;
using System.Data;
using System.Data.SqlClient;
using Dapper;

namespace Admin.App.DataAccessLayer.Provider
{
    public class CompanyProvider : ICompanyDetails
    {
        IConnectionFactory _connectionFactory = new ConnectionFactory();
        IDbConnection dbConnection;
        public SqlConnection con;
        #region Stored Procedures
        public string getAllCompany = "usp_GetAllCompany";
        public string saveNewCompany = "usp_SaveNewCompany";
        public string getCompanyByID = "usp_GetCompanyByID";
        public string UpdateCompanyDetails = "usp_UpdateCompanyDetails";
        #endregion
        public CompanyProvider()
        {
            dbConnection = _connectionFactory.GetConnection();
            con = _connectionFactory.GetDBConnection();
        }
        public bool DeleteCompany(int CompanyId)
        {
            throw new NotImplementedException();
        }

        public CompanyDetails GetCompanyByID(int CompanyID)
        {
            CompanyDetails compDetails = dbConnection.Query<CompanyDetails>("Select * From CompanyDetails WHERE CompanyID = @CompanyID", new { CompanyID }).SingleOrDefault();
            return compDetails;
        }

        public List<CompanyDetails> GetCompanyList()
        {
            con.Open();
            IList<CompanyDetails> compList = SqlMapper.Query<CompanyDetails>(
                                  con, getAllCompany).ToList();
            con.Close();
            return compList.ToList();
        }

        public int SaveCompany(CompanyDetails CompDetails)
        {
            var para = new DynamicParameters();
            para.Add("@CompanyName", CompDetails.CompanyName); // Normal Parameters  
            para.Add("@PrimaryMailID", CompDetails.PrimaryMailID);
            para.Add("@PrimaryPhoneNo", CompDetails.PrimaryPhoneNo);
            para.Add("@Fax", CompDetails.Fax);
            para.Add("@Website", CompDetails.Website);
            para.Add("@Address", CompDetails.Address);
            para.Add("@Address1", CompDetails.Address1);
            para.Add("@City", CompDetails.City);
            para.Add("@State", CompDetails.State);
            para.Add("@Country", CompDetails.Country);
            para.Add("@Pincode", CompDetails.Pincode);
            para.Add("@GSTNO", CompDetails.GSTNO);
            para.Add("@ImageExt", CompDetails.ImageExt);
            // Getting Out Parameter  
            para.Add("@Myout", dbType: DbType.Int32, direction: ParameterDirection.Output);
            // Getting Return value  
            para.Add("@Ret", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);

            con.Open();
            con.Execute(saveNewCompany, para, commandType: CommandType.StoredProcedure);
            int Valueout = para.Get<int>("@Myout"); //Getting Out Value  
            int Valuereturn = para.Get<int>("@Ret"); //Getting Out Return  
            con.Close();
            return Valueout;
        }

        public bool UpdateCompany(CompanyDetails CompDetails)
        {
            con.Open();
           int value= con.Execute(UpdateCompanyDetails, CompDetails, commandType: CommandType.StoredProcedure);
            con.Close();
            if (value > 0)
                return true;
            else
                return false;
        }
    }
}
