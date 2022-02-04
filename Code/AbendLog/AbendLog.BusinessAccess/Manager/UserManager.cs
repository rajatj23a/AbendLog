using AbendLog.BusinessAccess.Model;
using AbendLog.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbendLog.BusinessAccess.Manager
{
    public class UserManager : BaseManager
    {
        ASPAbendLogDataEntities DBEntities = new ASPAbendLogDataEntities();


        public UserManager()
        {

        }

        public Model.User Vaildate(string userName, string password)
        {
            Model.User user = new Model.User();

            foreach (p_LoginCredentials_Result loginCredentials_Result in DBEntities.p_LoginCredentials(userName, password))
            {

                user.ID = loginCredentials_Result.ID;
                user.LANID = loginCredentials_Result.LANID;
                user.Name = loginCredentials_Result.Name;
                user.EmailID = loginCredentials_Result.EmailID;
                user.UserType = loginCredentials_Result.UserType;
            }

            return user;
        }

        public Model.User VaildateUser(string lanId, string emailId)
        {
            Model.User user = new Model.User();

            foreach (p_GetUserData_Result getUserData_Result in DBEntities.p_GetUserData(lanId, emailId))
            {
                user.ID = getUserData_Result.ID;
            }

            return user;
        }

        public List<Model.User> Getusers()
        {
            List<Model.User> userLst = new List<Model.User>();
            var users = DBEntities.Users.ToList();
            foreach (var getUserData_Result in users)
            {
                Model.User user = new Model.User();
                user.ID = getUserData_Result.ID;
                user.Name = getUserData_Result.Name;
                user.LANID = getUserData_Result.LANID;
                user.Active = getUserData_Result.Active;
                user.UserType = getUserData_Result.UserType;
                userLst.Add(user);
            }

            return userLst;
        }

        public void AddUser(string name, string emailID, string lANID, string password)
        {
            DBEntities.p_InsertUserData(name, emailID, lANID, password, "Admin", System.DateTime.Now, null, null, true);
        }

        public void UpdateUser(string lanId, bool active, string userType, string modifiedBy)
        {
            try
            {
                var permanentFix = DBEntities.Users.Where(a => a.LANID == lanId).FirstOrDefault();
                permanentFix.Active = active;
                permanentFix.UserType = userType;
                permanentFix.ModifiedBy = modifiedBy;
                permanentFix.ModifiedDate = System.DateTime.Now;
                DBEntities.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
