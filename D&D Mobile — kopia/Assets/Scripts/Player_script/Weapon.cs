using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : Item
{
    public int type_of_weapon; // 0-sword
    public Weapon(int type, string name, string desc, States states,Texture2D icon) {
        this.type = 1;
        this.type_of_weapon = type;
        this.name = name;
        this.desc = desc;
        this.icon = icon;

    }
	
}
