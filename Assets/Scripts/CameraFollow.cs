using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    Camera mainCamera;
    Dungeon dungeon;
    [SerializeField] private Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;
        dungeon = gameObject.GetComponentInParent<Dungeon>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 playerPos = gameObject.GetComponent<Transform>().position;
        playerPos.x = Mathf.Clamp(playerPos.x, (-1.6f - dungeon.size.x * 0.7f + 0.2f) + 9.7f, ((dungeon.size.x) * 1.6f - dungeon.size.x * 0.7f  + 0.2f) - 9.7f);
        playerPos.y = Mathf.Clamp(playerPos.y, (-1.6f - dungeon.size.y * 0.7f + 0.2f) + 5.8f, ((dungeon.size.y) * 1.6f - dungeon.size.y * 0.7f + 0.2f) - 5.8f);

        mainCamera.transform.position = playerPos + offset;
    }
}
