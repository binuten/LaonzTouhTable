using System;

public class ArrUtil
{

    public static T[] Shuffle<T>(T[] array)

    {
        int count = array.Length;
        for (int i = count - 1; i > 0; --i)

        {
            int randIndex = UnityEngine.Random.Range(0, i);
            T temp = array[i];
            array[i] = array[randIndex];
            array[randIndex] = temp;
        }

        return array;
    }


    //public static T[] Shuffle<T>(T[] array)

    //{
    //    int count = array.Length;
    //    for (int i = count - 1; i > 0; --i)

    //    {
    //        int randIndex = UnityEngine.Random.Range(0, i);
    //        T temp = array[i];
    //        array[i] = array[randIndex];
    //        array[randIndex] = temp;
    //    }

    //    return array;
    //}


    public static T[] add<T>(T[] list, T addElement)
    {

        T[] newIndicesArray = new T[list.Length + 1];

        for (int i = 0; i < list.Length; i++) newIndicesArray[i] = list[i];

        newIndicesArray[list.Length] = addElement;

        list = newIndicesArray;

        return list;
    }


    public static T[] remove<T>(T[] list, T removeElement)
    {

        T[] newIndicesArray = new T[list.Length - 1];

        int i = 0;
        int j = 0;
        int targetIndex = Array.IndexOf(list, removeElement);

        while (i < list.Length)
        {
            if (i != targetIndex)
            {
                newIndicesArray[j] = list[i];
                j++;
            }
            i++;
        }

        list = newIndicesArray;

        return list;
    }



}
