using UnityEngine;
using System.Collections;

public class Walking : MonoBehaviour
{
    private Transform destination;
    private NavMeshAgent agent;
    private int speed;
    private bool madeMove;
    private bool canGo;
    private LineRenderer line;
    private Transform TropPos;

    RaycastHit hit;

    // Use this for initialization
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        speed = GetComponentInParent<Trops>().GetSpeed();
        line = GetComponent<LineRenderer>();
        canGo = true;
        madeMove = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            TropPos = transform;

            if (Physics.Raycast(ray, out hit, 100))
            {
                agent.SetDestination(hit.point);
                line.SetPosition(0, TropPos.position);

                DrawPath(agent.path);
                agent.Stop();

                if (agent.remainingDistance <= speed)
                {
                    canGo = true;
                    line.material.color = Color.green;// SetColors(Color.green, Color.green);
                }
                else if (agent.remainingDistance > speed)
                {
                    canGo = false;
                    line.material.color = Color.red; //line.SetColors(Color.red, Color.red);
                }


                Debug.Log("madeMove =" + madeMove + " canGo = " + canGo);
            }

        }

        if (Input.GetButtonUp("Fire1") && madeMove == false && canGo == true)
        {
            Debug.Log("move");
            agent.Resume();
            //madeMove = true;
        }

        if (Input.GetButtonUp("Fire1"))
        {
            clearPath();
        }
    }


    private void DrawPath(NavMeshPath path)
    {
        line.enabled = true;
        if (path.corners.Length < 2)
        {
            return;
        }

        line.SetVertexCount(path.corners.Length);

        for (int i = 1; i < path.corners.Length; i++)
        {
            line.SetPosition(i, path.corners[i]);
        }
    }

    private void clearPath()
    {
        // Destroy(line);
        //  line = this.gameObject.AddComponent<LineRenderer>();
        line.enabled = false;
    }
}

 

