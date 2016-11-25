using UnityEngine;
using System.Collections;

public class CharTranslation : MonoBehaviour {

	void Start () {
       
	}

    public void cTranslate (float speed)
    {

        float transZ = Input.GetAxis("Vertical") * speed;
        float transX = Input.GetAxis("Horizontal") * speed;
        transZ *= Time.deltaTime;
        transX *= Time.deltaTime;

        transform.Translate(transX, 0, transZ);
    }
}
