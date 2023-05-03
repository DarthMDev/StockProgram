using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockProgram
{
 // make an abstract class for the recognizers
    public abstract class Recognizer
    {
        // this is the name of the pattern the recognizer finds
        public string PatternName { get; set; }

         public Recognizer(string patternName = "?", int patternSize = 0)
        {
            PatternName = patternName;
            PatternSize = patternSize;
        }

        // this is the size of the pattern, in candlesticks of the pattern the recognizer finds
        public int PatternSize { get; set; }

        // get the subset based on the recognize method 


        // this is the real workhorse. This is the method that tells us if the subset matches the pattern
        protected abstract bool patternMatchesSubset(List<Candlestick> subsetOfCandlesticks);


        // this is the generalized looping code which runs through the candlesticks and tests each subset
        // // pattern. If it does match, it adds the index of the last candlestick in the subset to the result

        /// <summary>
        /// this does the work and the derived recognizers just need to provide the patternMatcheSubset() method
        /// </summary>
        /// <param name="listOfCandlesticks"></param> the list of candlesticks to search
        /// <returns></returns>
        public List<int> Recognize(List<Candlestick> listOfCandlesticks)
        {
            // make a list for the result
            List<int> result = new(listOfCandlesticks.Count / 8);
            // go through the list starting at the proper index (patternSize - 1)
            int offset = PatternSize - 1;
            for (int index = offset; index < listOfCandlesticks.Count; index++)
            {
                // get the subset of candlesticks
                List<Candlestick> subset = listOfCandlesticks.GetRange(index - offset, PatternSize);
                // test the subset
                if (patternMatchesSubset(subset))
                {
                    // if it matches, add the index to the result
                    result.Add(index);
                }
            }
            // we are done, return the result
            // debug result using system debug library
            return result;
        }
    }

}
