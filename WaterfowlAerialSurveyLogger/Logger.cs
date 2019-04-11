using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading;
using System.Media;
//using System.Speech.Synthesis;

using System.Device.Location;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Input = Microsoft.Xna.Framework.Input;



namespace WaterfowlAerialSurveyLogger
{
    #region LOGGER
    public partial class Logger : Form
    {
        //SpeechSynthesizer voice = new SpeechSynthesizer();

        public string keyPressed;
        public static string filePath; //path to the folder where results are stored
        public static string fileLog; // path to folder
        public static string fileData; // path to folder
        public static string fileDataName ; // file name for data
        public static string fileTrackLogName; // file name for track log
        public string aerialSurveyData;
        public string aerialSurveyTrack;
        public string sessionInfo;
        public string observerName;
        public string observerPosition;
        string format = "dddd dd MM yyyy hh_mm_ss tt";
        public string t;
        public string species; // for keeping track of the species recorded
        DateTime todayDate = DateTime.Now;
        string gamepadKeys = "helicopter"; // "fixedWing"; // "helicopter"
        //InputScope = "Number";
        string cloudCover;
        decimal temperature;
        decimal wind;
        

        // for the controller
        public GamePadState gamePadState;
        public GamePadState previousState;
        public PlayerIndex playerIndex;
        public SoundPlayer sp;
        public int vibrationCountdown = 0;
        public bool break_on = false;
        //left trigger
        //bool _lt = true;
        //right trigger
        //bool _rt = true;
        //bool lThumbstickStateDown = true;
        //bool lThumbstickStateLeft = true;
        //bool lThumbstickStateRight = true;
        //bool lThumbstickStateUp = true;
        bool leftThumbstickReleased = true;
        bool rightThumbstickReleased = true;
        float thumbstickTolerance = 0.5f;
        float triggerTolerance = 0.5f;
        bool leftTriggerReleased = true;
        bool rightTriggerReleased = true;

        // for the GPS
        public GeoCoordinateWatcher _locationWatcher;
        public double latitude;
        public double longitude;
        public double altitude;
        public string UTC;
        public double speed;
        public double bearing;
        public string UTCLocalTime;
        public long UTCTicks;
        public double HDOP; // horizontal dilution of precision (accuracy)
        public double VDOP; // vertical dilution of precision (accuracy)
        //*************************************************************

        public Logger()
        {
            InitializeComponent();
        }

        private void Logger_Load(object sender, EventArgs e)
        {
            controllerTimer.Enabled = false;
            tracklogTimer.Enabled = false;
            t = todayDate.ToString(format); // for testing

            // create watchers for GPS locations
            _locationWatcher = new GeoCoordinateWatcher(GeoPositionAccuracy.High); // location data for tracklog and observations
            //_locationWatcher.MovementThreshold = 5;
            _locationWatcher.PositionChanged += PositionChanged;
            _locationWatcher.StatusChanged += StatusChanged;
            _locationWatcher.Start();
        }

        private void AboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using(AboutBox1 box = new AboutBox1())
            {
                box.ShowDialog(this);
            }
        }

        public void UpdateTextBox(string text)
        {
             txtDataStream.AppendText(text);
        }

        // monitor the get controller state and update if there is a key pressed
        private void ControllerTimer_Tick(object sender, EventArgs e)
        {
            //CheckVibrationTimeout();
            //Controller gp = new Controller();
            UpDateController();
        }

        public void WriteDataOnSameLine(string newData) 
        {
            string p = fileData;
            string n = fileDataName;
            using(StreamWriter sr = new StreamWriter(p + n, true))
            {
                sr.Write(newData);
            }
        }

        public void WriteDataStartNewline(string newData)
        {
            string p = fileData;
            string n = fileDataName;
            using (StreamWriter sr = new StreamWriter(p + n, true))
            {
                sr.Write(newData + Environment.NewLine);
            }
        }

