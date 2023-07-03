using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaMove : MonoBehaviour
{
    //滑行速度
    public float speed = 5f;
    //旋转速度
    public float rotateSpeed = 1f;

    private bool isFlip = false;

    Rigidbody rigid;

    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void FixedUpdate()
    {
        RaycastHit hit;
        Vector3 point_dir = transform.TransformDirection(Vector3.down);
        Vector3 start = transform.position + new Vector3(0, 2, 0);
        if (Physics.Raycast(start, point_dir, out hit, 3f, LayerMask.GetMask("Ground")))
        {
            isFlip = false;
            Quaternion nextRot = Quaternion.LookRotation(Vector3.Cross(hit.normal, Vector3.Cross(transform.forward, hit.normal)), hit.normal);
            transform.rotation = Quaternion.Lerp(transform.rotation, nextRot, 0.1f);
            Move();
        }
        else
        {
            if (Input.GetKey(KeyCode.K) && !isFlip)
            {
                GameObject.Find("Player").GetComponent<AniController>().Flip();
                
                GameObject.Find("ScoreText").GetComponent<PlayerScore>().AddScore(100);
                isFlip = true;
            }
        }

    }

    private void Move()
    {
        if (Input.GetKey(KeyCode.W))
        {
            rigid.AddForce(transform.forward * speed);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.up, -rotateSpeed);
        }
        if (Input.GetKey(KeyCode.S))
        {
            rigid.AddForce(-transform.forward * speed);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(Vector3.up, rotateSpeed);
        }
    }

}
