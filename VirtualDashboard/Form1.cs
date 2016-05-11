using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            "0104", //Engine Load
            "0105"  //Coolant Temp
        };

        String RxString = "";

        public System.Windows.Forms.Label[] DashElements = new System.Windows.Forms.Label[14];

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
                Monitor mon = new Monitor(OBDPort, commands,this);
                mon.Start();

                //Assign UI elements to array for use in Monitor Class
                DashElements[4] = EngineLoad;
                DashElements[5] = CoolantTemp;
                DashElements[12] = RPMLabel;
                DashElements[13] = SpeedLabel;

            }
            catch(UnauthorizedAccessException ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void Form1_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Monitor.Stop();
        }

        public void UpdateUI(System.Windows.Forms.Label lab, int value)
        {
            if (lab != null)
            {
                try {
                    this.Invoke((MethodInvoker)delegate
                    {
                        try {
                            lab.Text = "" + value; // runs on UI thread
                    }
                        catch (Exception e)
                        {

                        }
                    });
                }
                catch(Exception e)
                {

                }
            }
        }

        public void UpdateUI(System.Windows.Forms.Label lab, String value)
        {
            if (lab != null)
            {
                try {
                    this.Invoke((MethodInvoker)delegate
                    {
                        try
                        {
                            lab.Text = value; // runs on UI thread
                    }
                        catch (Exception e)
                        {

                        }
                    });
                }
                catch(Exception e)
                {

                }
            }
        }

    }
}
