using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnCall
{
    internal static class EndRules
    {
       
        public static string GetRating(int satisfaction)
        {
            if (satisfaction >= 70)
            {
                return Texts.RatingExcellent;
            }
            if (satisfaction >= 40)
            {
                return Texts.RatingPassed;
            }
            return Texts.RatingProbation;
        }
    }
}