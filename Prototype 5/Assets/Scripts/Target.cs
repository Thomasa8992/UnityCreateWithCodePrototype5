using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    private Rigidbody targetRigidBody;
    private GameManager gameManager;
    public ParticleSystem explosionParticle;

    private const float minSpeed = 12;
    private const float maxSpeed = 16;

    private const float minTorque = -10;
    private const float maxTorque = 10;

    private const float minXRange = -4;
    private const float maxXRange = 4;
    private const float ySpawnPosition = -2;

    public int pointValue;
    // Start is called before the first frame update
    void Start() {
        targetRigidBody = GetComponent<Rigidbody>();

        targetRigidBody.AddForce(RandomForce(), ForceMode.Impulse);
        targetRigidBody.AddTorque(RandomTorque(), RandomTorque(), RandomTorque(), ForceMode.Impulse);

        transform.position = RandomSpawnPosition();

        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }
    private static Vector3 RandomForce() {
        return Vector3.up * Random.Range(minSpeed, maxSpeed);
    }
    private static float RandomTorque() {
        return Random.Range(minTorque, maxTorque);
    }

    private static Vector3 RandomSpawnPosition() {
        return new Vector3(Random.Range(minXRange, maxXRange), ySpawnPosition);
    }

    private void OnMouseDown() {
        if (gameManager.isGameActive) {
            Destroy(gameObject);
            Instantiate(explosionParticle, transform.position, explosionParticle.transform.rotation);
            gameManager.UpdateScore(pointValue);
        }
    }

    private void OnTriggerEnter(Collider other) {
        Destroy(gameObject);
        if(!gameObject.CompareTag("Bad")) {
            gameManager.GameOver();
        }
    }





    // Update is called once per frame
    void Update()
    {
        
    }
}
