using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLinq.Logic
{
    public static class ObjectExtensions
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="source"></param>
        /// <param name="argName"></param>
        public static void CheckArgument(this object source, string argName) //prüft, ob Object null ist.
        {
            if (source == null)
                throw new ArgumentNullException(argName);
        }
    }
}
