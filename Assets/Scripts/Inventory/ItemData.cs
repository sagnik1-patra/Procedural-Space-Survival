using UnityEngine;

namespace SpaceSurvival.Inventory
{
    public enum ItemType { Resource, Tool, Consumable, Component }

    [CreateAssetMenu(fileName = "New Item", menuName = "SpaceSurvival/Item")]
    public class ItemData : ScriptableObject
    {
        public string itemName;
        public string description;
        public ItemType type;
        public Sprite icon;
        public int maxStack = 99;
        public float weight = 0.1f;
        
        [Header("Consumable Stats")]
        public float healthRestore;
        public float oxygenRestore;
        public float energyRestore;
    }
}
