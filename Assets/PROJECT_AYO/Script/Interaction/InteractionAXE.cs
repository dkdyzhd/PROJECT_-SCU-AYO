using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AYO
{
    public class InteractionAXE : MonoBehaviour, IInteractable
    {
        public string Key => itemData.itemName + gameObject.GetHashCode();

        public string Message => "Pick Up";

        //Item ��ũ��Ʈ�� Ȱ���Ͽ� itemData ����
        public Item itemData;

        public void Interact()
        {
            throw new System.NotImplementedException();
        }
    }
}
