using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineRendererHelper : MonoBehaviour
{
    public LineRenderer lineRenderer;

    public List<Transform> positions;

    // Start is called before the first frame update
    void Start()
    {
        lineRenderer.positionCount = positions.Count;
    }

    // Update is called once per frame
    void Update()
    {
        for(int i = 0; i < positions.Count; i++)
        {
            lineRenderer.SetPosition(i, positions[i].position);
        }
    }
}
