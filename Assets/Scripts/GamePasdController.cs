using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePasdController : Singleton<GamePasdController>
{
    public bool isOnMobile;
    
    bool m_CanMoveLeft;
    bool m_CanMoveRight;


    public bool CanMoveLeft { get => m_CanMoveLeft; set => m_CanMoveLeft = value; }

    public bool CanMoveRight { get => m_CanMoveRight; set => m_CanMoveRight = value; }

    private void Update()
    {
        if (!isOnMobile)
        {
            PcHandle();
        }
    }
    void PcHandle()
    {
        m_CanMoveLeft = Input.GetAxisRaw("Horizontal") < 0;

        m_CanMoveRight = Input.GetAxisRaw("Horizontal") > 0;

    }
   
}
