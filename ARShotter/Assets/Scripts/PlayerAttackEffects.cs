using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackEffects : MonoBehaviour
{

    public GameObject groundImpact_Spawn, kickFX_Spawn;
    public GameObject groundImpact_Prefab, kickFX_Prefab, thunderFX_Prefab;
    
    void GroundImpact()
    {
        Instantiate(groundImpact_Prefab, groundImpact_Spawn.transform.position, UnityEngine.Quaternion.identity);
    }

    void Kick()
    {
        Instantiate(kickFX_Prefab, kickFX_Spawn.transform.position, UnityEngine.Quaternion.identity);
    }
  
    void ThunderAttack()
    {
        for (int i = 0; i < 5; i++)
        {
            UnityEngine.Vector3 position = UnityEngine.Vector3.zero;

            if (i == 0)
            {
                position = new UnityEngine.Vector3(transform.position.x - 0.2f, transform.position.y + 0.1f, transform.position.z);
            }
            else if (i == 1)
            {
                position = new UnityEngine.Vector3(transform.position.x + 0.2f, transform.position.y + 0.1f, transform.position.z);
            }
            else if (i == 2)
            {
                position = new UnityEngine.Vector3(transform.position.x, transform.position.y + 0.1f, transform.position.z - 0.2f);
            }
            else if (i == 3)
            {
                position = new UnityEngine.Vector3(transform.position.x, transform.position.y + 0.1f, transform.position.z + 0.2f);
            }
            else if (i == 4)
            {
                position = new UnityEngine.Vector3(transform.position.x + 0.025f, transform.position.y + 0.1f, transform.position.z + 0.025f);
            }
           





            Instantiate(thunderFX_Prefab, position, UnityEngine.Quaternion.identity);
        }
    }

}
