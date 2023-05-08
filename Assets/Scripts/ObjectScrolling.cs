using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectScrolling : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] float scrollingSpeed;
    private float startPos;
    private float endPos;
    private float length; 
    void Start()
    {
        length = GetComponent<SpriteRenderer>().bounds.size.x;
        startPos = length/2 + 10.1f;
        endPos = -15.32f; 
    }

    // Update is called once per frame
    void Update()
    {
        transform.position -= new Vector3(scrollingSpeed * Time.deltaTime, 0f, 0f); 

        if( transform.position.x <= endPos)
        {
            transform.position = new Vector3(startPos, transform.position.y, transform.position.z); 
        }
    }
}
