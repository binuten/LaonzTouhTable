using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using UnityEngine;
using System.Collections;
using System.Net;

namespace Dstrict.Net.Http
{
    public delegate void ReceiveGetDataEventHandler(Hashtable keyValues, HttpListenerContext context);
    public delegate void ReceivePostDataEventHandler(Hashtable keyValues, HttpListenerContext context, byte[] bytes, string filename);

    public class HttpServer : MonoBehaviour
    {
        public static HttpServer Instance;

        public int port = 8080;

        public bool runInBackground = true;

        public enum ServerState
        {
            READY,
            START,
            RUNNING,
            STOP
        }

        public static ReceiveGetDataEventHandler ReceiveGetDataEvent;
        public static ReceivePostDataEventHandler ReceivePostDataEvent;

        public bool autoStart = true;

        public ServerState serverState = ServerState.READY;

        private HttpListener listener;
        private HTTPPage[] pages;

        private Queue<HttpListenerContext> contexts = new Queue<HttpListenerContext>();

        private Thread httpThread;

        void Awake()
        {

            Instance = this;
        }

        public void Start()
        {

            if (autoStart)
                InitilizeServer(port, runInBackground);
        }

        public void ForceStart()
        {

                InitilizeServer(port, runInBackground);
        }

        private void PageRequest(HttpListenerContext context)
        {
            string path = context.Request.Url.AbsolutePath;

            bool found = false;

            foreach (var page in pages)
            {
                if (page.path == path)
                {
                    found = true;
                    page.Loop(context);
                }
            }

            if (!found)
            {
                string msg = "Not Found";
                int status = 404;
                byte[] htmlText = Encoding.UTF8.GetBytes(status.ToString() + " " + msg);

                // 원하는 Html 파일로 응답 할 때
                //WriteResponse(context, status,msg, GetFile("c:\\index.html"));

                // msg와 status로 응답 할 때
                WriteResponse(context, status, msg, htmlText);
            }
        }

        public void InitilizeServer(int portNumber, bool useRunBackground)
        {
            port = portNumber;
            runInBackground = useRunBackground;
            Application.runInBackground = runInBackground;

            pages = GetComponentsInChildren<HTTPPage>();

            ThreadStart ts = new ThreadStart(ServerLoop);
            httpThread = new Thread(ts);
            httpThread.Start();
            serverState = ServerState.START;

            Debug.Log("HTTP Server port : " + port.ToString() + " has Started.");
        }

        void Update()
        {
            while (contexts.Count > 0)
            {
                HttpListenerContext context = contexts.Dequeue();

                if (context != null) { context.Response.SendChunked = true; }
                try
                {                    // Pages Loop
                    PageRequest(context);
                }
                catch
                {

                }
            }
        }

        private void ServerLoop()
        {
            listener = new HttpListener();
            listener.Prefixes.Add("http://*:" + port.ToString() + "/");
            listener.Start();

            while (serverState == ServerState.START || serverState == ServerState.RUNNING)
            {
                try
                {
                    HttpListenerContext context = listener.GetContext();
                    contexts.Enqueue(context);

                    serverState = ServerState.RUNNING;
                }
                catch
                {
                }
            }
        }

        void OnApplicationQuit()
        {
            StopServer();
        }

        public void StopServer()
        {
            serverState = ServerState.STOP;

            try
            {
                if (listener != null)
                {
                    listener.Stop();
                    listener.Close();
                }

                httpThread.Join(500);
                httpThread.Abort();

                Debug.Log("HTTP Server has stopped.");
            }
            catch (ThreadAbortException)
            {
                Debug.LogError("Thread Abort Exception");
                return;
            }

        }

        public static void WriteResponse(HttpListenerContext context, int status, string message, byte[] bytes)
        {
            if (bytes == null)
            {
                //bytes = new byte[0];
                bytes = Encoding.UTF8.GetBytes(status.ToString() + " " + message);
            }

            context.Response.StatusCode = status;
            context.Response.StatusDescription = message;
            context.Response.ContentLength64 = bytes.Length;
            context.Response.ContentType = "text/html";

            context.Response.OutputStream.Write(bytes, 0, bytes.Length);
            context.Response.OutputStream.Close();
            context.Response.OutputStream.Flush();

            Debug.Log("ServerResponse : " + Encoding.UTF8.GetString(bytes));
        }

        public static byte[] GetFile(string file)
        {
            if (!File.Exists(file)) return null;
            FileStream readIn = new FileStream(file, FileMode.Open, FileAccess.Read);
            byte[] buffer = new byte[1024 * 1000];
            int nRead = readIn.Read(buffer, 0, 10240);
            int total = 0;
            while (nRead > 0)
            {
                total += nRead;
                nRead = readIn.Read(buffer, total, 10240);
            }
            readIn.Close();
            byte[] maxresponse_complete = new byte[total];
            System.Buffer.BlockCopy(buffer, 0, maxresponse_complete, 0, total);
            return maxresponse_complete;
        }

    }

}