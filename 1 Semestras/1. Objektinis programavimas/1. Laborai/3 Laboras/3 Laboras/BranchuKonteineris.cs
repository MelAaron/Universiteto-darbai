using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3_Laboras
{
    class BranchuKonteineris
    {
        private Branch[] branches;
        public int Count { get; private set; }

        /// <summary>
        /// sukuriamas naujas issisakojimu konteineris
        /// </summary>
        /// <param name="size">konteinerio dydis</param>
        public BranchuKonteineris(int size)
        {
            branches = new Branch[size];
            Count = 0;
        }
        /// <summary>
        /// prideda parduotuve i konteineri
        /// </summary>
        /// <param name="branch">parduotuve</param>
        public void PridetiBrancha(Branch branch)
        {
            branches[Count++] = branch;
        }
        /// <summary>
        /// prideda parduotuve i konteineri i nurodyta vieta
        /// </summary>
        /// <param name="branch">parduotuve</param>
        /// <param name="index">vieta</param>
        public void PridetiBrancha(Branch branch, int index)
        {
            branches[index] = branch;
        }
        /// <summary>
        /// gauna parduotuves inforamcija
        /// </summary>
        /// <param name="index">parduotuves vieta</param>
        /// <returns>grazina parduotuves duomenis</returns>
        public Branch GautiBrancha(int index)
        {
            return branches[index];
        }
    }
}
