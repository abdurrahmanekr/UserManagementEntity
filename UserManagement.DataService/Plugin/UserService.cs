using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserManagement.DataService
{
    public class UserService : IUserService
    {

        public string PcSection()
        {
            testEntities model = new testEntities();
            var pc = model.section.Where(x => x.name.Equals("Bilgisayar")).FirstOrDefault().id;
            return JsonConvert.SerializeObject(model.users.Where(x => x.section_id.Equals(pc)));
        }

        public string GetMotherFather()
        {
            testEntities model = new testEntities();
            var q = model.users
                .Join(model.parent,
                    c => c.id,
                    cm => cm.user_id,
                (c, cm) => new {
                    Yeni = c, YeniParent = cm 
                }).Select(x => x.Yeni.name + x.YeniParent.name);


            return JsonConvert.SerializeObject(q);
        }

        public string AddUser(string name, string sectionId, string surname)
        {
            testEntities model = new testEntities();
            var data = new users
            {
                name = name,
                section_id = Convert.ToInt32(sectionId),
                sur_name = surname
            };
            model.users.Add(data);

            model.SaveChanges();
            return "Eklendi";
        }


        public string AddParent(string mother, string father, int userId)
        {
            testEntities model = new testEntities();
            model.parent.Add(new parent
            {
                mother = mother,
                father = father,
                user_id = userId
            });

            model.SaveChanges();
            return "Eklendi";
        }


        public string AddSection(string name)
        {
            testEntities model = new testEntities();
            model.section.Add(new section
            {
                name = name
            });

            model.SaveChanges();
            return "Eklendi";
        }
    }
}
