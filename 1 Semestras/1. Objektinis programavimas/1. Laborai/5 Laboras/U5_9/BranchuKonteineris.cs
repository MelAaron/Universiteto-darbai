using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace U5_9
{
    class BranchuKonteineris
    {
        private Branch[] branches;
        public int Count { get; private set; }

        public BranchuKonteineris(int size)
        {
            branches = new Branch[size];
            Count = 0;
        }
        public void PridetiBrancha(Branch branch)
        {
            branches[Count++] = branch;
        }
        public void PridetiBrancha(Branch branch, int index)
        {
            branches[index] = branch;
        }
        public Branch GautiBrancha(int index)
        {
            return branches[index];
        }
    }
}
