using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarGem : MonoBehaviour
{
    [SerializeField] AudioClip pickUpSFX;
    [SerializeField] ParticleSystem pickUpVFX;

    [SerializeField] float resetTime = 3.0f;
    WaitForSeconds waitResetTime;
    new Collider collider;
    MeshRenderer meshRenderer;
    private void Awake()
    {
        collider = GetComponent<Collider>();
        meshRenderer = GetComponentInChildren<MeshRenderer>();
        waitResetTime = new WaitForSeconds(resetTime);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<PlayerController>(out PlayerController player))
        {
            player.CanAirjump = true;
            collider.enabled = false;//关闭碰撞体
            meshRenderer.enabled = false;//关闭渲染器

            SoundEffectsPlayer.AudioSource.PlayOneShot(pickUpSFX);//播放音效
            Instantiate(pickUpVFX, transform.position, Quaternion.identity);//播放粒子特效

            //Invoke函数 短时间调用一次可以用，短时间大量调用应该用协程
            //Invoke(nameof(Reset), resetTime);//延时 resetTime 秒后调用重置函数
            StartCoroutine(nameof(ResetCoroutine));
        }
    }

    private void Reset()
    {
        collider.enabled = true;//开启碰撞体
        meshRenderer.enabled = true;//开启渲染器
    }
    IEnumerator ResetCoroutine()
    {
        yield return waitResetTime;
        Reset();
    }
}
