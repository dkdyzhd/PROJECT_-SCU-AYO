using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AYO
{
    public class InteractionFood : MonoBehaviour, IInteractable
    {
        //�̸��� �ƿ� �����ϴ� �ͺ��� �������� ����� �����Ϳ��� itemData�� �����ͼ� �װ��� �̸����� ����
        //�ڵ� ���̱� & ������ �� ��ũ��Ʈ�� �ļ� �Ӽ��� �ο��ϴ� �ͺ��� ����
        public string Key => itemData.itemName + gameObject.GetHashCode();
        public string Message => "Pick Up";

        //Item ��ũ��Ʈ�� Ȱ���Ͽ� itemData ����
        public Item itemData;

        public void Interact()
        {
            InteractionUI.Instance.RemoveInteractionData(this);

            // To do : Add Inventory
            InventoryUI.Instance.AddItem(itemData.itemName);
            // �ı��� ���� ����
            Destroy(gameObject);
        }

    }
}
