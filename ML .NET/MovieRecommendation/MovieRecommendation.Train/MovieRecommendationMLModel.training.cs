﻿﻿// This file was auto-generated by ML.NET Model Builder. 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.ML.Data;
using Microsoft.ML.Trainers;
using Microsoft.ML;

namespace MovieRecommendation_Train
{
    public partial class MovieRecommendationMLModel
    {
        public static ITransformer RetrainPipeline(MLContext context, IDataView trainData)
        {
            var pipeline = BuildPipeline(context);
            var model = pipeline.Fit(trainData);

            return model;
        }

        /// <summary>
        /// build the pipeline that is used from model builder. Use this function to retrain model.
        /// </summary>
        /// <param name="mlContext"></param>
        /// <returns></returns>
        public static IEstimator<ITransformer> BuildPipeline(MLContext mlContext)
        {
            // Data process configuration with pipeline data transformations
            var pipeline = mlContext.Transforms.Conversion.MapValueToKey(@"userId", @"userId")      
                                    .Append(mlContext.Transforms.Conversion.MapValueToKey(@"movieId", @"movieId"))      
                                    .Append(mlContext.Recommendation().Trainers.MatrixFactorization(approximationRank:64,numberOfIterations:20,learningRate:0.1F,labelColumnName:@"rating",matrixColumnIndexColumnName:@"userId",matrixRowIndexColumnName:@"movieId"));

            return pipeline;
        }
    }
}
