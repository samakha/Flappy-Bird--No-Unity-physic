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
        transform.position += new Vector3(-speed * Time.deltaTime, 0f, 0f);

        CheckForRespawn(); 
    }

    private void CheckForRespawn( )
    {
        if ( this.gameObject.transform.position.x < -10f )
        {
            transform.position = new Vector3(10f, Random.Range(-1.3f,1.1f), transform.position.z); 
        }
    }

 
}
