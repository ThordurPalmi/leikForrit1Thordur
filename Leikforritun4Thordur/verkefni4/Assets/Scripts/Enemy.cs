using System;
using UnityEngine;

public class Enemy : MonoBehaviour
{
	public float speed;
	public float timeToChange;
	public bool horizontal;

	public GameObject smokeParticleEffect;
	public ParticleSystem fixedParticleEffect;
	
	Rigidbody2D rigidbody2d;
	float remainingTimeToChange;
	Vector2 direction = Vector2.right;
	
	Animator animator;
	
	
	void Start ()
	{
		rigidbody2d = GetComponent<Rigidbody2D>();
		remainingTimeToChange = timeToChange;

		direction = horizontal ? Vector2.right : Vector2.down;

		animator = GetComponent<Animator>();

	}
	
	void Update()
	{

		remainingTimeToChange -= Time.deltaTime;

		if (remainingTimeToChange <= 0)
		{
			remainingTimeToChange += timeToChange;
			direction *= -1;
		}

		animator.SetFloat("ForwardX", direction.x);
		animator.SetFloat("ForwardY", direction.y);
	}

	void FixedUpdate()
	{
		rigidbody2d.MovePosition(rigidbody2d.position + direction * speed * Time.deltaTime);
	}

	void OnCollisionStay2D(Collision2D other)
	{
		
		RubyController controller = other.collider.GetComponent<RubyController>();
		
		if(controller != null)
			controller.ChangeHealth(-1);
	}
}
