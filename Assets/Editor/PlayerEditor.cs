using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
public class PlayerEditor
{
    //CONTEXT 组件名 PlayerHealth脚本名 第三个组件btn名
    [MenuItem("CONTEXT/PlayerHealth/InitHealthAndSpeed")]
    static void InitHealthAndSpeed(MenuCommand cmd)//是当前正在操作的组件对象 系统调用不用传
    {
        //输出挂载物体的名字
        Debug.Log(cmd.context.name);
        //()转不行就报错 as 不管是不是空是不是能转类型都不会报错
        CompleteProject.PlayerHealth health = (CompleteProject.PlayerHealth)cmd.context;
        health.startingHealth = 200;
        health.flashSpeed = 10;
    }
    [MenuItem("CONTEXT/Rigidbody/Clear")]
    static void ClearMassAndGravity(MenuCommand cmd)
    {
        Rigidbody rgd = cmd.context as Rigidbody;
        rgd.mass = 0;
        rgd.useGravity = false;
    }


}
