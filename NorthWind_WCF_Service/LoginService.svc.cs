using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using DataModels;

namespace NorthWind_WCF_Service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class LoginService : ILoginService
    {
        public NORTHWINDEntities db = new NORTHWINDEntities();
        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }

        public User Login(string UserName, string Password)
        {

            var dbUser = db.Users.FirstOrDefault(x => x.UserName == UserName && x.Password == Password);
            if (dbUser != null)
                return new User() {
                    UserID=dbUser.UserID,
                    UserName = dbUser.UserName,
                    Password = dbUser.Password,
                    Role = dbUser.Role
                };

            return null;
        }
    }
}
