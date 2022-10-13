﻿using System;
using System.Collections.Generic;

namespace Statistics
{
    public class StatsComputer
    {
        public double average;
        public double max = Double.NegativeInfinity;
        public double min = Double.PositiveInfinity;
        
        public Stats CalculateStatistics(List<float> numbers) {
            //Implement statistics here
            Stats calc = new Stats();
            foreach(var item in numbers)
            {
                calc.enter(item);
            }
            min = calc.getMin();
            max = calc.getMax();
            average = calc.getAverage();
            return calc;
        }
    }
    public class StatsAlerter
    {
        Stats calc = new Stats();
        IAlerter[] alerter;
        double Threshold;
        public StatsAlerter(float maxThreshold, IAlerter[] alerters)
        {
            this.Threshold = maxThresold;
            this.alerter = alerters;
        }
        public IAlerter[] checkAndAlert(List<double> numbers)
        {
            alerter = calc.getAlert(Threshold, alerter);
            return alerter;
        }
    }
    public class EmailAlert
    {
        public bool emailSent;
    }
    public class LEDAlert
    {
        public bool ledGlows;
    }
    public partial class IAlerter
    {
        public EmailAlert emailAlert {get; set;}
        public LEDAlert ledAlert {get; set;}
    }
    public class Stats
    {
        private int count; //Count of numbers entered
        private double sum;//Sum of numbers
        private double avg;//Average of numbers
        private double max = Double.NegativeInfinity;
        private double min = Double.PositiveInfinity;
        
        public void enter(double num)
        {
            count++;
            sum += num;
            if(num > max)
                max = num;
            if(num < min)
                min = num;
        }
        public int getCount()
        {
            return count;
        }
        public double getSum()
        {
            return sum;
        }
        public double Average()
        {
            //If no numbers entered, count == 0 ; value is Double.NaN
            avg = sum / count;
            return avg;
        }
        public double getMin()
        {
            //If no numbers entered, value = infinity
            return min;
        }
        public double getMax()
        {
            //If no numbers entered, value = -infinity
            return max;
        }
        public IAlerter[] getAlert(double threshold, IAlerter[] alert)
        {
            if(max > threshold)
            {
                alert[0].emailAlert.emailSent = true;
                alert[0].ledAlert.ledGlows = true;                
            }
            else
            {
                alert[0].emailAlert.emailSent = false;
                alert[0].ledAlert.ledGlows = false;
            }
            return alert;
        }
    }
        
}
