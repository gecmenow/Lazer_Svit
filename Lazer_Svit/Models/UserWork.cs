using Lazer_Svit.Models.Database;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lazer_Svit.Models
{
    public class UserWork
    {
        DatabaseContext _db = new DatabaseContext();

        public List<DBUserWork> GetUsersWorks()
        {
            var data =
                (from entry in _db.UserWorkDB
                select entry).ToList();

            foreach (var item in data)
                if (!File.Exists(HttpContext.Current.Server.MapPath("~/Content/UsersWorks/" + item.File)))
                    item.File = "Файл не найден";

            return data;
        }

        public void AddWork(string name, string email, string phonne, string text, IEnumerable<HttpPostedFileBase> uploads)
        {
            string filename = "";
           
            foreach (var work in uploads)
                if (work != null)
                {
                    string filePath = HttpContext.Current.Server.MapPath("~/Content/UsersWorks/" + work.FileName);

                    int count = 1;

                    string fileNameOnly = Path.GetFileNameWithoutExtension(filePath);
                    string extension = Path.GetExtension(filePath);
                    string path = Path.GetDirectoryName(filePath);
                    string newFullPath = filePath;
                    string newFileName = "";

                    while (File.Exists(newFullPath))
                    {
                        newFileName = string.Format("{0}({1})", fileNameOnly, count++);
                        newFileName += extension;
                        newFullPath = Path.Combine(path, newFileName + extension);
                    }

                    work.SaveAs(newFullPath);
                    filename = newFileName;
                }

            _db.UserWorkDB.Add(new DBUserWork
            {
                UserName = name,
                UserEmail = email,
                UserPhone = phonne,
                Text = text,
                File = filename,
                FileTime = DateTime.Now.ToLongDateString()
            });

            _db.SaveChanges();
        }

        public void DeleteWork(int id)
        {
            var data = _db.UserWorkDB.Find(id);

            _db.UserWorkDB.Remove(data);

            _db.SaveChanges();
        }
    }
}