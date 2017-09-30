using UnityEngine;
using System.Collections;

public class CameraOperator : MonoBehaviour
{
    int minFov = 40;
    int maxFov = 120;
    int speed = 10;

	// Use this for initialization
	void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        //zoom
        float fov = Camera.main.fieldOfView;
        fov += Input.GetAxis("Mouse ScrollWheel") * speed;
        transform.Translate(0, 0, fov - 60);
        //move
        float ver = Input.GetAxis("Vertical") * 10 ;
        float hor = Input.GetAxis("Horizontal") * 10 ;
        ver *= Time.deltaTime;
        hor *= Time.deltaTime;
        transform.parent.GetComponent<Transform>().Translate(hor, 0, 0);
        transform.parent.GetComponent<Transform>().Translate(0, 0, ver, Space.Self); 
        //rotation
        if (Input.GetKey("q"))
        {
            transform.parent.GetComponent<Transform>().Rotate(Vector3.up * Time.deltaTime * speed * 2 , Space.World);
        }
        if (Input.GetKey("e"))
        {
            transform.parent.GetComponent<Transform>().Rotate(Vector3.down * Time.deltaTime * speed * 2 , Space.World);
        }
    }
}
