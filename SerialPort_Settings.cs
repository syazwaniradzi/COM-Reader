//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.IO.Ports;
//using System.Reflection;

//namespace Serial_Settings
//{
//    internal class SerialPort_Settings
//    {

        
//        public SerialPort()
//        {
//            // Finding installed serial ports on hardware
//            _currentSerialSettings.PortNameCollection = SerialPort.GetPortNames();
//            _currentSerialSettings.PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(_currentSerialSettings_PropertyChanged);

//            // If serial ports is found, we select the first found
//            if (_currentSerialSettings.PortNameCollection.Length > 0)
//                _currentSerialSettings.PortName = _currentSerialSettings.PortNameCollection[0];
//            Parity _parity = Parity.None;


//        }

//        void _serialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
//        {
//            int dataLength = _serialPort.BytesToRead;
//            byte[] data = new byte[dataLength];
//            int nbrDataRead = _serialPort.Read(data, 0, dataLength);
//            if (nbrDataRead == 0)
//                return;

//            // Send data to whom ever interested
//            if (NewSerialDataRecieved != null)
//                NewSerialDataRecieved(this, new SerialDataEventArgs(data));
//        }

//        public void StartReading()
//        {
//            //Close serial port if open
//            if (serialPort1 != null && serialPort1.IsOpen)
//                serialPort1.Close();

//            // Setting serial port settings
//            _serialPort = new SerialPort(
//                _currentSerialSettings.PortName,
//                _currentSerialSettings.BaudRate,
//                _currentSerialSettings.Parity,
//                _currentSerialSettings.DataBits,
//                _currentSerialSettings.StopBits);

//            // Subscribe to event and open serial port for data
//            _serialPort.DataReceived +=
//                new SerialDataReceivedEventHandler(_serialPort_DataReceived);
//            _serialPort.Open();
//        }


//    }
//    }
//}
