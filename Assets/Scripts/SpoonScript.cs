using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class SpoonScript : MonoBehaviour
{
    [SerializeField]
    private Vector2 throwForce;

    private bool isActive = true;

    private Rigidbody2D rb;

    private BoxCollider2D spoonCollider;

    public GameController GameController;

    public enum Sounds : int
    {
        IcecreamHit = 0,
        SpoonHit = 1,
    }

    public AudioSource[] splosh;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        spoonCollider = GetComponent<BoxCollider2D>();
        GameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && isActive)
        {
            rb.AddForce(throwForce, ForceMode2D.Impulse);
            rb.gravityScale = 1;
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (!isActive)
            return;
        isActive = false;

        if (collision.collider.CompareTag("Scoop"))
        {
            GetComponent<ParticleSystem>().Play();

            rb.velocity = new Vector2(0, 0);
            rb.bodyType = RigidbodyType2D.Kinematic;
            transform.SetParent(collision.collider.transform);

            GameController.DecrementDisplayedSpoonCount();

            GameController.OnSuccessfulSpoonHit();
            splosh[(int)Sounds.IcecreamHit].Play();
        }
        else
        {
            rb.velocity = new Vector2(rb.velocity.x, -2);

            GameController.ShowRestartButton();
            splosh[(int)Sounds.SpoonHit].Play();
        }
    }
}
