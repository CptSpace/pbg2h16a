using UnityEngine;
using System.Collections;

public class Lerp : MonoBehaviour {

    float ang = 0;
    Vector3 position;

    void Start () {
        position = transform.position;
    }
	
	void FixedUpdate () {
        ang = (ang + 0.05f) % (2*3.14159265359f);  
        transform.position = new Vector3(0, Mathf.Lerp(10, -10, Mathf.InverseLerp(1,-1,Mathf.Sin(ang))), 0) + position;
	}
}
