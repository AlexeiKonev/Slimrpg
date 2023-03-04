using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
/// <summary>
/// синглтон для управления ресурсами игры
/// </summary>
public class SlimeGame : MonoBehaviour {
    public Shoot shoot;

    public Text textMoney;
    public Text textAttack;
    public Text textAttackSpeed;
    public Text textHealth;

    public Text textAttackCost;
    public Text textSpeedAttackCost;
    public Text textHealthCost;


    public int money = 23;

    public int attack = 1;
    public int health = 10;

    public int attackCost = 1;
    public int attackSpeedCost = 1;
    public int healthCost = 1;

    public static SlimeGame instance;

    public GameObject prefabOfbattleArea;
    public bool isAreaClear = false;

    public GameObject GameOverScreen;

    
    private float attackSpeed;

    public Button btnBuyAttack;
    public Button btnBuySpeedAttack;
    public Button btnBuyHealthAttack;

    void Awake() {
        if (instance == null) {
            instance = gameObject.GetComponent<SlimeGame>();
        }
        GameOverScreen.SetActive(false);
    }
    private void Update() {
        if (money <= 0) {
            btnBuyAttack.enabled=false;
            btnBuySpeedAttack.enabled = false;
            btnBuyHealthAttack.enabled = false;
        }
        else if(money > 0) {
            btnBuyAttack.enabled=true;  
            btnBuySpeedAttack.enabled=true;
            btnBuyHealthAttack.enabled = true;
        }

        if (money >= 0) {
            UpdateUI(textMoney, money);
        }

        UpdateUI(textAttack, attack);
        UpdateUI(textHealth, health);
        UpdateUI(textAttackSpeed, (int)attackSpeed+1);

        UpdateUI(textHealthCost, healthCost);
        UpdateUI(textAttackCost, attackCost);
        UpdateUI(textSpeedAttackCost, attackSpeedCost);

       

    }

    public void BuyAttack() {
        if (money > 0) {
            money -= attackCost;
            attack++;
            attackCost++;//увеличим цену


            //изменим ui

            //UpdateUI(textMoney, money);
            //UpdateUI(textAttack, attack);
            //UpdateUI(textAttackCost, attackCost);
        }
        else {
            return;
        }
    }
    public void BuyAttackSpeed() {
        if (money > 0) {
            money -= attackSpeedCost;
            attackSpeed += 0.2f;
            attackSpeedCost++;//увеличим цену
            shoot.ChangeDelay(attackSpeed);


            //изменим ui

            //UpdateUI(textMoney, money);
            //UpdateUI(textAttack, attack);
            //UpdateUI(textAttackCost, attackCost);
        }
        else {
            return;
        }
    }
    public void BuyHealth() {
        if (money > 0) {
            money -= healthCost;
            health++;
            attackCost++;

            //UpdateUI(textMoney, money);
            //UpdateUI(textHealth, health);
            //UpdateUI(textHealthCost, healthCost);


        }
        else {
            return;
        }
    }
    void UpdateUI(Text some, int change) {
        some.text = change.ToString();
    }
    public void AddMoney() {
        money++;
        //UpdateUI(textMoney, money);
    }
    public void ShowGameOver() {
        GameOverScreen.SetActive(true);
        Time.timeScale = 0;
    }
    public void RestartLevel() {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;



    }
}

