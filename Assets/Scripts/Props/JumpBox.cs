using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpBox : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] GameObject brokenPart;
    [SerializeField] float jumpforce = 4f;
    [SerializeField] float lifes = 1f;
    [SerializeField] GameObject boxCollider;
    [SerializeField] Collider2D collid2D;
    [SerializeField] GameObject fruit;

    private void Start()
    {
        fruit.SetActive(false);
        fruit.transform.SetParent(FindObjectOfType<FruitManager>().transform);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.up * jumpforce;
            LosseAndHit();
        }
    }

    public void LosseAndHit()
    {
        lifes--;
        animator.Play("Hit");
        CheckLife();
    }

    public void CheckLife()
    {
        if (lifes <= 0)
        {
            fruit.SetActive(true);
            boxCollider.SetActive(false);
            collid2D.enabled = false;
            brokenPart.SetActive(true);
            spriteRenderer.enabled = false;
            Invoke("DestroyBox", 0.5f);
        }
    }

    public void DestroyBox()
    {
        Destroy(transform.parent.gameObject);
    }
}
