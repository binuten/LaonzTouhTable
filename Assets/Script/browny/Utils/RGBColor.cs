
using System;
using UnityEngine;

public class RGBColor
{
    //public Color getRGBColor { get; set; }

    //public RGBColor(float r, float g, float b)
    //{
    //    Color c;

    //    if (r > 255)
    //        r = 255f;

    //    if (g > 255)
    //        g = 255f;

    //    if (b > 255)
    //        b = 255f;

    //    r /= 255f;
    //    g /= 255f;
    //    b /= 255f;

    //    c = new Color(r, g, b);

    //    this.getRGBColor = c;

    //}

    public static Color getColor(float r, float g, float b)
    {
        Color c;

        if (r > 255)
            r = 255f;

        if (g > 255)
            g = 255f;

        if (b > 255)
            b = 255f;

        r /= 255f;
        g /= 255f;
        b /= 255f;

        c = new Color(r, g, b);

        // this.getRGBColor = c;

        return c;

    }

    public static Color hexToColor(string hex)
    {
        hex = hex.Replace("0x", "");//in case the string is formatted 0xFFFFFF
        hex = hex.Replace("#", "");//in case the string is formatted #FFFFFF
        byte a = 255;//assume fully visible unless specified in hex
        byte r = byte.Parse(hex.Substring(0, 2), System.Globalization.NumberStyles.HexNumber);
        byte g = byte.Parse(hex.Substring(2, 2), System.Globalization.NumberStyles.HexNumber);
        byte b = byte.Parse(hex.Substring(4, 2), System.Globalization.NumberStyles.HexNumber);
        //Only use alpha if the string has enough characters
        if (hex.Length == 8)
        {
            a = byte.Parse(hex.Substring(4, 2), System.Globalization.NumberStyles.HexNumber);
        }
        return new Color32(r, g, b, a);
    }



    //void RGBColor2(float r, float g, float b)
    //{
    //    Color c;

    //    if (r > 255)
    //        r = 255f;

    //    if (g > 255)
    //        g = 255f;

    //    if (b > 255)
    //        b = 255f;

    //    r /= 255f;
    //    g /= 255f;
    //    b /= 255f;

    //    c = new Color(r, g, b);

    //    this.getRGBColor = c;

    //}



}
