using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSelect : MonoBehaviour
{
    [SerializeField] public enum Player {Frog, VirtualGuy, PinkMan };
    public Player playerSelected;
    [SerializeField] Animator animator;
    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] RuntimeAnimatorController[] playersControler;
    [SerializeField] Sprite[] playerRenderer;
    bool enableSelectPlayer;


    // Start is called before the first frame update
    void Start()
    {
        if (!enableSelectPlayer){
            ChangePlayerInMenu();
        }
        else{
            switch (playerSelected){
                case Player.Frog:
                    spriteRenderer.sprite = playerRenderer[0];
                    animator.runtimeAnimatorController = playersControler[0];
                    break;
                case Player.VirtualGuy:
                    spriteRenderer.sprite = playerRenderer[2];
                    animator.runtimeAnimatorController = playersControler[2];
                    break;
                case Player.PinkMan:
                    spriteRenderer.sprite = playerRenderer[1];
                    animator.runtimeAnimatorController = playersControler[1];
                    break;
                default:
                    break;
            }
        }
    }

    public void ChangePlayerInMenu(){
        switch (PlayerPrefs.GetString("PlayerSelected")){
            case ("Frog"):
                spriteRenderer.sprite = playerRenderer[0];
                animator.runtimeAnimatorController = playersControler[0];
                break;
            case ("VirtualGuy"):
                spriteRenderer.sprite = playerRenderer[2];
                animator.runtimeAnimatorController = playersControler[2];
                break;
            case ("PinkMan"):
                spriteRenderer.sprite = playerRenderer[1];
                animator.runtimeAnimatorController = playersControler[1];
                break;
            default:
                break;
        }
    }
}
