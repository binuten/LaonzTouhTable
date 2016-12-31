using UnityEngine;
using System.Collections;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using System.Text;
using System.Collections.Generic;
using UnityEngine.UI;
using System;

public class TagData : MonoBehaviour
{

    public InputField input;

    Tdata data;
    string configPath = "C:/Laonz/TouchTable/xml/TouchConfig.xml";

    void Awake() { Info.tagData = this; }

    public int currentTag = -1;
    public float currentDistance = 0;

    public TextMesh tagname;

    void Start()
    {
        StreamReader r = File.OpenText(configPath);
        string configStr = r.ReadToEnd();
        r.Close();
        data = (Tdata)DeserializeObject(configStr);

        input.text = data.buffer.ToString();

        //Debug.Log("----" + configStr);
    }

    public void buttReceive(string _str)
    {
        switch (_str)
        {
            case "A":
                currentTag = 0;
                tagname.text = "tag : " + _str;
                break;
            case "B":
                currentTag = 1;
                tagname.text = "tag : " + _str;
                break;
            case "C":
                currentTag = 2;
                tagname.text = "tag : " + _str;
                break;
            case "D":
                currentTag = 3;
                tagname.text = "tag : " + _str;
                break;
            case "+":
                data.buffer += 0.01f;
                data.buffer = Math.Round(data.buffer, 2);
                if (data.buffer < 0) data.buffer = 0;
                input.text = data.buffer.ToString();
                break;
            case "-":
                data.buffer -= 0.01f;
                data.buffer = Math.Round(data.buffer, 2);
                if (data.buffer < 0) data.buffer = 0;
                input.text = data.buffer.ToString();
                break;
            case "Save1":
                if (currentTag > -1)
                {
                    Tdata.ttData td = data.list[currentTag];
                    td.distance = currentDistance.ToString();
                    data.list[currentTag] = td;
                    CreateXML();
                }
                break;
            case "Save2":
                currentTag = -1;
                CreateXML();
                break;
        }

    }



    object DeserializeObject(string pXmlizedString)
    {
        XmlSerializer xs = new XmlSerializer(typeof(Tdata));
        MemoryStream memoryStream = new MemoryStream(StringToUTF8ByteArray(pXmlizedString));
        XmlTextWriter xmlTextWriter = new XmlTextWriter(memoryStream, Encoding.UTF8);
        return xs.Deserialize(memoryStream);
    }


    byte[] StringToUTF8ByteArray(string pXmlString)
    {
        UTF8Encoding encoding = new UTF8Encoding();
        byte[] byteArray = encoding.GetBytes(pXmlString);
        return byteArray;
    }

    void MakeDumm()
    {
        saveDummData(new Tdata.ttData(), "A", .2f);
        saveDummData(new Tdata.ttData(), "B", 1.2f);
        saveDummData(new Tdata.ttData(), "C", 2f);
        saveDummData(new Tdata.ttData(), "D", 3.1f);

        foreach (Tdata.ttData item in data.list)
        {
            Debug.Log("item -- " + item.tagID);
        }
        Debug.Log("----" + SerializeObject(data));
        CreateXML();
    }

    public void saveDummData(Tdata.ttData d, string _name, float _distance)
    {
        //= new ttData();

        d.tagID = _name;
        d.distance = _distance.ToString();
        data.list.Add(d);
        //list[num - 1].tagID = _name;
        //list[list.Count].tagID = _name;
    }

    public void saveData(Tdata.ttData d, string _name, float _distance)
    {
        //= new ttData();

        d.tagID = _name;
        d.distance = _distance.ToString();
        data.list.Add(d);
        //list[num - 1].tagID = _name;
        //list[list.Count].tagID = _name;
    }



    public void CreateXML()
    {
        StreamWriter writer;
        FileInfo t = new FileInfo(configPath);

        if (!t.Exists)
        {
            writer = t.CreateText();
        }
        else
        {
            t.Delete();
            writer = t.CreateText();
        }
        writer.Write(SerializeObject(data));
        writer.Close();
        Debug.Log("File written.");
    }


    string SerializeObject(object pObject)
    {
        string XmlizedString = null;
        MemoryStream memoryStream = new MemoryStream();
        XmlSerializer xs = new XmlSerializer(typeof(Tdata));
        XmlTextWriter xmlTextWriter = new XmlTextWriter(memoryStream, Encoding.UTF8);
        xs.Serialize(xmlTextWriter, pObject);
        memoryStream = (MemoryStream)xmlTextWriter.BaseStream;
        XmlizedString = UTF8ByteArrayToString(memoryStream.ToArray());
        return XmlizedString;
    }

    string UTF8ByteArrayToString(byte[] characters)
    {
        UTF8Encoding encoding = new UTF8Encoding();
        string constructedString = encoding.GetString(characters);
        return (constructedString);
    }
}


public class Tdata
{
    public double buffer = 0.1f;

    public List<Tdata.ttData> list = new List<Tdata.ttData>();

    public Tdata() { }

    public struct ttData
    {
        public string tagID;
        public string distance;
    }
}
