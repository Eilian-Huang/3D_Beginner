using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackRange : MonoBehaviour
{
    /// <summary>
    /// Circular attack
    /// </summary>
    /// <param name="attacker">GameObject that is a attacker</param>
    /// <param name="target">GameObject being attacked</param>
    /// <param name="attackRadius">Attack Radius</param>
    bool RoundAttackLogic(Transform attacker, Transform target, float attackRadius)
    {
        float circleDistance = Vector3.Distance(target.position, attacker.position);
        if (tmpDis > attackRadius)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    /// <summary>
    /// Sector attack
    /// </summary>
    /// <param name="attacker">GameObject that is a attacker</param>
    /// <param name="target">GameObject being attacked</param>
    /// <param name="attackAngle">Attack angle</param>
    /// <param name="attackRadius">Attack Radius</param>
    void SectorAttack(Transform attacker, Transform target,float attackRadius)
    {
        Vector3 tmpVec = hero.position - transform.position;
        float cosValue = Vector3.Dot(tmpVec.normalized, transform.forward);
        float realAngle = Mathf.Acos(cosValue) * Mathf.Rad2Deg;
        if (realAngle <= attackAngle / 2 && tmpVec.magnitude <= attackRadius)
        {
            //攻击
        }
    }

    /// <summary>
    /// 矩形攻击判定
    /// </summary>
    /// <param name="hero">英雄</param>
    /// <param name="forwardAttack">前方防御范围</param>
    /// <param name="sizeAttack">左右防御范围</param>
    void RectAttack(Transform hero, float forwardAttack, float sizeAttack)
    {
        Vector3 delteA = hero.position - transform.position;
        float forwardDis = Vector3.Dot(delteA, transform.forward);
        if (forwardDis <= forwardAttack && forwardDis > 0)
        {
            float bothSize = Mathf.Abs(Vector3.Dot(delteA, transform.right));//能进到这里说明前方满足条件，而左右两边正负都行，所以只判断距离
            if (bothSize < sizeAttack)
            {
                //攻击
            }
        }
    }
}
