using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeadScript : MonoBehaviour
{
    public void DeleteDeadAnimation ()
    {
        Destroy(gameObject);
    }
}
