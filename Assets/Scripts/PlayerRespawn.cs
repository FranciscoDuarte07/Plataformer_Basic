using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerRespawn : MonoBehaviour
{
    private float checkPointPositionX, checkPointPositionY;
    [SerializeField] Animator animator;
    public GameObject[] hearts;
    private int lifes;

    // Start is called before the first frame update
    void Start(){
        lifes = hearts.Length;
        if (PlayerPrefs.GetFloat("checkPointPositionX") != 0){
            transform.position = (new Vector2(PlayerPrefs.GetFloat("checkPointPositionX"), PlayerPrefs.GetFloat("checkPointPositionY")));
        }
    }

    private void CheckLife()
    {
        if (lifes < 1)
        {
            Destroy(hearts[0].gameObject);
            animator.Play("Hit");
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        else if (lifes < 2)
        {
            Destroy(hearts[1].gameObject);
            animator.Play("Hit");
        }
        else if (lifes < 3)
        {
            Destroy(hearts[2].gameObject);
            animator.Play("Hit");
        }
    }

    public void ReachedCheckPoint(float x, float y){
        PlayerPrefs.SetFloat("checkPointPositionX",x);
        PlayerPrefs.SetFloat("checkPointPositionY", y);
    }

    public void PlayerDamaged(){
        lifes--;
        CheckLife();
    }
}
