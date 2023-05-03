using System.Data.SqlClient;
/// <summary>
/// this class represents a candlestick
/// it includes the date, open, high, low, close and volume
/// </summary>
public class Candlestick
{
    public DateTime Date { get; set; }
    public Double Open { get; set; }
    public Double High { get; set; }
    public Double Low { get; set; }
    public Double Close { get; set; }
    public long Volume { get; set; }
    // define period

    public String Period { get; set; }
    // define ticker
    public String  Ticker { get; set; }
    
    public Double BodyTop
    {
        get
        {
            return Math.Max(Open, Close);
        }
    }
    public Double BodyBottom
    {
        get
        {
            return Math.Min(Open, Close);
        }
    }

    public Candlestick()
    {
        Date = DateTime.Now;
        Open = 0;
        Close = 0;
        High = 0;
        Low = 0;
        Volume = 0;     
        Period = string.Empty;
        Ticker = string.Empty;
    }
    public Candlestick(DateTime date, Double open, Double high, Double low, Double close, long volume, string period, string ticker)
    {
        this.Date = date;
        this.Open = open;
        this.Close = close;
        this.High = high;
        this.Low = low;
        this.Volume = volume;
        this.Period = period;
        this.Ticker = ticker;

    }
        public Candlestick(DateTime date, Double open, Double high, Double low, Double close, long volume)
    {
        
        this.Date = date;
        this.Open = open;
        this.Close = close;
        this.High = high;
        this.Low = low;
        this.Volume = volume;
        this.Period = string.Empty;
        this.Ticker = string.Empty;
        computeProperties();


    }
    public Candlestick(Candlestick candlestick)
    {
        this.Date = candlestick.Date;
        this.Open = candlestick.Open;
        this.Close = candlestick.Close;
        this.High = candlestick.High;
        this.Low = candlestick.Low;
        this.Volume = candlestick.Volume;
        this.Ticker = candlestick.Ticker;
        this.Period = candlestick.Period;
        computeProperties();

    }
    public override string ToString()
    {
        string DateText;
        Period = Period.ToUpper();
        char p = Period[0];
        // if this is daily weekly, or monthly, we just need the date
        if (p == 'D' || p == 'W' || p == 'M')
        {
            DateText = Date.ToString("MM-dd-yyyy");
        }
        else
        {
            // otherwise, we  want the time up to the minute
            DateText = Date.ToString();
        }
        string result = Ticker + "," + DateText + "," + Open + "," + High + "," + Low + "," + Close + "," + Volume;
        return result;

    }
    #region Higher level properties of a candlestick

    //properties of the candle
    public double range { get; private set; }
    public double body { get; private set; }
    public double upperTail { get; private set; }
    public double lowerTail { get; private set; }
    public double topPrice { get; private set; }
    public double bottomPrice { get; private set; }
    public double Midpoint { get; private set; }
    

    // basic bullish/bearish/neutral properties
    public Boolean isBullish { get; private set; }
    public Boolean isBearish { get; private set; }
    public Boolean isNeutral { get; private set; }

    // different type of dojis
    public Boolean isDragonFlyDoji { get; private set; }
    public Boolean isGravestoneDoji { get; private set; }
    public Boolean isNeutralDoji { get; private set; }
    public Boolean isLongLeggedDoji { get; private set; }
    public Boolean isDoji { get; private set; }
    // different type of hammers
    public Boolean isHammer { get; private set; }
    public Boolean isBullishHammer { get; private set; }
    public Boolean isBearishHammer { get; private set; }

    // different types of inverted hammers

    public Boolean isInvertedHammer { get; private set; }
    public Boolean isBullishInvertedHammer { get; private set; }
    public Boolean isBearishInvertedHammer { get; private set; }


    // the marubozus
    public Boolean isMarubozu { get; private set; }
    //other types of candlesticks
    public Boolean isSpinningTop { get; private set; }
    public Boolean isPaperUmbrella { get; private set; }
    public Boolean isShootingStar { get; private set; }
    public Boolean isHangingMan { get; private set; }
    #endregion


