using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
namespace Formula1_Histogram
{
    public partial class Form1 : Form
    {
        XNamespace _ns = "http://ergast.com/mrd/1.5";
        Dictionary<string, System.Drawing.Bitmap> _flagMapDrivers = new Dictionary<string, System.Drawing.Bitmap>();
        Dictionary<string, System.Drawing.Bitmap> _flagMapConstructors = new Dictionary<string, System.Drawing.Bitmap>();
        Dictionary<string, int> _roundToNumber = new Dictionary<string, int>();
        List<Task<string>> _httpRequestList = new List<Task<string>>();
        Dictionary<int, string> _urlForEachThread = new Dictionary<int, string>();
        SoundPlayer _soundPlayer = new SoundPlayer();
        int _constructorNumber = 20;
        int _year;
        public Form1()
        {
            InitializeComponent();
        }
        /// <summary>
        /// If the button ENTER is pressed send request without the need of pressing the button.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void button1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
               button1_Click(sender, e);
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }
        /// <summary>
        /// Return the image coresponding to the nation flag given by the nationality.
        /// </summary>
        /// <param name="nationality"></param>
        /// <returns></returns>
        private System.Drawing.Bitmap getImageByNationality(string nationality)
        {   if(nationality=="argentine")
            return Properties.Resources.icons8_argentina_48;
            if (nationality == "australian")
                return Properties.Resources.icons8_australia_48;
            if (nationality == "austrian")
                return Properties.Resources.icons8_austria_48;
            if (nationality == "belgian")
                return Properties.Resources.icons8_belgium_48;
            if (nationality == "brazilian")
                return Properties.Resources.icons8_brazil_48;
            if (nationality == "canadian")
                return Properties.Resources.icons8_canada_flag_48;
            if (nationality == "chilean")
                return Properties.Resources.icons8_chile_48;
            if (nationality == "chinese")
                return Properties.Resources.icons8_china_48;
            if (nationality == "colombian")
                return Properties.Resources.icons8_colombia_flag_48;
            if (nationality == "czech")
                return Properties.Resources.icons8_czech_republic_48;
            if (nationality == "danish")
                return Properties.Resources.icons8_denmark_48;
            if (nationality == "finnish")
                return Properties.Resources.icons8_finland_48;
            if (nationality == "french")
                return Properties.Resources.icons8_france_48;
            if (nationality == "german")
                return Properties.Resources.icons8_germany_flag_48;
            if (nationality == "british")
                return Properties.Resources.icons8_great_britain_48;
            if (nationality == "hungarian")
                return Properties.Resources.icons8_hungarian_flag_48;
            if (nationality == "indian")
                return Properties.Resources.icons8_india_flag_48;
            if (nationality == "indonesian")
                return Properties.Resources.icons8_indonesia_48;
            if (nationality == "irish")
                return Properties.Resources.icons8_ireland_flag_48;
            if (nationality == "italian")
                return Properties.Resources.icons8_italian_flag_48;
            if (nationality == "japanese")
                return Properties.Resources.icons8_japan_48;
            if (nationality == "malaysian")
                return Properties.Resources.icons8_malaysia_flag_48;
            if (nationality == "mexican")
                return Properties.Resources.icons8_mexico_48;
            if (nationality == "monegasque")
                return Properties.Resources.icons8_monaco_48;
            if (nationality == "moroccan")
                return Properties.Resources.icons8_morocco_48;
            if (nationality == "dutch")
                return Properties.Resources.icons8_netherlands_flag_481;
            if (nationality == "new zealander")
                return Properties.Resources.icons8_new_zealand_48;
            if (nationality == "polish")
                return Properties.Resources.icons8_poland_48;
            if (nationality == "portuguese")
                return Properties.Resources.icons8_portugal_48;
            if (nationality == "russian")
                return Properties.Resources.icons8_russian_federation_48;
            if (nationality == "south african")
                return Properties.Resources.icons8_south_africa_48;
            if (nationality == "spanish")
                return Properties.Resources.icons8_spain_flag_48;
            if (nationality == "swedish")
                return Properties.Resources.icons8_sweden_48;
            if (nationality == "swiss")
                return Properties.Resources.icons8_switzerland_48;
            if (nationality == "thai")
                return Properties.Resources.icons8_thailand_48;
            if (nationality == "american")
                return Properties.Resources.icons8_usa_flag_48;
            if (nationality == "venezuelan")
                return Properties.Resources.icons8_venezuela_48;
            if (nationality == "uruguayan")
                return Properties.Resources.icons8_uruguay_flag_48;
            if (nationality == "zimbabwean")
                return Properties.Resources.icons8_zimbabwe_flag_48;
            return Properties.Resources.icons8_question_mark_50;
        }
        /// <summary>
        /// Configures the driver/constructor standings according to the given year.
        /// </summary>
        private async void configureStandings()
        {   //Make sure year is valid and is different from last request to minimize bad requests
            if (_year != int.Parse(yearLabel.Text) && int.Parse(yearLabel.Text)>=1950 && int.Parse(yearLabel.Text) <= 2023)
            {
                _year = int.Parse(yearLabel.Text);

                //Links for requests needed to get all the data
                string driverAPI = $"https://ergast.com/api/f1/{yearLabel.Text}/driverStandings";
                string constructorAPI = $"https://ergast.com/api/f1/{yearLabel.Text}/constructorStandings";
                string roundAPI = $"https://ergast.com/api/f1/{yearLabel.Text}";
                List<string> urlList = new List<string>();
                _httpRequestList.Clear();
                urlList.Add(driverAPI); 
                urlList.Add(constructorAPI); 
                urlList.Add(roundAPI);
                foreach(string  url in urlList)
                {   //Making things concurrently using threads to fasten the process
                    _httpRequestList.Add(MakeHttpRequestAsync(url));
                }

                var results = await Task.WhenAll(_httpRequestList);//Wait for all threads to end
                List<string> resultList = new List<string>();
                foreach(var result in results)
                {
                    resultList.Add(result);
                }

                //Parsing the header of the XML file
                XDocument driverDocument = XDocument.Parse(resultList[0]);
                XDocument constructorDocument = XDocument.Parse(resultList[1]);
                XDocument roundDocument = XDocument.Parse(resultList[2]);

                //The actual data that will be processed
                var drivers = driverDocument.Descendants(_ns + "Driver");
                var driverStandings = driverDocument.Descendants(_ns + "DriverStanding");
                var constructors = constructorDocument.Descendants(_ns + "ConstructorStanding");
                var rounds = roundDocument.Descendants(_ns + "Race");
                var constructorForEachDriver = driverDocument.Descendants(_ns + "Constructor");

                //Where the data will be eventually stored 
                List<Tuple<string, string>> driverNameList = new List<Tuple<string, string>>();
                List<string> driverPoints = new List<string>();
                List<Tuple<string, double>> constructorPointsList = new List<Tuple<string, double>>();
                List<string> constructorForDriver = new List<string>();
                Dictionary<string, double> winsForEachConstructor = new Dictionary<string, double>();
                Dictionary<string, double> winsForEachDriver = new Dictionary<string, double>();

                //Show the layout once the data is retrieved
                driversTable.Visible = true;
                constructorTable.Visible = true;
                dominationConstructorChart.Visible = true;
                dominationPilotChart.Visible = true;
                seasonConstructorStatisticsLabel.Visible = true;
                seasonDriverStatisticsLabel.Visible = true;
                driverStandingsLabel.Visible = true;
                constructorStandingLabel.Visible = true;
                roundBox.Visible = true;
                roundBox.DropDownStyle = ComboBoxStyle.DropDownList;
                roundBox.Enabled = true;
                roundBox.BringToFront();
                roundBox.Items.Clear();
                specificRoundLabel.Visible = true;
                specificRoundLabel.BringToFront();
                
                foreach(var constructor in driverStandings)
                {
                    constructorForDriver.Add(constructor.Element(_ns + "Constructor").Element(_ns + "Name")?.Value.Substring(0,3).ToUpper());
                    //Convert the constructor name to a 3 upper char name (i.e mercedes => MER) and adds it to the list of constructors 
                }
                foreach (var names in drivers)
                {
                    string givenName = names.Element(_ns + "GivenName")?.Value;
                    string givenFamilyName = names.Element(_ns + "FamilyName")?.Value;
                    string givenNationality = names.Element(_ns + "Nationality")?.Value;
                    driverNameList.Add(new Tuple<string, string>(givenName, givenFamilyName));
                    _flagMapDrivers[givenName + givenFamilyName] = getImageByNationality(givenNationality.ToLower());
                    //Configure the dictionary with names and nationalities

                }
                foreach (var driver in driverStandings)
                {
                    string driverPoint = driver.Attribute("points")?.Value;
                    string driverWins = driver.Attribute("wins")?.Value;
                    string driverCode = driver.Element(_ns + "Driver").Attribute("code")?.Value;// i.e Hamilton => HAM(code)
                    if (driverCode != null)
                    { 
                        winsForEachDriver[driverCode] = double.Parse(driverWins); 
                    }
                    else
                    {
                        ///Exception where driver code in invalid
                        driverCode = driver.Element(_ns + "Driver").Element(_ns + "FamilyName")?.Value.Substring(0, 3).ToUpper();
                        winsForEachDriver[driverCode] = double.Parse(driverWins);
                    }
                    driverPoints.Add(driverPoint);
                }
                dominationConstructorChart.Series["dominationChart"].Points.Clear();
                dominationPilotChart.Series["dominationChart"].Points.Clear();
                foreach (var constructor in constructors)
                {
                    string constructorPoints = constructor.Attribute("points")?.Value;
                    string constructorWins = constructor.Attribute("wins")?.Value;
                    string constructorName = constructor.Element(_ns + "Constructor").Element(_ns + "Name")?.Value;
                    string constructorNationality = constructor.Element(_ns + "Constructor").Element(_ns + "Nationality")?.Value;
                    _flagMapConstructors[constructorName] = getImageByNationality(constructorNationality.ToLower());
                    winsForEachConstructor[constructorName] = double.Parse(constructorWins);
                    constructorPointsList.Add(new Tuple<string, double>(constructorName, double.Parse(constructorPoints)));
                }
                
                int roundNumber = 1;
                roundBox.Items.Add("Select Round");//The default selection in the combobox
                foreach (var round in rounds)
                {   //Add each round from the season to the combobox
                    string givenRound = round.Element(_ns + "RaceName")?.Value;
                    roundBox.Items.Add(givenRound);
                    _roundToNumber[givenRound] = roundNumber;
                    roundNumber++;
                }
                seasonConstructorStatisticsLabel.Text = $"Constructor wins out of {roundBox.Items.Count - 1} rounds";
                foreach(var constructor in winsForEachConstructor)
                {   //Add only the winning constructors
                    if(constructor.Value!=0)
                        dominationConstructorChart.Series["dominationChart"].Points.AddXY($"{constructor.Key} \n{((constructor.Value / (roundBox.Items.Count - 1)) * 100).ToString("F2")}%", $"{(constructor.Value / (roundBox.Items.Count-1)) * 100}");
                }
                seasonDriverStatisticsLabel.Text = $"Driver wins out of {roundBox.Items.Count - 1} rounds";
                foreach (var driver in winsForEachDriver)
                {   //Add only the winning drivers
                    if (driver.Value!=0)
                        dominationPilotChart.Series["dominationChart"].Points.AddXY($"{driver.Key} \n{((driver.Value / (roundBox.Items.Count - 1)) * 100).ToString("F2")}%", $"{(driver.Value / (roundBox.Items.Count - 1)) * 100}");
                }
                driversTable.Controls.Clear();//Clear the data that will be replaced
                driversTable.RowCount = driverNameList.Count;//Set the number of rows to the number of drivers
                int number = 1;
                int pointIndex = 0;
                int constructorForEachDriverIndex = 0;
                foreach (Tuple<string, string> driver in driverNameList)
                {
                    
                    Label nameLabel = new Label();
                    Label nationLabel = new Label();
                    nameLabel.AutoSize = true;     
                    nationLabel.Image = _flagMapDrivers[driver.Item1 + driver.Item2];//Set the nation flag of the driver
                    nationLabel.ImageAlign = ContentAlignment.MiddleRight;
                    string fullName = driver.Item1 + " " + driver.Item2 + $"({constructorForDriver[constructorForEachDriverIndex]}) " + driverPoints[pointIndex] + "p";
                    nameLabel.Text = number.ToString() + ". " + fullName;

                    //The first three are highlighted
                    if (number == 1)
                        nameLabel.ForeColor = Color.Gold;
                    if (number == 2)
                        nameLabel.ForeColor = Color.Silver;
                    if (number == 3)
                        nameLabel.ForeColor = Color.Brown;

                    driversTable.Controls.Add(nameLabel);
                    driversTable.Controls.Add(nationLabel);
                    pointIndex++;
                    number++;
                    constructorForEachDriverIndex++;
                }
                number = 1;
                constructorTable.Controls.Clear();//Clear the data that will be replaced
                constructorTable.RowCount = constructorPointsList.Count;//Set the number of rows to the number of constructors

                //Adjust the label and the combobox according to the number of constructors (geometry 🤩)
                roundBox.Location = new Point(roundBox.Location.X, roundBox.Location.Y - 20 * (_constructorNumber - constructorPointsList.Count));
                _constructorNumber = constructorPointsList.Count;
                specificRoundLabel.Location = new Point(roundBox.Location.X, roundBox.Location.Y - 20 * (_constructorNumber - constructorPointsList.Count) + 25);

                roundBox.SelectedIndex = 0;//Default selected item is "Select Round"
                foreach (Tuple<string, double> constructor in constructorPointsList)
                {
                    Label nameLabel = new Label();
                    Label nationLabel = new Label();
                    nameLabel.AutoSize = true;
                    nationLabel.Image = _flagMapConstructors[constructor.Item1];
                    nationLabel.ImageAlign = ContentAlignment.MiddleRight;
                    string fullName = constructor.Item1 + " " + constructor.Item2 + "p";
                    nameLabel.Text = number.ToString() + ". " + fullName;

                    //The first three are highlighted
                    if (number == 1)
                        nameLabel.ForeColor = Color.Gold;
                    if (number == 2)
                        nameLabel.ForeColor = Color.Silver;
                    if (number == 3)
                        nameLabel.ForeColor = Color.Brown;
                    constructorTable.Controls.Add(nameLabel);
                    constructorTable.Controls.Add(nationLabel);
                    number++;
                }
            }
        }

