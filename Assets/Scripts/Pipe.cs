using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipe : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float speed = 5;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       if( GameManager.Instance.state == GameManager.GameplayState.Playing)
        {
              transform.position += new Vector3(-speed * Time.deltaTime, 0f, 0f);

              CheckForRespawn(); 
        }
       else
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z); 
        }

    }

    private void CheckForRespawn( )
    {
        if ( this.gameObject.transform.position.x < -10f )
        {
            transform.position = new Vector3(10f, Random.Range(-1.3f,1.1f), transform.position.z);
            GameManager.Instance.AddScore(); 
        }
    }

 
}
