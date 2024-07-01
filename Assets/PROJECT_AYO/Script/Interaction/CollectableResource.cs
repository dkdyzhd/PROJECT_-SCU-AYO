using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AYO
{
    public enum CollectResourceType //���������� �ڿ� ����
    {
        None = 0,
        Tree = 1,
        Stone = 2,
    }

    public class CollectableResource : MonoBehaviour
    {
        public static CollectableResource Instance { get; private set; } = null;

        public CollectResourceType ResourceType => resourceType;    //�Ŀ� �ν����� â�� ���̵���

        [SerializeField] private CollectResourceType resourceType;  //�ܺο��� ���� ���ϵ��� private

        public float resourceHp = 100.0f;

        private void Awake()
        {
            Instance = this;
        }
        

        public void OnDestroy()
        {
            if(resourceHp <= 0)
            {
                Instance = null;
                Destroy(gameObject);
            }
        }


    }
}
