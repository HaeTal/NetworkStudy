using Prism.Commands;
using Prism.Mvvm;
using Prism0823.Models;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Windows;

namespace Prism0823.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private int maxCount;
        public int MaxCount
        {
            get { return maxCount; }
            set { SetProperty(ref maxCount, value); }
        }

        private ObservableCollection<PrimeNumberModel> primesCollection;
        public ObservableCollection<PrimeNumberModel> PrimesCollection
        {
            get { return primesCollection; }
            set { SetProperty(ref primesCollection, value); }
        }

        private string time;
        public string Time
        {
            get { return time; }
            set { SetProperty(ref time, value); }
        }

        private int count;


        public DelegateCommand GetPrimesCommand { get; set; }   


        public MainWindowViewModel()
        {
            GetPrimesCommand = new DelegateCommand(GetPrimes);
        }


        private void GetPrimes()
        {
            count = 0;
            PrimesCollection = new ObservableCollection<PrimeNumberModel>();

            Stopwatch sw = new Stopwatch();

            sw.Start();

            for(int i = 1; i <= MaxCount; i++)
            {
                if(IsPrimeNumber(i))
                {
                    PrimeNumberModel primeNum = new PrimeNumberModel { Index = count++, Num = i };

                    PrimesCollection.Add(primeNum);
                }
            }

            sw.Stop();

            Time = sw.ElapsedMilliseconds.ToString() + "ms";
        }
        

        private bool IsPrimeNumber(int number)
        {
            if (number == 1)
                return false;

            if (number == 2 || number == 3)
                return true;

            for(int i = 2; i < number - 1; i++)
            {
                if ((number % i) == 0)
                    return false;
            }

            return true;
        }

    }
}
