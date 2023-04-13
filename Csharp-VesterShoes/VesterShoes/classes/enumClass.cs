using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            Pending,Start,Stop,Resume,End,Complete,Delete,Cancel,Deliverd
        }
        public enum ProcessStates
        {
           CuttMan,SoleMan, PtawaMan, ProiMan, ApperMan, ButtMan, FinishMan,JoraiMan
          // CmCuttMan,SmSoleMan, AmApperMan, BmButtMan, PMPtawaMan, PRProiMan, FmFinishMan
        }
        public enum ProcessStatesold
        {
            CM_CuttMan, SM_SoleMan, PM_PtawaMan, PR_ProiMan, Am_ApperMan, Bm_ButtMan, FM_FinishMan
            // CmCuttMan,SmSoleMan, AmApperMan, BmButtMan, PMPtawaMan, PRProiMan, FmFinishMan
        }
        public enum RecipeDetailCM
        {
            None
        }
        public enum RecipeDetailAM
        {
            سادہ,فوم
        }
       
        public enum RecipeDetailBM
        {
           None,اڈہ,سادہ
        }
        public enum RecipeDetailFM
        {
           سادہTPR, شیڈTPR,سادہSheet,شیڈSheet
        }
        public enum RecipeDetailProi
        {
            None
        }
        public enum RecipeDetailSM
        {
            None
        }
        public enum RecipeDetailPM
        {
            None
        }

        public enum RecipeDetailJM
        {
            None
        }
    }
}
