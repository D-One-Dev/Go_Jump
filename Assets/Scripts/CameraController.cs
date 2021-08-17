using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private float offset, smoothness;
    [SerializeField] private GameObject player;
    private float playerY;
    public bool isMoving;
    void Start()
    {
        playerY = player.transform.position.y;
        transform.position = new Vector3(transform.position.x, player.transform.position.y + offset, transform.position.z);
    }
    void FixedUpdate()
    {
        if (isMoving)
        { 
            float posY = Mathf.Lerp(transform.position.y, playerY + offset, smoothness);
            transform.position = new Vector3(transform.position.x, posY, transform.position.z);
        }
        if (transform.position.y >= playerY + offset - 0.01f && isMoving)
        {
            isMoving = false;
        }
    }
    public void MoveCam(float playerYPos)
    {
        playerY = playerYPos;
        isMoving = true;
    }
}
