using Admin.App.Common.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Admin.App.Common.Models;
using Admin.App.DataAccessLayer.Provider;

namespace Admin.App.BusinessLayer.Services
{
   public class CompanyService: ICompanyDetails
    {
        public ICompanyDetails _ICompanyDetails;
        public CompanyService()
        {
            _ICompanyDetails = new CompanyProvider();
        }

        public bool DeleteCompany(int CompanyId)
        {
            throw new NotImplementedException();
        }

        public CompanyDetails GetCompanyByID(int compID)
        {
           return _ICompanyDetails.GetCompanyByID(compID);
        }

        public List<CompanyDetails> GetCompanyList()
        {
            return _ICompanyDetails.GetCompanyList();
        }

        public int SaveCompany(CompanyDetails CompDetails)
        {
            return _ICompanyDetails.SaveCompany(CompDetails);
        }

        public bool UpdateCompany(CompanyDetails CompDetails)
        {
            return _ICompanyDetails.UpdateCompany(CompDetails);
        }
    }
}
