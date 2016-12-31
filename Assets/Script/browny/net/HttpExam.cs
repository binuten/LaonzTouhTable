using UnityEngine;
using System.Collections;
using Dstrict.Net.Http;
using System.Net;
using System.Text;

public class HttpExam : HTTPPage
{

    void Awake()
    {
        // 이벤트 추가
        HttpServer.ReceiveGetDataEvent += new ReceiveGetDataEventHandler(GetDataListener);
        HttpServer.ReceivePostDataEvent += new ReceivePostDataEventHandler(PostDataListener);
    }

    void Start()
    {
        //path = "/send";
        //HttpServer.Instance.InitilizeServer(5678, true);
    }

    // Get Method Listener Sample
    public void GetDataListener(Hashtable keyValues, HttpListenerContext context)
    {
        string _path = context.Request.Url.AbsolutePath;
        if (path == _path)
        {
            foreach (var key in keyValues.Keys)
            {
                Debug.Log("path--" + path);
                Debug.Log(keyValues[key].ToString());
                Debug.Log("---------------");

                //switch (key.ToString().ToLower())
                //{
                //    case "msg":
                //Debug.Log(MSG);
                //str.text = value;
                //        break;
                //}
            }
            HttpServer.WriteResponse(context, 200, "ok", Encoding.UTF8.GetBytes("success"));
        }
    }

    // Post Method Listener Sample
    public void PostDataListener(Hashtable keyValues, HttpListenerContext context, byte[] bytes, string filename)
    {
        if (bytes != null)
        {
            // Post로 받은 파일 파일로 저장
            //System.IO.File.WriteAllBytes("c:\\" + filename, bytes);

            // 받은 이미지 Texture2D에 넣기
            //picture = new Texture2D(1920,1080);
            //picture.LoadImage(bytes);
        }
    }

    public override void Get(Hashtable hash, HttpListenerContext context)
    {
        if (context.Request.QueryString.HasKeys())
        {
            int status = 200;

            string message = "ok";

            // 원하는 값으로 응답 할 때

            string str = "success";

            HttpServer.WriteResponse(context, status, message, Encoding.UTF8.GetBytes(str));

            // message와 status로 응답할때
            //HttpServer.WriteResponse(context, status, message, null);

            // 원하는 Html 파일로 응답 할 때
            //HttpServer.WriteResponse(context, status, message, HttpServer.GetFile("c:\\index.html"));

        }
    }






    public override void Post(Hashtable hash, byte[] file, HttpListenerContext context)
    {
        //int status = 200;
        //string message = "ok";

        // 원하는 값으로 응답 할 때
        //string str = "잘받았다";
        //HttpServer.WriteResponse(context, status, message, Encoding.UTF8.GetBytes(str));

        // message와 status로 응답할때
        //HttpServer.WriteResponse(context, status, message, null);

        // 원하는 Html 파일로 응답 할 때
        //HttpServer.WriteResponse(context, status, message, HttpServer.GetFile("c:\\index.html"));

        if (file != null)
        {
            // Post로 받은 파일 파일로 저장
            //System.IO.File.WriteAllBytes("c:\\" + filename, bytes);

            // 받은 이미지 Texture2D에 넣기
            //picture = new Texture2D(1920, 1080);
            //picture.LoadImage(bytes);
        }
    }







}
