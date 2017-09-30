using UnityEngine;
using System.Collections;

public class ThrowDice : MonoBehaviour
{
    public float forceAmount = 10.0f;
    public float torqueAmount = 10.0f;
    public ForceMode forceMode;

    private int currentValue;


    // Use this for initialization
    void Start ()
    {
	    
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            GetComponent<Rigidbody>().AddForce(Random.onUnitSphere * forceAmount , forceMode);
            GetComponent<Rigidbody>().AddTorque(Random.onUnitSphere * torqueAmount, forceMode);
        }

        ChangeCurrentValue();
        Debug.Log(currentValue);

    }

    private void ChangeCurrentValue()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, Vector3.up, out hit))
        {
            currentValue = int.Parse(hit.collider.transform.name[6].ToString()) ;
        }
    }
}
