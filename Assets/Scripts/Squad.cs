using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Squad : MonoBehaviour
{
    int troopsCount;
    List<Trops> tropsList;
    List<Vector3> TropsPositions;

	// Use this for initialization
	void Start ()
    {
        foreach (Trops t in GetComponentsInChildren<Trops>())
        {
            tropsList.Add(t);
        }
        foreach (Transform t in GetComponentsInChildren<Transform>())
        {
            TropsPositions.Add(t.localPosition);
        }
        troopsCount = tropsList.Count;
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}
}
