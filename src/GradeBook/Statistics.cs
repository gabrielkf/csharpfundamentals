using System;

namespace GradeBook
{
    public class Statistics
    {
        public double High;
        public double Low;
        public double Average
        {
            get
            {
                return Sum / Count;
            }
        }

        public char Letter
        {
            get
            {
                switch (Average)
                {
                    case var d when d >= 90.0:
                        return 'A';

                    case var d when d >= 80.0:
                        return 'B';

                    case var d when d >= 70.0:
                        return 'C';

                    case var d when d >= 60.0:
                        return 'D';

                    case var d when d >= 50.0:
                        return 'E';

                    default:
                        return 'F';
                }
            }
        }

        public double Sum;
        public int Count;

        public Statistics()
        {
            Low = double.MaxValue;
            High = double.MinValue;
            Sum = 0.0;
            Count = 0;
        }

        public void Add(double grade)
        {
            Low = Math.Min(grade, Low);
            High = Math.Max(grade, High);
            Sum += grade;
            Count++;
        }
    }
}