using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AYO
{
    public class TreeSensor : MonoBehaviour
    {
        //Ž���ȳ����� ������ ����Ʈ ����
        public List<CollectableResource> detectedTree = new List<CollectableResource>();

        public CollectableResource GetClosedTree()  //�������� ã�� �Լ�
        {
            CollectableResource result = null;  //Ž���Ȱ��� ������ null
            if (detectedTree.Count > 0) // Ž���ȳ����� �ִٸ�
            {
                float beforeDistance = float.MaxValue;  // �⺻�Ÿ� 9999..�� ����
                for (int i = 0; i < detectedTree.Count; i++)    // Ž���ȳ��� ����ŭ for�� ����
                {
                    // �÷��̾�� ���� ������ �Ÿ� ���ϱ�
                    float distance = Vector3.Distance(transform.position, detectedTree[i].transform.position);
                    if (distance < beforeDistance)  //�Ÿ��� �� �۴ٸ�(���� ���Ŀ��� Ž���Ǿ��� ������ �Ÿ��� ��)
                    {
                        result = detectedTree[i];   //Ž���ȳ����� ����� ����
                        beforeDistance = distance;  //before �Ÿ��� �Ÿ����� �����ϰ� ����
                    }

                    if(CollectableResource.Instance == null)
                    {
                        detectedTree.RemoveAt(i);   //������->
                    }
                }
            }
            // Ž���� ������ ���� �������� return
            return result;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.transform.root.TryGetComponent(out CollectableResource collectableResource))
            {
                if (collectableResource.ResourceType == CollectResourceType.Tree)   // Tree�� trigger�� ���Դٸ�
                {
                    detectedTree.Add(collectableResource);  //Ž���ȳ����� �߰�
                }
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.transform.root.TryGetComponent(out CollectableResource collectableResource))
            {
                if (collectableResource.ResourceType == CollectResourceType.Tree)   // trigger���� ������ 
                {
                    detectedTree.Remove(collectableResource);   // ����
                }
            }
        }
    }
}
