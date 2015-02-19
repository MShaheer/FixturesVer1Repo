using FixturesVer1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FixturesVer1.Services
{
    public class UsersService
    {
        private FixturesDb _db;
        public UsersService()
        {
            _db = new FixturesDb();
        }

        public User GetUserById(string userName)
        {
            var user = _db.Users.Find(userName);
            if (user != null)
            {
                return user;
            }
            else
                return null;
        }

        public MessagesViewModel GetMessagesByUserId(string userName)
        {
            //var messageList = _db
            throw new NotImplementedException();
        }


    }
}