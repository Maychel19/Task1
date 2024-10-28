namespace StudyCaseAGIT.Services
{
    public class ProductionBalancer
    {
        public static int[] BalanceProduction(int[] initialPlan)
        {
            int totalProduction = initialPlan.Sum();
            int averageProduction = totalProduction / 5;
            int remainder = totalProduction % 5;

            // Buat rencana produksi yang merata
            int[] balancedPlan = Enumerable.Repeat(averageProduction, 5).ToArray();

            // Distribusi sisa produksi ke hari-hari dengan nilai produksi awal yang lebih tinggi
            var sortedIndices = initialPlan
                .Select((value, index) => new { value, index })
                .OrderByDescending(x => x.value)
                .Select(x => x.index)
                .ToList();

            for (int i = 0; i < remainder; i++)
            {
                balancedPlan[sortedIndices[i]] += 1;
            }

            return balancedPlan;
        }
    }
}
