using UnityEngine;
using System.Collections;

public class OrbitCamera : MonoBehaviour {

    private float speed = .1f;

    public Vector3 inVect;
    public Vector3 outVect;
    private float fraction = 0;

    // Update is called once per frame
    void Update() {
        transform.RotateAround(Vector3.zero, Vector3.up, 20 * Time.deltaTime);

        if (fraction < 0) {
            fraction = 0;
            speed = Mathf.Abs(speed);
        } else if( fraction > 1) {
            fraction = 1;
            speed = - Mathf.Abs(speed);
        }
        fraction += speed * Time.deltaTime;

        Vector3 norm = transform.position.normalized;
        Vector3 offset = Vector3.Lerp(norm * 10, norm * 30, fraction);

        transform.position = offset;
    }
}
