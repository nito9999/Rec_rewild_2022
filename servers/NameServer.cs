﻿using System;
using System.IO;
using System.Net;
using System.Text;
using System.Threading;
using Newtonsoft.Json;
using start;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace server
{
    internal class NameServer
    {
        public NameServer()
        {
            try
            {
                Console.WriteLine("[NameServer.cs] has started.");
                new Thread(new ThreadStart(this.StartListen)).Start();
            }
            catch (Exception ex)
            {
                Console.WriteLine("An Exception Occurred while Listening :" + ex.ToString());
            }
        }
        private void StartListen()
        {
            this.listener.Prefixes.Add("http://localhost:2021/");
            for (; ; )
            {
                this.listener.Start();
                Console.WriteLine("[NameServer.cs] is listening.");
                HttpListenerContext context = this.listener.GetContext();
                HttpListenerRequest request = context.Request;
                HttpListenerResponse response = context.Response;
                string rawUrl = request.RawUrl;
                string s = "";

                //if (Program.beta)
                if (false)
                {
                    
                }
                else
                {
                    s = JsonConvert.SerializeObject(new
                    {
                        Accounts = "http://localhost:20210/",
                        API = "http://localhost:20210/",
                        Auth = "http://localhost:20214/",
                        BugReporting = "http://localhost:20210/",
                        Cards = "http://localhost:20210/",
                        CDN = "http://localhost:20210/",
                        Chat = "http://localhost:20210/",
                        Clubs = "http://localhost:20210/",
                        CMS = "http://localhost:20210/",
                        Commerce = "http://localhost:20210/",
                        Data = "http://localhost:20210/",
                        DataCollection = "http://localhost:20210/",
                        Discovery = "http://localhost:20210/",
                        Econ = "http://localhost:20210/",
                        GameLogs = "http://localhost:20210/",
                        Geo = "http://localhost:20210/",
                        Images = "http://localhost:20213/",
                        Leaderboard = "http://localhost:20210/",
                        Link = "http://localhost:20210/",
                        Lists = "http://localhost:20210/",
                        Matchmaking = "http://localhost:20215/",
                        Moderation = "http://localhost:20210/",
                        Notifications = "http://localhost:20212/",
                        PlayerSettings = "http://localhost:20210/",
                        RoomComments = "http://localhost:20210/",
                        Rooms = "http://localhost:20218/",
                        Storage = "http://localhost:20210/",
                        Strings = "http://localhost:20210/",
                        StringsCDN = "http://localhost:20210/",
                        Thorn = "http://localhost:20210/",
                        Videos = "http://localhost:20210/",
                        WWW = "http://localhost:20210/"
                    });
                }
                Console.WriteLine("NameServer Response: " + s);
                byte[] bytes = Encoding.UTF8.GetBytes(s);
                response.ContentLength64 = (long)bytes.Length;
                Stream outputStream = response.OutputStream;
                outputStream.Write(bytes, 0, bytes.Length);
                Thread.Sleep(400);
                outputStream.Close();
                this.listener.Stop();
            }
        }

       
        
        public class NSData
        {
            public string Accounts { get; set; }
            public string API { get; set; }
            public string Auth { get; set; }
            public string BugReporting { get; set; }
            public string Cards { get; set; }
            public string CDN { get; set; }
            public string Chat { get; set; }
            public string Clubs { get; set; }
            public string CMS { get; set; }
            public string Commerce { get; set; }
            public string Data { get; set; }
            public string DataCollection { get; set; }
            public string Discovery { get; set; }
            public string Econ { get; set; }
            public string GameLogs { get; set; }
            public string Geo { get; set; }
            public string Images { get; set; }
            public string Leaderboard { get; set; }
            public string Link { get; set; }
            public string Lists { get; set; }
            public string Matchmaking { get; set; }
            public string Moderation { get; set; }
            public string Notifications { get; set; }
            public string PlayerSettings { get; set; }
            public string RoomComments { get; set; }
            public string Rooms { get; set; }
            public string Storage { get; set; }
            public string Strings { get; set; }
            public string StringsCDN { get; set; }
            public string Thorn { get; set; }
            public string Videos { get; set; }
            public string WWW { get; set; }
        }
        private HttpListener listener = new HttpListener();
    }
}