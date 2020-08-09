using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float speed;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (gameObject.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Run_Rock"))
        {
            gameObject.transform.Translate(new Vector3(speed, 0));
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.gameObject.GetComponent<Animator>().SetTrigger("die");
            Debug.Log("Hit Player");
        }
        if (other.CompareTag("Ground"))
        {
            speed *= -1;
            Debug.Log("Hit Ground");
        }
    }
}
