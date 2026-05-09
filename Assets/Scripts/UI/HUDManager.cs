using UnityEngine;
using UnityEngine.UI;
using SpaceSurvival.Player;

namespace SpaceSurvival.UI
{
    public class HUDManager : MonoBehaviour
    {
        public SurvivalSystem playerStats;

        [Header("UI Elements")]
        public Image healthBar;
        public Image oxygenBar;
        public Image energyBar;
        public Text planetInfoText;

        void Update()
        {
            if (playerStats == null) return;

            // Update Bars
            healthBar.fillAmount = playerStats.health / playerStats.maxHealth;
            oxygenBar.fillAmount = playerStats.oxygen / playerStats.maxOxygen;
            energyBar.fillAmount = playerStats.energy / playerStats.maxEnergy;

            // Update Colors based on critical levels
            oxygenBar.color = (playerStats.oxygen < 20) ? Color.red : Color.cyan;
        }

        public void SetPlanetName(string name)
        {
            planetInfoText.text = $"Location: {name}";
        }
    }
}
