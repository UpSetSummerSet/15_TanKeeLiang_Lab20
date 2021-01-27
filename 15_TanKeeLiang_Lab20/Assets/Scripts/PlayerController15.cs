using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController15 : MonoBehaviour
{
    float speed = 6.0f;
    float rotatespeed = 3.0f;
    float jumpForce = 16.0f;

    int maxspeed = 6;
    bool IsGround = true;

    Rigidbody rb;
    AudioSource audioSource;

    public ParticleSystem jumpParticle;
    public AudioClip[] audioClips;
    public ParticleSystem collisionPartical;
    public ParticleSystem dustPartical;

    public float maxX;
    public float minX;
    public float maxZ;
    public float minZ;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.forward * Time.deltaTime * -speed);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.up * Time.deltaTime * -rotatespeed);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(Vector3.up * Time.deltaTime * rotatespeed);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
        */
        PlayerLimit();

        PlayerMovement();

        RestartGame();
    }

    private void PlayerMovement()
    {
        //Movement
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        transform.Rotate(new Vector3(0, h * rotatespeed, 0));

        rb.AddForce(v * transform.forward * speed);

        rb.velocity = new Vector3(Mathf.Clamp(rb.velocity.x, -maxspeed, maxspeed), 
            Mathf.Clamp(rb.velocity.y, -maxspeed, maxspeed), 
            Mathf.Clamp(rb.velocity.z, -maxspeed, maxspeed));

        //DustPartical Effect
        if (Input.GetKeyDown(KeyCode.W))
        {
            dustPartical.Play();
        }
        else if (Input.GetKeyDown(KeyCode.W))
        {
            dustPartical.Stop();
        }

        //Jump
        if (Input.GetKeyDown(KeyCode.Space) && IsGround == true)
        {
            audioSource.PlayOneShot(audioClips[1]);

            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);

            IsGround = false;

            jumpParticle.Play();
        }
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            jumpParticle.Stop();
        }
    }

    private void PlayerLimit()
    {
        if(transform.position.z > maxZ)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, maxZ);
        }
        else if (transform.position.z < minZ)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, minZ);
        }
        if (transform.position.x > maxX)
        {
            transform.position = new Vector3(maxX, transform.position.y, transform.position.z);
        }
        else if (transform.position.x < minX)
        {
            transform.position = new Vector3(minX, transform.position.y, transform.position.z);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Wall")
        {
            collisionPartical.Play();
            audioSource.PlayOneShot(audioClips[0]);
        }
        if(collision.gameObject.tag == "Ground")
        {
            if(IsGround == false)
            {
                IsGround = true;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Goal"))
        {
            audioSource.PlayOneShot(audioClips[2]);
        }
    }
    private void RestartGame()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene("SampleScene");
        }
    }
}
