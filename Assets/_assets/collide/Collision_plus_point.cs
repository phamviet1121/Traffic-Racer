using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class Collision_plus_point : MonoBehaviour
{
    //public GameObject point_txt;
    // public int plus_point;
    //int point = 0;
    public UnityEvent<Vector3,GameObject> Event_plus_point;
    //public void Collision_player_plus_point(Vector3 hitPosition, GameObject player)
    //{
    //    TextMeshPro tmp = point_txt.GetComponent<TextMeshPro>();

    //    Debug.Log($"cos congjo dieemrd ko{hitPosition}");
    //    point += plus_point;
    //    tmp.text = "+ " + point.ToString();
    //    Vector3 position_point_txt=new Vector3( player.transform.position.x, 30f, player.transform.position.z);
    //    if (hitPosition.x<= player.transform.position.x)
    //    {
    //        position_point_txt.x= player.transform.position.x-5f;
    //    }
    //    else
    //    {
    //        position_point_txt.x = player.transform.position.x +5f;
    //    }

    //    GameObject point_gameobject = Instantiate(point_txt, position_point_txt, Quaternion.identity);
    //    point_gameobject.transform.SetParent(player.transform);
    //}
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {


            Vector3 hitPosition = other.ClosestPoint(transform.position);
            GameObject player = other.gameObject;


           // Debug.Log($"player {player}");
            Vector3 car = transform.position;
            //Debug.Log($"car {car}");
            Event_plus_point.Invoke(hitPosition, player);
            //  Collision_player_plus_point(hitPosition, player);

        }
    }
}
