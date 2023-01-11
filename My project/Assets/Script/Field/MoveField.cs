using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveField : ObjectMoveBase
{
    // Start is called before the first frame update


    //動くゴミ
    //int counter = 0;
   [ SerializeField] float move = 0; 

    //プレイヤー親子関係
    Rigidbody rb;
    float upForce = 100f;
    [SerializeField] GameObject parentObj;

    //米倉
    
    void Start()
    {
        //プレイヤー親子関係
        rb = GetComponent<Rigidbody>();
        parentObj = GameObject.Find("Move");
    }

    // Update is called once per frame
    void Update()
    {
        //米倉
        X += move;
        //バカの考え
        //transform.Translate(new Vector3(move, 0, 0));
        //counter++;
        //if (counter == 300)
        // {
        // counter = 0;
        // move *= -1;
        // }

        //プレイヤー親子関係
        if (Input.GetMouseButtonDown(0))
            rb.AddForce(new Vector3(0, upForce, 0));
    }

    //プレイヤー親子関係
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.name == "Floor")
            transform.SetParent(parentObj.transform);
    }

    void OnCollisionExit(Collision other)
    {
        if (other.gameObject.name == "Floor")
            transform.SetParent(null);
    }
}
