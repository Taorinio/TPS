using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProxyAttackEvent : MonoBehaviour
{
    public EnemyAI eai;
    public void AttackEvent() {
        eai.AttackEv();
    }
}
