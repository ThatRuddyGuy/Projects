using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {
    public float speed = 0.075f;
    public GameObject projectile;
    public float projectileSpeed = 5f;
    public float firingRate = 0.1f;
    public float health = 1000f;
    public int healthValue = 100;

    private Health healthChange;

    public AudioClip fireSound;
    public AudioClip laserHit;
    public AudioClip death;

    private LevelManager levelManager;
    private int hits = 0;
  





    //limits for field of play
    float xmin = -6.1f;
    float xmax = 6.1f;
    float ymin = -4.5f;
    float ymax = -1.5f;

	// Use this for initialization
	void Start () {

        levelManager = GameObject.FindObjectOfType<LevelManager>();

        //Creates a clamp that provides the x values automatically
        /*
        float distance = transform.position.z - Camera.main.transform.position.z;
        Vector3 leftmost = Camera.main.ViewportToWorldPoint(new Vector3(0,0,distance));
	    Vector3 rightmost = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, distance));
        xmin = leftmost.x;
        xmax = rightmost.x;
        */

        healthChange = GameObject.Find("Health").GetComponent<Health>();

    }

    void Fire()
    {
        Vector3 offset = new Vector3(0f, 0f, 0f);
        GameObject beam = Instantiate(projectile, transform.position+offset, Quaternion.identity) as GameObject;
        beam.GetComponent<Rigidbody2D>().velocity = new Vector3(0, projectileSpeed, 0);
        AudioSource.PlayClipAtPoint(fireSound, transform.position);
    }
	

	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            InvokeRepeating("Fire", 0.000001f, firingRate);
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            CancelInvoke("Fire");
        }

        

       



        //movement input
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position += new Vector3(-speed, 0, 0);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.position += new Vector3(speed, 0, 0);
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.position += new Vector3(0, speed, 0);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.position += new Vector3(0, -speed, 0);
        }

        //restricts ship to the specified game space
        float newY = Mathf.Clamp(transform.position.y, ymin, ymax);
        float newX = Mathf.Clamp(transform.position.x, xmin, xmax);
        transform.position = new Vector3(newX, newY, transform.position.z);

        
        
	
	}

    void OnTriggerEnter2D(Collider2D collider)
    {


        

        Projectile missile = collider.gameObject.GetComponent<Projectile>();
        if (missile)
        {
            
            AudioSource.PlayClipAtPoint(laserHit, transform.position);
            health -= missile.GetDamage();
            missile.Hit();
            hits++;

            
            healthChange.Score(healthValue);

            

            
            if (health <= 0)
            {
                AudioSource.PlayClipAtPoint(death, transform.position);
                SceneManager.LoadScene("Lose");
                Destroy(gameObject);
                
            }
            


        }
    }
}
