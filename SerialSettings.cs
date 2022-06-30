//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Test_COM
//{
//    internal class SerialSettings
//    {

//        string _portName = "";
//        public string PortName
//        {
           
//        get { return _portName; }
//            set
//            {
//                if (!_portName.Equals(value))
//                {
//                    _portName = value;
//                    SendPropertyChangedEvent("PortName");
//                }
//            }
//        }
//        /// <summary>
//        /// The baud rate.
//        /// </summary>
//        public int BaudRate
//        {
//            get { return _baudRate; }
//            set
//            {
//                if (_baudRate != value)
//                {
//                    _baudRate = value;
//                    SendPropertyChangedEvent("BaudRate");
//                }
//            }
//        }

//        /// <summary>
//        /// One of the Parity values.
//        /// </summary>
//        public Parity Parity
//        {
//            get { return _parity; }
//            set
//            {
//                if (_parity != value)
//                {
//                    _parity = value;
//                    SendPropertyChangedEvent("Parity");
//                }
//            }
//        }
//        /// <summary>
//        /// The data bits value.
//        /// </summary>
//        public int DataBits
//        {
//            get { return _dataBits; }
//            set
//            {
//                if (_dataBits != value)
//                {
//                    _dataBits = value;
//                    SendPropertyChangedEvent("DataBits");
//                }
//            }
//        }
//        /// <summary>
//        /// One of the StopBits values.
//        /// </summary>
//        public StopBits StopBits
//        {
//            get { return _stopBits; }
//            set
//            {
//                if (_stopBits != value)
//                {
//                    _stopBits = value;
//                    SendPropertyChangedEvent("StopBits");
//                }
//            }
//        }

//        /// <summary>
//        /// Available ports on the computer
//        /// </summary>
//        public string[] PortNameCollection
//        {
//            get { return _portNameCollection; }
//            set { _portNameCollection = value; }
//        }

//        /// <summary>
//        /// Available baud rates for current serial port
//        /// </summary>
//        public BindingList<int> BaudRateCollection
//        {
//            get { return _baudRateCollection; }
//        }

//        /// <summary>
//        /// Available databits setting
//        /// </summary>
//        public int[] DataBitsCollection
//        {
//            get { return _dataBitsCollection; }
//            set { _dataBitsCollection = value; }
//        }


//    }
//}
