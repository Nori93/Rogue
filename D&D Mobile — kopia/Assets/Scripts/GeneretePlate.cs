using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GeneretePlate : MonoBehaviour {

    private GameObject[,] map;

    public int horizontal,
               verticular;
    public float tile_height,tile_width,
                 space,
                 start_x = -7.2f, start_y = -0.7f, start_z = -6f,
                 temp_x, temp_y, temp_z;

    public Material empty, 
                    pl,en;
    public Mesh none, type1;
    public float speed;


    public GameObject player_on;
    public GameObject player;
    public int player_x = 0, player_y = 0;
    public float ply_x, ply_y,tar_x,tar_y;

    public GameObject enemy_on,enemy_new;
    public GameObject enemy;
    public int enemy_x , enemy_y;
    public float emy_x, eny_y, et_x, et_y;


    private int[,] table;

    private bool canAttack = false;

    // Use this for initialization
    void Start() {

        table = new int[,] {
            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
            { 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0},
            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
            { 0, 0, 1, 0, 0, 0, 0, 0, 1, 0, 0},
            { 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0}
        };
        horizontal = table.GetLength(1);
        verticular = table.GetLength(0);


        enemy_x = horizontal - 5;
        enemy_y = verticular - 4;
        map = new GameObject[horizontal,verticular];
        //store gameObject reference
     
        temp_x = start_x;
        temp_y = start_y;
        temp_z = start_z;

        for (int y = 0; y < verticular; y++)
        {
            
            for (int x = 0; x < horizontal; x++)
            {
                if (table[y, x] == 0)
                {
                    GameObject objToSpawn;
                    //spawn object
                    objToSpawn = new GameObject("x" + x + "y" + y);
                    //Add Components
                    //objToSpawn.AddComponent<Rigidbody>();
                    objToSpawn.transform.localScale = new Vector3(tile_height, tile_width, 1f);
                    objToSpawn.transform.position = new Vector3(temp_x, temp_y, temp_z);
                    objToSpawn.AddComponent<MeshFilter>().mesh = none;
                    objToSpawn.AddComponent<FloreTile>().setIndex(x, y);
                    objToSpawn.GetComponent<FloreTile>().setMaterials(empty, pl, en);
                    objToSpawn.AddComponent<BoxCollider>();
                    objToSpawn.AddComponent<MeshRenderer>().material = empty;
                }
                    temp_x += space;
                
            }
            temp_x = start_x;temp_y += space;
        }


    }

    // Update is called once per frame
    void Update()
    {
        player_on = GameObject.Find("x" + player_x + "y" + player_y);
        player_on.GetComponent<FloreTile>().setPlayer(true);


        player.transform.position = Vector3.MoveTowards(player.transform.position, player_on.transform.position, speed);
        player.transform.position = new Vector3(player.transform.position.x,player.transform.position.y,-8f);
        player.GetComponent<Player>().setSelfTile(player_x, player_y);
        player.GetComponent<Player>().setEnemyTile(enemy_x, enemy_y);

        enemy_on = GameObject.Find("x" + enemy_x + "y" + enemy_y);
        enemy_on.GetComponent<FloreTile>().setEnemy(true);

        enemy.transform.position = Vector3.MoveTowards(enemy.transform.position, enemy_on.transform.position, speed);
        enemy.transform.position = new Vector3(enemy.transform.position.x, enemy.transform.position.y, -8f);
        enemy.GetComponent<Player>().setSelfTile(enemy_x, enemy_y);
        enemy.GetComponent<Player>().setEnemyTile(player_x, player_y);
        if (canAttack) {

            player.GetComponent<Player>().getHit();
            canAttack = false;
        }
        if (player_x == horizontal-1 && player_y == verticular-1) {
            SceneManager.LoadScene("main 2");
        }


    }
    public void changePlayerPosition(int x_new,int y_new) {
        player_on = GameObject.Find("x" + player_x + "y" + player_y);
        player_on.GetComponent<FloreTile>().setPlayer(false);
        player_x = x_new; player_y = y_new;

        isFight();
    }
    public void changeEnemyPosition(int x_new, int y_new)
    {
        enemy_on = GameObject.Find("x" + enemy_x + "y" + enemy_y);
        enemy_on.GetComponent<FloreTile>().setEnemy(false);
        
        enemy_x = x_new; enemy_y = y_new;
        enemy_new = GameObject.Find("x" + enemy_x + "y" + enemy_y);

        isFight();
    }
    public int[] getPlayerPosition() {
        return new int[]{player_x,player_y};
    }
    public int[] getEnemyPosition()
    {
        return new int[] { enemy_x, enemy_y };
    }
    void isFight() {
        if ((enemy_x == player_x && enemy_y + 1 == player_y) ||
              (enemy_x == player_x && enemy_y - 1 == player_y) ||
              (enemy_x + 1 == player_x && enemy_y == player_y) ||
              (enemy_x - 1 == player_x && enemy_y == player_y) ||
              (enemy_x + 1 == player_x && enemy_y + 1 == player_y) ||
              (enemy_x + 1 == player_x && enemy_y - 1 == player_y) ||
              (enemy_x - 1 == player_x && enemy_y + 1 == player_y) ||
              (enemy_x - 1 == player_x && enemy_y - 1 == player_y))
        {
            canAttack = true;
        }
    }
}


