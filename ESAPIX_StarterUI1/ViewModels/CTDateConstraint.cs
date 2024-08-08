using ESAPIX.Constraints;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VMS.TPS.Common.Model.API;

namespace ESAPIX_WPF_Example.ViewModels
{
    public class CTDateConstraint : IConstraint
    {
        public string Name => "CT Date < 60 days old";

        public string FullName => "CT Date < 60 days old";

        public ConstraintResult CanConstrain(PlanningItem pi)
        {
            var hasCT = pi.StructureSet?.Image != null;
            if (hasCT) { return new ConstraintResult(this, ResultType.PASSED, string.Empty); }
            else { return new ConstraintResult(this, ResultType.NOT_APPLICABLE, string.Empty); }
        }

        /// <summary>
        /// Check if CT date is older than 60 days
        /// </summary>
        /// <param name="pi"></param>
        /// <returns></returns>
        /// 

        public ConstraintResult Constrain(PlanningItem pi) => ConstrainDateOnly(pi.StructureSet.Image.CreationDateTime.Value);
        //{
        //    return ConstrainDateOnly(pi.StructureSet.Image.CreationDateTime.Value);
        //var ctDate = pi.StructureSet.Image.CreationDateTime;
        //var daysOld = (DateTime.Now - ctDate.Value).TotalDays;
        //var msg = $"CT is {daysOld} days old";
        //if (daysOld > 60)
        //{
        //    return new ConstraintResult(this, ResultType.ACTION_LEVEL_3, msg);
        //}
        //else
        //{
        //    return new ConstraintResult(this, ResultType.PASSED, msg);
        //}
        //}

        // for unit testing would need to create something like the following and would change the previous function to be simpler
        public ConstraintResult ConstrainDateOnly (DateTime ctDate)
        {
            //var ctDate = pi.StructureSet.Image.CreationDateTime;
            var daysOld = (DateTime.Now - ctDate).TotalDays;
            var msg = $"CT is {daysOld} days old";
            if (daysOld > 60)
            {
                return new ConstraintResult(this, ResultType.ACTION_LEVEL_3, msg);
            }
            else
            {
                return new ConstraintResult(this, ResultType.PASSED, msg);
            }
        }
        
        
    }
}
