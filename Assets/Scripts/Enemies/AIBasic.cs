using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIBasic : MonoBehaviour
{
    [SerializeField] public Animator animator;
    [SerializeField] public SpriteRenderer spriteRenderer;
    [SerializeField] public float speed = 0.5f;
    [SerializeField] public Transform[] moveSpots;
    private float waitTime;
    [SerializeField] public float starWaitTime = 2;
    private int i = 0;
    private Vector2 actualPos;


    // Start is called before the first frame update
    void Start()
    {
        waitTime = starWaitTime;
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(ChekckEnemyMoving());

        transform.position = Vector2.MoveTowards(transform.position, moveSpots[i].transform.position, speed * Time.deltaTime); //genera el movimiento de nuestro personaje de un punto a otro
        if (Vector2.Distance(transform.position,moveSpots[i].transform.position) < 0.1f)
        {
            if (waitTime <= 0)
            {
                if (moveSpots[i] != moveSpots[moveSpots.Length-1])
                {
                    i++;
                }
                else
                {
                    i = 0;
                }
                waitTime = starWaitTime;
            }
            else
            {
                waitTime -= Time.deltaTime;
            }
        }
    }

    IEnumerator ChekckEnemyMoving()
    {
        actualPos = transform.position;
        yield return new WaitForSeconds(0.5f);
        if (transform.position.x > actualPos.x)
        {
            spriteRenderer.flipX = true;
            animator.SetBool("Idle", false);
        }
        else if (transform.position.x < actualPos.x)
        {
            spriteRenderer.flipX = false;
            animator.SetBool("Idle", false);
        }
        else if (transform.position.x == actualPos.x)
        {
            animator.SetBool("Idle", true);
        }
    }
}
