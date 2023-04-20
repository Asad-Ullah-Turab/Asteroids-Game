using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A ship
/// </summary>
public class Ship : MonoBehaviour
{
    // thrust and rotation support
    Rigidbody2D rb2D;
    Vector2 thrustDirection = new Vector2(1, 0);
    const float ThrustForce = 10;
    const float rotationForce = 1;

	/// <summary>
	/// Start is called before the first frame update
	/// </summary>
	void Start()
	{
		// saved for efficiency
        rb2D = GetComponent<Rigidbody2D>();
	}

    /// <summary>
    /// Update is called once per frame
    /// </summary>
    void Update()
    {
        // change thrust direction to match ship rotation
        float zRotation = transform.eulerAngles.z * Mathf.Deg2Rad;
        thrustDirection.x = Mathf.Cos(zRotation);
        thrustDirection.y = Mathf.Sin(zRotation);
    }

    /// <summary>
    /// FixedUpdate is called 50 times per second
    /// </summary>
    void FixedUpdate()
    {
        HandleRotation();
        HandleThrust();
    }

    void HandleRotation()
    { 
        //rotate
        float rotationInput = Input.GetAxisRaw("Rotate");
        rb2D.AddTorque(rotationForce * rotationInput * Time.deltaTime, ForceMode2D.Impulse);

        if (rotationInput == 0)
            rb2D.angularVelocity = 0;
    }
    void HandleThrust()
    {
        float thrustInput = Input.GetAxisRaw("Thrust");
        rb2D.AddForce(ThrustForce * thrustDirection * thrustInput, ForceMode2D.Force);
    }
}
