using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class Playermovement : MonoBehaviour 
{
    public float speed = 5f;
    public float direction = 0f;
	public float jumpSpeed = 8f;
	private Rigidbody2D player;
	public KeyCode jumpKey;
	public string midjump="n";
	public AudioSource audioPlayer;
	

	// Start is called before the first frame update
	void Start () {

		player = GetComponent<Rigidbody2D> ();

	
	}

// Update is called once per frame
	void Update () 
	{  
		direction = Input.GetAxis("Horizontal");

		if (direction > 0f)
		{
			 transform.position += Vector3.right * speed * Time.deltaTime;
			 transform.localRotation = Quaternion.Euler(0, 0, 0);
		}
		else if (direction < 0f)
        {
			  transform.position += Vector3.right * -speed * Time.deltaTime;
			  transform.localRotation = Quaternion.Euler(0, 180, 0);
		}
		else
		{
			player.velocity = new Vector2(0, player.velocity.y);
		}

		if(Input.GetButtonDown("Jump") && (midjump == "n"))
		{
			player.velocity = new Vector2(player.velocity.y, jumpSpeed);
			transform.position += Vector3.up * jumpSpeed * Time.deltaTime;
            midjump="y";
		}
		 if (GetComponent<Rigidbody2D> ().velocity.y == 0)
            midjump = "n";
		
    }
 public void OnCollisionEnter2D(Collision2D collision){
	  if(collision.gameObject.tag == "CollisionTag"){
		 audioPlayer.Play();
	  }
 }
}