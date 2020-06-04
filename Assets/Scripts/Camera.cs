using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{

    public GameObject player;
    // private Player playerScript;
    public float speed = 0.05f;
    private Vector3 offset = new Vector3(0, 0, -12);

    void Start() {
        // playerScript = (Player) FindObjectOfType(typeof(Player));
        transform.position = player.transform.position + offset;
    }
    void LateUpdate() {
        Vector3 desiredPosition = new Vector3(player.transform.position.x, transform.position.y, 0) + offset;
        Vector3 smoothPosition = Vector3.Lerp(transform.position, desiredPosition, speed);
        transform.position = smoothPosition;
    }
}
