using System;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

namespace GUAaS
{
    class PointClass<T>
    {
        public T X { get; }
        public T Y { get; }
        public PointClass(T x, T y)
        {
            X = x;
            Y = y;
        }
        public override string ToString()
        {
            return $"{X}, {Y}";
        }
    }

    struct PointStruct<T>
    {
        public T X { get; set; }
        public T Y { get; set; }
        public override string ToString()
        {
            return $"{X}, {Y}";
        }
    }

    public class Program
    {

        static void Main(string[] args)
        {
            BenchmarkRunner.Run(typeof(Program).Assembly);
        }

        public class BenchClass
        {
            static int arraySize = 1000;
            Random rnd = new Random();
            static double tmpX, tmpY;
            PointClass<double>[] classDoubleArray = new PointClass<double>[arraySize];
            PointClass<float>[] classFloatArray = new PointClass<float>[arraySize];
            PointStruct<float>[] structFloatArray = new PointStruct<float>[arraySize];
            PointStruct<double>[] structDoubleArray = new PointStruct<double>[arraySize];

            public BenchClass()
            {// заполнение массива
                for (int i = 0; i < arraySize; i++)
                {
                    tmpX = rnd.NextDouble() * 100;
                    tmpY = rnd.NextDouble() * 100;
                    structDoubleArray[i].X = tmpX;
                    structDoubleArray[i].Y = tmpY;
                    structFloatArray[i].X = (float)tmpX;
                    structFloatArray[i].Y = (float)tmpY;
                    classFloatArray[i] = new PointClass<float>((float)tmpX, (float)tmpY);
                    classDoubleArray[i] = new PointClass<double>(tmpX, tmpY);
                }
            }

            [Benchmark]
            public void DistanceCalculateMeasurePointClassDouble()
            {
                for (int i = 0; i < arraySize; i += 2)
                {
                    DistanceCalculateDouble(classDoubleArray[i], classDoubleArray[i + 1]);
                }
            }
            static double DistanceCalculateDouble(PointClass<double> pointOne, PointClass<double> pointTwo)
            {
                return Math.Sqrt(((pointOne.X - pointTwo.X) * (pointOne.X - pointTwo.X)) + ((pointOne.Y - pointTwo.Y) * (pointOne.Y - pointTwo.Y)));
            }

            [Benchmark]
            public void DistanceCalculateMeasurePointClassFloat()
            {
                for (int i = 0; i < arraySize; i += 2)
                {
                    DistanceCalculate(classFloatArray[i], classFloatArray[i + 1]);
                }
            }
            static float DistanceCalculate(PointClass<float> pointOne, PointClass<float> pointTwo)
            {
                return MathF.Sqrt(((pointOne.X - pointTwo.X) * (pointOne.X - pointTwo.X)) + ((pointOne.Y - pointTwo.Y) * (pointOne.Y - pointTwo.Y)));
            }
        
            [Benchmark]
            public void DistanceCalculateMeasurePointStructFloat()
            {
                for (int i = 0; i < arraySize; i += 2)
                {
                    DistanceCalculate(structFloatArray[i], structFloatArray[i + 1]);
                }
            }
            static float DistanceCalculate(PointStruct<float> pointOne, PointStruct<float> pointTwo)
            {
                return MathF.Sqrt(((pointOne.X - pointTwo.X) * (pointOne.X - pointTwo.X)) + ((pointOne.Y - pointTwo.Y) * (pointOne.Y - pointTwo.Y)));
            }
        
            [Benchmark]
            public void DistanceCalculateMeasurePointStructDouble()
            {
                for (int i = 0; i < arraySize; i += 2)
                {
                    DistanceCalculate(structDoubleArray[i], structDoubleArray[i + 1]);
                }
            }
            static double DistanceCalculate(PointStruct<double> pointOne, PointStruct<double> pointTwo)
            {
                return Math.Sqrt(((pointOne.X - pointTwo.X) * (pointOne.X - pointTwo.X)) + ((pointOne.Y - pointTwo.Y) * (pointOne.Y - pointTwo.Y)));
            }
        
            [Benchmark]
            public void DistanceCalculateMeasurePointClassQuick()
            {
                for (int i = 0; i < arraySize; i += 2)
                {
                    DistanceCalculateQuick(structFloatArray[i], structFloatArray[i + 1]);
                }
            }
            static float DistanceCalculateQuick(PointStruct<float> pointOne, PointStruct<float> pointTwo)
            {
                return ((pointOne.X - pointTwo.X) * (pointOne.X - pointTwo.X)) + ((pointOne.Y - pointTwo.Y) * (pointOne.Y - pointTwo.Y));
            }

        }
    }
}
