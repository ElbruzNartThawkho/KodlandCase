using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [SerializeField] private GameObject GameOver;
    [SerializeField] private GameObject Victory;
    [SerializeField] private Text HpText;

    private int enemyCount = 0;

    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        CountEnemies();
    }

    /// <summary>
    /// Oyunu kazanma durumunu iþler.
    /// </summary>
    public void Win()
    {
        Victory.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Time.timeScale = 0;
    }

    /// <summary>
    /// Oyunu kaybetme durumunu iþler.
    /// </summary>
    public void Lost()
    {
        GameOver.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Time.timeScale = 0;
    }

    /// <summary>
    /// Saðlýk puaný yazýsýný iþler.
    /// </summary>
    public void SetHp(float value)
    {
        HpText.text = value.ToString();
    }

    /// <summary>
    /// Sahnede bulunan düþmanlarý sayan fonksiyon.
    /// </summary>
    private void CountEnemies()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        enemyCount = enemies.Length;
    }

    /// <summary>
    /// Düþman sayýsýný azaltmak için kullanýlan metod.
    /// </summary>
    public void DecreaseEnemyCount()
    {
        if (enemyCount > 1)
        {
            enemyCount--;
        }
        else
        {
            Win();
        }
    }
}
