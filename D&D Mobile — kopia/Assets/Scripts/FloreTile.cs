using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class FloreTile : MonoBehaviour
{

    public int xp, yp,xp_old,yp_old,xp_dis,yp_dis,
               xe, ye,xe_old,ye_old,xe_dis,ye_dis;
    public bool isPlayer = false;
    public bool isEnemy = false;
    public Material none,player,enemy;

    public void setIndex(int x, int y) {  this.xp = x;  this.yp = y;  }
    public void setPlayer(bool p) { this.isPlayer = p; }
    public void setEnemy(bool p) { this.isEnemy = p; }
    public void setMaterials(Material empty, Material pl,Material en) { none = empty; player = pl; enemy = en; }

    Renderer rend;
    GameObject flore;
    System.Random rnd = new System.Random();

    void Start()
    {
        flore = GameObject.Find("MapEngin");

        rend = GetComponent<Renderer>();
        rend.enabled = true;

        rend.material = none;
    }
    void Update()
    {
        if (isPlayer)
        {
            rend.material = player;
        }
        else if (isEnemy)
        {
            rend.material = enemy;
        }
        else
        {
            rend.material = none;
        }
    }

    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {

            Debug.Log("FloreTileCliced");

          //  xp_old = flore.GetComponent<MoveCont>().getPlayerPosition()[0];
          //  yp_old = flore.GetComponent<MoveCont>().getPlayerPosition()[1];

            xp_dis = Math.Abs(xp - xp_old); yp_dis= Math.Abs(yp - yp_old);
            if (xp_dis <= 2 && yp_dis <= 2)
            {

            //    flore.GetComponent<MoveCont>().changePlayerPosition(xp, yp);
                enemyMove();
            }
        }
    }

    void enemyMove()
    {

        for (int i = 0; i < 2; i++)
        {

         //   xp_old = flore.GetComponent<MoveCont>().getPlayerPosition()[0];
           // yp_old = flore.GetComponent<MoveCont>().getPlayerPosition()[1];
           // xe_old = flore.GetComponent<MoveCont>().getEnemyPosition()[0];
          ///  ye_old = flore.GetComponent<MoveCont>().getEnemyPosition()[1];

            if (canSee(xe_old,ye_old,xp_old,yp_old)) {
                if (xp_old > xe_old) { ++xe_old; }
                else if (xp_old < xe_old) { --xe_old; }

                if (yp_old > ye_old) { ++ye_old; }
                else if (yp_old < ye_old) { --ye_old; }
                /* if ((xp_old != xe_old || yp_old != ye_old)&& GameObject.Find("x"+xe_old+"y"+ye_old))
                 {
                     flore.GetComponent<GeneretePlate>().changeEnemyPosition(xe_old, ye_old);
                 }*/
                if (xp_old != xe_old || yp_old != ye_old)
                {
                    while (!GameObject.Find("x" + xe_old + "y" + ye_old))
                    {
                        xe_old += rnd.Next(-1, 1);
                        ye_old += rnd.Next(-1, 1);
                    }
                  //  flore.GetComponent<MoveCont>().changeEnemyPosition(xe_old, ye_old);
                }
            }
        }
    }

    bool canSee(int enemy_x,int enemy_y,int player_x,int player_y)
    {
       if (  player_x - enemy_x <= 2  && player_x - enemy_x >= -2 &&   player_y - enemy_y  <= 2  && player_y - enemy_y >= -2)
        /*if((enemy_x == player_x && enemy_y + 1 == player_y) || (enemy_x == player_x && enemy_y - 1 == player_y) ||
           (enemy_x + 1 == player_x && enemy_y == player_y) || (enemy_x - 1 == player_x && enemy_y == player_y) ||
           (enemy_x + 1 == player_x && enemy_y + 1 == player_y) || (enemy_x + 1 == player_x && enemy_y - 1 == player_y) ||
           (enemy_x - 1 == player_x && enemy_y + 1 == player_y) || (enemy_x - 1 == player_x && enemy_y - 1 == player_y) ||
           (enemy_x + 1 == player_x && enemy_y + 2 == player_y) || (enemy_x + 1 == player_x && enemy_y - 2 == player_y) ||
           (enemy_x + 2 == player_x && enemy_y + 1 == player_y) || (enemy_x - 2 == player_x && enemy_y + 1== player_y) ||
           (enemy_x + 2 == player_x && enemy_y + 2 == player_y) || (enemy_x + 2 == player_x && enemy_y - 2 == player_y) ||
           (enemy_x - 2 == player_x && enemy_y + 2 == player_y) || (enemy_x - 2 == player_x && enemy_y - 2 == player_y))*/
        {
            return true;
        }
        return false;
    }
}
