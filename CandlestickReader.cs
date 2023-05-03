using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.VisualStyles;

namespace StockProgram
{
    /// <summary>
    /// this class reads the stock data from the csv file
    /// and stores it in a list of candlesticks
    /// it is used for the chart
    /// </summary>
    internal class CandlestickReader
    {
        // data folder is Stock Data or StockData
        const string dataFolder = "Stock Data";

        public List<Candlestick> listOfCandlesticks;
        public CandlestickReader()
        {
            listOfCandlesticks = new List<Candlestick>();
        }
        /// <summary>
        /// this method reads the csv file and returns a list of candlesticks
        /// </summary>
        /// <param name="csvFileName"></param> the name of the csv file , e.g. AAPL-Day.csv
        /// <param name="startDate"></param> the start date , the format is yyyy-mm-dd
        /// <param name="endDate"></param> the end date
        /// <returns></returns>
        public List<Candlestick> readListOfCandlesticks(string csvFileName, DateTime startDate, DateTime endDate)
        {

            string[] lines;
            // get all the lines as an String array
           //try { lines = System.IO.File.ReadAllLines(csvFileName); }
           lines = System.IO.File.ReadAllLines(csvFileName);
            //catch (Exception e)
            //{
            //    // tell the user they have entered a ticker we dont have data for
            //    // or they have entered a period we dont have data for
            //    MessageBox.Show("Ticker not found or period not supported");
            //    // return an empty list
            //    return new List<Candlestick>();
            //}
            
            // skip the header. Could make sure it is valid
            string header = lines[0];

            // header looks like this : "Date","Open","High","Low","Close","Volume"
            // use the first line to make sure that file is a proper candlestick file
            if (header.Equals("\"Date\",\"Open\",\"High\",\"Low\",\"Close\",\"Volume\""))
            {
                char[] seperators = new char[] { '-', ',', '"' };
                // create the array of candlesticks
                listOfCandlesticks = new List<Candlestick>(lines.Length - 1);
                for (int i = 1; i < lines.Length; i++)
                {
                    // get the i nth line
                    string line = lines[i].Trim();
                    // split the line into an array of strings
                    string[] fields = line.Split(seperators, StringSplitOptions.RemoveEmptyEntries);
                   
                    
                   
                    int year = int.Parse(fields[0]);
                    int month = int.Parse(fields[1]);
                    int day = int.Parse(fields[2]);
                    // and we build a date object from the first 3 fields
                    DateTime date = new(year, month, day);
                    // now we just get the other parts of the line, open, high , low , close and volume
                    double open = double.Parse(fields[3]);
                    double high = double.Parse(fields[4]);
                    double low = double.Parse(fields[5]);
                    double close = double.Parse(fields[6]);
                    long volume = long.Parse(fields[7]);

                    // round the numbers to 2 decimal places
                    open = Math.Round(open, 2);
                    high = Math.Round(high, 2);
                    low = Math.Round(low, 2);
                    close = Math.Round(close, 2);
                    // now we create a candlestick object and add it to the array
                    Candlestick candlestick = new(date, open, high, low, close, volume);
                    listOfCandlesticks.Add(candlestick);
                }
            }
            // else header looks like this from yahoo finance with no quotes around them
            // Date,Open,High,Low,Close,Adj Close,Volume
            // 
            else if (header.Equals("Date,Open,High,Low,Close,Adj Close,Volume"))
            {
                char[] seperators = new char[] { ','};
                // create the array of candlesticks
                listOfCandlesticks = new List<Candlestick>(lines.Length - 1);
                for (int i = 1; i < lines.Length; i++)
                {
                    // get the i nth line
                    string line = lines[i].Trim();
                    // split the line into an array of strings
                    string[] fields = line.Split(seperators, StringSplitOptions.RemoveEmptyEntries);
                    // and we build a date object from the first 3 fields
                    // date has no quotes around it
                    // ex : 2022-04-07
                    string[] dateFields = fields[0].Split('-');
                    int year = int.Parse(dateFields[0]);
                    int month = int.Parse(dateFields[1]);
                    int day = int.Parse(dateFields[2]);
                    DateTime date = new(year, month, day);
                    // now we just get the other parts of the line, open, high , low , close and volume
                    double open = double.Parse(fields[1]);
                    double high = double.Parse(fields[2]);
                    double low = double.Parse(fields[3]);
                    double close = double.Parse(fields[4]);
                    long volume = long.Parse(fields[6]);

                    // round the numbers to 2 decimal places
                    open = Math.Round(open, 2);
                    high = Math.Round(high, 2);
                    low = Math.Round(low, 2);
                    close = Math.Round(close, 2);
                    // now we create a candlestick object and add it to the array
                    Candlestick candlestick = new(date, open, high, low, close, volume);
                    listOfCandlesticks.Add(candlestick);
                }
            }
            else
            {
               //prompt the user that the file is not a valid candlestick file
                MessageBox.Show("File is not a valid candlestick file");
                return new List<Candlestick>();
            }
            
            return listOfCandlesticks;
        }

        /// <summary>
        /// this method reads the csv file and returns a list of candlesticks
        /// </summary>
        /// <param name="ticker"></param> the stock symbol
        /// <param name="period"></param> the period of time
        /// <param name="startDate"></param> the start date
        /// <param name="endDate"></param>  the end date
        /// <returns></returns>
        public List<Candlestick> readStock(string ticker, string period, DateTime startDate, DateTime endDate)
        {
            // create filename for ticker by concatenating ticker and period

            string filename = dataFolder + "/" + ticker + "-" + period + ".csv";
            return readListOfCandlesticks(filename, startDate, endDate);
        }
        /// <summary>
        /// this method returns the lowest low in the list of candlesticks based on the period
        /// </summary>
        /// <returns>the lowest low</returns>
        public double getLowestLow(List<Candlestick> candleSticks)
        {
            // set to first lowest low value in the candlestick
            // if candlesticks is empty return 0
            if (candleSticks.Count == 0)
            {
                return 0;
            }
            double lowestLow = candleSticks[0].Low;
            foreach (Candlestick candlestick in candleSticks)
            {
                if (candlestick.Low < lowestLow)
                {
                    lowestLow = candlestick.Low;
                }
            }
            return lowestLow;
         
        }
        /// <summary>
        /// this method returns the highest high in the list of candlesticks based on the period
        /// </summary>
        /// <returns>the highest high</returns>
        public double getHighestHigh(List<Candlestick> candleSticks)
        {
            // if candlesticks is empty return 0
            if (candleSticks.Count == 0)
            {
                return 0;
            }
            // set to first high value in the candlestick
            double highestHigh = candleSticks[0].High;
            foreach (Candlestick candlestick in candleSticks)
            {
                if (candlestick.High > highestHigh)
                {
                    highestHigh = candlestick.High;
                }
            }
            return highestHigh;
          
        }
        /// <summary>
        ///this method reads the csv file and returns a list of candlesticks
        /// </summary>
        /// <param name="filename"></param> the name of the csv file , e.g. AAPL-Day.csv
        /// <param name="startDate"></param> the start date , the format is yyyy-mm-dd
        /// <param name="endDate"></param> the end date
        /// <returns></returns> a list of candlesticks
        public List <Candlestick> readStockFile(string filename, DateTime startDate, DateTime endDate)
        {
            return readListOfCandlesticks(filename, startDate, endDate);
        }

    }

}
