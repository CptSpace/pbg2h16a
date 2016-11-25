using UnityEngine;
using System.Collections;

public class CharController : MonoBehaviour {

    public Jump jump;
    public CharRotation rotation;
    public CharTranslation translation;

    GameObject body;

    public float rspeed = 2.0f;
    public float tspeed = 10.0f;

    void Start () {
        body = this.transform.parent.gameObject;
        Cursor.lockState = CursorLockMode.Locked;
    }
	
	void Update () {

        if (Cursor.lockState == CursorLockMode.Locked)
        {
            rotation.cRotate(body, rspeed);
            translation.cTranslate(tspeed);

            if (Input.GetKeyDown("space"))
            {
                jump.cJump();
            }
        }
        if (Input.GetKeyDown("escape"))
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        if (Input.GetMouseButton(0))
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
    }

}
