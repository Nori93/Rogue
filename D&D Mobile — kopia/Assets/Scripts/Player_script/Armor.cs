using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Armor : Item {

    public int type_of_armor; // 0 head/1 chest /2 head /3 shoulders /4 heands /5 legs /6 boots /7 neck /8 ring 

    public Armor(int type, string name, string desc, States states, Texture2D icon)
    {
        this.type = 0;
        this.type_of_armor = type;
        this.name = name;
        this.desc = desc;
        this.icon = icon;

    }
}
