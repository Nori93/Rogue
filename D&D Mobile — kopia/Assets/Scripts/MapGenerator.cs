using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class MapGenerator : MonoBehaviour {

    //Map parameters
    public int map_hight;
    public int map_width;
    public int seed;
    //Tile Model
    public Material tile_mat,empty,pl,en;
    public Mesh tile_mesh;
    public float tile_x, tile_y, tile_z, margin;

    private float start_x = -7.2f, start_y = -0.7f, start_z = -6f;

    private float temp_x = 0, temp_y = 0; // for loop

    private GameObject objectToSpawn;

    private Map tablemap;
    int[,] full_map;

	
	void Start ()
    {

        /* for (int y = 0; y < map_hight; y++){
             for (int x = 0; x < map_width; x++){

                 addTile(x, y);
                 temp_x += margin;
             }
             temp_x = start_x; temp_y += margin; 
         }*/
        tablemap = new Map(map_width, map_hight,seed);
        full_map = tablemap.getFullMap();
        map_width = full_map.GetLength(0);
        map_hight = full_map.GetLength(1);
        for (int y = 0; y < map_hight; y++){
             for (int x = 0; x < map_width; x++){
                if (full_map[x, y] == 0)
                {
                  addTile(x, y);
                }
                 temp_x += margin;
             }
             temp_x = start_x; temp_y += margin; 
         }
        Debug.Log("doneMap");
    }


    void addTile(int x, int y) {
        objectToSpawn = new GameObject("x" + x + "y" + y);
        objectToSpawn.transform.localScale = new Vector3(tile_x, tile_y, tile_z);
        objectToSpawn.transform.position = new Vector3(temp_x, temp_y, start_z);
        objectToSpawn.AddComponent<MeshFilter>().mesh = tile_mesh;
        objectToSpawn.AddComponent<Tiles>().setMapPosition(x, y);
        objectToSpawn.GetComponent<Tiles>().setMaterial(tile_mat,pl);
        objectToSpawn.AddComponent<BoxCollider>();
        
        objectToSpawn.AddComponent<MeshRenderer>().material = tile_mat;
    }

    
}

public class Room {

    private int[,] pattern; // chosen pattern

    public int DOOR_LEFT = 1, DOOR_RIGHT = 2, DOOR_BOTTOM = 3, DOOR_TOP = 4;
    public int PATTERN_1 = 1, PATTERN_2 = 2, PATTERN_3 = 3, PATTERN_4 = 4, PATTERN_5 = 5;

    private int[,] pattern_1 = {
        {2,2,2,2,2,2,2,3,2,2},
        {2,0,0,0,0,0,0,0,0,2},
        {2,0,1,0,0,0,0,1,0,2},
        {2,0,0,0,0,0,0,0,0,2},
        {2,0,0,0,0,0,0,0,0,2},
        {2,0,1,0,0,0,0,1,0,2},
        {2,0,0,0,0,0,0,0,0,2},
        {2,2,2,2,2,2,2,2,2,2}
    };
    private int[,] pattern_2 = {
        {2,2,2,2,2,2,2,2,2,2},
        {2,0,0,0,0,0,0,0,0,2},
        {2,0,0,0,1,1,0,0,0,2},
        {2,0,1,0,0,0,0,1,0,2},
        {2,0,1,0,0,0,0,1,0,2},
        {2,0,0,0,1,1,0,0,0,2},
        {2,0,0,0,0,0,0,0,0,2},
        {2,2,2,2,2,2,2,2,2,2}
    };
    private int[,] pattern_3 = {
        {2,2,2,2,2,2,2,2,2,2},
        {2,0,0,0,0,0,0,0,0,2},
        {2,0,1,1,0,0,0,0,0,2},
        {2,0,1,0,0,0,0,0,0,2},
        {2,0,0,0,0,0,0,1,0,2},
        {2,0,0,0,0,0,1,1,0,2},
        {2,0,0,0,0,0,0,0,0,2},
        {2,2,2,2,2,2,2,2,2,2}
    };
    private int[,] pattern_4 = {
        {2,2,2,2,2,2,2,2,2,2},
        {2,1,0,0,0,0,0,0,1,2},
        {2,0,1,0,0,0,0,1,0,2},
        {2,0,0,0,0,0,0,0,0,2},
        {2,0,0,0,0,0,0,0,0,2},
        {2,0,1,0,0,0,0,1,0,2},
        {2,1,0,0,0,0,0,0,1,2},
        {2,2,2,2,2,2,2,2,2,2}
    };
    private int[,] pattern_5 = {
        {2,2,2,2,2,2,2,2,2,2},
        {2,0,0,0,0,0,0,0,0,2},
        {2,0,0,0,0,0,0,0,0,2},
        {2,0,0,0,1,1,0,0,0,2},
        {2,0,0,0,1,1,0,0,0,2},
        {2,0,0,0,0,0,0,0,0,2},
        {2,0,0,0,0,0,0,0,0,2},
        {2,2,2,2,2,2,2,2,2,2}
    };

