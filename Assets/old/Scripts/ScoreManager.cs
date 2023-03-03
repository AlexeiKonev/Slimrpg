using UnityEngine;

using UnityEngine.UI;
namespace Slime {
    public class ScoreManager: MonoBehaviour {

        public static ScoreManager instance;
        public PlayerHealth playerHealth;
        public PlayerAttack playerAttack;

        public int score = 10;
        public Text scoreText;

        public Text costHealthText;
        public Text costAttackText;

        public Text currentAttackText;
        public Text currentHealthText;

        public int costHealth = 1;
        public int costAttack = 1;

        private void Awake() {
            if (instance == null) {
                instance = this;
            }
            else {
                Destroy(gameObject);
            }
        }

        public void AddScore(int points) {
            score += points;
            scoreText.text =  score.ToString();
        }
        public void AddHealth() {
            score -= costHealth;
            scoreText.text = score.ToString();
            playerHealth.currentHealth += costHealth;
            currentHealthText.text = playerHealth.currentHealth.ToString();
        }
        public void AddAttack() {
            score -= costAttack;
            scoreText.text = score.ToString();
            playerAttack.attackDamage += costAttack;
            currentAttackText.text = playerAttack.attackDamage.ToString();
        }
    }

}
