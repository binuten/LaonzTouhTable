using System;
using UnityEngine;

using System.Collections.Generic;

public class ListUtil
{

    public static List<T> Shuffle<T>(List<T> array)

    {
        int count = array.Count;
        for (int i = count - 1; i > 0; --i)

        {
            int randIndex = UnityEngine.Random.Range(0, i);
            T temp = array[i];
            array[i] = array[randIndex];
            array[randIndex] = temp;
        }

        return array;
    }


    //public static List<T> remove<T>(List<T> list, T removeElement)
    //{

    //    List<T> newIndicesArray = new List<T>();

    //    int i = 0;
    //    int j = 0;
    //    int targetIndex = list.IndexOf(removeElement);

    //    while (i < list.Count)
    //    {
    //        if (i != targetIndex)
    //        {
    //            newIndicesArray.Add(list[i]);
    //        }
    //        i++;
    //    }

    //    list = newIndicesArray;

    //    return list;
    //}





}
