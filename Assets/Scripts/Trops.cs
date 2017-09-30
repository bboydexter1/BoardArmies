using UnityEngine;
using System.Collections;

public class Trops : MonoBehaviour
{
    private int health ;
    private int walkSpeed ;

	// Use this for initialization
	void Awake ()
    {
        health = 1;
        walkSpeed = 20;
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}

    public void GetHit()
    {
        health--;
        if (health < 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Destroy(this);
    }

    public int GetSpeed()
    {
        return walkSpeed;
    }
}
