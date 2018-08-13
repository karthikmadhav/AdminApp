using Admin.App.Common.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Admin.App.Common.Models;
using Admin.App.DataAccessLayer.DataModel;
using System.Activities.Statements;

namespace Admin.App.DataAccessLayer.Provider
{
    public class UserDetailsProvider : IUserDetails
    {
        public List<UserDetails> GetAllUser()
        {
            using (var context = new AdminAppEntities())
            {
                var userList = context.UserDetails.ToList();
                if (userList != null)
                {
                    return userList.Select(x => new UserDetails
                    {
                        CompanyID=x.CompanyID,
                        FirstName=x.FirstName,
                        LastName=x.LastName,
                        PrimaryEmailID=x.PrimaryEmailID,
                        PhoneNumber=x.PhoneNumber,
                        EmployeeCode=x.EmployeeCode,
                        Address=x.Address,
                        Address1=x.Address1,
                        City=x.City,
                        State=x.State,
                        Country=x.Country,
                        Pincode=x.Pincode,
                        RoleId=x.RoleId,
                        UserId=x.UserID
                    }).ToList();
                }
                return null;
            }
        }

        public UserDetails GetUserByID(int userID)
        {
            throw new NotImplementedException();
        }

        public int SaveUser(UserDetails userDetails)
        {
            using (var context = new AdminAppEntities())
            {
                UserDetail details = new UserDetail {
                    CompanyID = userDetails.CompanyID,
                    RoleId=userDetails.RoleId,
                    FirstName=userDetails.FirstName,
                    LastName=userDetails.LastName,
                    PrimaryEmailID=userDetails.PrimaryEmailID,
                    PhoneNumber=userDetails.PhoneNumber,
                    EmployeeCode=userDetails.EmployeeCode,
                    Address=userDetails.Address,
                    Address1=userDetails.Address1,
                    City=userDetails.City,
                    State=userDetails.State,
                    Country=userDetails.Country,
                    Pincode=userDetails.Pincode,
                    Active=true
                };
                context.UserDetails.Add(details);
                context.SaveChanges();
                if (details.UserID > 0)
                {
                    UserAuthentication userAuth = new UserAuthentication
                    {
                        UserID=details.UserID,
                        UserName= userDetails.UserName,
                        Password= userDetails.Password
                    };
                    context.UserAuthentications.Add(userAuth);
                    context.SaveChanges();
                }
                return details.UserID;
            }
        }
        public bool UpdateUser(UserDetails userDetails)
        {
            bool result = true;
            using (var context = new AdminAppEntities())
            {
                UserDetail details = context.UserDetails.Where(x => x.UserID == userDetails.UserId).FirstOrDefault();
                UserDetail updatedetails = new UserDetail
                {
                    CompanyID = userDetails.CompanyID,
                    RoleId = userDetails.RoleId,
                    FirstName = userDetails.FirstName,
                    LastName = userDetails.LastName,
                    PrimaryEmailID = userDetails.PrimaryEmailID,
                    PhoneNumber = userDetails.PhoneNumber,
                    EmployeeCode = userDetails.EmployeeCode,
                    Address = userDetails.Address,
                    Address1 = userDetails.Address1,
                    City = userDetails.City,
                    State = userDetails.State,
                    Country = userDetails.Country,
                    Pincode = userDetails.Pincode,
                    Active = true,
                    UserID=userDetails.UserId
                };
                context.Entry(details).CurrentValues.SetValues(updatedetails);
                context.SaveChanges();

                UserAuthentication userAuth = context.UserAuthentications.Where(x => x.UserID == userDetails.UserId).FirstOrDefault();
                    context.UserAuthentications.Remove(userAuth);
                    context.SaveChanges();

                    UserAuthentication userAuthNew = new UserAuthentication
                    {
                        UserID = userDetails.UserId,
                        UserName = userDetails.UserName,
                        Password = userDetails.Password
                    };
                    context.UserAuthentications.Add(userAuthNew);
                    context.SaveChanges();

                return result;
            }
        }
    }
}
