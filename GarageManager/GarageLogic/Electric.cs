using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    internal class Electric : EnergyType
    {
        public Electric(float i_CurrentAmountOfEnergy, float i_MaxAmountOfEnergy)
            : base(i_CurrentAmountOfEnergy, i_MaxAmountOfEnergy)
        {

        }

        public override string ToString()
        {
            return string.Format(@"Electric current amount is :{0} , and max amount is : {1} "
, m_CurrentAmountOfEnergy, r_MaxAmountOfEnergy); 
        }
   
    }
}
