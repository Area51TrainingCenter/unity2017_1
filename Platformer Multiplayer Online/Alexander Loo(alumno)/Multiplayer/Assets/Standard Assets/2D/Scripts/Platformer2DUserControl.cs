using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
//Importamos librería de networking
using UnityEngine.Networking;

namespace UnityStandardAssets._2D
{
    [RequireComponent(typeof (PlatformerCharacter2D))]
	//Usamos NetworkBehaviour en vez de MonoBehaviour que tiene métodos extras para multiplayer
    public class Platformer2DUserControl : NetworkBehaviour
    {
        private PlatformerCharacter2D m_Character;
        private bool m_Jump;


        private void Awake()
        {
            m_Character = GetComponent<PlatformerCharacter2D>();
        }


        private void Update()
        {
            if (!m_Jump)
            {
                // Read the jump input in Update so button presses aren't missed.
                m_Jump = CrossPlatformInputManager.GetButtonDown("Jump");
            }
        }


        private void FixedUpdate()
        {
            // Read the inputs.
            bool crouch = Input.GetKey(KeyCode.LeftControl);
            float h = CrossPlatformInputManager.GetAxis("Horizontal");
			//Si el objeto pertenece al cliente, isLocalPlayer es true
			//si isLocalPlayer es true, podemos mover al personaje
			if (isLocalPlayer) {
				// Pass all parameters to the character control script.
				m_Character.Move(h, crouch, m_Jump);
			}
            m_Jump = false;
        }
    }
}
