using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
// add reference for legend


namespace StockProgram
{
    public partial class FormStockLoader : Form
    {
        public static List<Recognizer> recognizers = new List<Recognizer>();
        public FormStockLoader()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }




        /// <summary>
        /// Annotate the chart with a rectangle
        /// </summary>
        /// <param name="candleStickDataSource"></param> 
        /// <param name="chart"></param>

       private void annotateChart(List<Candlestick> candleStickDataSource, Chart chart, Recognizer recognizer, List<int> recognized)
        {
            // based on the recognizer pattern selected, annotate the chart
            // for loop going through candlesticks based on recognized list

            foreach (int i in recognized)
            {
                // Get the candlestick at the index
                Candlestick candlestick = candleStickDataSource[i];

                // Create a new rectangle annotation and set its properties
                RectangleAnnotation rectangle = new RectangleAnnotation
                {

                    Width = 0.5,
                    Height = 0.5,
                    // make the color yellow
                    BackColor = Color.Yellow,
                    LineColor = Color.Black,
                    AxisX = chart.ChartAreas[0].AxisX,
                    AxisY = chart.ChartAreas[0].AxisY,
                    X = candlestick.Date.ToOADate(),
                    Y = candlestick.High,
                    AnchorX = candlestick.Date.ToOADate(),
                    AnchorY = candlestick.High,

                };

                // Add the rectangle annotation to the chart annotations collection
                chart.Annotations.Add(rectangle);

            }

            // get the name from the recognizer
            string patternSelected = recognizer.PatternName;
            // set argument to color 
            Color yellow = Color.Yellow;
            // add the color to the legend
            chart.Legends["Legend1"].CustomItems.Add(yellow, patternSelected);
            //add a colored rectangle annotation to highlight the pattern
    


        }

        private void connectChart(List<Candlestick> candleStickDataSource, string period, Recognizer recognizer, List<int> recognized)
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
            // mark the patterns based on the pattern selected
            // using the recognizers
            annotateChart(candleStickDataSource, chartStock, recognizer, recognized);

    






     
           


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
            List <Recognizer> recognizers = new List<Recognizer>();
            // initialize recognizers
            recognizers = initializeRecognizers();

            // select a random pattern on initial launch
            comboBox_Pattern.SelectedIndex = new Random().Next(0, comboBox_Pattern.Items.Count);

            return;

        }

       private List<Recognizer> initializeRecognizers()
       {     
        
        // single candlestick patterns
        recognizers.Add(new BullishRecognizer());
        recognizers.Add(new BearishRecognizer());
        recognizers.Add(new DojiRecognizer());
        recognizers.Add(new MarubozuRecognizer());
        recognizers.Add(new HammerRecognizer());
        recognizers.Add(new BullishInvertedHammerRecognizer());
        recognizers.Add(new BearishInvertedHammerRecognizer());
        recognizers.Add(new SpinningTopRecognizer());
        recognizers.Add(new PaperUmbrellaRecognizer());
        recognizers.Add(new ShootingStarRecognizer());
        recognizers.Add(new HangingManRecognizer());
        recognizers.Add(new InvertedHammerRecognizer());
        recognizers.Add(new BearishHammerRecognizer());
        recognizers.Add(new BullishHammerRecognizer());
        recognizers.Add(new DragonFlyDojiRecognizer());
        recognizers.Add(new GravestoneDojiRecognizer());
        recognizers.Add(new LongLeggedDojiRecognizer());
        recognizers.Add(new NeutralDojiRecognizer());
        // multiple candlestick patterns
        recognizers.Add(new BullishEngulfingPatternRecognizer());
        recognizers.Add(new BearishEngulfingPatternRecognizer());
        recognizers.Add(new DarkCloudCoverRecognizer());
        recognizers.Add(new PiercingPatternRecognizer());
        recognizers.Add(new BullishHaramiRecognizer());
        recognizers.Add(new BearishHaramiRecognizer());
        recognizers.Add(new MorningStarRecognizer());
        recognizers.Add(new EveningStarRecognizer());



        // now add the recognizers to the combo box
        foreach (Recognizer rec in recognizers)
        {
            comboBox_Pattern.Items.Add(rec.PatternName);
        }

        return recognizers;


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

  
        private void candlestickBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }
        private void comboBox_Ticker_SelectedIndexChanged(object sender, EventArgs e)
        {
            // if recognizers is null initialize it
            if (recognizers == null)
            {
                // initialize recognizers
                recognizers = initializeRecognizers();
            }
            // logic check to make sure the index is not out of range
            if (comboBox_Pattern.SelectedIndex < 0 || comboBox_Pattern.SelectedIndex >= recognizers.Count)
            {
                return;
            }
            Recognizer recognizer = recognizers[comboBox_Pattern.SelectedIndex];            
            readStockFromComboBox(recognizer);
        }
        /// <summary>
        /// this method reads the stock file from ticker box, the pattern from the pattern box and then connects the chart with the data
        /// </summary>
        private void readStockFromComboBox(Recognizer recognizer)
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
                List<int> recognized = recognizer.Recognize(candleSticks);





                connectChart(candleSticks, period, recognizer, recognized);
            }
        }
        private void comboBox_Pattern_SelectedIndexChanged(object sender, EventArgs e)
        {
            // if recognizers is null initialize it
            if (recognizers == null)
            {
                // initialize recognizers
                recognizers = initializeRecognizers();
            }
            Recognizer recognizer = recognizers[comboBox_Pattern.SelectedIndex];
            readStockFromComboBox(recognizer);
          
            }


    }
   

}