using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    #region Show in Inspector

    public float speed;

    #endregion


    private void Awake()
    {
		_rigidbody = GetComponent<Rigidbody>();
    }


    private void Update()
    {
        GetInputs();
    }

    private void FixedUpdate()
    {
        MoveWithVelocity();
    }

    #region Private methods

    /// <summary>
    /// Collects inputs from user
    /// </summary>
    private void GetInputs()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        _movementDirection = new Vector3(horizontal, 0, vertical);
        _movementDirection.Normalize();
    }

    /// <summary>
    /// Rigidbody.velocity = newVelocity
    /// Uses above Vector3 to give velocity to the rigidbody.
    /// The engine applies the movement.
    /// </summary>
    private void MoveWithVelocity()
    {
        Vector3 velocity = _movementDirection * speed;
        _rigidbody.velocity = velocity;
    }

    #endregion

    #region Private 

    private Rigidbody _rigidbody;
    private Vector3 _movementDirection;

    #endregion
}
