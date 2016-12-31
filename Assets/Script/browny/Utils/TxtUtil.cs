using UnityEngine;
using System.Collections;

public class TxtUtil : MonoBehaviour
{
    public static string ResolveTextSize(string input, int lineLength)
    {
        //string[] linesRetrieved = input.Split("\n"[0]);

        input = input.Replace("\n", " ");
        input = input.Replace("  ", " ");
        input = input.Replace("   ", " ");

        //string[] linesRetrieved = input.Split("\n"[0]);

        string result = "";

        //for (int i = 0; i < linesRetrieved.Length; i++)
        //{
        //string actualLine = linesRetrieved[i];
        string[] words = input.Split(" "[0]);

        string line = "";


        //Debug.Log("----------------------------------");


        for (int i = 0; i < words.Length; i++)
        {

            string temp = line + words[i];


            //Debug.Log("item- " + words[i]);

            //line =
            //Debug.Log("line------  " + words[i]);

            if (temp.Length > lineLength)
            {


                if (i == 0) result += words[i];
                else
                {
                    //if (i == words.Length - 1)
                    //{
                    //    line = words[i];
                    //}
                    //else
                    //{
                    result += line + "\n";
                    line = words[i];
                    //}
                }

                //if (line.Length > 3)
                //else result += line + " ";

                //if (i == words.Length - 1)
                //    result += line;
                //else
                //{
                //    result += line + "\n";
                //    line = "";
                //}
                //line = s;
            }
            else
            {
                if (i == 0) line += words[i];
                else line += " " + words[i];
            }
        }



        //Debug.Log("line ------ " + line);

        result += line;

        //result += line;
        //if (i != linesRetrieved.Length - 1) { result += line + "\n"; }
        //else { result += line; }
        //}


        //foreach (string actualLine in linesRetrieved)
        //{
        //    string[] words = actualLine.Split(" "[0]);

        //    string line = "";

        //    foreach (string s in words)
        //    {

        //        string temp = line + " " + s;

        //        if (temp.Length > lineLength)
        //        {
        //            result += line + "\n ";
        //            line = s;
        //        }
        //        else
        //        {
        //            line = temp;
        //        }
        //    }

        //    result += line;

        //}

        return result;
    }

}



