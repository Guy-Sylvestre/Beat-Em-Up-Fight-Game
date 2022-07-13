using Microsoft.Win32;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackUniversal : MonoBehaviour
{
    //Declaration de variable interface
    public LayerMask collisionLayer;
    public GameObject hit_FX_Prefabs;


    //Declaration de variable public
    public float radius = 1f;
    public float damage = 2f;

    //Declaration de variable public de type Boolean
    public bool is_Player, is_Enemy;
    

    void Update()
    {
        DetectCollision();
    }

    void DetectCollision()
    {
        Collider[] hit = Physics.OverlapSphere(transform.position, radius, collisionLayer);

        if (hit.Length > 0)
        {
            
            if (is_Player)
            {
                Vector3 hitFX_Pos = hit[0].transform.position;
                hitFX_Pos.y += 1.3f;

                if (hit[0].transform.forward.x > 0)
                {
                    hitFX_Pos.x += 0.3f;
                }
                else  if (hit[0].transform.forward.x < 0)
                {
                    hitFX_Pos.x -= 0.3f;
                }

                Instantiate(hit_FX_Prefabs, hitFX_Pos, Quaternion.identity);
            } // if is player

            gameObject.SetActive(false);
        } // if have a hit
    }
} // class
