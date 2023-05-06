using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float gravity = 1.2f;
    [SerializeField] float forceBird = 3f;

    float birdX , birdY; 

    void Start()
    {
        birdX = transform.position.x;
        birdY = transform.position.y; 
    }

    // Update is called once per frame
    void Update()
    {
        ApplyGravity(); 
        if(Input.GetKeyDown(KeyCode.Space))
            {
            gravity = -9f;
            ApplyGravity(); 
          
            }
        if( Input.GetKeyUp(KeyCode.Space))
        {
            gravity = 35f;
            ApplyGravity(); 
        }
        else
        {
            gravity = -2.2f; 
        }
    }
    private void ApplyGravity( )
    {
        transform.position  += new Vector3(0, gravity*Time.deltaTime , 0 ); 
    }
  
}
