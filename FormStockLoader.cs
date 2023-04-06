using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
// add reference for legend


namespace StockProgram
{
    public partial class FormStockLoader : Form
    {
        public FormStockLoader()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        /// <summary>
        ///  this method highlights the long legged doji pattern and shows it as a rectangle
        /// </summary>
        /// <param name="candleStickDataSource"></param> the candlestick data source
        /// <param name="chart"></param> the chart to add the annotation to
        private void showLongLeggedDoji(List<Candlestick> candleStickDataSource, Chart chart)
        {
            Color black = Color.Black;
            chart.Legends["Legend1"].CustomItems.Add(black, "LongLeggedDoji");

            // loop through to check for long legged doji patterns
            for (int i = 0; i < candleStickDataSource.Count; i++)
            {
                if (candleStickDataSource[i].isLongLeggedDoji())
                {
                    RectangleAnnotation ann = new();
                    ann.BackColor = Color.Black;
                    // surround the certain area with the rectangle
                    ann.Width = 0.5;
                    ann.Height = 0.5;
                    // outline around the rectangle
                    ann.LineColor = Color.Gray;
                    ann.AxisX = chart.ChartAreas[0].AxisX;
                    ann.AxisY = chart.ChartAreas[0].AxisY;
                    ann.X = candleStickDataSource[i].Date.ToOADate();
                    // convert to double
                    ann.Y = Convert.ToDouble(candleStickDataSource[i].High);
                    ann.AnchorX = candleStickDataSource[i].Date.ToOADate();
                    ann.AnchorY = Convert.ToDouble(candleStickDataSource[i].High);
                    chart.Annotations.Add(ann); // increase the offset to add more space between annotations
                }
            }
        }
        /// <summary>
        /// this method highlights the neutral doji pattern and shows it as a rectangle
        /// </summary>
        /// <param name="candleStickDataSource"></param> the candlestick data source
        /// <param name="chart"></param> the chart to add the annotation to
        private void showNeutralDoji(List<Candlestick> candleStickDataSource, Chart chart)

