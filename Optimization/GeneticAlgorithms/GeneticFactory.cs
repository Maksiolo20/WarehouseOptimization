﻿using System;
using Optimization.GeneticAlgorithms.Crossovers;
using Optimization.GeneticAlgorithms.Eliminations;
using Optimization.GeneticAlgorithms.Mutations;
using Optimization.GeneticAlgorithms.Selections;
using Optimization.Parameters;

namespace Optimization.GeneticAlgorithms
{
    internal static class GeneticFactory
    {
        public static Crossover CreateCrossover(OptimizationParameters optimizationParameters, double[][] distancesMatrix)
        {
            int startingPoint = optimizationParameters.StartingId;
            Crossover crossover = optimizationParameters.CrossoverMethod switch
            {
                "Aex" => new AexCrossover(distancesMatrix, startingPoint),
                "HGreX" => new HGreXCrossover(distancesMatrix, startingPoint),
                "MPHGreX" => new MPHGreXCrossover(distancesMatrix, startingPoint),
                "HRndX" => new HRndXCrossover(distancesMatrix, startingPoint),
                "HProX" => new HProXCrossover(distancesMatrix, startingPoint),
                "MPHRndX" => new MPHRndXCrossover(distancesMatrix, startingPoint),
                "MPHProX" => new MPHProXCrossover(distancesMatrix, startingPoint),
                "KPoint" => new KPointCrossover(distancesMatrix, startingPoint),
                _ => throw new ArgumentException("Wrong crossover name in parameters json file")
            };
            return crossover;
        }

        public static Selection CreateSelection(OptimizationParameters optimizationParameters, int[][] population)
        {
            Selection selection = optimizationParameters.SelectionMethod switch
            {
                "Random" => new RandomSelection(population),
                "Tournament" => new TournamentSelection(population),
                "Elitism" => new ElitismSelection(population),
                "RouletteWheel" => new RouletteWheelSelection(population),
                _ => throw new ArgumentException("Wrong selection name in parameters json file")
            };
            return selection;
        }

        public static Elimination CreateElimination(OptimizationParameters optimizationParameters, int[][] population)
        {
            Elimination elimination = optimizationParameters.EliminationMethod switch
            {
                "Elitism" => new ElitismElimination(population),
                "RouletteWheel" => new RouletteWheelElimination(population),
                _ => throw new ArgumentException("Wrong elimination name in parameters json file")
            };
            return elimination;
        }

        public static Mutation CreateMutation(OptimizationParameters optimizationParameters, int[][] population, double mutationProbability)
        {
            Mutation mutation = optimizationParameters.MutationMethod switch
            {
                "Inversion" => new InversionMutation(population, mutationProbability),
                _ => throw new AggregateException("Wrong mutation method in parameters json file")
            };
            return mutation;
        }
    }
}