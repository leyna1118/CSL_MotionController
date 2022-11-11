using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

public class SocketClient
{
    private Socket socketClient;
    private Thread thread;
    private byte[] data = new byte[1024];
    public float w, x, y, z;
    public bool isTrigger;

    public SocketClient(string hostIP, int port) {
        
        thread = new Thread(() => {
            // while the status is "Disconnect", this loop will keep trying to connect.
            while (true) {
                try {
                    socketClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                    socketClient.Connect(new IPEndPoint(IPAddress.Parse(hostIP), port));
                    // while the connection
                    while (true) {
                        /*********************************************************
                         * TODO: you need to modify receive function by yourself *
                         *********************************************************/
                        SocketError err;
                        int length;
                        string message;
                    
                        while (socketClient.Available < 2) {
                            // Thread.Sleep(1);
                            // continue;
                        }
                        
                        length = socketClient.Receive(data, 0, 2, SocketFlags.None, out err);
                        message = Encoding.UTF8.GetString(data, 0, length);
                        int dataLen = Int16.Parse(message);
                        Debug.Log("DataLen: " + dataLen);
                        
                        while (socketClient.Available < dataLen) {
                            // Thread.Sleep(1);
                            // continue;
                        }

                        length = socketClient.Receive(data, 0, dataLen, SocketFlags.None, out err);
                        // Debug.Log("Recieve length: " + length);
                        message = Encoding.UTF8.GetString(data, 0, length);
                        Debug.Log("Recieve message: " + message);
                        string[] dataQua = message.Split(' ');
                        int cnt = 0;
                        foreach (var par in dataQua){
                            if(cnt == 0){
                                if(par == "0")this.isTrigger = false;
                                else this.isTrigger = true;
                            }
                            else if (cnt == 1){
                                this.w = float.Parse(par);
                            }
                            else if (cnt == 2){
                                this.x = float.Parse(par);
                            }
                            else if (cnt == 3){
                                this.y = float.Parse(par);
                            }
                            else if (cnt == 4){
                                this.z = float.Parse(par);
                            }
                            ++cnt;          
                        }

                        
                        // */
                    }
                } catch (Exception ex) {
                    if (socketClient != null) {
                        socketClient.Close();
                    }
                    Debug.Log(ex.Message);
                }
            }
        });
        thread.IsBackground = true;
        thread.Start();
    }

    public void Close() {
        thread.Abort();
        if (socketClient != null) {
            socketClient.Close();
        }
    }
}