        {
            Color blue = Color.Blue;
            chart.Legends["Legend1"].CustomItems.Add(blue, "NeutralDoji");

            for (int i = 0; i < candleStickDataSource.Count; i++)
            {
                if (candleStickDataSource[i].isNeutralDoji())
                {
                    RectangleAnnotation ann = new();
                    ann.BackColor = Color.Blue;
                    // surround the certain area with the rectangle
                    ann.Width = 0.5;
                    ann.Height = 0.5;
                    // outline around the rectangle
                    ann.LineColor = Color.Black;
                    ann.AxisX = chart.ChartAreas[0].AxisX;
                    ann.AxisY = chart.ChartAreas[0].AxisY;
                    ann.X = candleStickDataSource[i].Date.ToOADate();
                    // convert to double
                    ann.Y = Convert.ToDouble(candleStickDataSource[i].High);
                    ann.AnchorX = candleStickDataSource[i].Date.ToOADate();
                    ann.AnchorY = Convert.ToDouble(candleStickDataSource[i].High);
                    chart.Annotations.Add(ann);
                }
            }
        }
        /// <summary>
        /// this method highlights the gravestone doji pattern and shows it as a rectangle
        /// </summary>
        /// <param name="candlestickDataSource"></param> the candlestick data source
        /// <param name="chart"></param> the chart to add the annotation to
        private void showGravestoneDoji(List<Candlestick> candlestickDataSource, Chart chart)
        {
            Color green = Color.Green;
            chart.Legends["Legend1"].CustomItems.Add(green, "GravestoneDoji");

            // loop through to check for gravestone doji patterns


            for (int i = 0; i < candlestickDataSource.Count; i++)
            {
                if (candlestickDataSource[i].isGravestoneDoji())
                {
                    //add a colored rectangle annotation to highlight the pattern
                    RectangleAnnotation ann = new();
                    ann.BackColor = Color.Green;
                    // surround the certain area with the rectangle
                    ann.Width = 0.5;
                    ann.Height = 0.5;
                    //outline around the rectangle
                    ann.LineColor = Color.Black;
                    ann.AxisX = chart.ChartAreas[0].AxisX;
                    ann.AxisY = chart.ChartAreas[0].AxisY;
                    ann.X = candlestickDataSource[i].Date.ToOADate();
                    // convert to double
                    ann.Y = Convert.ToDouble(candlestickDataSource[i].High);
                    ann.AnchorX = candlestickDataSource[i].Date.ToOADate();
                    ann.AnchorY = Convert.ToDouble(candlestickDataSource[i].High);
                    chart.Annotations.Add(ann);


                }
            }
        }
        /// <summary>
        /// this method highlights the dragonfly doji pattern and shows it as a rectangle
        /// </summary>
        /// <param name="candleStickDataSource"></param> the candlestick data source
        /// <param name="chart"></param> the chart to add the annotation to
        private void showDragonflyDoji(List<Candlestick> candleStickDataSource, Chart chart)
        {
            Color red = Color.Red;
            chart.Legends["Legend1"].CustomItems.Add(red, "DragonflyDoji");

            // loop through to check for dragonfly doji patterns


            for (int i = 0; i < candleStickDataSource.Count; i++)
            {
                if (candleStickDataSource[i].isDragonFlyDoji())
                {
                    //add a colored rectangle annotation to highlight the pattern
                    RectangleAnnotation ann = new();
                    ann.BackColor = Color.Red;
                    // surround the certain area with the rectangle
                    ann.Width = 0.5;
                    ann.Height = 0.5;
                    //outline around the rectangle
                    ann.LineColor = Color.Black;


                    ann.AxisX = chart.ChartAreas[0].AxisX;
                    ann.AxisY = chart.ChartAreas[0].AxisY;
                    ann.X = candleStickDataSource[i].Date.ToOADate();
                    // convert to double
                    ann.Y = Convert.ToDouble(candleStickDataSource[i].High);
                    ann.AnchorX = candleStickDataSource[i].Date.ToOADate();
                    ann.AnchorY = Convert.ToDouble(candleStickDataSource[i].High);
                    chart.Annotations.Add(ann);


                }
            }

        }
        private void showWhiteMarubozu(List<Candlestick> candleStickDataSource, Chart chart)
        {
            Color yellow = Color.Yellow;
            chart.Legends["Legend1"].CustomItems.Add(yellow, "WhiteMarubozu");
            // loop through to check for white marubozu patterns
            for (int i = 0; i < candleStickDataSource.Count; i++)
            {
                if (candleStickDataSource[i].isWhiteMarubozu())
                {
                    //add a colored rectangle annotation to highlight the pattern
                    RectangleAnnotation ann = new();
                    ann.BackColor = Color.Yellow;
                    // surround the certain area with the rectangle
                    ann.Width = 0.5;
                    ann.Height = 0.5;
                    //outline around the rectangle
                    ann.LineColor = Color.Black;
                    ann.AxisX = chart.ChartAreas[0].AxisX;
                    ann.AxisY = chart.ChartAreas[0].AxisY;
                    ann.X = candleStickDataSource[i].Date.ToOADate();
                    // convert to double
                    ann.Y = Convert.ToDouble(candleStickDataSource[i].High);
                    ann.AnchorX = candleStickDataSource[i].Date.ToOADate();
                    ann.AnchorY = Convert.ToDouble(candleStickDataSource[i].High);
                    chart.Annotations.Add(ann);
                }
            }
        }
        private void showBlackMarubozu(List<Candlestick> candlStickDataSource, Chart chart)
        {
            Color blue = Color.Blue;
            chart.Legends["Legend1"].CustomItems.Add(blue, "BlackMarubozu");
            // loop through to check for black marubozu patterns
            for (int i = 0; i < candlStickDataSource.Count; i++)
            {
                if (candlStickDataSource[i].isBlackMarubozu())
                {
                    //add a colored rectangle annotation to highlight the pattern
                    RectangleAnnotation ann = new();
                    ann.BackColor = Color.Blue;
                    // surround the certain area with the rectangle
                    ann.Width = 0.5;
                    ann.Height = 0.5;
                    //outline around the rectangle
                    ann.LineColor = Color.Black;
                    ann.AxisX = chart.ChartAreas[0].AxisX;
                    ann.AxisY = chart.ChartAreas[0].AxisY;
                    ann.X = candlStickDataSource[i].Date.ToOADate();
                    // convert to double
                    ann.Y = Convert.ToDouble(candlStickDataSource[i].High);
                    ann.AnchorX = candlStickDataSource[i].Date.ToOADate();
                    ann.AnchorY = Convert.ToDouble(candlStickDataSource[i].High);
                    chart.Annotations.Add(ann);
                }
            }
        }
        private void showBullishHammer(List<Candlestick> candleStickDataSource, Chart chart)
        {
            Color orange = Color.Orange;
            chart.Legends["Legend1"].CustomItems.Add(orange, "Hammer");
            // loop through to check for hammer patterns
            for (int i = 0; i < candleStickDataSource.Count; i++)
            {
                if (candleStickDataSource[i].isBullishHammerPattern())
                {
                    //add a colored rectangle annotation to highlight the pattern
                    RectangleAnnotation ann = new();
                    ann.BackColor = Color.Orange;
                    // surround the certain area with the rectangle
                    ann.Width = 0.5;
                    ann.Height = 0.5;
                    //outline around the rectangle
                    ann.LineColor = Color.Black;
                    ann.AxisX = chart.ChartAreas[0].AxisX;
                    ann.AxisY = chart.ChartAreas[0].AxisY;
                    ann.X = candleStickDataSource[i].Date.ToOADate();
                    // convert to double
                    ann.Y = Convert.ToDouble(candleStickDataSource[i].High);
                    ann.AnchorX = candleStickDataSource[i].Date.ToOADate();
                    ann.AnchorY = Convert.ToDouble(candleStickDataSource[i].High);
                    chart.Annotations.Add(ann);
                }
            }
        }
        private void showInvertedHammer(List<Candlestick> candleStickDataSource, Chart chart)
        {
            Color green = Color.Green;
            chart.Legends["Legend1"].CustomItems.Add(green, "InvertedHammer");
            // loop through to check for inverted hammer patterns
            for (int i = 0; i < candleStickDataSource.Count; i++)
            {
                if (candleStickDataSource[i].isInvertedHammer())
                {
                    //add a colored rectangle annotation to highlight the pattern
                    RectangleAnnotation ann = new();
                    ann.BackColor = Color.Green;
                    // surround the certain area with the rectangle
                    ann.Width = 0.5;
                    ann.Height = 0.5;
                    //outline around the rectangle
                    ann.LineColor = Color.Black;
                    ann.AxisX = chart.ChartAreas[0].AxisX;
                    ann.AxisY = chart.ChartAreas[0].AxisY;
                    ann.X = candleStickDataSource[i].Date.ToOADate();
                    // convert to double
                    ann.Y = Convert.ToDouble(candleStickDataSource[i].High);
                    ann.AnchorX = candleStickDataSource[i].Date.ToOADate();
                    ann.AnchorY = Convert.ToDouble(candleStickDataSource[i].High);
                    chart.Annotations.Add(ann);
                }
            }
        }
        private void showBullishEngulfing(List<Candlestick> candleStickDataSource, Chart chart)
        {
            Color green = Color.Green;
            chart.Legends["Legend1"].CustomItems.Add(green, "BullishEngulfing");
            Candlestick previousCandlestick = candleStickDataSource[0];
            // loop through to check for bullish engulfing patterns
            for (int i = 0; i < candleStickDataSource.Count; i++)
            {
                if (i > 0) { previousCandlestick = candleStickDataSource[i - 1]; }

                if (candleStickDataSource[i].isBullishEngulfingPattern(previousCandlestick))
                {
                    //add a colored rectangle annotation to highlight the pattern
                    RectangleAnnotation ann = new();
                    ann.BackColor = Color.Green;
                    // surround the certain area with the rectangle
                    ann.Width = 0.5;
                    ann.Height = 0.5;
                    //outline around the rectangle
                    ann.LineColor = Color.Black;
                    ann.AxisX = chart.ChartAreas[0].AxisX;
                    ann.AxisY = chart.ChartAreas[0].AxisY;
                    ann.X = candleStickDataSource[i].Date.ToOADate();
                    // convert to double
                    ann.Y = Convert.ToDouble(candleStickDataSource[i].High);
                    ann.AnchorX = candleStickDataSource[i].Date.ToOADate();
                    ann.AnchorY = Convert.ToDouble(candleStickDataSource[i].High);
                    chart.Annotations.Add(ann);
                }

            }
        }
        private void showBearishEngulfing(List<Candlestick> candleStickDataSource, Chart chart)
        {
            Color red = Color.Red;
            chart.Legends["Legend1"].CustomItems.Add(red, "BearishEngulfing");
            Candlestick previousCandlestick = candleStickDataSource[0];
            // loop through to check for bearish engulfing patterns
            for (int i = 0; i < candleStickDataSource.Count; i++)
            {
                if (i > 0)  { previousCandlestick = candleStickDataSource[i - 1]; }

                if (candleStickDataSource[i].isBearishEngulfingPattern(previousCandlestick))
                {
                    //add a colored rectangle annotation to highlight the pattern
                    RectangleAnnotation ann = new();
                    ann.BackColor = Color.Red;
                    // surround the certain area with the rectangle
                    ann.Width = 0.5;
                    ann.Height = 0.5;
                    //outline around the rectangle
                    ann.LineColor = Color.Black;
                    ann.AxisX = chart.ChartAreas[0].AxisX;
                    ann.AxisY = chart.ChartAreas[0].AxisY;
                    ann.X = candleStickDataSource[i].Date.ToOADate();
                    // convert to double
                    ann.Y = Convert.ToDouble(candleStickDataSource[i].High);
                    ann.AnchorX = candleStickDataSource[i].Date.ToOADate();
                    ann.AnchorY = Convert.ToDouble(candleStickDataSource[i].High);
                    chart.Annotations.Add(ann);
                }

            }
        }

