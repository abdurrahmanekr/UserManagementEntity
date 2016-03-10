using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace UserManagement.DataService
{
    [ServiceContract]
    public interface IUserService
    {

        [OperationContract]
        string AddUser(string name, string sectionId, string surname);
        
        [OperationContract]
        string PcSection();
        
        [OperationContract]
        string GetMotherFather();

        [OperationContract]
        string AddParent(string mother, string father, int userId);

        [OperationContract]
        string AddSection(string name);
    }
}
