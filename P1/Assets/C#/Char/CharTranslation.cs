using UnityEngine;
using System.Collections;

public class CharTranslation : MonoBehaviour {

    public float jmpp = 0.2f;

    float tinAir = 0;
    float tjmp = 0;

    public void cTranslate (float speed, Vector3 groundNorm, Vector3 lasttransform, bool onground, bool jump, bool run) {

        float jmp = jmpp;
        if (run)
        {
            speed *= 2.0f;
            jmp *= 1.7f;
        }

        float transZ = Input.GetAxis("Vertical") * speed;
        float transX = Input.GetAxis("Horizontal") * speed;

        transZ *= Time.deltaTime;
        transX *= Time.deltaTime;

        Vector3 translateV = new Vector3(transX, 0, transZ);
        groundNorm = (new Quaternion(-1, 0, 0, 0) * transform.rotation) * groundNorm; //project movement onto ground plane
        translateV = Vector3.ProjectOnPlane(translateV, groundNorm);

        lasttransform = Quaternion.Inverse(transform.rotation) * lasttransform;
        lasttransform = Vector3.Scale(lasttransform, new Vector3(0.9f, 0.9f, 0.9f));


        if (!onground){
            tinAir += Time.deltaTime;
        }
        else {
            tinAir = 0;
        }
        Vector3 gravity = new Vector3(0, 5*Time.deltaTime*tinAir);
        lasttransform -= gravity;

        if (jump && onground) {
            tjmp += Time.deltaTime;
            lasttransform += new Vector3(0, jmp*tjmp, 0);
            
        }
        transform.Translate(translateV + lasttransform);
    }

}