        private void connectChart(List<Candlestick> candleStickDataSource, string period, string patternSelected)
        {
            //close any existing other chart windows
            List<Form> formsToClose = new List<Form>();
            foreach (Form form in Application.OpenForms)
            {
                if (form.Text == "Chart")
                {
                    formsToClose.Add(form);
                }
            }
            foreach (Form form in formsToClose)
            {
                form.Close();
            }
            // a new window that will display the chart

            Form chartWindow = new();
            chartWindow.Text = "Chart";
            // Get the screen resolution
            int screenWidth = Screen.PrimaryScreen.Bounds.Width;
            int screenHeight = Screen.PrimaryScreen.Bounds.Height;

            // Calculate the window size as a percentage of the screen resolution
            int windowWidth = (int)(screenWidth * 0.8); // set the window width to 80% of the screen width
            int windowHeight = (int)(screenHeight * 0.8); // set the window height to 80% of the screen height
            //initialize the chartStock since it will be cleared on new form creation
            Chart chartStock = new();
            chartStock.Name = "chartStock";
            //initialize the chart area
            ChartArea chartArea = new();
            chartStock.ChartAreas.Clear();
            chartStock.ChartAreas.Add(chartArea);
            chartStock.Series.Clear();
            // initialize the series for the chart
            Series series = new();
            // set the series name based on the period provided by the user
            chartStock.Series.Add(series);
            // hide the series legend
            chartStock.Series[0].IsVisibleInLegend = false;
            // set the chart type to candlestick
            chartStock.Series[0].ChartType = SeriesChartType.Candlestick;
            // set the form size to the calculated size
            chartWindow.Size = new Size(windowWidth, windowHeight);
            // clear the controls on the window
            chartWindow.Controls.Clear();
            // add the chart to the window
            chartWindow.Controls.Add(chartStock);
            //  hide the window till we are done
            chartWindow.Hide();
            // reset the legend on setup
            chartStock.Legends.Clear();

            // reset annotations on setup
            chartStock.Annotations.Clear();
            // set name of legend to Legend1
            chartStock.Legends.Add("Legend1");

            chartStock.DataSource = candleStickDataSource;
            chartStock.DataBind();
            // clear the grid
            chartStock.ChartAreas[0].AxisY.MajorGrid.LineWidth = 0;
            chartStock.ChartAreas[0].AxisX.MajorGrid.LineWidth = 0;

            // set the x axis to be the date values
            chartStock.Series[0].XValueMember = "Date";
            // set the y axis to be the high, low, open and close values
            chartStock.Series[0].YValueMembers = "High, Low, Open, Close";
            chartStock.Series[0].XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Date;
            chartStock.Series[0].CustomProperties = "PriceDownColor=Red, PriceUpColor=Green";
            // open close style
            chartStock.Series[0]["OpenCloseStyle"] = "Triangle";
            chartStock.Series[0]["ShowOpenClose"] = "Both";
            // hide the legend
            // chartStock.Legends[0].Enabled = false;
            // set the y range based off the highest high and lowest low values 
            CandlestickReader candleStickReaderObject = new CandlestickReader();
            chartStock.ChartAreas[0].AxisY.Minimum = (double)(candleStickReaderObject.getLowestLow(candleStickDataSource) - 10);
            chartStock.ChartAreas[0].AxisY.Maximum = (double)(candleStickReaderObject.getHighestHigh(candleStickDataSource) + 10);

            chartStock.ChartAreas[0].AxisY.Interval = 10;
            // create bools for each pattern
            bool longLeggedDoji = false;
            bool gravestoneDoji = false;
            bool neutralDoji = false;
            bool dragonflyDoji = false;
            bool whiteMarubozu = false;
            bool blackMarubozu = false;
            bool bullishHammer = false;
            bool invertedHammer = false;
            bool bullishEngulfing = false;
            bool bearishEngulfing = false;

            if (patternSelected == "Long Legged Doji")
            {
                longLeggedDoji = true;
            }
            else if (patternSelected == "Gravestone Doji")
            {
                gravestoneDoji = true;
            }
            else if (patternSelected == "Neutral Doji")
            {
                neutralDoji = true;
            }
            else if (patternSelected == "Dragonfly Doji")
            {
                dragonflyDoji = true;
            }
            else if (patternSelected == "White Marubozu")
            {
                whiteMarubozu = true;
            }
            else if (patternSelected == "Black Marubozu")
            {
                blackMarubozu = true;
            }
            else if (patternSelected == "Bullish Hammer")
            {
                bullishHammer = true;
            }
            else if (patternSelected == "Inverted Hammer")
            {
                invertedHammer = true;
            }
            else if (patternSelected == "Bullish Engulfing")
            {
                bullishEngulfing = true;
            }
            else if (patternSelected == "Bearish Engulfing")
            {
                bearishEngulfing = true;
            }



            // check the boolean values and call the appropriate method to show the pattern
            if (longLeggedDoji)
            {
                showLongLeggedDoji(candleStickDataSource, chartStock);
            }
            if (gravestoneDoji)
            {
                showGravestoneDoji(candleStickDataSource, chartStock);
            }

            if (neutralDoji)
            {
                showNeutralDoji(candleStickDataSource, chartStock);
            }
            if (dragonflyDoji)
            {
                showDragonflyDoji(candleStickDataSource, chartStock);

            }
            if (whiteMarubozu)
            {
                showWhiteMarubozu(candleStickDataSource, chartStock);

            }
            if (blackMarubozu)
            {
                showBlackMarubozu(candleStickDataSource, chartStock);
            }
            if (bullishHammer)
            {
                showBullishHammer(candleStickDataSource, chartStock);

            }
            if (invertedHammer)
            {
                showInvertedHammer(candleStickDataSource, chartStock);
            }
            if (bullishEngulfing)
            {
                showBullishEngulfing(candleStickDataSource, chartStock);
            }
            if (bearishEngulfing)
            {
                showBearishEngulfing(candleStickDataSource, chartStock);
            }
            //showNeutralDoji(candleStickDataSource, chartStock);
            //showDragonflyDoji(candleStickDataSource, chartStock);
            //showWhiteMarubozu(candleStickDataSource, chartStock);
            //showBlackMarubozu(candleStickDataSource, chartStock);
            //showBullishHammer(candleStickDataSource, chartStock);
            //showInvertedHammer(candleStickDataSource, chartStock);

            //showBullishEngulfing(candleStickDataSource, chartStock);


            // change the size of the chart to match the window by 90% of the size
            chartStock.Size = new Size((int)(chartWindow.Size.Width * 0.9), (int)(chartWindow.Size.Height * 0.9));
            // set the location of the chart to the top  center of the window
            chartStock.Location = new Point((int)(chartWindow.Size.Width * 0.05), 0);
            // show the chart window
            chartWindow.Show();











        }


