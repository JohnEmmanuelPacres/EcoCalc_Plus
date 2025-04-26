using System;
using System.Collections.Generic;
using Microsoft.ML.OnnxRuntime;
using Microsoft.ML.OnnxRuntime.Tensors;

namespace EcoCalc_Plus.CarbonFootrpintCalculator
{
    public class CarbonFootprintPredictor : IDisposable
    {
        private readonly InferenceSession _session;
        private const string InputName = "float_input";  // From your ONNX model
        private const string OutputName = "variable";    // From your ONNX model

        public CarbonFootprintPredictor(string onnxModelPath)
        {
            try
            {
                // Initialize ONNX runtime session
                _session = new InferenceSession(onnxModelPath);

                // Verify model matches our expectations
                if (!_session.InputMetadata.ContainsKey(InputName)
                    || !_session.OutputMetadata.ContainsKey(OutputName))
                {
                    throw new InvalidOperationException(
                        $"Model expects input '{InputName}' and output '{OutputName}'. " +
                        $"Found inputs: {string.Join(", ", _session.InputMetadata.Keys)}, " +
                        $"outputs: {string.Join(", ", _session.OutputMetadata.Keys)}");
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to initialize ONNX model: {ex.Message}", ex);
            }
        }

        public float Predict(CarbonFootprintInput input)
        {
            try
            {
                // Create input tensor with shape [1, 4]
                var inputTensor = new DenseTensor<float>(new[]
                {
                    input.VehicularEmission,
                    input.HomeEnergyEmission,
                    input.AppliancesEmission,
                    input.WasteEmission
                }, new[] { 1, 4 });

                // Prepare inputs
                var inputs = new List<NamedOnnxValue>
                {
                    NamedOnnxValue.CreateFromTensor(InputName, inputTensor)
                };

                // Run inference
                using var results = _session.Run(inputs);
                var outputTensor = results.FirstOrDefault(r => r.Name == OutputName)?.AsTensor<float>();

                if (outputTensor == null)
                {
                    throw new Exception($"Output '{OutputName}' not found in model results");
                }

                return outputTensor[0]; // Return the prediction value
            }
            catch (Exception ex)
            {
                throw new Exception($"Prediction failed: {ex.Message}", ex);
            }
        }

        public List<float> PredictBatch(List<CarbonFootprintInput> inputs)
        {
            var results = new List<float>();
            foreach (var input in inputs)
            {
                results.Add(Predict(input));
            }
            return results;
        }

        public void Dispose()
        {
            _session?.Dispose();
        }
    }

    // Keep your existing input and prediction classes
    public class CarbonFootprintInput
    {
        public float VehicularEmission { get; set; }
        public float HomeEnergyEmission { get; set; }
        public float AppliancesEmission { get; set; }
        public float WasteEmission { get; set; }
    }

    public class CarbonFootprintPrediction
    {
        public float TotalEmission { get; set; }
    }
}