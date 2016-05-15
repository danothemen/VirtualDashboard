using System;
using System.IO;
using System.IO.Ports;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace VirtualDashboard
{
    public partial class Form1 : Form
    {
        //Port that connects to elm327
        static SerialPort OBDPort = new SerialPort();

        //commands to be sent to monitor various aspects of the vehicle
        static String[] commands = {
            "010C", //RPM
            "010D", //Speed
            "010E", //Timing Advance
            "010F", //Intake Air Temp
            "0110", //MAF Air Intake
            "0104", //Engine Load
            "0105"  //Coolant Temp
        };

        public static String GaugeJSON = "";

        public static Gauge [] DashElements = new Gauge[17];

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Get com port names and populate UI Box
            string[] ArrayComPortsNames = null;
            ArrayComPortsNames = SerialPort.GetPortNames();
            ComPort.DataSource = ArrayComPortsNames;

            //Common Baud Rates
            BaudRate.Items.Add(300);
            BaudRate.Items.Add(600);
            BaudRate.Items.Add(1200);
            BaudRate.Items.Add(2400);
            BaudRate.Items.Add(9600);
            BaudRate.Items.Add(14400);
            BaudRate.Items.Add(19200);
            BaudRate.Items.Add(38400);
            BaudRate.Items.Add(57600);
            BaudRate.Items.Add(115200);

            //Add listener to stop second thread when closing
            Form1.ActiveForm.FormClosing += Form1_Closing;
        }

        

        private void ConnectBtn_Click(object sender, EventArgs e)
        {
            OBDPort.PortName = Convert.ToString(ComPort.Text);
            OBDPort.BaudRate = Convert.ToInt32(BaudRate.Text);

            //Manually set the connection settings for elm327
            OBDPort.DataBits = Convert.ToInt16("8");
            OBDPort.StopBits = (StopBits)Enum.Parse(typeof(StopBits), "1");
            OBDPort.Handshake = (Handshake)Enum.Parse(typeof(Handshake), "None");
            OBDPort.Parity = (Parity)Enum.Parse(typeof(Parity), "None");
            try
            {
                OBDPort.Open();
                Console.Write("Port Opened");

                //Send Command and display device type in the form title
                OBDPort.WriteLine("ATI\r");
                Thread.Sleep(1000);
                OBDPort.ReadLine();
                OBDPort.ReadLine();
                string message = OBDPort.ReadLine();
                Form1.ActiveForm.Text = message;

                //Tell Elm to select the proper OBD protocol automatically
                OBDPort.WriteLine("ATSP0\r");
                OBDPort.ReadLine();
                OBDPort.ReadLine();
                OBDPort.ReadLine();

                //Create new monitor object to run on seperate thread
                Monitor mon = new Monitor(OBDPort, DashElements,this);
                mon.Start();

                this.Close();
            }
            catch(UnauthorizedAccessException ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void Form1_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            //Monitor.Stop();
        }

        private void OpenLayout_Click(object sender, EventArgs e)
        {
            Stream myStream = null;
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.InitialDirectory = "c:\\";
            openFileDialog1.Filter = "JSON files (*.json)|*.json|All files (*.*)|*.*";
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if ((myStream = openFileDialog1.OpenFile()) != null)
                    {
                        FileChosen.Text = openFileDialog1.FileName;
            
                        using (StreamReader reader = new StreamReader(myStream, Encoding.UTF8))
                        {
                            // Insert code to read the stream here.
                            GaugeJSON = reader.ReadToEnd();
                            Console.WriteLine(GaugeJSON);
                            Console.WriteLine("Read File");
                            Gauge [] gags = JsonConvert.DeserializeObject<Gauge[]>(GaugeJSON);
                            for(int i = 0; i < DashElements.Length; i++)
                            {
                                foreach(Gauge gag in gags)
                                {
                                    if(gag.ModeCode == i)
                                    {
                                        DashElements[i] = gag;
                                        DashElements[i].init();
                                        ConnectBtn.Enabled = true;
                                    }
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                }
            }

        }
    }
}