        private void BtnStart_Click(object sender, EventArgs e)
        {
            if (btnStart.Text == "Start")
            {
                // create file to store data
                // create 'AerialSurveyResults' folder on the desktop
                filePath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                fileData = filePath + @"\AerialSurveyResults\";
                fileLog = filePath + @"\AerialSurveyResults\Tracklog\";
                if (!Directory.Exists(fileData)) // write the folder for the data
                {
                    Directory.CreateDirectory(fileData);
                }
                if (!Directory.Exists(fileLog)) // write the folder for the track log
                {
                    Directory.CreateDirectory(fileLog);
                }

                if (rdbAM.Checked) // session
                {
                    sessionInfo = "AM";
                }
                else if (rdbPM.Checked)
                {
                    sessionInfo = "PM";
                }
                else
                {
                    System.Windows.Forms.MessageBox.Show("You must select a session", "Select session",
                        MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                    return;
                }
                // observer
                observerName = Regex.Replace(cmbObserver.Text, @"[^A-Z]+", String.Empty); // just record first letter of each word
                if (observerName == "")
                {
                    System.Windows.Forms.MessageBox.Show("You must select an observer", "Select observer",
                        MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                    return;
                }
                if (!rdbRightFront.Checked & !rdbRightRear.Checked &!rdbLeftFront.Checked & !rdbLeftMid.Checked) // position
                {
                    observerPosition = "LeftRear";
                }
                else if (!rdbRightFront.Checked & !rdbLeftRear.Checked & !rdbLeftFront.Checked & !rdbLeftMid.Checked)
                {
                    observerPosition = "RightRear";
                }
                else if (!rdbLeftRear.Checked & !rdbRightFront.Checked & !rdbRightRear.Checked & !rdbLeftMid.Checked)
                {
                    observerPosition = "LeftFront";
                }
                else if (!rdbLeftRear.Checked & !rdbRightFront.Checked & !rdbRightRear.Checked & !rdbLeftFront.Checked)
                {
                    observerPosition = "LeftMiddle";
                }
                else
                {
                    observerPosition = "RightFront";
                }
                if (!rdbRightFront.Checked & !rdbRightRear.Checked & !rdbLeftRear.Checked & !rdbLeftFront.Checked & !rdbLeftMid.Checked) // nothing checked
                {
                    System.Windows.Forms.MessageBox.Show("You must select a position", "Select position",
                         MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                    return;
                }

                //if (cmbCloud.Text != "")
                //{
                //    cloudCover = cmbCloud.Text;
                //}
                //else
                //{
                //    cloudCover = "NA";
                //}
                
                //if (txtTemperature.Text != "")
                //{
                //    temperature = float.Parse(txtTemperature.Text);
                //}
                //else
                //{
                //    temperature = -9999;
                //}
                    
                //if (txtWind.Text != "")
                //{
                //    wind = float.Parse(txtWind.Text);
                //}
                //else
                //{
                //    wind = -9999;
                //}
                

                // all good so enable and start the controller
                controllerTimer.Enabled = true;
                tracklogTimer.Enabled = true;
                controllerTimer.Start();
                fileDataName = t + "_" + sessionInfo + "_" + observerName + "_" + observerPosition + ".dat";
                fileTrackLogName = t + "_" + sessionInfo + "_" + observerName + "_" + observerPosition + ".log";
                btnStart.Text = "Stop"; // all good so far, so proceed to write file
                TextWriter dw = new StreamWriter(fileData + fileDataName, true); // for debug
                TextWriter lw = new StreamWriter(fileLog + fileTrackLogName, true);
                dw.WriteLine(t + "_" + sessionInfo + "_" + observerName + "_" + observerPosition);
                lw.WriteLine(t + "_" + sessionInfo + "_" + observerName + "_" + observerPosition);
                dw.Close();
                lw.Close();
                txtDataStream.Focus();
                txtDataStream.Text = "OEH Aerial Survey Data File, " + 
                    System.DateTime.Now.ToString("dd MM yyyy, hh:mm:ss tt") + Environment.NewLine;
            }
            else
            {
                var result = System.Windows.Forms.MessageBox.Show("Are you sure you want to stop?", "End Recording",
                    MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    // TODO ensure the streamwriter closes properly
                    btnStart.Text = "Start";
                }
            }
        }

        private void QuitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _locationWatcher.Stop();
            Application.Exit();
        }

        public void ScrollToLastLine()
        {
            txtDataStream.ScrollToCaret(); // keep the latest data in view
        }

        public void UpdateDataStream(string text)
        {
            txtDataStream.AppendText(text + Environment.NewLine);
            ScrollToLastLine();
        }
        #endregion

        #region GPS
        private void StatusChanged(object sender, GeoPositionStatusChangedEventArgs e)
        {
            lblConnStatus.Text = e.Status.ToString();
            GPSStatusTimer.Enabled = true;
        }

        public void PositionChanged(object sender, GeoPositionChangedEventArgs<GeoCoordinate> e)
        {
            latitude = _locationWatcher.Position.Location.Latitude;
            longitude = _locationWatcher.Position.Location.Longitude;
            UTC = _locationWatcher.Position.Timestamp.UtcDateTime.ToString();
            speed = _locationWatcher.Position.Location.Speed;
            bearing = _locationWatcher.Position.Location.Course;
            altitude = _locationWatcher.Position.Location.Altitude;
            UTCLocalTime = _locationWatcher.Position.Timestamp.LocalDateTime.ToString();
            UTCTicks = _locationWatcher.Position.Timestamp.UtcTicks;
            HDOP = _locationWatcher.Position.Location.HorizontalAccuracy;
            VDOP = _locationWatcher.Position.Location.VerticalAccuracy;
        }

        private void TracklogTimer_Tick(object sender, EventArgs e)
        {
            WriteTrackData();
        }

        public void WriteTrackData()
        {
            // get UTC, latitude and longitude from the GPS and write to file
            string trk = Convert.ToString(DateTime.Now.ToLongTimeString() + ","
               + UTCTicks + "," + latitude + "," + longitude + "," + bearing);

            string p = fileLog;
            string n = fileTrackLogName;
            using (StreamWriter sr = new StreamWriter(p + n, true))
            {
                sr.Write(Environment.NewLine + trk);
            }
        }

        private void GPSStatusTimer_Tick(object sender, EventArgs e)
        {
            if (_locationWatcher.Position.Location != GeoCoordinate.Unknown)
            {
                lblToolStripUTC.Text = UTCLocalTime;
                lblToolStripLatitude.Text = String.Format("{0:0.00#}", latitude);
                lblToolStripLongitude.Text = String.Format("{0:0.00#}", longitude);
                lblHDOP.Text = String.Format("{0:0.##}", HDOP) + "m";
                if (_locationWatcher.Position.Location.HorizontalAccuracy < 50.0)
                {
                    lblToolStripGPSStatus.Image = WaterfowlAerialSurveyLogger.Properties.Resources.satellite_xxl_green;
                    lblToolStripGPSStatus.Text = "GPS Fix OK";
                }
                else
                {
                    lblToolStripGPSStatus.Text = "GPS Accuracy Low";
                }
            }
        }
        #endregion

        #region CONTROLLER

        public void StopAllVibration()
        {
            GamePad.SetVibration(PlayerIndex.One, 0.0f, 0.0f);
        }

        public void StartVibration()
        {
            GamePad.SetVibration(PlayerIndex.One, 0.5f, 0.5f);
            vibrationCountdown = 30;
        }

        public void PlaySound(System.IO.UnmanagedMemoryStream soundFile)
        {
            sp = new SoundPlayer(soundFile);
            sp.Play();
        }

        public void UpDateController()
        {
            //Get the new gamepad state and save the old state.
            previousState = gamePadState;
            gamePadState = GamePad.GetState(playerIndex);
            //int triggerState = 0;

            if (!gamePadState.IsConnected)
            {
                controllerTimer.Enabled = false; // stop the messagebox from tripping repeatedly
                System.Windows.Forms.MessageBox.Show("The controller is not connected", "Controller Error",
                                MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                // stop for user input, respond to answer
                controllerTimer.Enabled = true;
                return;
            }

            // switch to choose XBox controller button layout: fixedWing or helicopter
            switch (gamepadKeys)
            {
                case "fixedWing":
                    FixedWingController();
                    break;
                case "helicopter":
                    HelicopterControllerLayout();
                    break;
                default:
                    System.Windows.Forms.MessageBox.Show("No controller layout chosen", "Controller layout",
                         MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                    break;
            }



            void FixedWingController() // XBox button layout for fixed-wing surveys
            {
                if (gamePadState.IsConnected)
                {
                    if (!gamePadState.Buttons.Equals(previousState.Buttons))
                    {
                        if (gamePadState.Buttons.A == Input.ButtonState.Pressed)
                        {
                            // subitise value 1
                            keyPressed = ",1";
                            PlaySound(WaterfowlAerialSurveyLogger.Properties.Resources.one);
                            UpdateTextBox(keyPressed);
                            WriteDataOnSameLine(keyPressed);
                        }
                        if (gamePadState.Buttons.B == Input.ButtonState.Pressed)
                        {
                            // subitise value 2
                            keyPressed = ",2";
                            PlaySound(WaterfowlAerialSurveyLogger.Properties.Resources.two);
                            UpdateTextBox(keyPressed);
                            WriteDataOnSameLine(keyPressed);
                        }
                        if (gamePadState.Buttons.Y == Input.ButtonState.Pressed)
                        {
                            // subitise value 3
                            keyPressed = ",3";
                            PlaySound(WaterfowlAerialSurveyLogger.Properties.Resources.three);
                            UpdateTextBox(keyPressed);
                            WriteDataOnSameLine(keyPressed);
                        }
                        if (gamePadState.Buttons.X == Input.ButtonState.Pressed)
                        {
                            // subitise value 4
                            keyPressed = ",4";
                            PlaySound(WaterfowlAerialSurveyLogger.Properties.Resources.four);
                            UpdateTextBox(keyPressed);
                            WriteDataOnSameLine(keyPressed);
                        }
                        if (gamePadState.Buttons.RightStick == Input.ButtonState.Pressed)
                        {
                            if (species == ",goat")
                            {
                                keyPressed = ",10";
                                PlaySound(WaterfowlAerialSurveyLogger.Properties.Resources.ten);
                                UpdateTextBox(keyPressed);
                                WriteDataOnSameLine(keyPressed);
                            }
                        }
                        if (gamePadState.Buttons.LeftShoulder == Input.ButtonState.Pressed)
                        {
                            // goat
                            keyPressed = ",plumed_whistling";
                            species = keyPressed;
                            PlaySound(WaterfowlAerialSurveyLogger.Properties.Resources.plumed_whistling);
                            string obs = Convert.ToString(Environment.NewLine + DateTime.Now.ToLongTimeString() + "," + sessionInfo + "," +
                                observerName + "," + observerPosition + "," + UTCTicks + "," + latitude + "," + longitude + "," +
                                bearing + "," + altitude + "," + HDOP + "," + VDOP + keyPressed);
                            UpdateTextBox(obs);
                            WriteDataOnSameLine(obs);
                        }
                        if (gamePadState.Buttons.RightShoulder == Input.ButtonState.Pressed)
                        {
                            keyPressed = ",black_duck";
                            PlaySound(WaterfowlAerialSurveyLogger.Properties.Resources.black_duck);
                            string obs = Convert.ToString(Environment.NewLine + DateTime.Now.ToLongTimeString() + "," + sessionInfo + "," +
                                observerName + "," + observerPosition + "," + UTCTicks + "," + latitude + "," + longitude + "," +
                                bearing + "," + altitude + "," + HDOP + "," + VDOP + keyPressed);
                            UpdateTextBox(keyPressed);
                            WriteDataOnSameLine(keyPressed);
                        }

                        if (gamePadState.Buttons.Start == Input.ButtonState.Pressed)
                        {
                            // dry
                            keyPressed = ",dry";
                            PlaySound(WaterfowlAerialSurveyLogger.Properties.Resources.dry);
                            UpdateTextBox(keyPressed);
                            WriteDataOnSameLine(keyPressed);

                            // pause/resume or break on/break off
                            //if (!break_on)
                            //{
                            //    keyPressed = ",break_on";
                            //    break_on = true;
                            //    PlaySound(WaterfowlAerialSurveyLogger.Properties.Resources.break_on);
                            //    string obs = Convert.ToString(Environment.NewLine + DateTime.Now.ToLongTimeString() + "," + sessionInfo + "," +
                            //    observerName + "," + observerPosition + "," + UTCTicks + "," + latitude + "," + longitude + "," +
                            //    bearing + "," + altitude + "," + HDOP + "," + VDOP + keyPressed);
                            //    UpdateTextBox(obs);
                            //    WriteDataOnSameLine(obs);
                            //}
                            //else // already on a break then key press changes to break off
                            //{
                            //    keyPressed = ",break_off";
                            //    break_on = false;
                            //    PlaySound(WaterfowlAerialSurveyLogger.Properties.Resources.break_off);
                            //    string obs = Convert.ToString(Environment.NewLine + DateTime.Now.ToLongTimeString() + "," + sessionInfo + "," +
                            //    observerName + "," + observerPosition + "," + UTCTicks + "," + latitude + "," + longitude + "," +
                            //    bearing + "," + altitude + "," + HDOP + "," + VDOP + keyPressed);
                            //    UpdateTextBox(obs);
                            //    WriteDataOnSameLine(obs);
                            //}
                        }
                        if (gamePadState.Buttons.Back == Input.ButtonState.Pressed)
                        {
                            // delete last record
                            keyPressed = ", delete_last_record";
                            PlaySound(WaterfowlAerialSurveyLogger.Properties.Resources.delete_last_record);
                            UpdateTextBox(keyPressed);
                            WriteDataOnSameLine(keyPressed);
                        }
                    }

                    // DPad
                    if (!gamePadState.DPad.Equals(previousState.DPad))
                    {
                        if (gamePadState.DPad.Up == Input.ButtonState.Pressed)
                        {
                            // ducks flying when observed
                            keyPressed = ",fying";
                            PlaySound(WaterfowlAerialSurveyLogger.Properties.Resources.flying);
                            UpdateTextBox(keyPressed);
                            WriteDataOnSameLine(keyPressed);
                        }
                        if (gamePadState.DPad.Left == Input.ButtonState.Pressed)
                        {
                            // ducks on bank
                            keyPressed = ",on_bank";
                            PlaySound(WaterfowlAerialSurveyLogger.Properties.Resources.on_bank);
                            UpdateTextBox(keyPressed);
                            WriteDataOnSameLine(keyPressed);
                        }
                        if (gamePadState.DPad.Down == Input.ButtonState.Pressed)
                        {
                            // ducsl on water
                            keyPressed = ",on_water";
                            PlaySound(WaterfowlAerialSurveyLogger.Properties.Resources.on_water);
                            UpdateTextBox(keyPressed);
                            WriteDataOnSameLine(keyPressed);
                        }
                        if (gamePadState.DPad.Right == Input.ButtonState.Pressed)
                        {
                            // ducks on bank
                            keyPressed = ",on_bank";
                            PlaySound(WaterfowlAerialSurveyLogger.Properties.Resources.on_bank);
                            UpdateTextBox(keyPressed);
                            WriteDataOnSameLine(keyPressed);
                        }
                    }

                    #region TRIGGERS
                    // check to see if triggers released
                    if (gamePadState.Triggers.Left < triggerTolerance)
                        leftTriggerReleased = true;
                    if (gamePadState.Triggers.Right < triggerTolerance)
                        rightTriggerReleased = true;

                    if (GetTriggerPress(PlayerIndex.One, true) == Buttons.DPadDown
                        && leftTriggerReleased == true) // left trigger
                    {
                        // grey teak
                        leftTriggerReleased = false;
                        keyPressed = ",grey_teal";
                        species = keyPressed;
                        PlaySound(WaterfowlAerialSurveyLogger.Properties.Resources.grey_teal);
                        string obs = Convert.ToString(Environment.NewLine + DateTime.Now.ToLongTimeString() + "," + sessionInfo + "," +
                            observerName + "," + observerPosition + "," + UTCTicks + "," + latitude + "," + longitude + "," +
                            bearing + "," + altitude + "," + HDOP + "," + VDOP + keyPressed);
                        UpdateTextBox(obs);
                        WriteDataOnSameLine(obs);
                    }

                    if (GetTriggerPress(PlayerIndex.One, false) == Buttons.DPadDown
                        && rightTriggerReleased == true) // right trigger
                    {
                        // wood duck
                        rightTriggerReleased = false;
                        keyPressed = ",wood_duck";
                        species = keyPressed;
                        PlaySound(WaterfowlAerialSurveyLogger.Properties.Resources.wood_duck);
                        string obs = Convert.ToString(Environment.NewLine + DateTime.Now.ToLongTimeString() + "," + sessionInfo + "," +
                            observerName + "," + observerPosition + "," + UTCTicks + "," + latitude + "," + longitude + "," +
                            bearing + "," + altitude + "," + HDOP + "," + VDOP + keyPressed);
                        UpdateTextBox(obs);
                        WriteDataOnSameLine(obs);
                    }
                    #endregion

                    #region THUMBSTICKS
                    // check to see if thumbsticks released
                    if (Math.Abs(gamePadState.ThumbSticks.Left.Y) < thumbstickTolerance
                        && Math.Abs(gamePadState.ThumbSticks.Left.X) < thumbstickTolerance)
                    {
                        leftThumbstickReleased = true;
                    }
                    if (Math.Abs(gamePadState.ThumbSticks.Right.Y) < thumbstickTolerance
                        && Math.Abs(gamePadState.ThumbSticks.Right.X) < thumbstickTolerance)
                    {
                        rightThumbstickReleased = true;
                    }

                    // record thumbstick data
                    if (leftThumbstickReleased)
                    {
                        if (GetThumbstickDirection(PlayerIndex.One, true) == Buttons.DPadDown) // down
                        {
                            // distance class yellow (0-50m)
                            leftThumbstickReleased = false;
                            keyPressed = ",yellow(0-50m)";
                            PlaySound(WaterfowlAerialSurveyLogger.Properties.Resources.yellow);
                            UpdateTextBox(keyPressed);
                            WriteDataOnSameLine(keyPressed);
                        }
                        if (GetThumbstickDirection(PlayerIndex.One, true) == Buttons.DPadLeft)  // left
                        {
                            // distance class green (50-100m)
                            leftThumbstickReleased = false;
                            keyPressed = ",green(50-100m)";
                            PlaySound(WaterfowlAerialSurveyLogger.Properties.Resources.green);
                            UpdateTextBox(keyPressed);
                            WriteDataOnSameLine(keyPressed);
                        }
                        if (GetThumbstickDirection(PlayerIndex.One, true) == Buttons.DPadUp) // up
                        {
                            // distance class blue (100-200m)
                            leftThumbstickReleased = false;
                            keyPressed = ",blue(100-200m)";
                            PlaySound(WaterfowlAerialSurveyLogger.Properties.Resources.blue);
                            UpdateTextBox(keyPressed);
                            WriteDataOnSameLine(keyPressed);
                        }
                        if (GetThumbstickDirection(PlayerIndex.One, true) == Buttons.DPadRight) // right
                        {
                            // distance class black (200-300m)
                            leftThumbstickReleased = false;
                            keyPressed = ",black(200-300m)";
                            PlaySound(WaterfowlAerialSurveyLogger.Properties.Resources.black);
                            UpdateTextBox(keyPressed);
                            WriteDataOnSameLine(keyPressed);
                        }
                    }
                    #endregion
                }
            }

            void HelicopterControllerLayout() // XBox button layout for helicopter surveys
            {
                if (gamePadState.IsConnected)
                {
                    GetWeather(); // update to latest weather inputs
                    if (!gamePadState.Buttons.Equals(previousState.Buttons))
                    {
                        if (gamePadState.Buttons.A == Input.ButtonState.Pressed)
                        {
                            // subitise value 1
                            keyPressed = ",1";
                            PlaySound(WaterfowlAerialSurveyLogger.Properties.Resources.one);
                            UpdateTextBox(keyPressed);
                            WriteDataOnSameLine(keyPressed);
                        }
                        if (gamePadState.Buttons.B == Input.ButtonState.Pressed)
                        {
                            // subitise value 2
                            keyPressed = ",2";
                            PlaySound(WaterfowlAerialSurveyLogger.Properties.Resources.two);
                            UpdateTextBox(keyPressed);
                            WriteDataOnSameLine(keyPressed);
                        }
                        if (gamePadState.Buttons.Y == Input.ButtonState.Pressed)
                        {
                            // subitise value 3
                            keyPressed = ",3";
                            PlaySound(WaterfowlAerialSurveyLogger.Properties.Resources.three);
                            UpdateTextBox(keyPressed);
                            WriteDataOnSameLine(keyPressed);
                        }
                        if (gamePadState.Buttons.X == Input.ButtonState.Pressed)
                        {
                            // subitise value 4
                            keyPressed = ",4";
                            PlaySound(WaterfowlAerialSurveyLogger.Properties.Resources.four);
                            UpdateTextBox(keyPressed);
                            WriteDataOnSameLine(keyPressed);
                        }
                        if (gamePadState.Buttons.Back == Input.ButtonState.Pressed)
                        {
                            // group of 10 animals observed
                            keyPressed = ",10";
                            PlaySound(WaterfowlAerialSurveyLogger.Properties.Resources.ten);
                            UpdateTextBox(keyPressed);
                            WriteDataOnSameLine(keyPressed);
                        }
                        if (gamePadState.Buttons.LeftShoulder == Input.ButtonState.Pressed)
                        {
                            // most common ducks
                            keyPressed = ",black_duck";
                            PlaySound(WaterfowlAerialSurveyLogger.Properties.Resources.black_duck);
                            string obs = Convert.ToString(Environment.NewLine + DateTime.Now.ToLongTimeString() + "," + sessionInfo + "," +
                                observerName + "," + observerPosition + "," + UTCTicks + "," + latitude + "," + longitude + "," +
                                bearing + "," + altitude + "," + HDOP + "," + VDOP + "," + cloudCover + "," + temperature + "," + wind + keyPressed);
                            UpdateTextBox(obs);
                            WriteDataOnSameLine(obs);
                        }
                        if (gamePadState.Buttons.RightShoulder == Input.ButtonState.Pressed)
                        {
                            keyPressed = ",plumed_whistling";
                            PlaySound(WaterfowlAerialSurveyLogger.Properties.Resources.plumed_whistling);
                            string obs = Convert.ToString(Environment.NewLine + DateTime.Now.ToLongTimeString() + "," + sessionInfo + "," +
                                observerName + "," + observerPosition + "," + UTCTicks + "," + latitude + "," + longitude + "," +
                                bearing + "," + altitude + "," + HDOP + "," + VDOP + "," + cloudCover + "," + temperature + "," + wind + keyPressed);
                            UpdateTextBox(obs);
                            WriteDataOnSameLine(obs);
                        }
                        if (gamePadState.Buttons.RightStick == Input.ButtonState.Pressed)
                        {
                            rightThumbstickReleased = false;
                            keyPressed = ",pink_ear";
                            PlaySound(WaterfowlAerialSurveyLogger.Properties.Resources.pink_ear);
                            string obs = Convert.ToString(Environment.NewLine + DateTime.Now.ToLongTimeString() + "," + sessionInfo + "," +
                                observerName + "," + observerPosition + "," + UTCTicks + "," + latitude + "," + longitude + "," +
                                bearing + "," + altitude + "," + HDOP + "," + VDOP + "," + cloudCover + "," + temperature + "," + wind + keyPressed);
                            UpdateTextBox(obs);
                            WriteDataOnSameLine(obs);
                        }
                        if (gamePadState.Buttons.LeftStick == Input.ButtonState.Pressed)
                        {
                            keyPressed = ",recount";
                            PlaySound(WaterfowlAerialSurveyLogger.Properties.Resources.recount);
                            string obs = Convert.ToString(Environment.NewLine + DateTime.Now.ToLongTimeString() + "," + sessionInfo + "," +
                                observerName + "," + observerPosition + "," + UTCTicks + "," + latitude + "," + longitude + "," +
                                bearing + "," + altitude + "," + HDOP + "," + VDOP + "," + cloudCover + "," + temperature + "," + wind + keyPressed);
                            UpdateTextBox(obs);
                            WriteDataOnSameLine(obs);
                        }

                        if (gamePadState.Buttons.Start == Input.ButtonState.Pressed)
                        {
                            {
                                keyPressed = ",5";
                                PlaySound(WaterfowlAerialSurveyLogger.Properties.Resources.five);
                                UpdateTextBox(keyPressed);
                                WriteDataOnSameLine(keyPressed);
                            }
                            // pause/resume or start/stop
                            //if (!break_on)
                            //{
                            //    keyPressed = ",start";
                            //    break_on = true;
                            //    PlaySound(WaterfowlAerialSurveyLogger.Properties.Resources.start);
                            //    string obs = Convert.ToString(Environment.NewLine + DateTime.Now.ToLongTimeString() + "," + sessionInfo + "," +
                            //        observerName + "," + observerPosition + "," + UTCTicks + "," + latitude + "," + longitude + "," +
                            //        bearing + "," + altitude + "," + HDOP + "," + VDOP + "," + cloudCover + "," + temperature + "," + wind + keyPressed);
                            //    UpdateTextBox(obs);
                            //    WriteDataOnSameLine(obs);
                            //}
                            //else // already on a break then key press changes to break off
                            //{
                            //    keyPressed = ",stop";
                            //    break_on = false;
                            //    PlaySound(WaterfowlAerialSurveyLogger.Properties.Resources.end);
                            //    string obs = Convert.ToString(Environment.NewLine + DateTime.Now.ToLongTimeString() + "," + sessionInfo + "," +
                            //        observerName + "," + observerPosition + "," + UTCTicks + "," + latitude + "," + longitude + "," +
                            //        bearing + "," + altitude + "," + HDOP + "," + VDOP + "," + cloudCover + "," + temperature + "," + wind + keyPressed);
                            //    UpdateTextBox(obs);
                            //    WriteDataOnSameLine(obs);
                            //}
                        }
                    }
                    if (!gamePadState.DPad.Equals(previousState.DPad))
                    {
                        if (gamePadState.DPad.Up == Input.ButtonState.Pressed)
                        {
                            // emu
                            keyPressed = ",flying";
                            PlaySound(WaterfowlAerialSurveyLogger.Properties.Resources.flying);
                            //string obs = Convert.ToString(Environment.NewLine + DateTime.Now.ToLongTimeString() + "," + sessionInfo + "," +
                            //    observerName + "," + observerPosition + "," + UTCTicks + "," + latitude + "," + longitude + "," +
                            //    bearing + "," + altitude + "," + HDOP + "," + VDOP + "," + cloudCover + "," + temperature + "," + wind + keyPressed);
                            UpdateTextBox(keyPressed);
                            WriteDataOnSameLine(keyPressed);
                        }
                        if (gamePadState.DPad.Left == Input.ButtonState.Pressed)
                        {
                            // swamp wallaby
                            keyPressed = ",on_bank";
                            PlaySound(WaterfowlAerialSurveyLogger.Properties.Resources.on_bank);
                            //string obs = Convert.ToString(Environment.NewLine + DateTime.Now.ToLongTimeString() + "," + sessionInfo + "," +
                            //    observerName + "," + observerPosition + "," + UTCTicks + "," + latitude + "," + longitude + "," +
                            //    bearing + "," + altitude + "," + HDOP + "," + VDOP + "," + cloudCover + "," + temperature + "," + wind + keyPressed);
                            UpdateTextBox(keyPressed);
                            WriteDataOnSameLine(keyPressed);
                        }
                        if (gamePadState.DPad.Down == Input.ButtonState.Pressed)
                        {
                            // wombat
                            keyPressed = ",on_water";
                            PlaySound(WaterfowlAerialSurveyLogger.Properties.Resources.on_water);
                            //string obs = Convert.ToString(Environment.NewLine + DateTime.Now.ToLongTimeString() + "," + sessionInfo + "," +
                            //    observerName + "," + observerPosition + "," + UTCTicks + "," + latitude + "," + longitude + "," +
                            //    bearing + "," + altitude + "," + HDOP + "," + VDOP + "," + cloudCover + "," + temperature + "," + wind + keyPressed);
                            UpdateTextBox(keyPressed);
                            WriteDataOnSameLine(keyPressed);
                        }
                        if (gamePadState.DPad.Right == Input.ButtonState.Pressed)
                        {
                            // red necked wallaby
                            keyPressed = ",on_bank";
                            PlaySound(WaterfowlAerialSurveyLogger.Properties.Resources.on_bank);
                            //string obs = Convert.ToString(Environment.NewLine + DateTime.Now.ToLongTimeString() + "," + sessionInfo + "," +
                            //    observerName + "," + observerPosition + "," + UTCTicks + "," + latitude + "," + longitude + "," +
                            //    bearing + "," + altitude + "," + HDOP + "," + VDOP + "," + cloudCover + "," + temperature + "," + wind + keyPressed);
                            UpdateTextBox(keyPressed);
                            WriteDataOnSameLine(keyPressed);
                        }
                    }

                    #region TRIGGERS
                    // check to see if triggers released
                    if (gamePadState.Triggers.Left < triggerTolerance)
                        leftTriggerReleased = true;
                    if (gamePadState.Triggers.Right < triggerTolerance)
                        rightTriggerReleased = true;

                    if (GetTriggerPress(PlayerIndex.One, true) == Buttons.DPadDown
                        && leftTriggerReleased == true) // left trigger
                    {
                        // grey kangaroo
                        leftTriggerReleased = false;
                        keyPressed = ",grey_teal";
                        species = keyPressed;
                        PlaySound(WaterfowlAerialSurveyLogger.Properties.Resources.grey_teal);
                        string obs = Convert.ToString(Environment.NewLine + DateTime.Now.ToLongTimeString() + "," + sessionInfo + "," +
                            observerName + "," + observerPosition + "," + UTCTicks + "," + latitude + "," + longitude + "," +
                            bearing + "," + altitude + "," + HDOP + "," + VDOP + "," + cloudCover + "," + temperature + "," + wind + keyPressed);
                        UpdateTextBox(obs);
                        WriteDataOnSameLine(obs);
                    }

                    if (GetTriggerPress(PlayerIndex.One, false) == Buttons.DPadDown
                        && rightTriggerReleased == true) // right trigger
                    {
                        // wallaroo
                        rightTriggerReleased = false;
                        keyPressed = ",wood_duck";
                        species = keyPressed;
                        PlaySound(WaterfowlAerialSurveyLogger.Properties.Resources.wood_duck);
                        string obs = Convert.ToString(Environment.NewLine + DateTime.Now.ToLongTimeString() + "," + sessionInfo + "," +
                            observerName + "," + observerPosition + "," + UTCTicks + "," + latitude + "," + longitude + "," +
                            bearing + "," + altitude + "," + HDOP + "," + VDOP + "," + cloudCover + "," + temperature + "," + wind + keyPressed);
                        UpdateTextBox(obs);
                        WriteDataOnSameLine(obs);
                    }
                    #endregion

                    #region THUMBSTICKS
                    // check to see if thumbsticks released
                    if (Math.Abs(gamePadState.ThumbSticks.Left.Y) < thumbstickTolerance
                        && Math.Abs(gamePadState.ThumbSticks.Left.X) < thumbstickTolerance)
                    {
                        leftThumbstickReleased = true;
                    }
                    if (Math.Abs(gamePadState.ThumbSticks.Right.Y) < thumbstickTolerance
                        && Math.Abs(gamePadState.ThumbSticks.Right.X) < thumbstickTolerance)
                    {
                        rightThumbstickReleased = true;
                    }

                    // record thumbstick data
                    if (leftThumbstickReleased)
                    {
                        if (GetThumbstickDirection(PlayerIndex.One, true) == Buttons.DPadDown) // down
                        {
                            // end dam
                            leftThumbstickReleased = false;
                            keyPressed = ",end_dam";
                            PlaySound(WaterfowlAerialSurveyLogger.Properties.Resources.end);
                            UpdateTextBox(keyPressed);
                            WriteDataOnSameLine(keyPressed);
                        }
                        if (GetThumbstickDirection(PlayerIndex.One, true) == Buttons.DPadLeft)  // left
                        {
                            // dry
                            leftThumbstickReleased = false;
                            keyPressed = ",dry";
                            PlaySound(WaterfowlAerialSurveyLogger.Properties.Resources.dry);
                            UpdateTextBox(keyPressed);
                            WriteDataOnSameLine(keyPressed);
                        }
                        if (GetThumbstickDirection(PlayerIndex.One, true) == Buttons.DPadUp) // up
                        {
                            // delete last record
                            leftThumbstickReleased = false;
                            keyPressed = ",delete_last_record";
                            PlaySound(WaterfowlAerialSurveyLogger.Properties.Resources.delete_last_record);
                            UpdateTextBox(keyPressed);
                            WriteDataOnSameLine(keyPressed);
                        }
                        if (GetThumbstickDirection(PlayerIndex.One, true) == Buttons.DPadRight) // right
                        {
                            // water no ducks
                            leftThumbstickReleased = false;
                            keyPressed = ",water no ducks";
                            PlaySound(WaterfowlAerialSurveyLogger.Properties.Resources.water_no_ducks);
                            UpdateTextBox(keyPressed);
                            WriteDataOnSameLine(keyPressed);
                        }
                    }

                    // right thumbstick
                    if (rightThumbstickReleased)
                    {
                        //if (gamePadState.Buttons.RightStick == Input.ButtonState.Pressed)
                        //{
                        //    rightThumbstickReleased = false;
                        //    keyPressed = ",pink_ear";
                        //    PlaySound(WaterfowlAerialSurveyLogger.Properties.Resources.pink_ear);
                        //    string obs = Convert.ToString(Environment.NewLine + DateTime.Now.ToLongTimeString() + "," + sessionInfo + "," +
                        //        observerName + "," + observerPosition + "," + UTCTicks + "," + latitude + "," + longitude + "," +
                        //        bearing + "," + altitude + "," + HDOP + "," + VDOP + "," + cloudCover + "," + temperature + "," + wind + keyPressed);
                        //    UpdateTextBox(obs);
                        //    WriteDataOnSameLine(obs);
                        //}
                        if (GetThumbstickDirection(PlayerIndex.One, false) == Buttons.DPadDown) // down
                        {
                            // blue winged shoveler
                            rightThumbstickReleased = false;
                            keyPressed = ",BW_shoveler";
                            PlaySound(WaterfowlAerialSurveyLogger.Properties.Resources.bw_shoveler);
                            string obs = Convert.ToString(Environment.NewLine + DateTime.Now.ToLongTimeString() + "," + sessionInfo + "," +
                                observerName + "," + observerPosition + "," + UTCTicks + "," + latitude + "," + longitude + "," +
                                bearing + "," + altitude + "," + HDOP + "," + VDOP + "," + cloudCover + "," + temperature + "," + wind + keyPressed);
                            UpdateTextBox(obs);
                            WriteDataOnSameLine(obs);
                        }
                        if (GetThumbstickDirection(PlayerIndex.One, false) == Buttons.DPadLeft)  // left
                        {
                            // chestnut teal
                            rightThumbstickReleased = false;
                            keyPressed = ",chestnut_teal";
                            PlaySound(WaterfowlAerialSurveyLogger.Properties.Resources.chestnut_teal);
                            string obs = Convert.ToString(Environment.NewLine + DateTime.Now.ToLongTimeString() + "," + sessionInfo + "," +
                                observerName + "," + observerPosition + "," + UTCTicks + "," + latitude + "," + longitude + "," +
                                bearing + "," + altitude + "," + HDOP + "," + VDOP + "," + cloudCover + "," + temperature + "," + wind + keyPressed);
                            UpdateTextBox(obs);
                            WriteDataOnSameLine(obs);
                        }
                        if (GetThumbstickDirection(PlayerIndex.One, false) == Buttons.DPadUp) // up
                        {
                            // hard head
                            rightThumbstickReleased = false;
                            keyPressed = ",hardhead";
                            PlaySound(WaterfowlAerialSurveyLogger.Properties.Resources.hard_head);
                            string obs = Convert.ToString(Environment.NewLine + DateTime.Now.ToLongTimeString() + "," + sessionInfo + "," +
                                observerName + "," + observerPosition + "," + UTCTicks + "," + latitude + "," + longitude + "," +
                                bearing + "," + altitude + "," + HDOP + "," + VDOP + "," + cloudCover + "," + temperature + "," + wind + keyPressed);
                            UpdateTextBox(obs);
                            WriteDataOnSameLine(obs);
                        }
                        if (GetThumbstickDirection(PlayerIndex.One, false) == Buttons.DPadRight) // right
                        {
                            // mountain duck
                            rightThumbstickReleased = false;
                            keyPressed = ",mountain_duck";
                            PlaySound(WaterfowlAerialSurveyLogger.Properties.Resources.mountain_duck);
                            string obs = Convert.ToString(Environment.NewLine + DateTime.Now.ToLongTimeString() + "," + sessionInfo + "," +
                                observerName + "," + observerPosition + "," + UTCTicks + "," + latitude + "," + longitude + "," +
                                bearing + "," + altitude + "," + HDOP + "," + VDOP + "," + cloudCover + "," + temperature + "," + wind + keyPressed);
                            UpdateTextBox(obs);
                            WriteDataOnSameLine(obs);
                        }
                        //if (GetThumbstickDirection(PlayerIndex.One, false) == Buttons.RightStick) // right pressed
                        //{
                        //    // goat
                        //    rightThumbstickReleased = false;
                        //    keyPressed = ",pink_ear";
                        //    PlaySound(WaterfowlAerialSurveyLogger.Properties.Resources.pink_ear);
                        //    string obs = Convert.ToString(Environment.NewLine + DateTime.Now.ToLongTimeString() + "," + sessionInfo + "," +
                        //        observerName + "," + observerPosition + "," + UTCTicks + "," + latitude + "," + longitude + "," +
                        //        bearing + "," + altitude + "," + HDOP + "," + VDOP + "," + cloudCover + "," + temperature + "," + wind + keyPressed);
                        //    UpdateTextBox(obs);
                        //    WriteDataOnSameLine(obs);
                        //}
                    }
                    #endregion
                }

            }
        }
        #endregion

        static Buttons GetThumbstickDirection(PlayerIndex player, bool leftStick) // http://www.magicaltimebean.com/2012/01/getting-dpad-input-from-thumbsticks-in-xna-the-right-way/
        {
            float thumbstickTolerance = 0.75f;

            GamePadState gs = GamePad.GetState(player);
            Vector2 direction = (leftStick) ?
                gs.ThumbSticks.Left : gs.ThumbSticks.Right;

            float absX = Math.Abs(direction.X);
            float absY = Math.Abs(direction.Y);

            if (absX > absY && absX > thumbstickTolerance)
            {
                return (direction.X > 0) ? Buttons.DPadRight : Buttons.DPadLeft;
            }
            else if (absX < absY && absY > thumbstickTolerance)
            {
                return (direction.Y > 0) ? Buttons.DPadUp : Buttons.DPadDown;
            }
            return (Buttons)0;
        }

        static Buttons GetTriggerPress(PlayerIndex player, bool leftTrigger)
        {
            float triggerTolerance = 0.75f;
            GamePadState gs = GamePad.GetState(player);
            float direction = (leftTrigger) ?
                gs.Triggers.Left : gs.Triggers.Right;

            float absX = Math.Abs(direction);

            if (absX > triggerTolerance)
            {
                return Buttons.DPadDown;
            }
            return (Buttons)0;
        }

        private void Logger_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void FixedWingCessnaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            gamepadKeys = "fixedWing"; // key layout
        }

        private void HelicopterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            gamepadKeys = "helicopter"; // key layout
        }

        private void GetWeather()
        {
            if (cmbCloud.Text != "")
            {
                cloudCover = cmbCloud.Text;
            }
            else
            {
                cloudCover = "NA";
            }

            if (cmbCloud.Text != "")
            {
                temperature = nudTemperature.Value;
            }
            else
            {
                temperature = -9999;
            }

            if (cmbCloud.Text != "")
            {
                wind = nudWind.Value;
            }
            else
            {
                wind = -9999;
            }
        }

        //private void NewSpeciesRecord(string keyPressed)
        //{
        //    string obs = Convert.ToString(Environment.NewLine + DateTime.Now.ToLongTimeString() + "," + sessionInfo + "," +
        //        observerName + "," + observerPosition + "," + UTCTicks + "," + latitude + "," + longitude + "," +
        //        bearing + "," + altitude + "," + HDOP + "," + VDOP + "," + cloudCover + "," + temperature + "," + wind + keyPressed);
        //    return (obs);
        //}
    }
}