    public Room(int patt) {
       pattern = setPattern(patt);
        

    }

    private int[,] setPattern(int patt){
        switch (patt) {
            case 1:
                return pattern_1;
                break;
            case 2:
                return pattern_2;
                break;
            case 3:
                return pattern_3;
                break;
            case 4:
                return pattern_4;
                break;
            case 5:
                return pattern_5;
                break;
            default:
                return new int[,] { };
        }
     }

    public void setDoors(int door) {
        switch (door) {
            case 1:
                pattern[3, 0] = 0;
                pattern[4, 0] = 0;
                break;
            case 2:
                pattern[3, 9] = 0;
                pattern[4, 9] = 0;
                break;
            case 3:
                pattern[0, 4] = 0;
                pattern[0, 5] = 0;
                break;
            case 4:
                pattern[7, 4] = 0;
                pattern[7, 5] = 0;
                break;
           
        }

    }

    public int[,] getRoom() {
        return pattern;
    }





}

public class Map {

        

    private int map_width, map_height;

    private int room_width=10, room_height=8;

    

    private int[,] mini_map,full_map;

    private int rooms;


    private System.Random rand;

    public Map(int width, int height ,int seed) {
        mini_map = new int[height, width];
        rooms = 0;

       rand = new System.Random();

        map_width = width;
        map_height = height;
        mini_map = borderIn(mini_map);
       
            setMiniMap(seed);
        


        mini_map = borderOut(mini_map);
       
        
        
        full_map = new int[map_width*10,map_height*8];
        full_map = boardfull(full_map);
        setFullMap(mini_map);
        
       

    }
    private int[,] borderIn(int[,] t)
    {
        for (int j = 0; j < t.GetLength(1); j++)
        {
            for (int i = 0; i < t.GetLength(0); i++)
            {
                if (i == 0 || i == t.GetLength(0)-1)
                {
                    t[i, j] = -1;
                }
                else if (j == 0 || j == t.GetLength(1)-1)
                {
                    t[i, j] = -1;
                }
               
            }

        }
        return t;
    }
    private int[,] borderOut(int[,] t)
    {
        for (int j = 0; j < t.GetLength(1); j++)
        {
            for (int i = 0; i < t.GetLength(0); i++)
            {
                if (i == 0 || i == t.GetLength(0) - 1)
                {
                    t[i, j] = 0;
                }
                else if (j == 0 || j == t.GetLength(1) - 1)
                {
                    t[i, j] = 0;
                }

            }

        }
        return t;
    }

    private int[,] boardfull(int[,] t)
    {
        for (int j = 0; j < t.GetLength(1); j++)
        {
            for (int i = 0; i < t.GetLength(0); i++)
            {              
                    t[i, j] = -2;
               
                 }

        }
        return t;
        }

    private void setMiniMap(int seed) {
        int index_x = 1, index_y= 1, num = 0;
        int move = 0;
       

        while (num <= seed) {
            mini_map[index_x, index_y] = 1;
            move = nextRoom(index_x, index_y,move);
            //where is next room;
            if (move == 1) { index_x--;  }else if (move == 2) { index_x++; }else if (move == 3) { index_y--; }else if (move == 4) { index_y++; }
            if (move == 5) { //break; 
            }
            num++;
          
        } 
    }

    private int nextRoom(int x,int y,int last) {
        int direction = rand.Next(1, 4);
        if (direction == last) { direction = rand.Next(1, 4); }
        int move = nextDirection(direction,x,y,0);
     
        return move;
        
    }

