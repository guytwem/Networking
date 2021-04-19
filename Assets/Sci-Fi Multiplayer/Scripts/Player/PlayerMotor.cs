using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Battlecars.Player
{

    public class PlayerMotor : MonoBehaviour
    {
        private bool isSetup = false;

        [SerializeField] private float speed = 3;


        public void SetUp()
        {
            isSetup = true;
        }

        // Update is called once per frame
        void Update()
        {
            if (!isSetup)
                return;
            transform.position += transform.forward * Input.GetAxis("Vertical") * speed * Time.deltaTime;
            transform.position += transform.right * Input.GetAxis("Horizontal") * speed * Time.deltaTime;


            
        }
    }
}
