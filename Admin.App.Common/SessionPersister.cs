using Admin.App.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Admin.App.Common
{
    public static class SessionPersister
    {
        public static int userID = 0;
        public static string sessionValue;
        public static UserDetails userDet;
        public static List<MenuPermission> menuPer;
        public static int _userID
        {
            get
            {
                if (HttpContext.Current.Session["_UserID"] == null)
                {
                    return userID;
                }
                else
                {
                    sessionValue = HttpContext.Current.Session["_UserID"].ToString();
                    if (sessionValue != null && sessionValue != string.Empty)
                        userID = Convert.ToInt32(sessionValue);
                }
                return userID;
            }
            set
            {
                HttpContext.Current.Session["_UserID"] = value;
            }
        }
        public static UserDetails _UserInfo
        {
            get
            {
                if (HttpContext.Current.Session["_UserInfo"] == null)
                {
                    return userDet;
                }
                else
                {
                    UserDetails UDet =(UserDetails)HttpContext.Current.Session["_UserInfo"];
                    if (UDet != null)
                        userDet = UDet;
                }
                return userDet;
            }
            set
            {
                HttpContext.Current.Session["_UserInfo"] = value;
            }
        }
        public static List<MenuPermission> _PrivilegeInfo
        {
            get
            {
                if (HttpContext.Current.Session["_PrivilegeInfo"] == null)
                {
                    return menuPer;
                }
                else
                {
                    List<MenuPermission> mInfo = (List<MenuPermission>)HttpContext.Current.Session["_PrivilegeInfo"];
                    if (mInfo != null)
                        menuPer = mInfo;
                }
                return menuPer;
            }
            set
            {
                HttpContext.Current.Session["_PrivilegeInfo"] = value;
            }
        }
    }
}