    private int nextDirection(int direction, int x, int y, int br) {
        int nextRoom = 0;
        int break_ = br;
        if (break_ < 3)
        {
            switch (direction)
            {   //Left
                case 1:
                    try
                    {
                        if (mini_map[x - 1, y] == nextRoom && mini_map[x-1,y-1] <= 0 && mini_map[x - 2, y ] <= 0 && mini_map[x - 1, y + 1] <= 0 )
                        {
                            mini_map[x - 1, y] = 1;
                            rooms++;
                            return direction;
                        }
                        else
                        {
                            break_++;
                            return nextDirection(direction + 1, x, y, break_);
                        }
                    }
                    catch (Exception e)
                    {
                        break_++;
                        return nextDirection(direction + 1, x, y, break_);
                    }
                //Right
                case 2:
                    try
                    {
                        if (mini_map[x + 1, y] == nextRoom && mini_map[x + 1, y - 1] <= 0 && mini_map[x + 2, y] <= 0 && mini_map[x + 1, y + 1] <= 0)
                        {
                            mini_map[x + 1, y] = 1;
                            rooms++;
                            return direction;
                        }
                        else
                        {
                            break_++;
                            return nextDirection(direction + 1, x, y, break_);
                        }
                    }
                    catch (Exception e)
                    {
                        break_++;
                        return nextDirection(direction + 1, x, y, break_);
                    }
                //Bottm
                case 3:
                    try
                    {
                        if (mini_map[x, y - 1] == nextRoom && mini_map[x - 1, y - 1] <= 0 && mini_map[x + 1, y -1] <= 0 && mini_map[x , y - 2] <= 0)
                        {
                            mini_map[x, y - 1] = 1;
                            rooms++;
                            return direction;
                        }
                        else
                        {
                            break_++;
                            return nextDirection(direction + 1, x, y, break_);
                        }
                    }
                    catch (Exception e)
                    {
                        break_++;
                        return nextDirection(direction + 1, x, y, break_);
                    }
                //Top
                case 4:
                    try
                    {
                        if (mini_map[x, y + 1] == nextRoom && mini_map[x - 1, y + 1] <= 0 && mini_map[x + 1, y + 1] <= 0 && mini_map[x, y + 2] <= 0)
                        {
                            mini_map[x, y + 1] = 1;
                            rooms++;
                            return direction;
                        }
                        else
                        {
                            break_++;
                            return nextDirection(direction - 3, x, y, break_);

                        }
                    }
                    catch (Exception e)
                    {
                        break_++;
                        return nextDirection(direction - 3, x, y, break_);
                    }
                default:
                    return 0;
            }

        }
        else {
            return 5;
        }
    }

    private void Log(int[,] t) {
        string temp =  "";
        for (int j = 0; j < t.GetLength(1); j++)
        {
            for (int i = 0; i < t.GetLength(0); i++)
            {
                temp += " " + t[i, j] + " ";
            }
            Debug.Log(temp);
            temp = "";
        }


    }

    private void setFullMap(int[,] map) {
        int id_x = 0, id_y = 0, min_w = map.GetLength(0), min_h = map.GetLength(1), door = 0;
        int[] doors = new int[4] {0,0,0,0 };
        for (int j = 0; j < min_h; j++)
        {
            for (int i = 0; i < min_w; i++) {
                if (map[i, j] == 1) {
                    if (map[i - 1, j] == 1) { doors[0] = 1; }
                    
                    if (map[i + 1, j] == 1) { doors[1] = 2; 
                    }
                    
                    if (map[i, j - 1] == 1) { doors[2] = 3; 
                    }
                    
                    if (map[i, j + 1] == 1) { doors[3] = 4; 
                    }
                   

                    addRoom(id_x,id_y,doors);
                    doors = new int[4] { 0, 0, 0, 0 };

                }
                 id_x += 9;
            }id_y += 7;
             id_x = 0;
        }

    }

    private void addRoom(int x, int y,int[] d) {
       
        Room room = new Room(getRandom());
        for (int i = 0; i < 4; i++) {
            if (d[i] != 0) { room.setDoors(d[i]); }
        }

        int[,] room_table;
        room_table = room.getRoom();
        for (int j = 0; j < room_height-1; j++)
        {
            for (int i = 0; i < room_width-1; i++)
            {
              
                full_map[i+x, j+y] = room_table[j,i];

            }
        }

    }

    public int[,] getFullMap() { return full_map; }

    private int getRandom() {
        int temp;   
        temp = UnityEngine.Random.Range(1, 5);
        return temp;
    }
}
