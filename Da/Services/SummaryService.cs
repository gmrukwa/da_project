using System.Linq;
using System.Windows;
using Backend.Utils;

namespace Da.Services
{
    class SummaryService
    {
        public void CountPayoffs()
        {
            double sum = 0;
            double min = 0;
            double max = 0;
            using (var context = new Context())
            {
                if (context.Salaries.Any())
                {
                    sum = context.Salaries.Sum(s => s.Amount);
                    min = context.Salaries.Min(s => s.Amount);
                    max = context.Salaries.Max(s => s.Amount);
                }
            }
            MessageBox.Show("Sum: " + sum + "\nMin: " + min + "\nMax: " + max, "Payoffs summary", MessageBoxButton.OK);
        }


    }
}
