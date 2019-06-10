using UnityEditor;
using UnityEngine;
public class Tools
{
    [MenuItem("Tools/test/test1")]//在菜单栏Tools 的test点击使用方法
    static void Test()//要用静态才能被调用到
    {
        Debug.Log("Test1");
    }

    [MenuItem("Tools/test/test2")]
    static void Test2()
    {
        Debug.Log("Test2");
    }
    //每一个类都有横线分割 默认是第四类 如果在第一类就也可以在Hierarchy右键出来
    //每一个菜单栏的priority优先级默认为1000 小于10按大小排序 大于10是分到另外一组
    [MenuItem("GameObject/my tool",false,10)]
    static void Test3()
    {
        Debug.Log("Test3");
    }

    [MenuItem("Assets/assetbtn")]
    static void Test4()
    {
        Debug.Log("Test4");
    }
    [MenuItem("Tools/Show Info",false,1)]
    static void Test5()
    {
        //显示 选择的第一个东西的名字
        //Debug.Log(Selection.activeGameObject.name);
        //选中多个的个数
       // Debug.Log(Selection.objects.Length);
        //选中sence视图的gameobject
       // Debug.Log(Selection.gameObjects.Length);
    }

    //除了bool都一样
    [MenuItem("GameObject/my delete", true, 11)]
    static bool MyDeleteValidate()
    {
        if (Selection.objects.Length>0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    //第二个参数 是验证方法是否可用
    [MenuItem("GameObject/my delete", false,11)]
    static void Test6()
    {
        foreach (var item in Selection.objects)
        {
            //编辑器模式下的删除 Ctrl Z无法恢复
            //GameObject.DestroyImmediate(item);

            //需要把删除的操作注册到操作记录里 这个可以撤销的
            Undo.DestroyObjectImmediate(item);
        }
    }

    //要有空格 然后加_
    [MenuItem("Tools/test3 _t")]
    static void Test7()
    {
        Debug.Log("Test3");
    }

    //%=ctrl #=shift &=alt 
    [MenuItem("Tools/test4 %q")]
    static void Test8()
    {
        Debug.Log("Test3");
    }

}
