using System.IO;
using System.Text;
using System.Collections.Generic;

namespace Dstrict.Net.Http
{
    public class HttpContentParser
	{
		public HttpContentParser(Stream stream)
		{
			this.Parse(stream, Encoding.UTF8);
		}

		public HttpContentParser(Stream stream, Encoding encoding)
		{
			this.Parse(stream, encoding);
		}

		private void Parse(Stream stream, Encoding encoding)
		{
			this.Success = false;

			byte[] data = Misc.ToByteArray(stream);

			string content = encoding.GetString(data);

			string name = string.Empty;
			string value = string.Empty;
			bool lookForValue = false;
			int charCount = 0;

			foreach (var c in content)
			{
				if (c == '=')
				{
					lookForValue = true;
				}
				else if (c == '&')
				{
					lookForValue = false;
					AddParameter(name, value);
					name = string.Empty;
					value = string.Empty;
				}
				else if (!lookForValue)
				{
					name += c;
				}
				else
				{
					value += c;
				}

				if (++charCount == content.Length)
				{
					AddParameter(name, value);
					break;
				}
			}

			if (Parameters.Count != 0)
				this.Success = true;
		}

		private void AddParameter(string name, string value)
		{
			if (name != "" && name != null && value != "" && value != null)
				Parameters.Add(name.Trim(), value.Trim());
		}

		public IDictionary<string, string> Parameters = new Dictionary<string, string>();

		public bool Success
		{
			get;
			private set;
		}
	}
}
