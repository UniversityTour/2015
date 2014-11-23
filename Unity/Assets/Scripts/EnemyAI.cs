using UnityEngine;
using System.Collections;

public class EnemyAI : MonoBehaviour
{

    public Transform[] waypoint;
    public float speed = 20;
    private int currentWaypoint=0;
    public bool loop = false;
    float Distance = 1;
    Vector3 velocityy;
    public Transform spawnPoint;
    public bool isDead=false;

    void Awake()
    {
       // waypoint[0] = transform; //first waypoint is his starting position
    }

    // Update is called once per frame
    void Update()
    {
        if (!isDead)
        {
            if (currentWaypoint < waypoint.Length)
            {
                Vector3 target = waypoint[currentWaypoint].position;
                Vector3 moveDirection = target - transform.position;
                velocityy = rigidbody.velocity;

                if (moveDirection.magnitude < Distance)
                {
                    currentWaypoint++;
                }
                else
                {
                    velocityy = moveDirection.normalized * speed;
                }
            }
            else
            {
                if (loop)
                {
                    currentWaypoint = 0;
                }
                else
                {
                    velocityy = Vector3.zero;
                }
            }
            rigidbody.velocity = velocityy;

        }
        else
        {
            Debug.Log("ich bin tot, ich enemy");
        }
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("collision with player");
            Debug.Log("TOOOOOT!!!");
            GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>().SetBool("isDead", true);
            //other.transform.position = spawnPoint.position;
           // GameObject.FindGameObjectWithTag("MainCamera").transform.position =
            //    new Vector3(spawnPoint.position.x + 4.0f, spawnPoint.position.y + 2.0f, spawnPoint.position.z - 10.0f);
        }
    }
}
