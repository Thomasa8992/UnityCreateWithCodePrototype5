using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    private const float minSpeed = 12;
    private const float maxSpeed = 16;

    private const float minTorque = -10;
    private const float maxTorque = 10;

    private const float minXRange = -4;
    private const float maxXRange = 4;
    private const float ySpawnPosition = -6;

    private Rigidbody targetRigidBody;
    // Start is called before the first frame update
    void Start() {
        targetRigidBody = GetComponent<Rigidbody>();

        targetRigidBody.AddForce(RandomForce(), ForceMode.Impulse);
        targetRigidBody.AddTorque(RandomTorque(), RandomTorque(), RandomTorque(), ForceMode.Impulse);

        transform.position = RandomSpawnPosition();
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





    // Update is called once per frame
    void Update()
    {
        
    }
}
