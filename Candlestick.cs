/// <summary>
/// this class represents a candlestick
/// it includes the date, open, high, low, close and volume
/// </summary>
public class Candlestick
{
    public DateTime Date { get; set; }
    public Decimal Open { get; set; }
    public Decimal High { get; set; }
    public Decimal Low { get; set; }
    public Decimal Close { get; set; }
    public long Volume { get; set; }

    public Candlestick()
    {
        Date = DateTime.Now;
        Open = 0;
        Close = 0;
        High = 0;
        Low = 0;
        Volume = 0;
    }
    public Candlestick(DateTime date, Decimal open, Decimal high, Decimal low, Decimal close, long volume)
    {
        this.Date = date;
        this.Open = open;
        this.Close = close;
        this.High = high;
        this.Low = low;
        this.Volume = volume;
    }



    /// <summary>
    /// Determines whether the given candlestick represents a Dragonfly Doji pattern or not
    /// 
    /// </summary>
    /// <param name="candlestick"> The candlesticks to check</param>
    /// <returns> True if the candlestick represents a dragonfly pattern, false otherwise</returns>
    /// 
    public bool isDragonFlyDoji()
    {
        decimal bodyLength = Math.Abs(Open - Close);
        decimal upperShadowLength = High - Math.Max(Open, Close);
        decimal lowerShadowLength = Math.Min(Open, Close) - Low;

        // Check if the candlestick is a Dragonfly Doji
        return (bodyLength < upperShadowLength * 0.1m && bodyLength < lowerShadowLength * 0.1m);
        
        }

    
    /// <summary>
    /// this method determines whether the given candlestick represents a gravestone doji pattern or not
    /// </summary>
    /// <param name="candlestick"></param> the candlesticks to check
    /// <returns></returns> a boolean represents a gravestone pattern
    public bool isGravestoneDoji()
    {
        decimal bodyLength = Math.Abs(Open - Close);
        decimal upperShadowLength = High - Math.Max(Open, Close);
        decimal lowerShadowLength = Math.Min(Open, Close) - Low;

    // check if the candlestick is a gravestone doji
    return (bodyLength < upperShadowLength * 0.1m && bodyLength < lowerShadowLength * 0.1m);


    }
    /// <summary>
    /// Determines whether the given candlestick represents a Neutral Doji pattern or not
    /// </summary>
    /// <param name="candlestick"> The candlesticks to check</param>
    /// <returns> a boolean that  represents a Neutral Doji pattern</returns>
    public bool isNeutralDoji()
    {
        decimal bodyLength = Math.Abs(Open - Close);
        decimal shadowLength = Math.Max(High - Close, Open - Low);

    // Check if the candlestick is a Neutral Doji
    return (bodyLength < shadowLength * 0.1m && shadowLength > bodyLength);


    }

    /// <summary>
    /// Determines whether the given candlestick represents a Long-Legged Doji pattern or not
    /// </summary>
    /// <param name="candlestick"> The candlesticks to check</param>
    /// <returns>  a boolean that represents the check of a  candlestick that represents a Long-Legged Doji pattern</returns>
    public bool isLongLeggedDoji()
    {
        decimal bodyLength = Math.Abs(Open - Close);
        decimal shadowLength = Math.Max(High - Close, Open - Low);

    // Check if the candlestick is a Long-Legged Doji
    return (bodyLength < shadowLength * 0.1m && shadowLength > bodyLength * 2);




    }
    /// <summary>
    /// this method determines whether the given candlestick represents a white marubozu pattern
    /// </summary>
    /// <returns></returns> a boolean representing whether or not its a white marubozu
   public bool isWhiteMarubozu()
    {
        decimal bodyLength = Math.Abs(Open - Close);
        decimal upperShadowLength = High - Math.Max(Open, Close);
        decimal lowerShadowLength = Math.Min(Open, Close) - Low;

    // Check if the candlestick is a White Marubozu
    return (bodyLength > upperShadowLength && bodyLength > lowerShadowLength && Open < Close);

        
    }
    /// <summary>
    /// this method determines whether the given candlestick represents a black marubozu pattern
    /// </summary>
    /// <returns></returns> a boolean representing whether or not its a black marubozu
  public bool isBlackMarubozu()
    {
        decimal bodyLength = Math.Abs(Open - Close);
        decimal upperShadowLength = High - Math.Max(Open, Close);
        decimal lowerShadowLength = Math.Min(Open, Close) - Low;

    // Check if the candlestick is a Black Marubozu
    return (bodyLength > upperShadowLength && bodyLength > lowerShadowLength && Open > Close);

    }
    /// <summary>
    /// this method determines whether the candlestick has a bullish hammer pattern
    /// </summary>
    /// <returns></returns> a boolean representing this pattern
public bool isBullishHammerPattern()
    
