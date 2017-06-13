using System.Linq;
using System.Windows;
using Backend.Utils;

namespace Da.Services
{
    class SummaryService
    {
        public void CountPayoffs()
        {
            double sum, min, max;
            using (var context = new Context())
            {
                sum = context.Salaries.Sum(s => s.Amount);
                min = context.Salaries.Min(s => s.Amount);
                max = context.Salaries.Max(s => s.Amount);
            }
            MessageBox.Show("Sum: " + sum + "\nMin: " + min + "\nMax: " + max, "Payoffs summary", MessageBoxButton.OK);
        }
    }
}
