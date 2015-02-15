using FixturesVer1.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace FixturesVer1.Services
{
    public class AccountsService
    {
        private FixturesDb _db;
        public AccountsService()
        {
            _db = new FixturesDb();
        }

        public bool AuthenticateUser(LoginViewModel loginModel)
        {
          
            User user = _db.Users.Find(loginModel.usr_Username);
            if (user != null)
            {
                if(user.usr_Password == Utility.Cryptography.Encryption(loginModel.usr_Password))
                { return true; }
                else
                { return false; }
                
            }
            else return false;
      
        }

        public bool RegisterUser(User userModel)
        {
         
                var user = _db.Users.Find(userModel.usr_Username);
                if (user == null)
                {
                    _db.Users.Add(userModel);
                    _db.SaveChanges();

                    return true;
                }
                else return false;
          
        }

        public bool ManageUser(User userModel)
        {
          
                //var user = _db.Users.Find(userModel.usr_Username);
                //if (user != null)
                //{
                    //Issues related to golbally opened _dbContext .. Resolve later. 
                    //user = userModel;
            
                     _db.Entry(userModel).State = EntityState.Modified;
                    _db.SaveChanges();
                    return true;
                //}
                //else return false;
            }
      
    }
}