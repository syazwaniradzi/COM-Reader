using System;
using System.Data;
using System.IO;
using System.IO.Ports;
using System.Windows.Forms;
using System.Data.SQLite;

namespace Test_COM
{
    public partial class Form1 : Form
    {
        string dataIn;
        string connectionString;


        public Form1()
        {

            InitializeComponent();
            connectionString = @"Data Source = C:\Syazwani\COM RS485\Test COM\Serial Port SQL.db; Version = 3";

        }

        private void Form1_Load(object sender, EventArgs e)
        {

            string[] ports = SerialPort.GetPortNames();
            cboPort.Items.AddRange(ports);


        }


        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {

            try
            {

                serialPort1.PortName = cboPort.Text;
                serialPort1.BaudRate = Convert.ToInt32(cboBaudRate.Text);
                serialPort1.BaudRate = Convert.ToInt32(cboDataBits.Text);
                serialPort1.StopBits = (StopBits)Enum.Parse(typeof(StopBits), cboStopBits.Text);
                serialPort1.Parity = (Parity)Enum.Parse(typeof(Parity), cboParityBits.Text);

                serialPort1.Open();
                progressBar1.Value = 100;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }



        private void btnClose_Click(object sender, EventArgs e)
        {

            if (serialPort1.IsOpen)
            {
                serialPort1.Close();
                progressBar1.Value = 0;
            }


        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            btn_Start.Enabled = true;
            timer1.Enabled = false;

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtMessage_TextChanged(object sender, EventArgs e)
        {

        }

        private void btn_Start_Click_1(object sender, SerialDataReceivedEventArgs e)
        {

        }

        private void ShowData(object sender, EventArgs e)
        {
            throw new NotImplementedException();

        }

        private void bindingSource1_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void btn_Start_Click(object sender, EventArgs e)
        {

            //Create connection to SQL
            using (SQLiteConnection con = new SQLiteConnection(connectionString))
            {

                try
                {

                    con.Open();
                    if (con.State == ConnectionState.Open)
                    {

                        //MessageBox.Show("connection created successfully");

                    }
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }

            }
            timer1.Enabled = true;
            SerialPort sp = serialPort1;

            string indata = sp.ReadExisting();
            dataIn = indata;

            txtMessage.Text = dataIn;

        }


        public static string getBetween(string strSource, string strStart, string strEnd)
        {
            if (strSource.Contains(strStart) && strSource.Contains(strEnd))
            {
                int Start, End;
                Start = strSource.IndexOf(strStart, 1) + strStart.Length;
                End = strSource.IndexOf(strEnd, Start);
                return strSource.Substring(Start, End - Start);
            }

            return "";
        }

        private void timer1_Tick(object sender, EventArgs e)

        {
            timer1.Enabled = true;
            timer1.Interval = 3000;
            SerialPort sp = serialPort1;

            string indata = sp.ReadExisting();
            dataIn = indata;

            txtMessage.Text = dataIn;

            //Remove newline
            string serialdata = indata.Replace("\n\r", "");

            using (StreamWriter writer = new StreamWriter("C:\\Data\\COMLogtest4.txt", true))
            {

                //Find ADC value
                string ADC = getBetween(serialdata, "-", "AC");
                //writer.Write(serialdata);

                //Find AC Level , find the last :
                string level = serialdata.Substring(serialdata.LastIndexOf(':') + 1);
                writer.WriteLine(level);

                //Create connection to SQL
                using (SQLiteConnection con = new SQLiteConnection(connectionString))
                {

                    try
                    {

                        con.Open();
                        if (con.State == ConnectionState.Open)
                        {

                            //MessageBox.Show("connection created successfully");

                        }
                    }
                    catch (Exception ex)
                    {

                        MessageBox.Show(ex.Message);
                    }

                }

                //SQL
                DateTime now = DateTime.Now;
                using (SQLiteConnection con = new SQLiteConnection(connectionString))
                {
                    SQLiteCommand cmd = new SQLiteCommand();
                    con.Open();

                    cmd.CommandText = @" INSERT INTO [tblSerialport] (Timestamp,ADC_AC,AC_Level)  VALUES (@Timestamp,@ADC_AC, @AC_Level)";
                    cmd.Connection = con;
                    cmd.Parameters.Add(new SQLiteParameter("@Timestamp", (now.ToString("dddd, dd MMMM yyyy HH:mm:ss"))));
                    cmd.Parameters.Add(new SQLiteParameter("@ADC_AC", ADC));
                    cmd.Parameters.Add(new SQLiteParameter("@AC_Level", level));

                    cmd.ExecuteNonQuery();
                    //MessageBox.Show("Data saved");

                }

            }
        }


    }
} 
