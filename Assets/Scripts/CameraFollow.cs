using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    Camera mainCamera;
    [SerializeField] private Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 playerPos = gameObject.GetComponent<Transform>().position;
        Mathf.Clamp(playerPos.x, 0, 1);
        Mathf.Clamp(playerPos.y, 0, 1);

        mainCamera.transform.position = playerPos + offset;
    }
}