        {
        decimal bodyLength = Math.Abs(Open - Close);
        decimal upperShadowLength = High - Math.Max(Open, Close);
        decimal lowerShadowLength = Math.Min(Open, Close) - Low;

        // Check if the candlestick is a Bullish Hammer
        return (bodyLength < upperShadowLength * 0.1m && bodyLength < lowerShadowLength * 0.1m && Open < Close);



    
    }

    /// <summary>
    /// this method determines whether the given candlestick has an inverted hammer pattern
    /// </summary>
    /// <returns></returns> a boolean representing an inverted hammer
    public bool isInvertedHammer()
    {
        // Calculate the real body and upper/lower shadow lengths
        decimal realBody = Math.Abs(this.Open - this.Close);
        decimal upperShadow = this.High - Math.Max(this.Open, this.Close);
        decimal lowerShadow = Math.Min(this.Open, this.Close) - this.Low;

        // Check if the candlestick has an inverted hammer pattern
        bool isRealBodySmall = realBody < (0.1m * this.High);
        bool isUpperShadowLong = upperShadow >= (2m * realBody);
        bool isLowerShadowSmall = lowerShadow < (0.1m * this.High);

        return isRealBodySmall && isUpperShadowLong && isLowerShadowSmall;
    }
    /// <summary>
    /// 
    /// this method determines whether the given candlestick has a bullish engulfing pattern
    /// </summary>
    /// <param name="previousCandle"></param>
    /// <returns></returns> a boolean representing a bullish engulfing pattern
    public bool isBullishEngulfingPattern(Candlestick previousCandle)
    {
        // Calculate the real body and upper/lower shadow lengths of the current candlestick
        decimal currentRealBody = Math.Abs(this.Open - this.Close);
        decimal currentUpperShadow = this.High - Math.Max(this.Open, this.Close);
        decimal currentLowerShadow = Math.Min(this.Open, this.Close) - this.Low;

        // Calculate the real body and upper/lower shadow lengths of the previous candlestick
        decimal previousRealBody = Math.Abs(previousCandle.Open - previousCandle.Close);
        decimal previousUpperShadow = previousCandle.High - Math.Max(previousCandle.Open, previousCandle.Close);
        decimal previousLowerShadow = Math.Min(previousCandle.Open, previousCandle.Close) - previousCandle.Low;

        // Check if the current candlestick is a bullish engulfing pattern
        bool isBullishEngulfing = (this.Close > this.Open) // current candlestick is bullish
                                 && (previousCandle.Close < previousCandle.Open) // previous candlestick is bearish
                                 && (this.Open <= previousCandle.Close) && (this.Close >= previousCandle.Open) // engulfing condition
                                 && (currentUpperShadow < (0.1m * this.High)) // small upper shadow for current candlestick
                                 && (previousLowerShadow > previousRealBody) // long lower shadow for previous candlestick
                                 && (previousRealBody < previousUpperShadow); // small real body for previous candlestick

        return isBullishEngulfing;
    }
    /// <summary>
    /// this method determines whether the given candlestick has a bearish engulfing pattern
    /// </summary>
    /// <param name="previousCandle"></param>
    /// <returns></returns> a boolean representing a bearish engulfing pattern
    public bool isBearishEngulfingPattern(Candlestick previousCandle)
    {
        // Calculate the real body and upper/lower shadow lengths of the current candlestick
        decimal currentRealBody = Math.Abs(this.Open - this.Close);
        decimal currentUpperShadow = this.High - Math.Max(this.Open, this.Close);
        decimal currentLowerShadow = Math.Min(this.Open, this.Close) - this.Low;

        // Calculate the real body and upper/lower shadow lengths of the previous candlestick
        decimal previousRealBody = Math.Abs(previousCandle.Open - previousCandle.Close);
        decimal previousUpperShadow = previousCandle.High - Math.Max(previousCandle.Open, previousCandle.Close);
        decimal previousLowerShadow = Math.Min(previousCandle.Open, previousCandle.Close) - previousCandle.Low;

        // Check if the current candlestick is a bearish engulfing pattern
        bool isBearishEngulfing = (this.Close < this.Open) // current candlestick is bearish
                                 && (previousCandle.Close > previousCandle.Open) // previous candlestick is bullish
                                 && (this.Open >= previousCandle.Close) && (this.Close <= previousCandle.Open) // engulfing condition
                                 && (currentLowerShadow < (0.1m * this.Low)) // small lower shadow for current candlestick
                                 && (previousUpperShadow > previousRealBody) // long upper shadow for previous candlestick
                                 && (previousRealBody < previousLowerShadow); // small real body for previous candlestick

        return isBearishEngulfing;
    }

}