using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Valve.VR.InteractionSystem
{
    namespace UnityEngine.UI{
        public class scroll_content : MonoBehaviour
        {
            public SteamVR_Action_Vector2 touchpadwalkingAction = SteamVR_Input.GetVector2Action("touchpadwalking");
            public RectTransform m_Content;
            public RectTransform content { get { return m_Content; } set { m_Content = value; } }
            protected Vector2 m_ContentStartPosition = Vector2.zero;
            private Vector2 currentposition;
            private Vector2 touchpadaxis;
            public float offset = 0.1f;
            void Start()
            {
                currentposition.y  = touchpadwalkingAction.GetAxis(SteamVR_Input_Sources.RightHand).y;
            }
            void FixedUpdate()
            {
                Player player  = Player.instance;
                touchpadaxis.y = touchpadwalkingAction.GetAxis(SteamVR_Input_Sources.RightHand).y ; 
                if (touchpadaxis.y > currentposition.y)
                {   
                    Debug.Log("手在上半部");
                    Vector2 position = m_Content.anchoredPosition;
                    position.y += offset;
                    m_Content.anchoredPosition = position;
                }
                else if (touchpadaxis.y <  currentposition.y)
                { 
                    // Debug.Log("手在下半部");
                    Vector2 position = m_Content.anchoredPosition;
                    position.y -= offset;
                    m_Content.anchoredPosition = position; 
                }    
                currentposition.y = touchpadaxis.y;   
            }
        }    
    }
}
