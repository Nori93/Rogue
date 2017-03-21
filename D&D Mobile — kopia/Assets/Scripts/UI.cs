using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI : MonoBehaviour {

    public GameObject target;

    
    float x, y, z;
	void Start () {
       // GetComponent<UnityEngine.UI.Text>().text = target.GetComponent<Player_>().getName();
	}
	
	
	void Update () {
        x = target.transform.position.x;
        y = target.transform.position.y + 0.6f;
        z = transform.position.z;

        transform.position = new Vector3(x, y, z);

	}
}
