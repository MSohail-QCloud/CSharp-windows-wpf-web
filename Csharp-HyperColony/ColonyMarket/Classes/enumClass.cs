using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using System.Threading.Tasks;

namespace VesterShoes.classes
{
    public class enumClass
    {
        public enum profileType
        {
            Customer,Vender,Employee,Comm_CareOf
        }
        public enum jobStates
        {
            Pending,Start,Stop,Resume,End,Complete,Delete,Cancel
        }
        public enum ProcessStates
        {
           CmCuttMan,SmSoleMan, AmApperMan, BmButtMan, PMPtawaMan, PRProiMan, FmFinishMan
        }
    }
}
