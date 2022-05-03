﻿using Decrypt_Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decrypt_Library.EntityFrameworkCode
{
    internal class EntityframeworkUsers
    {
        public static List<Models.User> ShowAllUsers()
        {
            using (var db = new Decrypt_LibraryContext())
            {
                var users = db.Users.ToList();
                return users;
            }
        }

        public static void CreateUser(User newCustomer)
        {
            using (var db = new Decrypt_LibraryContext())
            {
                var userList = db.Users;

                userList.Add(newCustomer);
                db.SaveChanges();
            }
        }
    }
}
