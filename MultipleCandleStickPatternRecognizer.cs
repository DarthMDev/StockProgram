namespace StockProgram
{
    // the file that recognizes the different multiple candlestick patterns  
    // like the bearish engulfing pattern, the bullish engulfing pattern, piercing pattern, dark cloud cover,  etc.
    internal class BearishEngulfingPatternRecognizer : Recognizer
    {
        public BearishEngulfingPatternRecognizer() : base("Bearish Engulfing Pattern", 2) { }
        /// <summary>
        /// The method that does the actual recognition
        /// </summary>
        /// <param name="candles">The candles to be recognized</param>
        /// <returns>True if the pattern is recognized, false otherwise</returns>
        protected override bool patternMatchesSubset(List<Candlestick> candles)
        {
            // the pattern is recognized if the first candle is a bullish candle
            // and the second candle is a bearish candle
            // and the second candle engulfs the first candle
            // we dont check for length as we know the base class won't send us a list that is too short
            return candles[0].isBullish && candles[1].isBearish && candles[1].Engulfs(candles[0]);
        }


    }
    internal class BullishEngulfingPatternRecognizer : Recognizer
    {
        public BullishEngulfingPatternRecognizer() : base("Bullish Engulfing Pattern", 2) { }
        /// <summary>
        /// The method that does the actual recognition
        /// </summary>
        /// <param name="candles">The candles to be recognized</param>
        /// <returns>True if the pattern is recognized, false otherwise</returns>
        protected override bool patternMatchesSubset(List<Candlestick> candles)
        {
            // the pattern is recognized if the first candle is a bearish candle
            // and the second candle is a bullish candle
            // and the second candle engulfs the first candle
            // we dont check for length as we know the base class won't send us a list that is too short
            return candles[0].isBearish && candles[1].isBullish && candles[1].Engulfs(candles[0]);
        }
    }
    internal class DarkCloudCoverRecognizer : Recognizer
    {
        public DarkCloudCoverRecognizer() : base("Dark Cloud Cover", 2) { }
        /// <summary>
        /// The method that does the actual recognition
        /// </summary>
        /// <param name="candles">The candles to be recognized</param>
        /// <returns>True if the pattern is recognized, false otherwise</returns>
        protected override bool patternMatchesSubset(List<Candlestick> candles)
        {
            // the pattern is recognized if the first candle is a bullish candle
            // and the second candle is a bearish candle
            // and the second candle opens above the first candle
            // and the second candle closes below the midpoint of the first candle
            // we dont check for length as we know the base class won't send us a list that is too short
            return candles[0].isBullish && candles[1].isBearish && candles[1].Open > candles[0].Open && candles[1].Close < candles[0].Midpoint;
        }
    }
    internal class PiercingPatternRecognizer : Recognizer
    {
        public PiercingPatternRecognizer() : base("Piercing Pattern", 2) { }
        /// <summary>
        /// The method that does the actual recognition
        /// </summary>
        /// <param name="candles">The candles to be recognized</param>
        /// <returns>True if the pattern is recognized, false otherwise</returns>
        protected override bool patternMatchesSubset(List<Candlestick> candles)
        {
            // the pattern is recognized if the first candle is a bearish candle
            // and the second candle is a bullish candle
            // and the second candle opens below the first candle
            // and the second candle closes above the midpoint of the first candle
            // we dont check for length as we know the base class won't send us a list that is too short
            return candles[0].isBearish && candles[1].isBullish && candles[1].Open < candles[0].Open && candles[1].Close > candles[0].Midpoint;
        }
    }
    // The Bullish Harami
    internal class BullishHaramiRecognizer : Recognizer
    {
        public BullishHaramiRecognizer() : base("Bullish Harami", 2) { }
        /// <summary>
        /// The method that does the actual recognition
        /// </summary>
        /// <param name="candles">The candles to be recognized</param>
        /// <returns>True if the pattern is recognized, false otherwise</returns>
        protected override bool patternMatchesSubset(List<Candlestick> candles)
        {
            // the pattern is recognized if the first candle is a bearish candle
            // and the second candle is a bullish candle
            // and the second candle opens below the first candle
            // and the second candle closes above the midpoint of the first candle
            // we dont check for length as we know the base class won't send us a list that is too short
            return candles[0].isBearish && candles[1].isBullish && candles[1].Open < candles[0].Open && candles[1].Close > candles[0].Midpoint;
        }

    }
    // The Bearish Harami
    internal class BearishHaramiRecognizer : Recognizer
    {
        public BearishHaramiRecognizer() : base("Bearish Harami", 2) { }
        /// <summary>
        /// The method that does the actual recognition
        /// </summary>
        /// <param name="candles">The candles to be recognized</param>
        /// <returns>True if the pattern is recognized, false otherwise</returns>
        protected override bool patternMatchesSubset(List<Candlestick> candles)
        {
            // the pattern is recognized if the first candle is a bullish candle
            // and the second candle is a bearish candle
            // and the second candle opens above the first candle
            // and the second candle closes below the midpoint of the first candle
            // we dont check for length as we know the base class won't send us a list that is too short
            return candles[0].isBullish && candles[1].isBearish && candles[1].Open > candles[0].Open && candles[1].Close < candles[0].Midpoint;
        }
    }

    // morning star
    internal class MorningStarRecognizer : Recognizer
    {
        public MorningStarRecognizer() : base("Morning Star", 3) { }
        /// <summary>
        /// The method that does the actual recognition
        /// </summary>
        /// <param name="candles">The candles to be recognized</param>
        /// <returns>True if the pattern is recognized, false otherwise</returns>
        protected override bool patternMatchesSubset(List<Candlestick> candles)
        {
            // the pattern is recognized if the first candle is a bearish candle
            // and the second candle is a bullish candle
            // and the third candle is a bearish candle
            // and the second candle opens below the first candle
            // and the second candle closes above the midpoint of the first candle
            // and the third candle opens below the midpoint of the second candle
            // and the third candle closes below the midpoint of the first candle
            // we dont check for length as we know the base class won't send us a list that is too short
            return candles[0].isBearish && candles[1].isBullish && candles[2].isBearish && candles[1].Open < candles[0].Open && candles[1].Close > candles[0].Midpoint && candles[2].Open < candles[1].Midpoint && candles[2].Close < candles[0].Midpoint;
        }
    }
    // evening star
    internal class EveningStarRecognizer : Recognizer
    {
        public EveningStarRecognizer() : base("Evening Star", 3) { }
        /// <summary>
        /// The method that does the actual recognition
        /// </summary>
        /// <param name="candles">The candles to be recognized</param>
        /// <returns>True if the pattern is recognized, false otherwise</returns>
        protected override bool patternMatchesSubset(List<Candlestick> candles)
        {
            // the pattern is recognized if the first candle is a bullish candle
            // and the second candle is a bearish candle
            // and the third candle is a bullish candle
            // and the second candle opens above the first candle
            // and the second candle closes below the midpoint of the first candle
            // and the third candle opens above the midpoint of the second candle
            // and the third candle closes above the midpoint of the first candle
            // we dont check for length as we know the base class won't send us a list that is too short
            return candles[0].isBullish && candles[1].isBearish && candles[2].isBullish && candles[1].Open > candles[0].Open && candles[1].Close < candles[0].Midpoint && candles[2].Open > candles[1].Midpoint && candles[2].Close > candles[0].Midpoint;
        }
    }
}