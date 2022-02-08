using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class OpenDoor : MonoBehaviour
{
    [SerializeField] Text text;
    [SerializeField] string levelName;
    bool inDoor = false;

    private void OnTriggerEnter2D(Collider2D collision){
        if (collision.gameObject.CompareTag("Player")){
            text.gameObject.SetActive(true);
            inDoor = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision) {
        text.gameObject.SetActive(false);
        inDoor = false;
    }

    private void Update(){
        if (inDoor && Input.GetKey("e")){
            SceneManager.LoadScene(levelName);
        }
    }
}
