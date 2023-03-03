using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
/// <summary>
/// синглтон для управления ресурсами игры
/// </summary>
public class SlimeGame : MonoBehaviour {

    public Text textMoney;
    public Text textAttack;
    public Text textHealth;

    public Text textAttackCost;
    public Text textHealthCost;


    public int money = 3;

    public int attack = 1;
    public int health = 10;

    public int attackCost = 1;
    public int healthCost = 1;

    public static SlimeGame instance;

    public GameObject prefabOfbattleArea;
    public bool isAreaClear = false;

    public GameObject GameOverScreen;

    void Awake() {
        if (instance == null) {
            instance = gameObject.GetComponent<SlimeGame>();
        }
        GameOverScreen.SetActive(false);
    }
    private void Update() {
        if (money > 0) {
            UpdateUI(textMoney, money);
        }
      
        UpdateUI(textAttack, attack);
        UpdateUI(textHealth, health);
       
    }

    public void BuyAttack() {
        if (money > 0) {
            money -= attackCost;
            attack++;
            attackCost++;//увеличим цену


            //изменим ui

            UpdateUI(textMoney, money);
            UpdateUI(textAttack, attack);
            UpdateUI(textAttackCost, attackCost);
        }
    }
    public void BuyHealth() {
        if (money > 0) {
            money -= healthCost;
            health++;
            attackCost++;

            UpdateUI(textMoney, money);
            UpdateUI(textHealth, health);
            UpdateUI(textHealthCost, healthCost);


        }
    }
    void UpdateUI(Text some, int change) {
        some.text = change.ToString();
    }
    public void AddMoney() {
        money++;
        UpdateUI(textMoney, money);
    }
    public void ShowGameOver() {
        GameOverScreen.SetActive(true); 
        Time.timeScale = 0;
    } 
 public  void RestartLevel() {
        SceneManager.LoadScene(0); 
        Time.timeScale = 1;



    }
}
