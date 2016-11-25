using UnityEngine;
using System.Collections;

public class CharController : MonoBehaviour {

    public Jump jump;
    public CharRotation rotation;
    public CharTranslation translation;

    GameObject body;

    public float rspeed = 2.0f;
    public float tspeed = 10.0f;

    bool onGround = false;

    Vector3 groundNormal;

    void Start (){
        body = this.transform.parent.gameObject;
        Cursor.lockState = CursorLockMode.Locked;
    }
	
	void Update (){
		SetInputs();
		SetCursorLock();
    }

    void CallMethods(){
    	    rotation.cRotate(body, rspeed);
            translation.cTranslate(tspeed, groundNormal);

            if (Input.GetKeyDown("space")) {
                jump.cJump();
            }
    }

    void SetInputs(){
    	Vector3 castSource = transform.parent.position;
    	Vector3 castTarget = transform.parent.position + new Vector3(0,-2, 0);
    	RaycastHit hit;

    	if (Physics.Raycast(castSource, -Vector3.up, out hit, 1.5f)){
    		onGround = true;
    		groundNormal = hit.normal;  		
    	}	
    }

    void SetCursorLock(){
        if (Cursor.lockState == CursorLockMode.Locked){
        	CallMethods();
        }
        if (Input.GetKeyDown("escape")) {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        if (Input.GetMouseButton(0)) {
            Cursor.lockState = CursorLockMode.Locked;
        }
    }

}
