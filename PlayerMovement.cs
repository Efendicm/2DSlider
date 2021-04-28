using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float hSpeed;
    public float jumpforce;
    private bool Isjumping = false;

    public Rigidbody2D rb;

    public bool FacingRight;

    public SpriteRenderer CharacterSpriteRenderer;

    public void Awake()
    {
        CharacterSpriteRenderer = GetComponent<SpriteRenderer>();
    }
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {

        FacingRightMethod();

        if (FacingRight == true)
        {
            if (CharacterSpriteRenderer.flipX != false) CharacterSpriteRenderer.flipX = false;
        }
        else
        {
            if (CharacterSpriteRenderer.flipX != true) CharacterSpriteRenderer.flipX = true;
        }


        if (Input.GetKey(KeyCode.A))
        {
            rb.velocity = new Vector2(-hSpeed * Time.deltaTime, rb.velocity.y);
        }

        if (Input.GetKey(KeyCode.D))
        {
            rb.velocity = new Vector2(hSpeed * Time.deltaTime, rb.velocity.y);
        }
        //Jump Code

        if (Isjumping)
        {
            rb.AddForce(new Vector2(0f, jumpforce));
        }
        if (Input.GetButtonDown("Jump"))
        {
            Isjumping = true;
        }
    }
        


    public void FacingRightMethod()
    {
        if (rb.velocity.x > 0)
        {
            FacingRight = true;
        }
        if (rb.velocity.x < 0)
        {
            FacingRight = false;
        }
    }



}
