using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class InteractivePlatformController : MonoBehaviour
{
    [SerializeField] private Transform startingPosition;
    [SerializeField] private float speed;

    public void RestartPlatform()
    {
        transform.position = startingPosition.position;
    }

    private void Update()
    {
        transform.position += Vector3.right * Time.deltaTime * speed;
    }

    public void Turn(Vector3 move)
    {
        transform.position += move;
    }
}
