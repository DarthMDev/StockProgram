namespace StockProgram
{
    partial class FormStockLoader
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.dateTimePickerStartDate = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerEndDate = new System.Windows.Forms.DateTimePicker();
            this.labelTicker = new System.Windows.Forms.Label();
            this.labelStartDate = new System.Windows.Forms.Label();
            this.labelEndDate = new System.Windows.Forms.Label();
            this.chartStock = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.candlestickBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataGridViewStock = new System.Windows.Forms.DataGridView();
            this.candlestickBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.comboBox_Ticker = new System.Windows.Forms.ComboBox();
            this.radioButtonMonthly = new System.Windows.Forms.RadioButton();
            this.radioButtonWeekly = new System.Windows.Forms.RadioButton();
            this.radioButtonDaily = new System.Windows.Forms.RadioButton();
            this.groupBoxPeriod = new System.Windows.Forms.GroupBox();
            this.patternLabel = new System.Windows.Forms.Label();
            this.comboBox_Pattern = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.chartStock)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.candlestickBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewStock)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.candlestickBindingSource1)).BeginInit();
            this.groupBoxPeriod.SuspendLayout();
            this.SuspendLayout();
            // 
            // dateTimePickerStartDate
            // 
            this.dateTimePickerStartDate.Location = new System.Drawing.Point(137, 56);
            this.dateTimePickerStartDate.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.dateTimePickerStartDate.Name = "dateTimePickerStartDate";
            this.dateTimePickerStartDate.Size = new System.Drawing.Size(186, 20);
            this.dateTimePickerStartDate.TabIndex = 2;
            this.dateTimePickerStartDate.Value = new System.DateTime(2022, 1, 1, 0, 0, 0, 0);
            // 
            // dateTimePickerEndDate
            // 
            this.dateTimePickerEndDate.Location = new System.Drawing.Point(137, 94);
            this.dateTimePickerEndDate.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.dateTimePickerEndDate.Name = "dateTimePickerEndDate";
            this.dateTimePickerEndDate.Size = new System.Drawing.Size(186, 20);
            this.dateTimePickerEndDate.TabIndex = 3;
            this.dateTimePickerEndDate.Value = new System.DateTime(2023, 1, 18, 0, 0, 0, 0);
            // 
            // labelTicker
            // 
            this.labelTicker.AutoSize = true;
            this.labelTicker.Location = new System.Drawing.Point(16, 298);
            this.labelTicker.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelTicker.Name = "labelTicker";
            this.labelTicker.Size = new System.Drawing.Size(43, 13);
            this.labelTicker.TabIndex = 4;
            this.labelTicker.Text = "Ticker: ";
            this.labelTicker.Click += new System.EventHandler(this.label1_Click);
            // 
            // labelStartDate
            // 
            this.labelStartDate.AutoSize = true;
            this.labelStartDate.Location = new System.Drawing.Point(35, 58);
            this.labelStartDate.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelStartDate.Name = "labelStartDate";
            this.labelStartDate.Size = new System.Drawing.Size(61, 13);
            this.labelStartDate.TabIndex = 5;
            this.labelStartDate.Text = "Start Date: ";
            // 
            // labelEndDate
            // 
            this.labelEndDate.AutoSize = true;
            this.labelEndDate.Location = new System.Drawing.Point(35, 94);
            this.labelEndDate.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelEndDate.Name = "labelEndDate";
            this.labelEndDate.Size = new System.Drawing.Size(55, 13);
            this.labelEndDate.TabIndex = 6;
            this.labelEndDate.Text = "End Date:";
            // 
            // chartStock
            // 
            chartArea2.Name = "ChartArea1";
            this.chartStock.ChartAreas.Add(chartArea2);
            this.chartStock.DataSource = this.candlestickBindingSource;
            legend2.Name = "Legend1";
            this.chartStock.Legends.Add(legend2);
            this.chartStock.Location = new System.Drawing.Point(553, 27);
            this.chartStock.Margin = new System.Windows.Forms.Padding(2);
            this.chartStock.Name = "chartStock";
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Candlestick;
            series2.Legend = "Legend1";
            series2.Name = "Daily";
            series2.YValuesPerPoint = 4;
            this.chartStock.Series.Add(series2);
            this.chartStock.Size = new System.Drawing.Size(425, 372);
            this.chartStock.TabIndex = 10;
            this.chartStock.Text = "StockChart";
            this.chartStock.Visible = false;
            this.chartStock.Click += new System.EventHandler(this.chartStock_Click);
            // 
            // candlestickBindingSource
            // 
            this.candlestickBindingSource.DataSource = typeof(Candlestick);
            this.candlestickBindingSource.CurrentChanged += new System.EventHandler(this.candlestickBindingSource_CurrentChanged);
            // 
            // dataGridViewStock
            // 
            this.dataGridViewStock.AllowUserToOrderColumns = true;
            this.dataGridViewStock.AutoGenerateColumns = false;
            this.dataGridViewStock.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridViewStock.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridViewStock.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dataGridViewStock.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridViewStock.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewStock.DataSource = this.candlestickBindingSource1;
            this.dataGridViewStock.GridColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.dataGridViewStock.Location = new System.Drawing.Point(472, 27);
            this.dataGridViewStock.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridViewStock.Name = "dataGridViewStock";
            this.dataGridViewStock.RowHeadersWidth = 82;
            this.dataGridViewStock.RowTemplate.Height = 33;
            this.dataGridViewStock.Size = new System.Drawing.Size(483, 364);
            this.dataGridViewStock.TabIndex = 11;
            this.dataGridViewStock.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewStock_CellContentClick);
            // 
            // comboBox_Ticker
            // 
            this.comboBox_Ticker.FormattingEnabled = true;
            this.comboBox_Ticker.Location = new System.Drawing.Point(19, 314);
            this.comboBox_Ticker.Name = "comboBox_Ticker";
            this.comboBox_Ticker.Size = new System.Drawing.Size(126, 21);
            this.comboBox_Ticker.TabIndex = 16;
            this.comboBox_Ticker.SelectedIndexChanged += new System.EventHandler(this.comboBox_Ticker_SelectedIndexChanged);
            // 
            // radioButtonMonthly
            // 
            this.radioButtonMonthly.AutoSize = true;
            this.radioButtonMonthly.Location = new System.Drawing.Point(0, 58);
            this.radioButtonMonthly.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.radioButtonMonthly.Name = "radioButtonMonthly";
            this.radioButtonMonthly.Size = new System.Drawing.Size(62, 17);
            this.radioButtonMonthly.TabIndex = 9;
            this.radioButtonMonthly.Text = "Monthly";
            this.radioButtonMonthly.UseVisualStyleBackColor = true;
            this.radioButtonMonthly.CheckedChanged += new System.EventHandler(this.radioButtonWasChecked);
            // 
            // radioButtonWeekly
            // 
            this.radioButtonWeekly.AutoSize = true;
            this.radioButtonWeekly.Location = new System.Drawing.Point(0, 32);
            this.radioButtonWeekly.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.radioButtonWeekly.Name = "radioButtonWeekly";
            this.radioButtonWeekly.Size = new System.Drawing.Size(61, 17);
            this.radioButtonWeekly.TabIndex = 8;
            this.radioButtonWeekly.Text = "Weekly";
            this.radioButtonWeekly.UseVisualStyleBackColor = true;
            this.radioButtonWeekly.CheckedChanged += new System.EventHandler(this.radioButtonWasChecked);
            // 
            // radioButtonDaily
            // 
            this.radioButtonDaily.AutoSize = true;
            this.radioButtonDaily.Checked = true;
            this.radioButtonDaily.Location = new System.Drawing.Point(0, 15);
            this.radioButtonDaily.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.radioButtonDaily.Name = "radioButtonDaily";
            this.radioButtonDaily.Size = new System.Drawing.Size(48, 17);
            this.radioButtonDaily.TabIndex = 7;
            this.radioButtonDaily.TabStop = true;
            this.radioButtonDaily.Text = "Daily";
            this.radioButtonDaily.UseVisualStyleBackColor = true;
            this.radioButtonDaily.CheckedChanged += new System.EventHandler(this.radioButtonWasChecked);
            // 
            // groupBoxPeriod
            // 
            this.groupBoxPeriod.Controls.Add(this.radioButtonDaily);
            this.groupBoxPeriod.Controls.Add(this.radioButtonWeekly);
            this.groupBoxPeriod.Controls.Add(this.radioButtonMonthly);
            this.groupBoxPeriod.Location = new System.Drawing.Point(19, 149);
            this.groupBoxPeriod.Margin = new System.Windows.Forms.Padding(2);
            this.groupBoxPeriod.Name = "groupBoxPeriod";
            this.groupBoxPeriod.Padding = new System.Windows.Forms.Padding(2);
            this.groupBoxPeriod.Size = new System.Drawing.Size(126, 76);
            this.groupBoxPeriod.TabIndex = 14;
            this.groupBoxPeriod.TabStop = false;
            this.groupBoxPeriod.Text = "Period";
            // 
            // patternLabel
            // 
            this.patternLabel.AutoSize = true;
            this.patternLabel.Location = new System.Drawing.Point(194, 298);
            this.patternLabel.Name = "patternLabel";
            this.patternLabel.Size = new System.Drawing.Size(44, 13);
            this.patternLabel.TabIndex = 17;
            this.patternLabel.Text = "Pattern:";
            // 
            // comboBox_Pattern
            // 
            this.comboBox_Pattern.FormattingEnabled = true;
            this.comboBox_Pattern.Location = new System.Drawing.Point(197, 313);
            this.comboBox_Pattern.Name = "comboBox_Pattern";
            this.comboBox_Pattern.Size = new System.Drawing.Size(121, 21);
            this.comboBox_Pattern.TabIndex = 18;
            this.comboBox_Pattern.SelectedIndexChanged += new System.EventHandler(this.comboBox_Pattern_SelectedIndexChanged);
            // 
            // FormStockLoader
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(989, 410);
            this.Controls.Add(this.comboBox_Pattern);
            this.Controls.Add(this.patternLabel);
            this.Controls.Add(this.comboBox_Ticker);
            this.Controls.Add(this.chartStock);
            this.Controls.Add(this.dataGridViewStock);
            this.Controls.Add(this.groupBoxPeriod);
            this.Controls.Add(this.labelEndDate);
            this.Controls.Add(this.labelStartDate);
            this.Controls.Add(this.labelTicker);
            this.Controls.Add(this.dateTimePickerEndDate);
            this.Controls.Add(this.dateTimePickerStartDate);
            this.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.Name = "FormStockLoader";
            this.Text = "Stock Viewer";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chartStock)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.candlestickBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewStock)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.candlestickBindingSource1)).EndInit();
            this.groupBoxPeriod.ResumeLayout(false);
            this.groupBoxPeriod.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Button buttonLoad;
        private DateTimePicker dateTimePickerStartDate;
        private DateTimePicker dateTimePickerEndDate;
        private Label labelTicker;
        private Label labelStartDate;
        private Label labelEndDate;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartStock;
        private BindingSource candlestickBindingSource;
        public DataGridView dataGridViewStock;
        private DataGridViewTextBoxColumn dateDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn openDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn highDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn lowDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn closeDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn volumeDataGridViewTextBoxColumn;
        private BindingSource candlestickBindingSource1;
        private ComboBox comboBox_Ticker;
        private RadioButton radioButtonMonthly;
        private RadioButton radioButtonWeekly;
        private RadioButton radioButtonDaily;
        private GroupBox groupBoxPeriod;
        private Label patternLabel;
        private ComboBox comboBox_Pattern;
    }
}