        static async Task<string> MakeHttpRequestAsync(string url)
        {   //Simplest way of getting the XML data
            HttpClient httpClient = new HttpClient();
            HttpResponseMessage response = await httpClient.GetAsync(url);
            string content = await response.Content.ReadAsStringAsync();
            return content;
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            configureStandings();
        }
        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void year_TextChanged(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// Configures the standings according to the selected round.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {   //Only request data if the selected round is valid
            if(roundBox.Text == "Select Round")
            {
                raceNameLabel.Visible = false;
                afterRaceClasification.Visible = false;
                seasonConstructorStatisticsLabel.Visible = true;
                seasonDriverStatisticsLabel.Visible = true;
                dominationConstructorChart.Visible = true;
                dominationPilotChart.Visible = true;
            }
            if (roundBox.Text != "Select Round")
            {
                
                string driverAfterRoundAPI = $"http://ergast.com/api/f1/{_year}/{_roundToNumber[roundBox.Text]}/driverStandings";
                string constructorAfterRoundAPI = $"http://ergast.com/api/f1/{_year}/{_roundToNumber[roundBox.Text]}/constructorStandings";
                string raceResultsAPI = $"http://ergast.com/api/f1/{_year}/{_roundToNumber[roundBox.Text]}/results";
                List<string> urlList = new List<string>();
                _httpRequestList.Clear();
                urlList.Add(driverAfterRoundAPI);
                urlList.Add(constructorAfterRoundAPI);
                urlList.Add(raceResultsAPI);
                foreach (string url in urlList)
                {
                    _httpRequestList.Add(MakeHttpRequestAsync(url));
                }
                var results = await Task.WhenAll(_httpRequestList);
                List<string> resultList = new List<string>();
                foreach (var result in results)
                {
                    resultList.Add(result);
                }

                List<Tuple<string, string>> driverNameList = new List<Tuple<string, string>>();
                List<Tuple<string, string>> constructorNameList = new List<Tuple<string, string>>();
                List<string> constructorForDriver = new List<string>();

                XDocument afterSpecificRoundDriverDocument = XDocument.Parse(resultList[0]);
                XDocument afterSpecificRoundConstructorDocument = XDocument.Parse(resultList[1]);
                XDocument specificRaceResultsDocument = XDocument.Parse(resultList[2]);

                var drivers = afterSpecificRoundDriverDocument.Descendants(_ns + "DriverStanding");
                var constructors = afterSpecificRoundConstructorDocument.Descendants(_ns + "ConstructorStanding");
                var roundResults = specificRaceResultsDocument.Descendants(_ns + "Result");

                foreach (var driver in drivers)
                {
                    string givenPoints = driver.Attribute("points")?.Value;
                    string givenName = driver.Element(_ns + "Driver").Element(_ns + "GivenName")?.Value;
                    string givenFamilyName = driver.Element(_ns + "Driver").Element(_ns + "FamilyName")?.Value;
                    string givenNationality = driver.Element(_ns + "Driver").Element(_ns + "Nationality")?.Value;
                    string givenConstructor = driver.Element(_ns + "Constructor").Element(_ns + "Name")?.Value;
                    driverNameList.Add(new Tuple<string, string>(givenName + " " + givenFamilyName, givenPoints));
                    constructorForDriver.Add(givenConstructor.Substring(0,3).ToUpper());
                    _flagMapDrivers[Regex.Replace(givenName + givenFamilyName, @"\s", "")] = getImageByNationality(givenNationality.ToLower());
                }
                foreach (var constructor in constructors)
                {
                    string constructorPoint = constructor.Attribute("points")?.Value;
                    string constructorName = constructor.Element(_ns + "Constructor").Element(_ns + "Name")?.Value;
                    string constructorNationality = constructor.Element(_ns + "Constructor").Element(_ns + "Nationality")?.Value;
                    _flagMapConstructors[constructorName] = getImageByNationality(constructorNationality.ToLower());

                    constructorNameList.Add(new Tuple<string, string>(constructorName, constructorPoint));
                }
                int numberFinished = 1;
                string fastestLap;
                string numberOfLaps = "100";
                List<string> raceResultsList = new List<string>();
                foreach(var driver in roundResults)
                {    
                    string givenCode = driver.Element(_ns + "Driver").Element(_ns + "FamilyName")?.Value;
                    string constructorName = driver.Element(_ns + "Constructor").Element(_ns + "Name")?.Value;
                    string driverLabel = driverLabel = $"{numberFinished}. {givenCode} ({constructorName.Substring(0,3).ToUpper()}) ";
                    string numberOfPoints = driver.Attribute("points")?.Value;
                    try
                    {
                        if(driver.Element(_ns + "FastestLap").Attribute("rank")?.Value == "1")
                        {
                            fastestLap = driver.Element(_ns + "FastestLap").Element(_ns + "Time")?.Value;
                            driverLabel += fastestLap;
                        }
                    }
                    catch(Exception ex)
                    {

                    }
                    driverLabel += $" {numberOfPoints}p";
                    string finishStatus = driver.Element(_ns + "Status")?.Value;
                    if (finishStatus != "Finished" && finishStatus.Substring(0,1)!= "+")
                    {
                        driverLabel += " DNF";
                    }
                    raceResultsList.Add(driverLabel);
                    numberFinished++;
                }
                driversTable.Controls.Clear();
                afterRaceClasification.BringToFront();
                afterRaceClasification.Controls.Clear();
                afterRaceClasification.RowCount = raceResultsList.Count;
                driversTable.RowCount = driverNameList.Count;
                int number = 1;
                int pointIndex = 0;
                int constructorForEachDriverIndex = 0;
                foreach (Tuple<string, string> driver in driverNameList)
                {
                    Label nameLabel = new Label();
                    nameLabel.AutoSize = true;
                    Label nationLabel = new Label();
                    nationLabel.Image = _flagMapDrivers[Regex.Replace(driver.Item1, @"\s", "")];
                    nationLabel.ImageAlign = ContentAlignment.MiddleRight;
                    string fullName = driver.Item1 + $"({constructorForDriver[constructorForEachDriverIndex]}) " + driver.Item2 + "p";
                    nameLabel.Text = number.ToString() + ". " + fullName;
                    if (number == 1)
                        nameLabel.ForeColor = Color.Gold;
                    if (number == 2)
                        nameLabel.ForeColor = Color.Silver;
                    if (number == 3)
                        nameLabel.ForeColor = Color.Brown;

                    driversTable.Controls.Add(nameLabel);
                    driversTable.Controls.Add(nationLabel);
                    pointIndex++;
                    number++;
                    constructorForEachDriverIndex++;


                }
                number = 1;
                constructorTable.Controls.Clear();
                constructorTable.RowCount = constructorNameList.Count;
                roundBox.Location = new Point(roundBox.Location.X, roundBox.Location.Y - 20 * (_constructorNumber - constructorNameList.Count));
                _constructorNumber = constructorNameList.Count;
                specificRoundLabel.Location = new Point(roundBox.Location.X, roundBox.Location.Y - 20 * (_constructorNumber - constructorNameList.Count) + 25);
                foreach (Tuple<string, string> constructor in constructorNameList)
                {
                    Label nameLabel = new Label();
                    Label nationLabel = new Label();
                    nameLabel.AutoSize = true;
                    nationLabel.Image = _flagMapConstructors[constructor.Item1];
                    nationLabel.ImageAlign = ContentAlignment.MiddleRight;
                    string fullName = constructor.Item1 + " " + constructor.Item2 + "p";
                    nameLabel.Text = number.ToString() + ". " + fullName;
                    if (number == 1)
                        nameLabel.ForeColor = Color.Gold;
                    if (number == 2)
                        nameLabel.ForeColor = Color.Silver;
                    if (number == 3)
                        nameLabel.ForeColor = Color.Brown;
                    constructorTable.Controls.Add(nameLabel);
                    constructorTable.Controls.Add(nationLabel);
                    number++;
                }
                number = 1;
                foreach (string driver in raceResultsList)
                {
                    Label nameLabel = new Label();
                    nameLabel.AutoSize = true;
                    nameLabel.Text = driver;
                    if (number == 1)
                        nameLabel.ForeColor = Color.Gold;
                    if (number == 2)
                        nameLabel.ForeColor = Color.Silver;
                    if (number == 3)
                        nameLabel.ForeColor = Color.Brown;
                    if (driver.Contains(":"))
                        nameLabel.ForeColor = Color.Purple;
                    afterRaceClasification.Controls.Add(nameLabel);
                    number++;
                }
                raceNameLabel.Text = roundBox.Text;
                raceNameLabel.Visible = true;
                afterRaceClasification.Visible = true;
                seasonConstructorStatisticsLabel.Visible = false;
                seasonDriverStatisticsLabel.Visible = false;
                dominationConstructorChart.Visible = false;
                dominationPilotChart.Visible = false;
            }
        }

        private void label2_Click_1(object sender, EventArgs e)
        {

        }
    }
}
