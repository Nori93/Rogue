using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Equipt  {

    Item[] itemlist;

    public Equipt() {
        itemlist =new Item[9];
    }

    public bool add(Armor armor)
    {
        if (itemlist[armor.type_of_armor] == null)
        {
            itemlist[armor.type_of_armor] = armor;
            return true;
        }
        else
        {
            return false;
        }
    }
}
