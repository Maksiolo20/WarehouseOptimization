﻿using System;

namespace Optimization.DistanceMode.GeneticAlgorithms.Mutations
{
    public class InversionMutation : Mutation
    {
        public InversionMutation(int[][] population, OptimizationParameters optimizationParameters) : base(population, optimizationParameters)
        {
        }

        public override void Mutate()
        {
            if (_probability > 0d)
            {
                for (int m = (int)(0.1 * _population.Length); m < _population.Length; m++)
                {
                    if (_random.Next(0, 1000) <= _probability)
                    {
                        var j = _random.Next(1, _population[m].Length);
                        var i = _random.Next(1, j);
                        Array.Reverse(_population[m], i, j - i);
                    }
                }
            }
        }
    }
}