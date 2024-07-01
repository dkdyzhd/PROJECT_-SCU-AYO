using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AYO
{
    public enum CollectResourceType //수집가능한 자원 종류
    {
        None = 0,
        Tree = 1,
        Stone = 2,
    }

    public class CollectableResource : MonoBehaviour
    {
        public static CollectableResource Instance { get; private set; } = null;

        public CollectResourceType ResourceType => resourceType;    //후에 인스펙터 창에 보이도록

        [SerializeField] private CollectResourceType resourceType;  //외부에서 수정 못하도록 private

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
