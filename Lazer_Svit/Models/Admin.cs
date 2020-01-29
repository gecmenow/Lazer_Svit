using Lazer_Svit.Hashing;
using Lazer_Svit.Models.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;

namespace Lazer_Svit.Models
{
    public class Admin
    {
        readonly DatabaseContext _db = new DatabaseContext();

        string adminCookieName = "stuff";
        string adminCookeKey = "qwe";

        string sharedKey = "123";

        public static bool CheckLogedIn()
        {
            bool status = false;

            HttpCookie cookieReq = HttpContext.Current.Request.Cookies["stuff"];

            if (cookieReq != null)
            {
                Admin admin = new Admin();

                status = admin.IsAdmin();
            }

            return status;
        }

        public bool LogIn(string name, string password)
        {
            var admin =
                (from enrty in _db.AdminDB
                 select enrty).First();

            bool success = false;

            if (admin.Name == name && admin.Password == password)
            { 
                updateCokie(admin);

                success = true;
            }

            return success;
        }

        public bool IsAdmin()
        {
            bool status = false;

            HttpCookie cookieReq = HttpContext.Current.Request.Cookies[adminCookieName];

            if (cookieReq != null)
            {
                string data = cookieReq[adminCookeKey];

                string decryptedId = "";

                decryptedId = Hash.DecryptStringAES(data, sharedKey);

                int adminUniqueNumber = Convert.ToInt32(decryptedId);

                int uniqueNumber = _db.AdminDB.Where(v => v.uniqueNumber == adminUniqueNumber).Select(v => v.uniqueNumber).First();

                if (adminUniqueNumber == uniqueNumber)
                    status = true;
            }
                
            return status;
        }

        public bool ChangeLogin(string oldName, string newName)
        {
            bool status = IsAdmin();

            if (status == true)
            {
                var admin = _db.AdminDB.Where(v => v.Name == oldName).First();

                admin.Name = newName;

                Random r = new Random();

                admin.uniqueNumber = r.Next();

                _db.SaveChanges();

                updateCokie(admin);
            }
            else
                status = false;

            return status;
        }

        public bool ChangePassword(string oldPass, string newPass)
        {
            bool status = IsAdmin();

            if (status == true)
            {
                var admin = _db.AdminDB.Where(v => v.Password == oldPass).First();

                admin.Password = oldPass;

                Random r = new Random();

                admin.uniqueNumber = r.Next();

                _db.SaveChanges();

                updateCokie(admin);
            }
            else
                status = false;

            return status;
        }

        void updateCokie(DbAdmin admin)
        {
            string adminId = "";

            adminId = Hash.EncryptStringAES(admin.uniqueNumber.ToString(), sharedKey);

            HttpCookie cookie = new HttpCookie(adminCookieName);

            cookie[adminCookeKey] = adminId;

            // Добавить куки в ответ
            HttpContext.Current.Response.Cookies.Add(cookie);

            // Этот cookie-набор будет оставаться 
            // действительным в течение одного года
            cookie.Expires = DateTime.Now.AddDays(7);
        }
    }
}