        /// <summary>
        /// this method makes the grid visible when the form loads
        /// </summary>
        /// <param name="sender"></param> the object that sent the event
        /// <param name="e"></param> the event arguments
        private void Form1_Load(object sender, EventArgs e)
        {
            chartStock.Visible = false;
            // radio button daily is automatically checked
            radioButtonWasChecked(radioButtonDaily, e);
            comboBox_Pattern.Items.Clear();
            List<string> listOfPatterns = new List<string>
            {
                "Long Legged Doji",
                "Gravestone Doji",
                "Neutral Doji",
                "Dragonfly Doji",
                "White Marubozu",
                "Black Marubozu",
                "Bullish Hammer",
                "Inverted Hammer",
                "Bullish Engulfing",
                "Bearish Engulfing"
            };
            comboBox_Pattern.Items.AddRange(listOfPatterns.ToArray());
            // select a random pattern on initial launch
            comboBox_Pattern.SelectedIndex = new Random().Next(0, comboBox_Pattern.Items.Count);

            return;

        }


        /// <summary>
        /// this method makes the grid visible when the grid radio button is checked
        /// and makes the chart invisible
        /// </summary>
        /// <param name="sender"></param> the object that sent the event
        /// <param name="e"></param> the event arguments
        private void radioButtonChart_CheckedChanged(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// this method makes the chart visible when the chart radio button is checked
        /// and makes the grid invisible
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void radioButtonGridView_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
        }
        private void chartStock_Click(object sender, EventArgs e)
        {

        }

