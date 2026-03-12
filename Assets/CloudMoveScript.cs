using UnityEngine;

public class CloudMoveScript : MonoBehaviour
{
    public float moveSpeed = 10f;
    public float deadZone = -150f;

    void Start()
    {
        moveSpeed = 10f;
        deadZone = -150f;
    }

    void Update()
    {
        transform.position += Vector3.left * moveSpeed * Time.deltaTime;

        if (transform.position.x < deadZone)
        {
            Destroy(gameObject);
        }
    }
}