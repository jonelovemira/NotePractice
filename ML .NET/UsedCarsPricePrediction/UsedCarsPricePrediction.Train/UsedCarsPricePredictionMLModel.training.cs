﻿﻿// This file was auto-generated by ML.NET Model Builder. 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.ML.Data;
using Microsoft.ML.Trainers.FastTree;
using Microsoft.ML.Trainers;
using Microsoft.ML;

namespace UsedCarsPricePrediction_Train
{
    public partial class UsedCarsPricePredictionMLModel
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
            var pipeline = mlContext.Transforms.Categorical.OneHotEncoding(new []{new InputOutputColumnPair(@"Fuel_Type", @"Fuel_Type"),new InputOutputColumnPair(@"Transmission", @"Transmission"),new InputOutputColumnPair(@"Owner_Type", @"Owner_Type")})      
                                    .Append(mlContext.Transforms.ReplaceMissingValues(new []{new InputOutputColumnPair(@"Year", @"Year"),new InputOutputColumnPair(@"Kilometers_Driven", @"Kilometers_Driven"),new InputOutputColumnPair(@"Seats", @"Seats")}))      
                                    .Append(mlContext.Transforms.Text.FeaturizeText(@"Name", @"Name"))      
                                    .Append(mlContext.Transforms.Text.FeaturizeText(@"Location", @"Location"))      
                                    .Append(mlContext.Transforms.Text.FeaturizeText(@"Engine", @"Engine"))      
                                    .Append(mlContext.Transforms.Text.FeaturizeText(@"Power", @"Power"))      
                                    .Append(mlContext.Transforms.Concatenate(@"Features", new []{@"Fuel_Type",@"Transmission",@"Owner_Type",@"Year",@"Kilometers_Driven",@"Seats",@"Name",@"Location",@"Engine",@"Power"}))      
                                    .Append(mlContext.Transforms.NormalizeMinMax(@"Features", @"Features"))      
                                    .Append(mlContext.Regression.Trainers.FastTreeTweedie(new FastTreeTweedieTrainer.Options(){NumberOfLeaves=4,MinimumExampleCountPerLeaf=9,NumberOfTrees=79,MaximumBinCountPerFeature=184,LearningRate=5.52056994217405E-05F,FeatureFraction=0.666340630272705F,LabelColumnName=@"Price",FeatureColumnName=@"Features"}));

            return pipeline;
        }
    }
}
