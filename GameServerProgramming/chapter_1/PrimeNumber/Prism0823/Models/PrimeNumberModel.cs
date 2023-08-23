using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prism0823.Models
{
    public class PrimeNumberModel : BindableBase
    {
        private int index;
        public int Index
        {
            get { return index; }
            set { SetProperty(ref index, value); }
        }

        private int num;
        public int Num
        {
            get { return num; }
            set { SetProperty(ref num, value); }
        }

    }
}
