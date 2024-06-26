using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Progress;

namespace AYO
{
    public class InventoryUI : UIBase
    {
        public static InventoryUI Instance { get; private set; } = null;

        public Image Slot1 => inventorySlots[0];
        public Image Slot2 => inventorySlots[1];
        public Image Slot3 => inventorySlots[2];
        public Image Slot4 => inventorySlots[3];
        public Image Slot5 => inventorySlots[4];
        public Image Slot6 => inventorySlots[5];


        public List<Image> inventorySlots = new List<Image>();

        public int pickupCount = 0;
      
        private void Awake()
        {
            Instance = this;
        }

        private void OnDestroy()
        {
            Instance = null;
        }

        public void CheckItem() // Update �� �������� üũ�ϴ� ���̱� ������ AddItem �Լ� �������� ȣ��
        {
            for (int i = 0; i < inventorySlots.Count; i++)
            {
                if (inventorySlots[i].sprite != null )
                {
                    inventorySlots[i].color = new Color(1, 1, 1, 1);
                }
                else
                {
                    inventorySlots[i].color = new Color(1, 1, 1, 0);
                }
            }
        }
       
        public void AddItem(string itemName)
        {
            //var targetItemData = GameDataManager.Instance.ItemDataList.Find(x => x.itemName.Equals(itemName));
            //Slot1.sprite = targetItemData.itemImage;

            //if (itemName.Equals("Fish"))
            //{
            //    var targetSprite = Resources.Load<Sprite>("UI/Sprite/Fish");
            //}

            //To do : for���� �̿��Ͽ� �������� ���ڸ��� ������ ������� ��⵵��
            var targetItemData = GameDataManager.Instance.ItemDataList.Find(x => x.itemName.Equals(itemName));
            Debug.Log("ItemDataList���� ã��");

            pickupCount++;

            for (int i = 0; i < inventorySlots.Count; i++)
            {
                if (inventorySlots[i].sprite == null && i < pickupCount )
                { 
                    inventorySlots[i].sprite = targetItemData.itemImage;
                    Debug.Log("�κ��丮�� ���");
                }
            }
            
            CheckItem();
        }
    }
}
