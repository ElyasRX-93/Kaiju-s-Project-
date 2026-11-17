using System.Security.Cryptography.X509Certificates;
using System.Timers;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
namespace ProjectKaiju
{
    public class Program
    {
        public static void Main(string[] args)
        { 

            public class OverworldUI : MonoBehaviour
            {
                [Header("Player Stats")]
                public Slider healthBar;
                public Slider staminaBar;
                public Slider expBar;

                [Header("Text")]
                public TMP_Text levelText;
                public TMP_Text goldText;
                public TMP_Text questText;

                [Header("Buttons")]
                public GameObject inventoryPanel;
                public GameObject pausePanel;

                private int gold;
                private int level = 1;

                private void Start()
                {
                    UpdateHealth(100, 100);
                    UpdateStamina(100, 100);
                    UpdateExp(0, 100);

                    levelText.text = $"Lv. {level}";
                    goldText.text = $"Gold: {gold}";
                }

                public void UpdateHealth(float current, float max)
                {
                    healthBar.maxValue = max;
                    healthBar.value = current;
                }

                public void UpdateStamina(float current, float max)
                {
                    staminaBar.maxValue = max;
                    staminaBar.value = current;
                }

                public void UpdateExp(float current, float required)
                {
                    expBar.maxValue = required;
                    expBar.value = current;
                }

                public void SetLevel(int newLevel)
                {
                    level = newLevel;
                    levelText.text = $"Lv. {level}";
                }

                public void AddGold(int amount)
                {
                    gold += amount;
                    goldText.text = $"Gold: {gold}";
                }

                public void SetQuest(string questDescription)
                {
                    questText.text = questDescription;
                }

                public void ToggleInventory()
                {
                    inventoryPanel.SetActive(!inventoryPanel.activeSelf);
                }

                public void TogglePause()
                {
                    bool paused = !pausePanel.activeSelf;

                    pausePanel.SetActive(paused);
                    Time.timeScale = paused ? 0f : 1f;
                }
            }
    }
}