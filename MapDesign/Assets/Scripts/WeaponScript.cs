using UnityEngine;

/// <summary>
/// Launch projectile
/// </summary>
public class WeaponScript : MonoBehaviour
{
    private Animator an;
    //--------------------------------
    // 1 - Designer variables
    //--------------------------------

    /// <summary>
    /// Projectile prefab for shooting
    /// </summary>
    public Transform shotPrefab;

    /// <summary>
    /// Cooldown in seconds between two shots
    /// </summary>
    public float shootingRate;

    //--------------------------------
    // 2 - Cooldown
    //--------------------------------

    public float shootCooldown;

    void Start()
    {
        shootCooldown = 0f;
        an = GetComponent<Animator>();
    }

    void Update()
    {
        if (shootCooldown > 0)
        {
            shootCooldown -= Time.deltaTime;
        }
        Attack();
    }

    //--------------------------------
    // 3 - Shooting from another script
    //--------------------------------

    /// <summary>
    /// Create a new projectile if possible
    /// </summary>
    public void Attack()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (CanAttack)
            {
                shootCooldown = shootingRate;
                // Create a new shot
                var shotTransform = Instantiate(shotPrefab) as Transform;

                // Assign position
                shotTransform.position = transform.position;


                // Make the weapon shot always towards it
                onlymove move = shotTransform.gameObject.GetComponent<onlymove>();
                if (move != null)
                {
                    move.direction = this.transform.up; // towards in 2D space is the right of the sprite
                }
                an.SetBool("click", true);
            }            
        }
        else an.SetBool("click", false);
    }

    /// <summary>
    /// Is the weapon ready to create a new projectile?
    /// </summary>
    public bool CanAttack
    {
        get
        {
            return shootCooldown <= 0f;
        }
    }
}