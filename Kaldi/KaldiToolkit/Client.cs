using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Text;
using log4net;

namespace Kaldi
{
    namespace KaldiToolkit
    {
        public class Client
        {			
            private TcpClient tcpClient;
			private string host;
			private int port;

            public Client(string hostname, int portnum)
            {
				this.host = hostname;
				this.port = portnum;
                //this.tcpClient = new TcpClient(hostname, port);

                //Console.WriteLine("Created Kaldi TCP Client");
				
				//Send ("Initialize message");
				//Console.WriteLine (Receive ());
				//Thread.Sleep(1000);
				
            }

            public void Send(string message)
            {
				lock (this) {
				
					this.tcpClient = new TcpClient(host, port);
					Console.WriteLine("Sending message: {0}", message);
					
	                //byte[] messageData = Encoding.ASCII.GetBytes(message);
					//byte[] sendData = new byte[messageData.Length + 1];
					//for (int i=0 ; i < messageData.Length; i++)
						//sendData[i] = messageData[i];
					//sendData[messageData.Length] = 13; // CR
	                //tcpClient.GetStream().Write(sendData, 0, sendData.Length);
					
	                byte[] messageData = Encoding.ASCII.GetBytes(message + "\r");
					tcpClient.GetStream().Write (messageData, 0, messageData.Length);
					tcpClient.GetStream().Flush();
					
					//Console.WriteLine("Sent message: {0}", message);
					
				}
            }

            public String Receive()
            {
				lock (this) {
	                //Console.WriteLine("Receiving message...");
					
	                NetworkStream networkStream = tcpClient.GetStream();
	                StringBuilder builder = new StringBuilder();
	                byte[] dataBuffer = new byte[1024];
	                int bytesReceived = 0;
	                do
	                {
	                    bytesReceived = networkStream.Read(dataBuffer, 0, dataBuffer.Length);
	                    builder.Append(Encoding.ASCII.GetString(dataBuffer, 0, bytesReceived));
	                }
	                while (networkStream.DataAvailable);
	                String receivedMessage = builder.ToString();
	                //Console.WriteLine("Received message: {0}", receivedMessage);
					
					tcpClient.Close();
					return receivedMessage;
				}
            }
			
			/*
            private bool MakeRequest(RequestMessage request)
            {
                Send(request);
                ReplyMessage reply = new ReplyMessage(Receive());
                if (reply.IsError)
                {
                    throw new RequestException(reply.ErrorMessage);
                }
                return reply.IsGranted;
            }

            public bool MakeRequest(params string[] parameters)
            {
				lock (this) {
                	return MakeRequest(new RequestMessage(parameters));
				}
            }
            */
        }
    }
}
