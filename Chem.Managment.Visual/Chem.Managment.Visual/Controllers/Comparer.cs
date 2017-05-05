using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Chem.Managment.Visual.Controllers
{
    public class Comparer:IComparer<string>
    {
        private string pattern;

        public Comparer(string pattern)
        {
            // TODO: Complete member initialization
            this.pattern = pattern;
        }

        public int Compare(string x, string y)
        {
            int comp= Math.Abs(x.GetHashCode() - pattern.GetHashCode()) - Math.Abs(y.GetHashCode() - pattern.GetHashCode());
            if (comp < 0)
                return -1;
            else if (comp > 0)
                return 1;
            else
                return 0;
        }
    }
}
