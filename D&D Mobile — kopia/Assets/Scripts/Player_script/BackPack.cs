using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackPack  {

    public int size;
    List<Item> itemlist;

    public BackPack() {
        itemlist = new List<Item>();
    }

    public bool add(Item item)
    {
        if (itemlist.Count < size)
        {
            itemlist.Add(item);
            return true;
        }
        else
        {
            return false;
        }
    }

}
