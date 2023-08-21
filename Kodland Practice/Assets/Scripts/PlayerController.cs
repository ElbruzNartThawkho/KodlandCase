using UnityEngine;

/// <summary>
/// Oyuncu karakterinin kontrol�n� sa�layan s�n�f.
/// </summary>
public class PlayerController : MonoBehaviour
{
    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform rifleStart;

    [SerializeField] private float moveSpeed = 10;
    [SerializeField] private float gravity = 10;
    private CharacterController characterController;

    public float health = 100;

    private void Start()
    {
        characterController = GetComponent<CharacterController>();
        GameManager.instance.SetHp(health);
    }

    private void Update()
    {
        Movement();
        if (Input.GetMouseButtonDown(0))
        {
            Shot();
        }
    }

    /// <summary>
    /// Oyuncunun sa�l�k de�erini de�i�tirir.
    /// </summary>
    /// <param name="hp">De�i�tirilecek sa�l�k miktar�.</param>
    public void ChangeHealth(int hp)
    {
        health += hp;
        if (health > 100)
        {
            health = 100;
        }
        else if (health <= 0)
        {
            GameManager.instance.Lost();
        }
        GameManager.instance.SetHp(health);
    }

    /// <summary>
    /// Fare t�klamas�na g�re ate� etme i�lemini ger�ekle�tirir.
    /// </summary>
    public void Shot()
    {
        Instantiate(bullet, rifleStart.position, rifleStart.rotation);
    }

    /// <summary>
    /// Oyuncu hareketini sa�lar.
    /// </summary>
    public void Movement()
    {
        if (characterController.isGrounded)
        {
            Vector3 moveDirection = Input.GetAxis("Vertical") * transform.forward + Input.GetAxis("Horizontal") * transform.right;
            characterController.Move(moveSpeed * Time.deltaTime * moveDirection);
        }
        else
        {
            characterController.Move(gravity * Time.deltaTime * Vector3.down);
        }
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.CompareTag("Heal"))
        {
            ChangeHealth(50);
            Destroy(hit.gameObject);
        }
        else if (hit.gameObject.CompareTag("Finish"))
        {
            GameManager.instance.Win();
        }
        else if (hit.gameObject.CompareTag("Enemy"))
        {
            GameManager.instance.Lost();
        }
    }
}