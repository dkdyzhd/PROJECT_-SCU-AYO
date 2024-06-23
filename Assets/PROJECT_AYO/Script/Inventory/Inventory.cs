using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;

namespace AYO
{
    public class Inventory : MonoBehaviour
    {
        public List<Item> items;

        [SerializeField]
        private Transform slotParent;
        [SerializeField]
        private SlotItem[] slotItems;

#if UNITY_EDITOR
        private void OnValidate()
        {
            slotItems = slotParent.GetComponentsInChildren<SlotItem>();
        
        }
#endif
        void Awake()
        {
            FreshSlot();
        }

        private void FreshSlot()
        {
            int i = 0;
            for (; i < items.Count && i < slotItems.Length; i++)
            {
                slotItems[i].item = items[i];
            }
            for (; i < slotItems.Length; i++)
            {
                slotItems[i].item = null;
            }
        
        }

        public void AddItem(Item _item)
        {
            if (items.Count < slotItems.Length)
            {
                items.Add(_item);
                FreshSlot();
            }
            else
            {
                print("������ ���� �� �ֽ��ϴ�.");
                //to do : ������ drop���� ��ü
            }
        }
    }
}
