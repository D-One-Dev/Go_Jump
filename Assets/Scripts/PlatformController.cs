using UnityEngine;

public class PlatformController : MonoBehaviour
{
    [SerializeField] private Sprite[] platformsSkins;
    [SerializeField] Rigidbody2D rb;
    [SerializeField] private float maxSpeed, minSpeed;
    public Vector3 freezedPos;
    public float speed;
    public bool isFreezed;
    void Start()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = platformsSkins[PlayerPrefs.GetInt("PlatformsSprite", 0)];
        speed = Random.Range(minSpeed, maxSpeed);
        transform.localScale = new Vector3(Random.Range(2f, 5f), 1f, 1f);
    }
    void FixedUpdate()
    {
        if (isFreezed)
        { 
            rb.velocity = Vector2.zero;
            transform.position = freezedPos;
        }
        transform.position += new Vector3(speed * Time.fixedDeltaTime, 0f, 0f);
        if (transform.position.x - transform.localScale.x/2 >= 3f && speed > 0f) speed = -speed;
        else if (transform.position.x + transform.localScale.x/2 <= -3f && speed < 0f) speed = -speed;
    }
}
