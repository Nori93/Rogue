using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player_ : MonoBehaviour {

    public string Name;
    
    public Race race;
    public Classe classe;

    public States states;

    public Equipt Equipt;

    public BackPack backpack;

    public bool IamPlayer;

    private GameObject Enemy;

    public int x_player, y_player,x_enemy,y_enemy;

    public int Hp;
    public GameObject hp;

    
    void Start () {
        if (IamPlayer)
        {
            Enemy = GameObject.Find("Enemy");
        }
        else
        {
            Enemy = GameObject.Find("Player");
            
        }

       // x_enemy = Enemy.GetComponent<Player>().getSelfTile()[0];
      //  y_enemy = Enemy.GetComponent<Player>().getSelfTile()[1];

    }
	
	
	void Update () {
        hp.GetComponent<RectTransform>().sizeDelta = new Vector2((float)(Hp), 14.2f);
        if (Hp <= 0)
        {
            SceneManager.LoadScene("main 2");
        }
        
    }
    public string getName() { return Name; }
    public void setName(string n) { Name = n; }

    public int[] getSelfTile() { return new int[]{x_player,y_player}; }
    public void setSelfTile(int x ,int y) { x_player = x; y_player = y; }

    public int[] getEnemyTile() { return new int[] { x_enemy, y_enemy }; }
    public void setEnemyTile(int x, int y) { x_enemy = x; y_enemy = y; }
    public void getHit() { Hp = Hp - 10; }
}
