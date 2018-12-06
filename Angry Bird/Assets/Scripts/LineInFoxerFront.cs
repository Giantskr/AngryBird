using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineInFoxerFront : MonoBehaviour
{
    LineRenderer lineRenderer;
    public GameObject Holder;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        lineRenderer = GetComponent<LineRenderer>();
        Vector3[] vector3s = new Vector3[2];
        vector3s[0] = new Vector3(-4.75f, -1.4f, -0.2f);
        vector3s[1] = Holder.transform.position;
        lineRenderer.SetPositions(vector3s);
    }
}
