using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator animator;
    private Vector3 tempPos;
    private Vector3 tempScale;
    private float xAxis;

    [SerializeField]
    private float incognitoSpeed = 4f;

    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        xAxis = Input.GetAxisRaw("Horizontal");

        if(xAxis != 0)
        {

            if(xAxis < 0)
            {
                tempScale = transform.localScale;
                tempScale.x = -1;
                transform.localScale = tempScale;
                animator.Play("Run");
            }

            else if(xAxis > 0)
            {
                tempScale = transform.localScale;
                tempScale.x = 1;
                transform.localScale = tempScale;
                animator.Play("Run");
            }

            tempPos = transform.position;
            tempPos.x += xAxis * incognitoSpeed * Time.deltaTime;
            transform.position = tempPos;
        }
        else
            animator.Play("Idle");
    }
}
