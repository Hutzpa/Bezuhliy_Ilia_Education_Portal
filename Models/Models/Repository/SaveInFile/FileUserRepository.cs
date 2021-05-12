using Models.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace Models.Repository.SaveInFile
{
    public class FileUserRepository : IRepository<User>
    {
        private string FILE_NAME = "Users.xml";
        public void Create(User entity)
        {
            XmlSerializer formatter = new XmlSerializer(typeof(User));
            // получаем поток, куда будем записывать сериализованный объект
            using (FileStream fs = new FileStream(FILE_NAME, FileMode.OpenOrCreate))
                formatter.Serialize(fs, entity);

        }

        public void Delete(User entity)
        {
            XmlSerializer formatter = new XmlSerializer(typeof(List<User>));
            List<User> users = GetObjectsList().ToList();
            if (users.Count == 0)
                throw new ArgumentOutOfRangeException("Sequence contains no elements");
            if (!users.Contains(entity))
                throw new NullReferenceException("No such user");
            users.Remove(entity);

            using (FileStream fs = new FileStream(FILE_NAME, FileMode.OpenOrCreate))
                formatter.Serialize(fs, users);
        }


        public User GetSpecificEntity(int id)
        {
            List<User> users = GetObjectsList().ToList();
            if (users.Count == 0)
                throw new ArgumentOutOfRangeException("Sequence contains no elements");
            var user = users.FirstOrDefault(o => o.Id == id);
            if (user == null)
                throw new NullReferenceException("No such user");
            return user;
        }

        public IEnumerable<User> GetObjectsList()
        {
            XmlSerializer formatter = new XmlSerializer(typeof(List<User>));
            List<User> users = new List<User>();
            // десериализация
            using (FileStream fs = new FileStream(FILE_NAME, FileMode.Open))
                users = (List<User>)formatter.Deserialize(fs);
            return users;
        }

      
        public void Update(User entity)
        {
            Delete(entity);
            Create(entity);
        }
       
    }
}
