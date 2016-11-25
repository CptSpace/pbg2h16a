using UnityEngine;
using System.Collections;

public class CharRotation : MonoBehaviour {

    Vector2 mouseLook;
	
	public void cRotate (GameObject body, float speed) {

        var mouseD  = new Vector2(Input.GetAxisRaw("Mouse Y"), Input.GetAxisRaw("Mouse X"));
        mouseD = Vector2.Scale(mouseD, new Vector2(speed, speed));

        mouseLook += mouseD;
        if (mouseLook.x >= 90)
        {
            mouseLook.x = 90;
        }
        if (mouseLook.x <= -90)
        {
            mouseLook.x = -90;
        }
        transform.localRotation = Quaternion.AngleAxis(-mouseLook.x, Vector3.right);
        body.transform.localRotation = Quaternion.AngleAxis(mouseLook.y, Vector3.up);
	}
}
