using UnityEngine;
using System.Collections;

public class EnemyBehavior : MonoBehaviour {
    public GameObject projectile;
    public float health = 150f;
    public float projectileSpeed = 5f;
    public float shotsPerSecond = 0.5f;
    public int scoreValue;

    private ScoreKeeper scoreKeeper;
    public AudioClip LaserHit;
    public AudioClip Death;
    public AudioClip fireSound;

    void Start()
    {
        scoreKeeper = GameObject.Find("Score").GetComponent<ScoreKeeper>();
    }


    void Update()
    {
        float probability = Time.deltaTime * shotsPerSecond;
        if (Random.value < probability) {
            Fire();
        }
    }

    void Fire()
    {
        Vector3 startPosition = transform.position + new Vector3(0f, 0f, 0f);
        GameObject missile = Instantiate(projectile, startPosition, Quaternion.identity) as GameObject;
        missile.GetComponent<Rigidbody2D>().velocity = new Vector3(0, -projectileSpeed, 0);
        AudioSource.PlayClipAtPoint(fireSound, transform.position);
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        Projectile missile = collider.gameObject.GetComponent<Projectile>();
        if (missile)
        {
            AudioSource.PlayClipAtPoint(LaserHit, transform.position);
            health -= missile.GetDamage();
            missile.Hit();
            scoreKeeper.Score(scoreValue);
            if (health <= 0)
            {
                AudioSource.PlayClipAtPoint(Death, transform.position);
                Destroy(gameObject);
                
            }
           

        }
    }
}
