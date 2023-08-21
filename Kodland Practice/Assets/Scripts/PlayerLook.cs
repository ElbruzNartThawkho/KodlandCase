using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    [SerializeField] private float mouseSense; // Fare hassasiyeti
    [SerializeField] private Transform player; // Oyuncu dönüş noktası
    [SerializeField] private Transform playerArms; // Oyuncunun kollarının dönüş noktası

    private float xAxisClamp = 0; // X eksen sınırlayıcı

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; // Fare imlecini sabitleme
    }

    private void Update()
    {
        RotateCamera(); // Kamerayı döndürme metodu
    }

    private void RotateCamera()
    {
        float rotateX = Input.GetAxis("Mouse X") * mouseSense; // X ekseninde fare dönüşü
        float rotateY = Input.GetAxis("Mouse Y") * mouseSense; // Y ekseninde fare dönüşü

        xAxisClamp -= rotateY;
        Vector3 rotPlayerArms = playerArms.rotation.eulerAngles;
        Vector3 rotPlayer = player.rotation.eulerAngles;

        // Kolların dönüşünü ayarlama
        rotPlayerArms.x -= rotateY;
        rotPlayerArms.z = 0;

        // Oyuncunun dönüşünü ayarlama
        rotPlayer.y += rotateX;

        // Dikey dönüşü sınırlama
        if (xAxisClamp > 90)
        {
            xAxisClamp = 90;
            rotPlayerArms.x = 90;
        }
        else if (xAxisClamp < -90)
        {
            xAxisClamp = -90;
            rotPlayerArms.x = 270;
        }

        playerArms.rotation = Quaternion.Euler(rotPlayerArms);
        player.rotation = Quaternion.Euler(rotPlayer);
    }
}
