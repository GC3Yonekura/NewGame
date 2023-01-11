using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveField : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Transform MField;
  

    //�����S�~
    //int counter = 0;
   float move = 0.01f;

    //�v���C���[�e�q�֌W
    Rigidbody rb;
    float upForce = 100f;
    [SerializeField] GameObject parentObj;

    //�đq

    void Start()
    {
        //�v���C���[�e�q�֌W
        rb = GetComponent<Rigidbody>();
        parentObj = GameObject.Find("Move");
    }

    // Update is called once per frame
    void Update()
    {
        //�đq
        MField.position = new Vector3(MField.position.x + move,MField.position.y,MField.position.z);
        //�o�J�̍l��
        //transform.Translate(new Vector3(move, 0, 0));
        //counter++;
        //if (counter == 300)
        // {
        // counter = 0;
        // move *= -1;
        // }

        //�v���C���[�e�q�֌W
        if (Input.GetMouseButtonDown(0))
            rb.AddForce(new Vector3(0, upForce, 0));
    }

    //�v���C���[�e�q�֌W
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