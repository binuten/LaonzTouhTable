using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using UnityEngine;
using System.Collections;

namespace Dstrict.Net.Http
{
	public class HttpMultiPartParser
    {
        public HttpMultiPartParser(Stream stream, string filePartName)
        {
            FilePartName = filePartName;
            this.Parse(stream, Encoding.UTF8);
        }

		public HttpMultiPartParser(Stream stream, Encoding encoding, string filePartName)
        {
            FilePartName = filePartName;
            this.Parse(stream, encoding);
        }

        private void Parse(Stream stream, Encoding encoding)
        {
		    this.Success = false;

            byte[] data = Misc.ToByteArray(stream);

            string content = encoding.GetString(data);

			if(content.IndexOf("\r\n")==0)content = content.Substring(content.IndexOf("\r\n") + "\r\n".Length);

            int delimiterEndIndex = content.IndexOf("\r\n");

            if (delimiterEndIndex > -1)
            {
                string delimiter = content.Substring(0, content.IndexOf("\r\n"));

                string[] sections = content.Split(new string[] { delimiter }, StringSplitOptions.RemoveEmptyEntries);

                foreach (string s in sections)
                {
                    if (s.Contains("Content-Disposition") | s.Contains("Content-disposition"))
                    {
                        Match nameMatch = new Regex(@"(?<=name\=\"")(.*?)(?=\"")").Match(s);
                        string name = nameMatch.Value.Trim();

                        if (name == FilePartName)
                        {
                            Regex re = new Regex(@"(?<=Content\-Type:)(.*?)(?=\r\n)");
                            Match contentTypeMatch = re.Match(content);

                            re = new Regex(@"(?<=filename\=\"")(.*?)(?=\"")");
                            Match filenameMatch = re.Match(content);

                            if (contentTypeMatch.Success && filenameMatch.Success)
                            {
                                this.ContentType = contentTypeMatch.Value.Trim();
                                this.Filename = filenameMatch.Value.Trim();

								int startIndex = 0;

								if(contentTypeMatch.Index > filenameMatch.Index){

									startIndex = contentTypeMatch.Index + contentTypeMatch.Length + "\r\n\r\n".Length;
								}else{

									startIndex = filenameMatch.Index + filenameMatch.Length + 7;
								}

                                byte[] delimiterBytes = encoding.GetBytes("\r\n" + delimiter);
                                int endIndex = Misc.IndexOf(data, delimiterBytes, startIndex);

                                int contentLength = endIndex - startIndex;

                                byte[] fileData = new byte[contentLength];

                                Buffer.BlockCopy(data, startIndex, fileData, 0, contentLength);

                                this.FileContents = fileData;
                            }
                        }
                        else if (name!="" && name!=null)
                        {
                            int startIndex = nameMatch.Index + nameMatch.Length + "\r\n\r\n".Length;
                            Parameters.Add(name, s.Substring(startIndex).TrimEnd(new char[] { '\r', '\n' }).Trim());
                        }
                    }
                }

                if (FileContents != null || Parameters.Count != 0)
                    this.Success = true;
            }
        }

        public IDictionary<string, string> Parameters = new Dictionary<string, string>();

        public string FilePartName
        {
            get;
            private set;
        }

        public bool Success
        {
            get;
            private set;
        }

        public string Title
        {
            get;
            private set;
        }

        public int UserId
        {
            get;
            private set;
        }

        public string ContentType
        {
            get;
            private set;
        }

        public string Filename
        {
            get;
            private set;
        }

        public byte[] FileContents
        {
            get;
            private set;
        }
    }
}
