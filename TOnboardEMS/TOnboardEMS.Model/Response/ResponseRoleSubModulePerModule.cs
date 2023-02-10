using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TOnboardEMS.Model.DataTypes;

namespace TOnboardEMS.Model.Response
{
    public class ResponseRoleSubModulePerModule
    {
        public int parentID;
        public Restrictions parentRestrictions;
        List<ResponseSubModule> ListOfSubModules;

        public ResponseRoleSubModulePerModule(int ParentID, Restrictions ParentRestrictions,List<ResponseSubModule> listOfSubModules)
        {
            parentID = ParentID;
            parentRestrictions = ParentRestrictions;
            ListOfSubModules = listOfSubModules;
        }
    }
}
