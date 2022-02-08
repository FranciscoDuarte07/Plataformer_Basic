using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FruitManager : MonoBehaviour
{
    public Text levelCleared;
    [SerializeField] GameObject transition;
    [SerializeField] public Text totalFruits;
    [SerializeField] public Text fruitCollected;
    private int totalFruitsInLevel;

    private void Start()
    {
        totalFruitsInLevel = transform.childCount;
    }

    private void Update()
    {
        AllFruitCollected();
        totalFruits.text = totalFruitsInLevel.ToString();
        fruitCollected.text = transform.childCount.ToString();
    }
    public void AllFruitCollected()
    {
        if (transform.childCount == 0)
        {
            Debug.Log("No quedan frutas, Victoria");
            levelCleared.gameObject.SetActive(true);
            transition.SetActive(true);
            Invoke("ChangeScene", 1);
        }
    }

    void ChangeScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
