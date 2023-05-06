using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float gravity = 1.2f;
    [SerializeField] float forceBird = 3f;

    //public GameObject pipe1; 
    //public GameObject pipe2; 
    //public GameObject pipe3;

    public List<GameObject> pipeList = new List<GameObject>(); 
    float birdX , birdY , pipeX , pipeY;

    private float flyTimer;
    public float defaultFlyTimer = .5f; 
    private bool onFly; 

    void Start()
    {
        flyTimer = defaultFlyTimer; 
    }

    // Update is called once per frame
    void Update()
    { 
        birdX = transform.position.x;
        birdY = transform.position.y; 
        DetectCollider(); 
        ApplyGravity(); 
        if (Input.GetKey(KeyCode.Space)) {
            gravity = 24f;
                }     
        else
        {
            gravity = -3f; 
        }
    }
    private void ApplyGravity( )
    {
        transform.position  += new Vector3(0, gravity*Time.deltaTime , 0 ); 
    }
  
    private void DetectCollider( )
    {
      
        for ( int i = 0; i< pipeList.Count; i++)
        {
            float  pipeX = pipeList[i].gameObject.transform.position.x; 
            float pipeY = pipeList[i].gameObject.transform.position.y;

               if ((birdX+Constant.birdWidth/2 >= pipeX-Constant.pipeWidth/2 && birdX+ Constant.birdWidth/2 <= pipeX+Constant.pipeWidth)   &&  
                  ( birdY+Constant.birdHeight/2<= pipeY-Constant.distanceBetweenPipe || birdY+Constant.birdHeight/2 >=pipeY+Constant.distanceBetweenPipe)  )
                   {
                        Debug.Log("dead"); 
                    }
        }
       
    }
}