        private void dataGridViewStock_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {


        }

        private void radioButtonWasChecked(object sender, EventArgs e)
        {
            string dataFolder = @"Stock Data\";
            // get the radio button that fired the event
            RadioButton radioButton = (RadioButton)sender;
            // if this is the button that was unchecked, do nothing
            if (!radioButton.Checked) return;
            // start with a base string for the filename pattern
            // we first start by assuming the user's choice is daily
            string fileNamesPattern = "*-Day.csv";
            // was weekly chosen
            if (radioButtonWeekly.Checked)
            {
                fileNamesPattern = "*-Week.csv";
            }
            else if (radioButtonMonthly.Checked)
            {
                // was monthly chosen
                fileNamesPattern = "*-Month.csv";
            }
            // now that we have the name pattern , go get all the filenames that match
            string[] filenames = Directory.GetFiles(dataFolder, fileNamesPattern);
            // clear the combo box
            comboBox_Ticker.Items.Clear();
            // create / instantiate a new list of strings to hold the filenames
            List<string> fileNamesList = new List<string>();
            // loop through the filenames
            foreach (string filename in filenames)
            {
                // get the filename without the path
                string filenameOnly = Path.GetFileNameWithoutExtension(filename);
                // add the filename to the list
                fileNamesList.Add(filenameOnly);
            }
            // add the list to the combo box
            comboBox_Ticker.Items.AddRange(fileNamesList.ToArray());
            // select the first item to put in the window
            // if it is empty then the user will be prompted that the period is not available
            if (comboBox_Ticker.Items.Count > 0)

            {
                // make it a random number between 0 and the number of items
                comboBox_Ticker.SelectedIndex = new Random().Next(0, comboBox_Ticker.Items.Count);

            }
            else
            {
                MessageBox.Show("No data available.");

            }
        }

        private void comboBoxTicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            readStockFromComboBox();
        }

        private void candlestickBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// this method reads the stock file from ticker box, the pattern from the pattern box and then connects the chart with the data
        /// </summary>
        private void readStockFromComboBox()
        {
            string dataFolder = @"Stock Data\";
            if (comboBox_Ticker.Text != string.Empty)
            {
                string filename = dataFolder + comboBox_Ticker.Text + ".csv";
                string[] sep = { "-" };
                string[] temp = comboBox_Ticker.Text.Split(sep, StringSplitOptions.RemoveEmptyEntries);
                string ticker = temp[0];
                string period = temp[1];

                CandlestickReader candleStickReaderObject = new();

                List<Candlestick> candleSticks = candleStickReaderObject.readStockFile(filename, dateTimePickerStartDate.Value, dateTimePickerEndDate.Value);

                connectChart(candleSticks, period, comboBox_Pattern.Text);
            }
        }
        private void comboBox_Pattern_SelectedIndexChanged(object sender, EventArgs e)
        {
            readStockFromComboBox();
          
            }


    }

}