using UnityEngine;
using System.Collections;
using System.Net;

namespace Dstrict.Net.Http
{
	public class HTTPPage : MonoBehaviour
	{
		public string path = "/";

		public virtual void Get(Hashtable hash, HttpListenerContext context)
		{

		}

		public virtual void Post(Hashtable hash, byte[] file, HttpListenerContext context)
		{

		}

		public void Loop(HttpListenerContext context)
		{
			// Get
			if (context.Request.HttpMethod == "GET")
			{
				Hashtable ht = new Hashtable();

				foreach (string key in context.Request.QueryString.AllKeys)
				{
					ht.Add(key, context.Request.QueryString.Get(key).ToString());
				}

				Get(ht, context);

				// Event
				HttpServer.ReceiveGetDataEvent(ht, context);

				ht.Clear();
				ht = null;
			}
			// Post
			else if (context.Request.HttpMethod == "POST")
			{
				// Multipart/Form-data 방식이면
				if (context.Request.ContentType.IndexOf("multipart/form-data") > -1)	
				{
					Debug.Log("multipart/form-data");

					HttpMultiPartParser parser = new HttpMultiPartParser(context.Request.InputStream, context.Request.ContentEncoding, "file");

					if (parser.Success)
					{
						Hashtable ht = new Hashtable();

						foreach (string key in parser.Parameters.Keys)
						{
							ht.Add(key, parser.Parameters[key]);
						}

						byte[] imagebuffer;

						if (parser.FileContents != null)
						{
							// byte 배열에 받은 파일 넣기
							imagebuffer = parser.FileContents;
							Post(ht, imagebuffer, context);

							// Event Handler
							HttpServer.ReceivePostDataEvent(ht, context, imagebuffer, parser.Parameters["filename"]);
						}
						else
						{
							// Event Handler
							HttpServer.ReceivePostDataEvent(ht, context, null, null);
							Post(ht, null, context);
						}

						imagebuffer = null;

						ht.Clear();
						ht = null;
					}
				}
				else
				{
					Debug.Log("no multipart/form-data");

					HttpContentParser parser2 = new HttpContentParser(context.Request.InputStream);

					if (parser2.Success)
					{
						Hashtable ht = new Hashtable();

						foreach (string key in parser2.Parameters.Keys)
						{
							ht.Add(key, parser2.Parameters[key]);
						}

						Post(ht, null, context);

						// Event Handler
						HttpServer.ReceivePostDataEvent(ht, context, null, null);

						ht.Clear();
						ht = null;
					}
				}
			}
		}
	}
}