using UnityEngine;
using SpaceSurvival.Core;

namespace SpaceSurvival.Player
{
    public class SurvivalSystem : MonoBehaviour
    {
        [Header("Stats")]
        public float health = 100f;
        public float maxHealth = 100f;
        public float oxygen = 100f;
        public float maxOxygen = 100f;
        public float energy = 100f;
        public float maxEnergy = 100f;

        [Header("Degradation Rates")]
        public float oxygenDepletionRate = 0.5f;
        public float energyDepletionRate = 0.2f;

        void Update()
        {
            if (GameManager.Instance.CurrentState != GameState.Exploration) return;

            // Deplete stats
            oxygen -= oxygenDepletionRate * Time.deltaTime;
            energy -= energyDepletionRate * Time.deltaTime;

            // Handle Oxygen starvation
            if (oxygen <= 0)
            {
                oxygen = 0;
                TakeDamage(5f * Time.deltaTime);
            }

            // Clamping
            health = Mathf.Clamp(health, 0, maxHealth);
            oxygen = Mathf.Clamp(oxygen, 0, maxOxygen);
            energy = Mathf.Clamp(energy, 0, maxEnergy);

            if (health <= 0)
            {
                Die();
            }
        }

        public void TakeDamage(float amount)
        {
            health -= amount;
            Debug.Log($"Player took damage! Current Health: {health}");
        }

        public void RestoreOxygen(float amount)
        {
            oxygen += amount;
        }

        void Die()
        {
            EventManager.Trigger(GameEvents.ON_PLAYER_DEATH);
            GameManager.Instance.SetState(GameState.GameOver);
        }
    }
}
