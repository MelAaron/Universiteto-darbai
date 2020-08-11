using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace U1_9
{
    class BranchuKonteineris
    {
        private Branch[] branches;
        public int Count { get; private set; }

        /// <summary>
        /// sukuria nauja branchu konteineri
        /// </summary>
        /// <param name="size">konteinerio dydis</param>
        public BranchuKonteineris(int size)
        {
            branches = new Branch[size];
            Count = 0;
        }
        /// <summary>
        /// prideda paduota branch i konteineri
        /// </summary>
        /// <param name="branch">paduota informacija apie
        /// ziurova</param>
        public void PridetiBrancha(Branch branch)
        {
            branches[Count++] = branch;
        }
        /// <summary>
        /// prideda branch i nurodyta vieta konteineryje
        /// </summary>
        /// <param name="branch"></param>
        /// <param name="index"></param>
        public void PridetiBrancha(Branch branch, int index)
        {
            branches[index] = branch;
        }
        /// <summary>
        /// gauna branch is konteinerio
        /// nurodant jo vieta
        /// </summary>
        /// <param name="index">vieta konteineryje</param>
        /// <returns>branch informacija</returns>
        public Branch GautiBrancha(int index)
        {
            return branches[index];
        }

    }
}
