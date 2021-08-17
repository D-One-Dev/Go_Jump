using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private ParticleSystem PS;
    [SerializeField] private GameObject touchScreen;
    [SerializeField] private GameObject cam;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float jumpForce;
    private GameObject lastPlatform;
    private float currentPosY = -4f;
    private bool isDead, isJumping;
    private float timer;
    private void FixedUpdate()
    {
        if (timer < 0.5f) timer += Time.fixedDeltaTime;
        else touchScreen.SetActive(true);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (currentPosY > transform.position.y + 1f)
        {
            cam.GetComponent<DeathAnimation>().dead = true;
            isDead = true;
            if (cam.GetComponent<ScoreController>().scoreValue > PlayerPrefs.GetInt("Highscore", -1)) PlayerPrefs.SetInt("Highscore", cam.GetComponent<ScoreController>().scoreValue);
        }
        else
        { 
            isJumping = false;
            float playerY = transform.position.y - transform.localScale.y / 2;
            float platformY = collision.transform.position.y + collision.transform.localScale.y / 2 - 0.01f;
            if (collision.gameObject.CompareTag("MovingPlatform") && playerY >= platformY && !isDead)
            {
                collision.gameObject.GetComponent<PlatformController>().speed = 0f;
                collision.gameObject.GetComponent<PlatformController>().freezedPos = collision.transform.position;
                collision.gameObject.GetComponent<PlatformController>().isFreezed = true;
                rb.velocity = Vector2.zero;
                transform.rotation = Quaternion.Euler(Vector3.zero);
                currentPosY = transform.position.y;
                if (collision.gameObject != lastPlatform)
                {
                    lastPlatform = collision.gameObject;
                    cam.GetComponent<CameraController>().MoveCam(transform.position.y);
                    cam.GetComponent<PlatformSpawner>().SpawnPlatform();
                    cam.GetComponent<ScoreController>().AddScore();
                }
            }
            else if (collision.gameObject.CompareTag("MovingPlatform") && !isDead)
            {
                cam.GetComponent<DeathAnimation>().dead = true;
                isDead = true;
                if (cam.GetComponent<ScoreController>().scoreValue > PlayerPrefs.GetInt("Highscore", -1)) PlayerPrefs.SetInt("Highscore", cam.GetComponent<ScoreController>().scoreValue);
                PlayerPrefs.SetInt("Money", PlayerPrefs.GetInt("Money", 0) + cam.GetComponent<ScoreController>().scoreValue);
            }
        }
    }

    public void Jump()
    {
        if (!isDead && !isJumping)
        {
            rb.AddForce(new Vector2(0f, jumpForce));
            isJumping = true;
            PS.transform.position = new Vector3(transform.position.x, transform.position.y - 0.25f, transform.position.z);
            PS.Play();

        }
        else if (isDead)
        {
            SceneManager.LoadScene("Menu");
        }
    }
}
