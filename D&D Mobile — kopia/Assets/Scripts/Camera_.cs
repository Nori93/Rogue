using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_ : MonoBehaviour {
    public Transform target;
    public float hight;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        transform.position = target.transform.position;
        transform.position = new Vector3(target.position.x, target.position.y, hight);
    }
}
