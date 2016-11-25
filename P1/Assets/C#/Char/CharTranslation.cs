using UnityEngine;
using System.Collections;

public class CharTranslation : MonoBehaviour {

	void Start () {
       
	}

    public void cTranslate (float speed, Vector3 groundNorm) {


        float transZ = Input.GetAxis("Vertical") * speed;
        float transX = Input.GetAxis("Horizontal") * speed;

        transZ *= Time.deltaTime;
        transX *= Time.deltaTime;

        Vector3 translateV = new Vector3(transX, 0,transZ);
        groundNorm = transform.rotation*groundNorm;
        translateV = Vector3.ProjectOnPlane(translateV, groundNorm);

        transform.Translate(translateV); 
    }
}
