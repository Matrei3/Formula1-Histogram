namespace Formula1_Histogram
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.requestButton = new System.Windows.Forms.Button();
            this.yearLabel = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.constructorStandingLabel = new System.Windows.Forms.Label();
            this.constructorTable = new System.Windows.Forms.TableLayoutPanel();
            this.driversTable = new System.Windows.Forms.TableLayoutPanel();
            this.driverStandingsLabel = new System.Windows.Forms.Label();
            this.roundBox = new System.Windows.Forms.ComboBox();
            this.specificRoundLabel = new System.Windows.Forms.Label();
            this.waitingLabel = new System.Windows.Forms.Label();
            this.dominationConstructorChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.seasonConstructorStatisticsLabel = new System.Windows.Forms.Label();
            this.seasonDriverStatisticsLabel = new System.Windows.Forms.Label();
            this.dominationPilotChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.dominationConstructorChart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dominationPilotChart)).BeginInit();
            this.SuspendLayout();
            // 
            // requestButton
            // 
            this.requestButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.requestButton.Font = new System.Drawing.Font("Rockwell", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.requestButton.ForeColor = System.Drawing.Color.Crimson;
            this.requestButton.Location = new System.Drawing.Point(550, 65);
            this.requestButton.Name = "requestButton";
            this.requestButton.Size = new System.Drawing.Size(146, 31);
            this.requestButton.TabIndex = 0;
            this.requestButton.Text = "Get Request";
            this.requestButton.UseVisualStyleBackColor = true;
            this.requestButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // yearLabel
            // 
            this.yearLabel.Location = new System.Drawing.Point(550, 39);
            this.yearLabel.Name = "yearLabel";
            this.yearLabel.Size = new System.Drawing.Size(146, 20);
            this.yearLabel.TabIndex = 2;
            this.yearLabel.TextChanged += new System.EventHandler(this.year_TextChanged);
            this.yearLabel.KeyDown += new System.Windows.Forms.KeyEventHandler(this.button1_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.Control;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label1.Font = new System.Drawing.Font("Rockwell", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.label1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label1.Location = new System.Drawing.Point(500, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(233, 23);
            this.label1.TabIndex = 3;
            this.label1.Text = "Insert Year (1950-2023)";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // constructorStandingLabel
            // 
            this.constructorStandingLabel.AutoSize = true;
            this.constructorStandingLabel.Font = new System.Drawing.Font("Rockwell", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.constructorStandingLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.constructorStandingLabel.Location = new System.Drawing.Point(399, 115);
            this.constructorStandingLabel.Name = "constructorStandingLabel";
            this.constructorStandingLabel.Size = new System.Drawing.Size(275, 29);
            this.constructorStandingLabel.TabIndex = 6;
            this.constructorStandingLabel.Text = "Constructor Standings";
            this.constructorStandingLabel.Visible = false;
            // 
            // constructorTable
            // 
            this.constructorTable.ColumnCount = 2;
            this.constructorTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 86.90308F));
            this.constructorTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 13.09692F));
            this.constructorTable.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.constructorTable.Location = new System.Drawing.Point(404, 147);
            this.constructorTable.Name = "constructorTable";
            this.constructorTable.RowCount = 32;
            this.constructorTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.constructorTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.constructorTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.constructorTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.constructorTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.constructorTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.constructorTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.constructorTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.constructorTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.constructorTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.constructorTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.constructorTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.constructorTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.constructorTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.constructorTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.constructorTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.constructorTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.constructorTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.constructorTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.constructorTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.constructorTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.constructorTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.constructorTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.constructorTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.constructorTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.constructorTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.constructorTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.constructorTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.constructorTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.constructorTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.constructorTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.constructorTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.constructorTable.Size = new System.Drawing.Size(315, 402);
            this.constructorTable.TabIndex = 7;
            this.constructorTable.Visible = false;
            // 
            // driversTable
            // 
            this.driversTable.ColumnCount = 2;
            this.driversTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 90.85873F));
            this.driversTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 9.141274F));
            this.driversTable.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.driversTable.Location = new System.Drawing.Point(12, 147);
            this.driversTable.Name = "driversTable";
            this.driversTable.RowCount = 32;
            this.driversTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.driversTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.driversTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.driversTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.driversTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.driversTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.driversTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.driversTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.driversTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.driversTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.driversTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.driversTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.driversTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.driversTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.driversTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.driversTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.driversTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.driversTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.driversTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.driversTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.driversTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.driversTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.driversTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.driversTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.driversTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.driversTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.driversTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.driversTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.driversTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.driversTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.driversTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.driversTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.driversTable.Size = new System.Drawing.Size(382, 602);
            this.driversTable.TabIndex = 4;
            this.driversTable.Visible = false;
            // 
            // driverStandingsLabel
            // 
            this.driverStandingsLabel.AutoSize = true;
            this.driverStandingsLabel.Font = new System.Drawing.Font("Rockwell", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.driverStandingsLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.driverStandingsLabel.Location = new System.Drawing.Point(12, 115);
            this.driverStandingsLabel.Name = "driverStandingsLabel";
            this.driverStandingsLabel.Size = new System.Drawing.Size(211, 29);
            this.driverStandingsLabel.TabIndex = 5;
            this.driverStandingsLabel.Text = "Driver Standings";
            this.driverStandingsLabel.Visible = false;
            this.driverStandingsLabel.Click += new System.EventHandler(this.label2_Click);
            // 
            // roundBox
            // 
            this.roundBox.FormattingEnabled = true;
            this.roundBox.Location = new System.Drawing.Point(407, 555);
            this.roundBox.Name = "roundBox";
            this.roundBox.Size = new System.Drawing.Size(267, 21);
            this.roundBox.TabIndex = 8;
            this.roundBox.Visible = false;
            this.roundBox.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // specificRoundLabel
            // 
            this.specificRoundLabel.AutoSize = true;
            this.specificRoundLabel.Font = new System.Drawing.Font("Rockwell", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.specificRoundLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.specificRoundLabel.Location = new System.Drawing.Point(403, 595);
            this.specificRoundLabel.Name = "specificRoundLabel";
            this.specificRoundLabel.Size = new System.Drawing.Size(245, 19);
            this.specificRoundLabel.TabIndex = 9;
            this.specificRoundLabel.Text = "Standings after specific round";
            this.specificRoundLabel.Visible = false;
            // 
            // waitingLabel
            // 
            this.waitingLabel.AutoSize = true;
            this.waitingLabel.Font = new System.Drawing.Font("Rockwell", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.waitingLabel.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.waitingLabel.Location = new System.Drawing.Point(702, 78);
            this.waitingLabel.Name = "waitingLabel";
            this.waitingLabel.Size = new System.Drawing.Size(168, 17);
            this.waitingLabel.TabIndex = 10;
            this.waitingLabel.Text = "Waiting for response...";
            this.waitingLabel.Visible = false;
            this.waitingLabel.Click += new System.EventHandler(this.label2_Click_1);
            // 
            // dominationConstructorChart
            // 
            chartArea1.Name = "ChartArea1";
            this.dominationConstructorChart.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.dominationConstructorChart.Legends.Add(legend1);
            this.dominationConstructorChart.Location = new System.Drawing.Point(730, 147);
            this.dominationConstructorChart.Name = "dominationConstructorChart";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Doughnut;
            series1.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            series1.Legend = "Legend1";
            series1.Name = "dominationChart";
            this.dominationConstructorChart.Series.Add(series1);
            this.dominationConstructorChart.Size = new System.Drawing.Size(387, 242);
            this.dominationConstructorChart.TabIndex = 11;
            this.dominationConstructorChart.Text = "dominationChart";
            this.dominationConstructorChart.Visible = false;
            // 
            // seasonConstructorStatisticsLabel
            // 
            this.seasonConstructorStatisticsLabel.AutoSize = true;
            this.seasonConstructorStatisticsLabel.Font = new System.Drawing.Font("Rockwell", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.seasonConstructorStatisticsLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.seasonConstructorStatisticsLabel.Location = new System.Drawing.Point(725, 115);
            this.seasonConstructorStatisticsLabel.Name = "seasonConstructorStatisticsLabel";
            this.seasonConstructorStatisticsLabel.Size = new System.Drawing.Size(215, 29);
            this.seasonConstructorStatisticsLabel.TabIndex = 12;
            this.seasonConstructorStatisticsLabel.Text = "Constructor wins";
            this.seasonConstructorStatisticsLabel.Visible = false;
            // 
            // seasonDriverStatisticsLabel
            // 
            this.seasonDriverStatisticsLabel.AutoSize = true;
            this.seasonDriverStatisticsLabel.Font = new System.Drawing.Font("Rockwell", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.seasonDriverStatisticsLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.seasonDriverStatisticsLabel.Location = new System.Drawing.Point(725, 395);
            this.seasonDriverStatisticsLabel.Name = "seasonDriverStatisticsLabel";
            this.seasonDriverStatisticsLabel.Size = new System.Drawing.Size(151, 29);
            this.seasonDriverStatisticsLabel.TabIndex = 13;
            this.seasonDriverStatisticsLabel.Text = "Driver wins";
            this.seasonDriverStatisticsLabel.Visible = false;
            // 
            // dominationPilotChart
            // 
            chartArea2.Name = "ChartArea1";
            this.dominationPilotChart.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.dominationPilotChart.Legends.Add(legend2);
            this.dominationPilotChart.Location = new System.Drawing.Point(730, 429);
            this.dominationPilotChart.Name = "dominationPilotChart";
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Doughnut;
            series2.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            series2.Legend = "Legend1";
            series2.Name = "dominationChart";
            this.dominationPilotChart.Series.Add(series2);
            this.dominationPilotChart.Size = new System.Drawing.Size(387, 242);
            this.dominationPilotChart.TabIndex = 14;
            this.dominationPilotChart.Text = "chart1";
            this.dominationPilotChart.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1264, 761);
            this.Controls.Add(this.roundBox);
            this.Controls.Add(this.dominationPilotChart);
            this.Controls.Add(this.specificRoundLabel);
            this.Controls.Add(this.seasonDriverStatisticsLabel);
            this.Controls.Add(this.seasonConstructorStatisticsLabel);
            this.Controls.Add(this.dominationConstructorChart);
            this.Controls.Add(this.waitingLabel);
            this.Controls.Add(this.constructorTable);
            this.Controls.Add(this.constructorStandingLabel);
            this.Controls.Add(this.driverStandingsLabel);
            this.Controls.Add(this.driversTable);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.yearLabel);
            this.Controls.Add(this.requestButton);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "F1 Histogram";
            ((System.ComponentModel.ISupportInitialize)(this.dominationConstructorChart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dominationPilotChart)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button requestButton;
        private System.Windows.Forms.TextBox yearLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TableLayoutPanel driversTable;
        private System.Windows.Forms.Label driverStandingsLabel;
        private System.Windows.Forms.Label constructorStandingLabel;
        private System.Windows.Forms.TableLayoutPanel constructorTable;
        private System.Windows.Forms.ComboBox roundBox;
        private System.Windows.Forms.Label specificRoundLabel;
        private System.Windows.Forms.Label waitingLabel;
        private System.Windows.Forms.DataVisualization.Charting.Chart dominationConstructorChart;
        private System.Windows.Forms.Label seasonConstructorStatisticsLabel;
        private System.Windows.Forms.Label seasonDriverStatisticsLabel;
        private System.Windows.Forms.DataVisualization.Charting.Chart dominationPilotChart;
    }
}

