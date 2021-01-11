using System;

namespace Optimization.DistanceMode.GeneticAlgorithms.Selections {
    public abstract class Selection
    {
        protected readonly int[][] Population;
        protected readonly int PopulationSize;
        protected readonly Random Random;
        protected int Strictness = 1;

        public Selection(int[][] population)
        {
            Population = population;
            PopulationSize = population.Length;
            Random = new Random();
        }
        public bool IncreaseStrictness(int numberOfChildren)
        {
            if (numberOfChildren*Math.Pow(2, Strictness + 1) <= PopulationSize)
            {
                Strictness++;
                return true;
            }
            return false;
        }

        public abstract int[][] GenerateParents(int numberOfParents, double[] fitness);
    }
}