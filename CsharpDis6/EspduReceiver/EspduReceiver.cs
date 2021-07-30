using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using OpenDis.Core;

namespace EspduReceiver
{
    internal static class EspduReceiver
    {
        private static IPAddress mcastAddress;
        private static int mcastPort, broadcastPort;
        private static Socket mcastSocket;
        private static MulticastOption mcastOption;
        private static EndPoint remoteEP;

        private static void MulticastOptionProperties()
        {
            Console.WriteLine("Current multicast group is: " + mcastOption.Group);
            Console.WriteLine("Current multicast local address is: " + mcastOption.LocalAddress);
        }

        private static void StartMulticast()
        {
            try
            {
                mcastSocket = new Socket(AddressFamily.InterNetwork,
                                         SocketType.Dgram,
                                         ProtocolType.Udp);

                //Console.Write("Enter the local IP address: ");  //In case multiple NICs
                //IPAddress localIPAddr = IPAddress.Parse(Console.ReadLine());
                //IPAddress localIPAddr = IPAddress.Parse("x.x.x.x");  //Easier than entering each time

                var localIPAddr = IPAddress.Any;  //Easiest

                var localEP = (EndPoint)new IPEndPoint(localIPAddr, 0);

                try
                {
                    mcastSocket.Bind(localEP);
                }
                catch (SocketException e)   //If port busy
                {
                    Console.WriteLine(e.ToString());
                    mcastSocket.Close();
                    Console.Write("Unable to Bind port ---->   HIT ENTER TO EXIT");
                    Console.ReadLine();
                    System.Environment.Exit(1);
                }

                // Define a MulticastOption object specifying the multicast group 
                // address and the local IPAddress.
                // The multicast group address is the same as the address used by the server.
                mcastOption = new MulticastOption(mcastAddress, localIPAddr);

                mcastSocket.SetSocketOption(SocketOptionLevel.IP,
                                            SocketOptionName.AddMembership,
                                            mcastOption);

                // Display MulticastOption properties.
                MulticastOptionProperties();

                //remoteEP = new IPEndPoint(mcastAddress, mcastPort);
                remoteEP = new IPEndPoint(IPAddress.Any, mcastPort);  //Good for general Multicast 
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        private static void StartBroadcast()
        {
            try
            {
                remoteEP = new IPEndPoint(IPAddress.Any, broadcastPort);

                mcastSocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp)
                { ExclusiveAddressUse = false };

                mcastSocket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);

                mcastSocket.Bind(remoteEP);

                Console.WriteLine("Receive Broadcat UDP on Port: " + broadcastPort);
                Console.WriteLine("----------------------------");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                Console.Write("Error ---->   HIT ENTER TO EXIT");
                Console.ReadLine();
            }
        }

        private static void ReceiveBroadcastMessages()
        {
            const bool done = false;
            byte[] bytes = new byte[10000];
            //PduProcessor could use some work and move towards all static methods (PduXmlDecode is instance method)
            var pduProcessor = new PduProcessor { Endian = Endian.Big }; //DIS use Big Endian format
            List<object> pduList;

            try
            {
                while (!done)
                {
                    Console.WriteLine("Waiting for  packets.......");
                    Console.WriteLine("Enter ^C to terminate.");

                    int length = mcastSocket.ReceiveFrom(bytes, ref remoteEP);
                    Console.WriteLine("Received broadcast from {0} :\n Bytes:{1}\n", remoteEP.ToString(), length);
                    Console.WriteLine("________________________________\n");

                    //Decode only 1 PDU
                    //Pdu pdu = PduProcessor.ConvertByteArrayToPdu1998(bytes[2], bytes, Endian.Big);                    
                    //Console.WriteLine("Received PDU Info {0} :\n ", pduProcessor.XmlDecodePdu(pdu));
                    //Console.WriteLine("*******************************\n");

                    //Could be many PDU received in datagram packet so be safe and get list

                    pduList = pduProcessor.ProcessPdu(bytes, Endian.Big);
                    Console.WriteLine("Received PDU List Size:[{0}]\n ", pduList.Count);
                    Console.WriteLine("________________________________\n");
                    foreach (object pduObj in pduList)
                    {
                        //Both of below work fine
                        //Console.WriteLine("Received PDU List Info {0} :\n ", PduProcessor.DecodePdu(pduObj).ToString());
                        Console.WriteLine("Received PDU List XML Info {0} :\n ", pduProcessor.XmlDecodePdu(pduObj));
                        Console.WriteLine("*******************************\n");
                    }
                }

                mcastSocket.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        public static void Main(string[] args)
        {
            mcastAddress = IPAddress.Parse("239.1.2.3");
            mcastPort = 62040;
            broadcastPort = 62040;  //3000 is default for DisMapper / VBS

            // Start a multicast or broadcast.
            //StartMulticast();  // Mulicast only
            StartBroadcast(); //Works with DisMapper and EspduSender when they are set to 'Broadcast'           

            // Process Incomming messages.
            ReceiveBroadcastMessages();
        }
    }
}
