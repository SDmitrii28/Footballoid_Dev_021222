using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(new Vector2(0.5f, -1f) * speed);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("platform")){
            FindObjectOfType<GameOver>().audBlock.Play();
            Destroy(collision.gameObject);
            SpawnBlock.countBlock--;
            SpawnBlock.best_score++;
            SpawnBlock.score++;
            FindObjectOfType<SpawnBlock>().checkingCountBall();
        }
        if (collision.collider.CompareTag("gameover"))
        {
            Time.timeScale = 0f;
            FindObjectOfType<GameOver>().ActivePanelGameOver();
        }
    }
}
