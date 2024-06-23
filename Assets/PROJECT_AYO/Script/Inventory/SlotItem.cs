using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace AYO
{
    public class SlotItem : MonoBehaviour
    {
        //Image Component�� ���� ��
        [SerializeField] Image image;

        private Item _item;
        public Item item
        {
            //������ item ������ �Ѱ��� �� ���
            get { return _item; }
            set
            {
                //item�� ������ ������ ���� _item�� ����
                _item = value;
                //Inventory ��ũ��Ʈ�� List<Item> items�� ��ϵ� �������� �ִٸ�
                if (_item != null)
                {
                    //itemImage�� image�� ���� �׸��� Image�� ���� ���� 1�� �Ͽ� �̹����� ǥ��
                    image.sprite = item.itemImage;
                    image.color = new Color(1, 1, 1, 1);
                }
                //item�� null �̸�(�󽽷� �̸�) Image�� ���� �� 0�� �־� ȭ�鿡 ǥ��X
                else
                {
                    image.color = new Color(1, 1, 1, 0);
                }
            }
        }
    }
}
