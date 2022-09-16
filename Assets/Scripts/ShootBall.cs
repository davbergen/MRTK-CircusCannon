using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootBall : MonoBehaviour
{
    [SerializeField] private GameObject projectilePrefab = null;
    [SerializeField] private float firePower = 15f;

    private int firedBalls = 0;

    // Start is called before the first frame update
    void Start()
    {
        if(projectilePrefab == null)
        {
            Debug.LogWarning("Please attach a cannonball prefab to this ShootBall script");
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(firedBalls < Time.fixedTime/2f)  //fire once every 2 seconds
        {
            firedBalls++;
            GameObject ball = Instantiate(projectilePrefab, this.transform.position, Quaternion.identity);
            ball.transform.SetParent(this.transform);   //just to reduce clutter
            Rigidbody ballRB = ball.GetComponent<Rigidbody>();
            if (ballRB != null)
                ballRB.AddForce(this.transform.up * firePower, ForceMode.Impulse);
            else
                Debug.LogWarning("Projectile is missing a rigidBody!");
        }
    }
}
