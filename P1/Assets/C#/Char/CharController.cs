using UnityEngine;
using System.Collections;

public class CharController : MonoBehaviour {

    public CharRotation rotation;
    public CharTranslation translation;

    GameObject body;

    public float rspeed = 2.0f;
    public float tspeed = 0.5f;

    bool onGround;
    bool jump = false;
    bool run = false;

    Vector3 groundnormal = new Vector3(0, 1, 0);
    Vector3 lastposition;
    Vector3 lasttransform;

    void Start (){
        onGround = false;
        body = this.transform.parent.gameObject;
        Cursor.lockState = CursorLockMode.Locked;
        lastposition = transform.position;
    }
	
	void Update (){
        
    }

    void FixedUpdate()
    {
        SetInputs();
        SetCursorLock();
        CallMethods();
    }

    void CallMethods(){
	    rotation.cRotate(body, rspeed);    
    	translation.cTranslate(tspeed, groundnormal, lasttransform, onGround, jump, run);
    	if (Input.GetKey("space")) {
            jump = true;
        } else {
            jump = false;
        }
        if (Input.GetKey("left shift"))
        {
            run = true;
        }
        else {
            run = false;
        }
    }

    void SetInputs(){
        lasttransform = transform.position - lastposition;
        lastposition = transform.position;

        RaycastHit hit;
        Vector3 castsource = transform.parent.position;

        if(Physics.Raycast(castsource, Vector3.down, out hit, 1.5f)) {
            groundnormal = hit.normal;
            onGround = true;
        } else {
            onGround = false;
        }
    }

    void SetCursorLock(){
        if (Input.GetKeyDown("escape")){
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        if (Input.GetMouseButton(0)){
            Cursor.lockState = CursorLockMode.Locked;
        }
    }

}
