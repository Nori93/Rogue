using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tiles : MonoBehaviour
{

    private int map_x, map_y;
    private float game_x, game_y, game_z;
    private Material material, glow;
    private Mesh mesh;

    private GameObject onTile;

    public bool clicked;


    RuntimePlatform platform = Application.platform;

    public void onCreate()
    {

    }

    void Update()
    {

    
    }

    void checkTouch(Vector3 pos)
    {
        Vector3 wp = Camera.main.ScreenToWorldPoint(pos);
        Vector2 touchPos = new Vector2(wp.x, wp.y);
        Collider2D hit = Physics2D.OverlapPoint(touchPos);

        if (hit)
        {
            hit.transform.gameObject.SendMessage("Clicked", 0, SendMessageOptions.DontRequireReceiver);
        }
    
    }
    

    public void setPosition(float x, float y, float z)
    {
        transform.position = new Vector3(x, y, z);
    }

    public void setMapPosition(int x, int y)
    {
        map_x = x; map_y = y;
    }

    public int[] getMapPosition()
    {
        return new int[] { map_x, map_y };
    }

    public void setMaterial(Material mat, Material g)
    {
        material = mat;
        glow = g;
    }

    void OnMouseOver()
    {
        Debug.Log("over x" + map_x + " y" + map_y);
    
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("clicked x"+map_x+" y"+map_y);
        }
    }


}
