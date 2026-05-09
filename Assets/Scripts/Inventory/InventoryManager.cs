using System.Collections.Generic;
using UnityEngine;
using SpaceSurvival.Core;

namespace SpaceSurvival.Inventory
{
    public class InventoryManager : Singleton<InventoryManager>
    {
        public int maxSlots = 20;
        public List<InventorySlot> items = new List<InventorySlot>();

        public bool AddItem(ItemData item, int amount = 1)
        {
            // Check for existing stack
            foreach (var slot in items)
            {
                if (slot.item == item && slot.amount < item.maxStack)
                {
                    slot.amount += amount;
                    EventManager.Trigger(GameEvents.ON_INVENTORY_CHANGED);
                    return true;
                }
            }

            // Add to new slot
            if (items.Count < maxSlots)
            {
                items.Add(new InventorySlot(item, amount));
                EventManager.Trigger(GameEvents.ON_INVENTORY_CHANGED);
                return true;
            }

            Debug.Log("Inventory Full!");
            return false;
        }

        public void RemoveItem(ItemData item, int amount = 1)
        {
            for (int i = items.Count - 1; i >= 0; i--)
            {
                if (items[i].item == item)
                {
                    items[i].amount -= amount;
                    if (items[i].amount <= 0) items.RemoveAt(i);
                    EventManager.Trigger(GameEvents.ON_INVENTORY_CHANGED);
                    break;
                }
            }
        }
    }

    [System.Serializable]
    public class InventorySlot
    {
        public ItemData item;
        public int amount;

        public InventorySlot(ItemData item, int amount)
        {
            this.item = item;
            this.amount = amount;
        }
    }
}
