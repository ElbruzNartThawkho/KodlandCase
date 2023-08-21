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
    /// Oyunu kazanma durumunu i�ler.
    /// </summary>
    public void Win()
    {
        Victory.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Time.timeScale = 0;
    }

    /// <summary>
    /// Oyunu kaybetme durumunu i�ler.
    /// </summary>
    public void Lost()
    {
        GameOver.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Time.timeScale = 0;
    }

    /// <summary>
    /// Sa�l�k puan� yaz�s�n� i�ler.
    /// </summary>
    public void SetHp(float value)
    {
        HpText.text = value.ToString();
    }

    /// <summary>
    /// Sahnede bulunan d��manlar� sayan fonksiyon.
    /// </summary>
    private void CountEnemies()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        enemyCount = enemies.Length;
    }

    /// <summary>
    /// D��man say�s�n� azaltmak i�in kullan�lan metod.
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
