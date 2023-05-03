namespace StockProgram
{
    // the file that recognizes the different single candlestick patterns
    /// <summary>
    /// The default constructor telling the base class (Recognizer) 
    /// the name of the pattern ("Bullish" ) 
    /// and the size of the pattern (1)
    /// </summary>
    /// <param name="name">The name of the pattern</param>
    /// <param name="size">The size of the pattern</param>
    internal class BullishRecognizer : Recognizer
    {
        public BullishRecognizer() : base("Bullish", 1) { }
        /// <summary>
        /// The method that does the actual recognition
        /// </summary>
        /// <param name="candles">The candles to be recognized</param>
        /// <returns>True if the pattern is recognized, false otherwise</returns>
        protected override bool patternMatchesSubset(List<Candlestick> candles)
        {
            // the pattern is recognized if the first candle is a bullish candle
            // we dont check for length as we know the base class won't send us a list that is too short
            return candles[0].isBullish;
        }
    }
    /// <summary>
    /// The default constructor telling the base class (Recognizer)
    /// the name of the pattern ("Bearish")
    /// and the size of the pattern (1)
    /// </summary>

    /// <param name="name">The name of the pattern</param>
    /// <param name="size">The size of the pattern</param>
    internal class BearishRecognizer : Recognizer
    {
        public BearishRecognizer() : base("Bearish", 1) { }
        /// <summary>
        /// The method that does the actual recognition
        /// </summary>
        /// <param name="candles">The candles to be recognized</param>
        /// <returns>True if the pattern is recognized, false otherwise</returns>
        protected override bool patternMatchesSubset(List<Candlestick> candles)
        {
            // the pattern is recognized if the first candle is a bearish candle
            // we dont check for length as we know the base class won't send us a list that is too short
            return candles[0].isBearish;
        }
    }
    /// <summary>
    /// The default constructor telling the base class (Recognizer)
    /// the name of the pattern ("Doji")
    /// and the size of the pattern (1)
    /// </summary>

    /// <param name="name">The name of the pattern</param>
    /// <param name="size">The size of the pattern</param>


    internal class DojiRecognizer : Recognizer
    {
        public DojiRecognizer() : base("Doji", 1) { }
        protected override bool patternMatchesSubset(List<Candlestick> candles)
        {
            return candles[0].isDoji;
        }
    }
    internal class HammerRecognizer : Recognizer
    {
        public HammerRecognizer() : base("Hammer", 1) { }
        protected override bool patternMatchesSubset(List<Candlestick> candles)
        {
            return candles[0].isHammer;
        }
    }
    internal class MarubozuRecognizer : Recognizer
    {
        public MarubozuRecognizer() : base("Marubozu", 1) { }
        protected override bool patternMatchesSubset(List<Candlestick> candles)
        {
            return candles[0].isMarubozu;
        }
    }
    internal class SpinningTopRecognizer : Recognizer
    {
        public SpinningTopRecognizer() : base("SpinningTop", 1) { }
        protected override bool patternMatchesSubset(List<Candlestick> candles)
        {
            return candles[0].isSpinningTop;
        }
    }
    internal class PaperUmbrellaRecognizer : Recognizer
    {
        public PaperUmbrellaRecognizer() : base("PaperUmbrella", 1) { }
        protected override bool patternMatchesSubset(List<Candlestick> candles)
        {
            return candles[0].isPaperUmbrella;
        }
    }
    internal class ShootingStarRecognizer : Recognizer
    {
        public ShootingStarRecognizer() : base("ShootingStar", 1) { }
        protected override bool patternMatchesSubset(List<Candlestick> candles)
        {
            return candles[0].isShootingStar;
        }
    }
    internal class HangingManRecognizer : Recognizer
    {
        public HangingManRecognizer() : base("HangingMan", 1) { }
        protected override bool patternMatchesSubset(List<Candlestick> candles)
        {
            return candles[0].isHangingMan;
        }
    }
    internal class InvertedHammerRecognizer : Recognizer
    {
        public InvertedHammerRecognizer() : base("InvertedHammer", 1) { }
        protected override bool patternMatchesSubset(List<Candlestick> candles)
        {
            return candles[0].isInvertedHammer;
        }
    }
    internal class BearishHammerRecognizer: Recognizer
    {
        public BearishHammerRecognizer() : base("BearishHammer", 1) { }
        protected override bool patternMatchesSubset(List<Candlestick> candles)
        {
            return candles[0].isBearishHammer;
        }
    }
    internal class BullishHammerRecognizer : Recognizer
    {
        public BullishHammerRecognizer() : base("BullishHammer", 1) { }
        protected override bool patternMatchesSubset(List<Candlestick> candles)
        {
            return candles[0].isBullishHammer;
        }
    }
    internal class BearishInvertedHammerRecognizer : Recognizer
    {
        public BearishInvertedHammerRecognizer() : base("BearishInvertedHammer", 1) { }
        protected override bool patternMatchesSubset(List<Candlestick> candles)
        {
            return candles[0].isBearishInvertedHammer;
        }
    }
    internal class BullishInvertedHammerRecognizer : Recognizer
    {
        public BullishInvertedHammerRecognizer() : base("BullishInvertedHammer", 1) { }
        protected override bool patternMatchesSubset(List<Candlestick> candles)
        {
            return candles[0].isBullishInvertedHammer;
        }
    }
    internal class DragonFlyDojiRecognizer : Recognizer
    {
        public DragonFlyDojiRecognizer() : base("DragonFlyDoji", 1) { }
        protected override bool patternMatchesSubset(List<Candlestick> candles)
        {
            return candles[0].isDragonFlyDoji;
        }
    }
    internal class GravestoneDojiRecognizer : Recognizer
    {
        public GravestoneDojiRecognizer() : base("GravestoneDoji", 1) { }
        protected override bool patternMatchesSubset(List<Candlestick> candles)
        {
            return candles[0].isGravestoneDoji;
        }
    }
    internal class LongLeggedDojiRecognizer: Recognizer
    {
        public LongLeggedDojiRecognizer() : base("LongLeggedDoji", 1) { }
        protected override bool patternMatchesSubset(List<Candlestick> candles)
        {
            return candles[0].isLongLeggedDoji;
        }
    }
    internal class NeutralDojiRecognizer: Recognizer
    {
        public NeutralDojiRecognizer() : base("NeutralDoji", 1) { }
        protected override bool patternMatchesSubset(List<Candlestick> candles)
        {
            return candles[0].isNeutralDoji;
        }
    }


}