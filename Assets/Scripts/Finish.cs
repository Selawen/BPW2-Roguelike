using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Finish : MonoBehaviour
{
    [SerializeField] private GameObject finishPanel;

    // Start is called before the first frame update
    void Start()
    {
        finishPanel = GameObject.Find("FinishPanel");
        finishPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Time.timeScale = 0;
            finishPanel.SetActive(true);
        }
    }
}
