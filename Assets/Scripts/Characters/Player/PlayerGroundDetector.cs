using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGroundDetector : MonoBehaviour
{
    [SerializeField] float detectionRadius = 0.1f;//检测器半径
    [SerializeField] LayerMask groundLayer;//地面层
    Collider[] colliders = new Collider[1];//碰撞体数组
    public bool IsGrounded => Physics.OverlapSphereNonAlloc(transform.position, detectionRadius, colliders, groundLayer) != 0;
    //画线函数，画出检测器的范围
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;

        Gizmos.DrawWireSphere(transform.position, detectionRadius);
    }
}
