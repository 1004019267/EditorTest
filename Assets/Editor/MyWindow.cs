using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
//继承这个类
public class MyWindow : EditorWindow
{
    [MenuItem("Window/Show My Window")]
    static void ShowMyWindow()
    {
        EditorWindow.GetWindow<MyWindow>().Show();
    }

    string name1="";
    //绘制 循环调用的
    private void OnGUI()
    {
        //Text
        GUILayout.Label("这是我的窗口");
        //输入框
        name1 = GUILayout.TextField(name1);

        if (GUILayout.Button("创建"))
        {
            GameObject go = new GameObject(name1);
            //登记撤销记录
            Undo.RegisterCreatedObjectUndo(go,"Create obj");
        }       
    }
}
