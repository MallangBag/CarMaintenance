using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RatchetManager : MonoBehaviour
{
    [SerializeField]
    private GameObject Sockets;     //���ϵ�

    //���� ��ư ������, Socket ���������� �� - ���������� ���� 
    public void RatchetOnClick()
    {
        if (Sockets.activeSelf == false)
        {
            Sockets.SetActive(true);
            StartCoroutine(SocketGetOff());
        }
        else
        {
            Sockets.SetActive(false);
        }
    }

    //����List ������ �Ҷ�� ��������
    IEnumerator SocketGetOff()
    {
        GameObject[] SocketArr = new GameObject[Sockets.transform.childCount];

        //���̶�Ű ���� ����
        for (int i = 0; i < Sockets.transform.childCount; i++)
        {
            SocketArr[i] = Sockets.transform.GetChild(Sockets.transform.childCount - (i+1)).gameObject;
        }

        //10mm ���� ��ġ�� �� �ű�
        for (int i = 0; i < SocketArr.Length; i++)
        {
            SocketArr[i].transform.localPosition = SocketArr[0].transform.localPosition;       
        }

        
        Vector3 nextPosition = SocketArr[0].transform.localPosition;
        nextPosition.y -= 85f; 
        Vector3 currentPosition = SocketArr[0].transform.localPosition;

        float speed = 42.5f;

        int indexNum = 1;
        while (indexNum < SocketArr.Length)
        {
            currentPosition.y -= speed;
            for (int i = indexNum; i < SocketArr.Length; i++)
            {
                SocketArr[i].transform.localPosition = currentPosition;
            }
            if(currentPosition == nextPosition)
            {
                nextPosition.y -= 85;
                indexNum++;
            }
            yield return null;
        }
    }




}