    public Boolean dojiTest(double bodyTolerance = 0.03)
    {
        return body <= bodyTolerance * range;
    }
    public Boolean spinningTopTest(double bodyTolerance = 0.03, double tailTolerance = 0.05)
    {
        return body <= bodyTolerance * range && upperTail <= tailTolerance * range && lowerTail <= tailTolerance * range;
    }
    public Boolean dragonflyDojiTest(double bodyTolerance = 0.03, double upperTailTolerance = 0.05)
    {
        return dojiTest(bodyTolerance) && upperTail <= upperTailTolerance * range;
    }
    public Boolean gravestoneDojiTest(double bodyTolerance = 0.03, double lowerTailTolerance = 0.05)
    {
        return dojiTest(bodyTolerance) && lowerTail <= lowerTailTolerance * range;
    }
// long legged doji test
public Boolean longLeggedDojiTest(double bodyTolerance = 0.03, double tailTolerance = 0.05)
    {
        return dojiTest(bodyTolerance) && upperTail >= tailTolerance * range && lowerTail >= tailTolerance * range;
    }
    public Boolean hammerTest(double minBodyTolerance = 0.15, double maxBodyTolerance = 0.25, double upperTailTolerance = 0.05)
    {
        return body >= minBodyTolerance * range && body <= maxBodyTolerance * range && upperTail <= upperTailTolerance * range;
    }
    public Boolean bullishHammerTest(double minBodyTolerance = 0.15, double maxBodyTolerance = 0.25, double upperTailTolerance = 0.05)
    {
        return hammerTest(minBodyTolerance, maxBodyTolerance, upperTailTolerance) && Close > Open;
    }
    public Boolean bearishHammerTest(double minBodyTolerance = 0.15, double maxBodyTolerance = 0.25, double lowerTailTolerance = 0.05)
    {
        return hammerTest(minBodyTolerance, maxBodyTolerance, lowerTailTolerance) && Close < Open;
    }
    public Boolean invertedHammerTest(double minBodyTolerance = 0.15, double maxBodyTolerance = 0.25, double lowerTailTolerance = 0.05)
    {
        return body >= minBodyTolerance * range && body <= maxBodyTolerance * range && lowerTail <= lowerTailTolerance * range;

    }
    public Boolean bearishInvertedHammerTest(double minBodyTolerance = 0.15, double maxBodyTolerance = 0.25, double lowerTailTolerance = 0.05)
    {
        return invertedHammerTest(minBodyTolerance, maxBodyTolerance, lowerTailTolerance) && Close < Open;
    }
    public Boolean bullishInvertedHammerTest(double minBodyTolerance = 0.15, double maxBodyTolerance = 0.25, double upperTailTolerance = 0.05)

    {
        return invertedHammerTest(minBodyTolerance, maxBodyTolerance, upperTailTolerance) && Close > Open;
    }
    public Boolean MarubozuTest()
    {
        return body == range;
    }
    public Boolean PaperUmbrellaTest(double bodyTolerance = 0.03, double tailTolerance = 0.05)
    {
        return body <= bodyTolerance * range && upperTail <= tailTolerance * range && lowerTail <= tailTolerance * range;
    }
    public Boolean Engulfs(Candlestick other)
    {
        return (other.Open < Open && other.Close > Close) || (other.Open > Open && other.Close < Close);
    }
    private void computeProperties()
    {
        range = High - Low;
        body = Math.Abs(Open - Close);
        topPrice = High - Math.Max(Open, Close);
        bottomPrice = Math.Min(Open, Close) - Low;
        upperTail = topPrice - High;
        lowerTail = Low - bottomPrice;
        Midpoint =  (High + Low) / 2;
        computePatterns();


    }
    private void computePatterns()
    {
        // general
        isBullish = Close > Open;
        isNeutral = Close == Open;
        isBearish = Close < Open;
        //doji computations
        isDoji = dojiTest();
        isDragonFlyDoji = dragonflyDojiTest();
        isGravestoneDoji = gravestoneDojiTest();
        isNeutralDoji = Close == Open;
        isLongLeggedDoji = longLeggedDojiTest();
        // hammer computations
        isHammer = hammerTest();
        isBullishHammer = bullishHammerTest();
        isBearishHammer = bearishHammerTest();
        // inverted hammer computations
        isInvertedHammer = invertedHammerTest();
        isBullishInvertedHammer = bullishInvertedHammerTest();
        isBearishInvertedHammer = bearishInvertedHammerTest();
        // marubozu computations
        isMarubozu = MarubozuTest();
        // other computations
        isSpinningTop = spinningTopTest();
        isPaperUmbrella = PaperUmbrellaTest();
        isHangingMan = isBearishHammer && isLongLeggedDoji;
        isShootingStar = isBullishHammer && isLongLeggedDoji;




    }
}
