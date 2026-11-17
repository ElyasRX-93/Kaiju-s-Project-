using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace ProjectKaiju
{
    public class HeroStats : MonoBehaviour
    {
        [Header("Primary Stats")]
        public string heroName = "Hero";
        public int level = 1;
        public int experience = 0;
        public int experienceToNextLevel = 100;

        [Header("Resources")]
        public int maxHealth = 100;
        public int maxMana = 50;
        public int maxStamina = 100;

        [SerializeField] private int currentHealth;
        [SerializeField] private int currentMana;
        [SerializeField] private int currentStamina;

        [Header("Combat Stats")]
        public int strength = 10;
        public int defense = 5;
        public int speed = 5;

        [Header("Currency")]
        public int gold = 0;

        private void Start()
        {
            currentHealth = maxHealth;
            currentMana = maxMana;
            currentStamina = maxStamina;
        }

        #region Health

        public void TakeDamage(int amount)
        {
            int damageTaken = Mathf.Max(amount - defense, 1);

            currentHealth -= damageTaken;
            currentHealth = Mathf.Max(currentHealth, 0);

            Debug.Log($"{heroName} took {damageTaken} damage!");

            if (currentHealth <= 0)
            {
                Die();
            }
        }

        public void Heal(int amount)
        {
            currentHealth += amount;
            currentHealth = Mathf.Min(currentHealth, maxHealth);
        }

        #endregion

        #region Mana

        public bool UseMana(int amount)
        {
            if (currentMana < amount)
                return false;

            currentMana -= amount;
            return true;
        }

        public void RestoreMana(int amount)
        {
            currentMana += amount;
            currentMana = Mathf.Min(currentMana, maxMana);
        }

        #endregion

        #region Stamina

        public bool UseStamina(int amount)
        {
            if (currentStamina < amount)
                return false;

            currentStamina -= amount;
            return true;
        }

        public void RestoreStamina(int amount)
        {
            currentStamina += amount;
            currentStamina = Mathf.Min(currentStamina, maxStamina);
        }

        #endregion

        #region Experience

        public void GainExperience(int amount)
        {
            experience += amount;

            while (experience >= experienceToNextLevel)
            {
                LevelUp();
            }
        }

        private void LevelUp()
        {
            experience -= experienceToNextLevel;

            level++;

            experienceToNextLevel = Mathf.RoundToInt(experienceToNextLevel * 1.25f);

            maxHealth += 20;
            maxMana += 10;
            maxStamina += 10;

            strength += 2;
            defense += 1;
            speed += 1;

            currentHealth = maxHealth;
            currentMana = maxMana;
            currentStamina = maxStamina;

            Debug.Log($"LEVEL UP! You are now level {level}");
        }

        #endregion

        #region Gold

        public void AddGold(int amount)
        {
            gold += amount;
        }

        public bool SpendGold(int amount)
        {
            if (gold < amount)
                return false;

            gold -= amount;
            return true;
        }

        #endregion

        private void Die()
        {
            Debug.Log($"{heroName} has fallen!");

            // Respawn logic here
            // Scene reload
            // Game Over screen
        }

        #region Getters

        public int CurrentHealth => currentHealth;
        public int CurrentMana => currentMana;
        public int CurrentStamina => currentStamina;

        #endregion
    }

}
