﻿using SimpleTalk.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleTalk.WebApi.Services
{
    public class UserService
    {
        private static List<User> users = new List<User>();
        private static int Count = 1;
        private static readonly string[] names = new string[] { "Kader"  };
        private static readonly string[] surnames = new string[] { "Özen"  };
        private static readonly string[] extensions = new string[] { "@gmail.com"};
        static UserService()
        {
            Random rnd = new Random();
            for (int i = 0; i < 1; i++)
            {
                string currName = names[rnd.Next(names.Length)];
                User user = new User
                {
                    Id = Count++,
                    Name = currName + " " + surnames[rnd.Next(surnames.Length)],
                    Email = currName.ToLower() + extensions[rnd.Next(extensions.Length)],
                    Document = (rnd.Next(0, 100000) * rnd.Next(0, 100000)).ToString().PadLeft(10, '0'),
                    Phone = "05425123645"
                };
                users.Add(user);
            }
        }
        public List<User> GetAll()
        {
            return users;
        }
        public User GetById(int id)
        {
            return users.Where(user => user.Id == id).FirstOrDefault();
        }
        public User Create(User user)
        {
            user.Id = Count++;
            users.Add(user);
            return user;
        }
        public void Update(int id, User user)
        {
            User found = users.Where(n => n.Id == id).FirstOrDefault();
            found.Name = user.Name;
            found.Email = user.Email;
            found.Document = user.Document;
            found.Phone = user.Phone;
        }
        public void Delete(int id)
        {
            users.RemoveAll(n => n.Id == id);
        }
    }
}
