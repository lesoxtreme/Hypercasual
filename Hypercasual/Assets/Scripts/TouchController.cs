using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class TouchController : MonoBehaviour
{
    public Vector3 pastPosition;
    public float velocity = 1f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButton(0))
        {
            //mousePosition AGORA - mousePosition Antigo
            Move(Input.mousePosition.x - pastPosition.x);
        }
        pastPosition = Input.mousePosition;
    }

    public void Move(float speed)
    {
        transform.position += Vector3.right * Time.deltaTime * speed * velocity;
    }
    private void OnTriggerEnter(Collider other)
    {
    velocity = 0f;
    }
}
