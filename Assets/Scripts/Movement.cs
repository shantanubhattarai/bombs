using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public GameObject car;
    // Start is called before the first frame update
    Vector2 position;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.anyKey){
            if(Input.GetKey(KeyCode.UpArrow)){
                position.y+=1;
            }
            if(Input.GetKey(KeyCode.DownArrow)){
                position.y-=1;
            }
            if(Input.GetKey(KeyCode.LeftArrow)){
                position.x-=1;
            }
            if(Input.GetKey(KeyCode.RightArrow)){
                position.x+=1;   
            }
            car.transform.position = position;
        }
    }
}
