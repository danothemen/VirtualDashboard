using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VirtualDashboard
{
    class Monitor
    {
        static SerialPort portToWrite;
        private static bool running = false;
        Thread readThread = new Thread(run);
        private static String[] commands;
        static Form1 Dash;

        public Monitor(SerialPort OBDPort, String [] Commands, Form1 dash)
        {
            if (!OBDPort.IsOpen)
            {
                throw new Exception("Serial Port Not Open");
            }
            portToWrite = OBDPort;
            commands = Commands;
            Dash = dash;
        }

        private static void run()
        {
            while (running)
            {
                foreach(String com in commands)
                {

                    String command = com;
                    //Add return character to each command so the elm chip executes it
                    command += "\r";

                    portToWrite.WriteLine(command);

                    //Trim feedback from OBD connector and process it
                    String result = portToWrite.ReadLine();
                    while(result.Trim().Equals("") || result.Trim()[0] == '>')
                    {
                        result = portToWrite.ReadLine();
                    }

                    result = result.Trim();
                    processResult(result,""+command[2]+command[3]);

                }
            }
        }

        public void Start()
        {
            running = true;
            readThread.Start();
        }

        public static void Stop()
        {
            running = false;
        }

        private static void processResult(String result, String mode)
        {
            Boolean excepted = false;

            Console.WriteLine(result);
            //split the string returned from the serial connection
            String [] toAnalyze = result.Split(' ');
            int Mode = 0;
            try {
                //Parse the mode out of the returned string
                Mode = int.Parse(mode, NumberStyles.HexNumber);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                excepted = true;
            }
            //concatenate hex numbers into single string after mode humbers
            String toParse = "";
            for (int i = 2; i < toAnalyze.Length; i++)
            {
                toParse += toAnalyze[i];
            }

            int value = 0;
            try {
                //Generic value from any mode
                value = int.Parse(toParse, NumberStyles.HexNumber);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                if (Form1.DashElements[Mode] != null)
                {
                    Form1.DashElements[Mode].setValue(value);
                }
                excepted = true;
            }


            //Do calculations for those values that need it
            switch (Mode)
            {
                case 12:
                    //RPM Mode Value
                    value = value / 4;
                    break;
                case 4:
                    //Engine load value
                    value = value / 255 * 100;
                    break;
                case 5:
                    //Coolant Temp
                    value = value - 40;
                    break;
                case 16:
                    //Air Flow
                    value = value/100;
                    break;
                default:
                    break;
            }
            if (!excepted)
            {
                //Program.DashBoardDisplay.UpdateUI(Dash.DashElements[Mode], value);
            }
            if(Form1.DashElements[Mode] != null)
            {
                Form1.DashElements[Mode].setValue(value);
            }

        }

    }
}
