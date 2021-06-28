using System;
using System.Collections.Generic;
using System.IO;
using BTC_Rate.Models;
using System.Xml.Serialization;


namespace BTC_Rate
{
    //class, that contains methods, which will be called by controllers
    public class UserService
    {
        //reads DB file, which is in xml format (deserialization)
        public List<User> GetUsers()
        {
            List<User> users = new List<User>();
            try
            {
                FileStream fs = new FileStream("users.xml", FileMode.OpenOrCreate);
                XmlSerializer xml = new XmlSerializer(users.GetType());
                users = (List<User>)xml.Deserialize(fs);//explicit typecasting of deserialized data
                fs.Close();
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            return users;
        }
        //returns FALSE if system does not contain user with such e-mail
        public bool isContain(string email)
        {
            List<User> users = new List<User>(GetUsers());//coping of the deserialized list
            foreach (User u in users)
            {
                if (u.Email == email)//if system already contains user with such email
                {
                    return true;//TRUE is returned
                }
            }
            return false;
        }
        //serialization in file
        public void Add(User user)
        {
            List<User> users = new List<User>(GetUsers());
            users.Add(user);//add new user to the list
            FileStream fs = new FileStream("user.xml", FileMode.OpenOrCreate);//open stream
            fs.SetLength(0);//clear file
            XmlSerializer x = new XmlSerializer(users.GetType());
            x.Serialize(fs, users);//serialize in xml file
            fs.Close();//close file
        }
    }
}