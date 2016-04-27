using UnityEngine;
using System.Collections;

public class CharacterMovement : MonoBehaviour {

    Rigidbody2D playerRigidbody;

    bool facingRight;

    public float speed = 4f;

    //public GameObject playerSprite;
    Animator anim;

    //Transform mainCamera;

    // Use this for initialization
	void Start ()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
        anim = GetComponentInChildren<Animator>();
        //mainCamera = Camera.main.GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        //TODO: Add touch controls (whatever form I want)

        float moveHorizontal = Input.GetAxis("Horizontal");
        anim.SetFloat("speed", Mathf.Abs(moveHorizontal));
        playerRigidbody.velocity = new Vector2(moveHorizontal * speed, playerRigidbody.velocity.y);

        if (!facingRight && moveHorizontal > 0)
        {
            Flip();
        }
        else if (facingRight && moveHorizontal < 0)
        {
            Flip();
        }
    }

    void Flip()
    {
        facingRight = !facingRight;

        Vector3 playerScale = transform.localScale;
        playerScale.x *= -1;
        transform.localScale = playerScale;

        //Vector3 cameraScale = mainCamera.localScale;
        //cameraScale.x *= -1;
        //mainCamera.localScale = cameraScale;


    }

}
