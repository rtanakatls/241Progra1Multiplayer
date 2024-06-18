using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviourPun
{
    private static GameObject localInstance;

    [SerializeField] private float speed;
    private Rigidbody rb;

    public static GameObject LocalInstance
    {
        get
        {
            return localInstance;
        }
    }

    private void Awake()
    {
        if(photonView.IsMine)
        {
            localInstance = gameObject;
        }

        DontDestroyOnLoad(gameObject);
        rb=GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (!photonView.IsMine || !PhotonNetwork.IsConnected)
        {
            return;
        }
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        rb.velocity = new Vector3(horizontal * speed, rb.velocity.y, vertical * speed);
    }
}
