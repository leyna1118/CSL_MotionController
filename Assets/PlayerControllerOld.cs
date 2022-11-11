// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class PlayerController : MonoBehaviour
// {
//     public SimpleShoot gun;
//     public float shootCoolDownTime = 1f;
//     private float shootCoolDownTimer;

//     // Start is called before the first frame update
//     void Start()
//     {

//     }

//     // Update is called once per frame
//     void Update()
//     {
//         if (Input.GetKeyDown(KeyCode.LeftArrow)) {
//             this.transform.eulerAngles = new Vector3(0f, -30f, 0f);
//         } else if (Input.GetKeyDown(KeyCode.UpArrow)) {
//             this.transform.eulerAngles = new Vector3(0f, 0f, 0f);
//         } else if (Input.GetKeyDown(KeyCode.RightArrow)) {
//             this.transform.eulerAngles = new Vector3(0f, 30f, 0f);
//         }
//         if (shootCoolDownTimer <= 0f && Input.GetKeyDown(KeyCode.Space)) {
//             shootCoolDownTimer = shootCoolDownTime;
//             gun.GetComponent<Animator>().SetTrigger("Fire");
//         } else {
//             shootCoolDownTimer -= Time.deltaTime;
//         }
//     }
// }
