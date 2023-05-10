using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float gravity = 1.2f;
   // [SerializeField] float forceBird = 3f;

    //public GameObject pipe1; 
    //public GameObject pipe2; 
    //public GameObject pipe3;

    public List<GameObject> pipeList = new List<GameObject>(); 
    float birdX , birdY , pipeX , pipeY;

    private float flyTimer;
    public float defaultFlyTimer = .5f; 
    private bool onFly;
    public float multi;
    public float rotateSpeed;

   public bool isPlaying;  

    void Start()
    {
        flyTimer = defaultFlyTimer;
        isPlaying = false; 
    }

    // Update is called once per frame
    void Update()
    {
       if( GameManager.Instance.state == GameManager.GameplayState.Playing)
        {
            birdX = this.transform.position.x;
            birdY = this.transform.position.y;
            DetectCollider();
            ApplyGravity();
            if (Input.GetKey(KeyCode.Space))
            {
                multi = 0;
                gravity = 19f;
                transform.eulerAngles = new Vector3(0, 0, 50f * Time.deltaTime ) * rotateSpeed; // rotating bird with 40 degrees
             //     SoundManager.Instance.PlaySoundWingClip(); 
            }

            else
            {
                multi += -0.1f;
                gravity = -4f+multi;  //  ADD ACCELERATION
                transform.eulerAngles = new Vector3(0, 0, 0);  // reset rotate
            }
        }
       else   // stop bird when state != playing
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
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

               if ((birdX+Constant.birdWidth/2 >= pipeX-Constant.pipeWidth/2 && birdX+ Constant.birdWidth/2 <= pipeX+Constant.pipeWidth/2)   &&  
                  ( birdY+ Constant.birdHeight/2<= pipeY-Constant.distanceBetweenPipe/2+.4f || birdY+Constant.birdHeight/2 >=pipeY+Constant.distanceBetweenPipe/2) || 
                   (birdY<=Constant.groundY || birdY>=Constant.topY))  
                   {
                         SoundManager.Instance.PlaySoundHitClip(); 
                         GameManager.Instance.GameOver(); 
                    }

        }
       
    }

   
}
