using System;
using Unity.Mathematics;
using UnityEngine;

public class GoldCube : MonoBehaviour
{
    private float speed = 3f;
    private float amplitude = 0.1f;
    [SerializeField] private AudioClip coinSound;
    private Vector3 basePosition;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        basePosition = transform.localPosition;
    }

    void Update()
    {
        transform.eulerAngles+=new Vector3(0,1,0);
        float y = Mathf.Cos(Time.time * speed) * amplitude;
        transform.position = basePosition + new Vector3(0, y, 0);
    }
    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        AudioManager.instance.PlaySFX(coinSound);
    }
}
