using Admin.App.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Admin.App.Common.Interface
{
  public  interface ICompanyDetails
    {
        List<CompanyDetails> GetCompanyList();
        int SaveCompany(CompanyDetails CompDetails);
        bool UpdateCompany(CompanyDetails CompDetails);
        bool DeleteCompany(int CompanyId);
        CompanyDetails GetCompanyByID(int compID);
    }
}
