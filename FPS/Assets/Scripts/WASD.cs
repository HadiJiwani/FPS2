using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WASD : MonoBehaviour
{
    public float MovementSpeed = 1f;
    private Rigidbody2D _rigidbody;
    public float JumpForce = 1f;
    private bool facingright = true;
    private bool isGrounded;
    private bool canShoot;
    
    public Transform groundCheck;
    public float checkRaidius;
    public LayerMask whatIsGround;
    public Transform player;
    public KeyCode shootbtn;
    public Transform FirePoint;
    public GameObject bullet;
    public int bulletAmount = 3;
    public int reloadTime;
    public HealthBar healthbar;
    public int maxHealth = 5;
    public int CH;



    // Start is called before the first frame update
    void Start()
    {
        canShoot = true;
        _rigidbody = GetComponent<Rigidbody2D>();
        healthbar.SetMaxHealth(maxHealth);
        CH = maxHealth;

    }


    private void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRaidius, whatIsGround);
    }


    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown(shootbtn))
        {
            shoot();
        }

        var movement = Input.GetAxis("WASD");
        transform.position += new Vector3(movement, 0, 0) * Time.deltaTime * MovementSpeed;
        
        if(isGrounded == true)
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                _rigidbody.AddForce(new Vector2(0, JumpForce), ForceMode2D.Impulse);
            }
        }

        if(movement<0 && facingright)
        {
            flip();
        }
        else if (movement>0 && !facingright)
        {
            flip();
        }

        if(bulletAmount == 0)
        {
            canShoot = false;
        }
        else if (bulletAmount > 0)
        {
            canShoot = true;
        }
    }

    public void shoot()
    {
        if (canShoot == true)
        {
            Instantiate(bullet, FirePoint.position, FirePoint.rotation);
            bulletAmount--;

            StartCoroutine(waitBeforeReload());

            waitBeforeReload();
        }
    }

    void flip()
    {
        facingright = !facingright;
        transform.Rotate(0, 180f, 0);
    }

    IEnumerator waitBeforeReload()
    {
        yield return new WaitForSeconds(reloadTime);

        bulletAmount++;
    }

}
