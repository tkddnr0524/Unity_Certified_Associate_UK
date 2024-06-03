using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animal
{
    //Monobehavior 없에줌(해당 클래스는 유니티 컴포넌트와 관련이 없기 때문에 상속에서 제외)
    public string name;
    public string sound;
    
    public void PlaySound()
    {
        Debug.Log(name + " : " + sound);
    }
}
