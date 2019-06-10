using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
//可编程的对话框
public class EnemyChange : ScriptableWizard
{
    [MenuItem("Tools/CreateWizard")]
    static void CreateWizard()
    {
        //泛型是做对话框的类 第一个参数是对话框名字 第二个是改变的btn名字
        ScriptableWizard.DisplayWizard<EnemyChange>("统一修改敌人", "Change And Close", "Change");
    }

    public int changeHealthValue = 10;
    public int changeSinkSpeedValue = 1;

    const string changeHealthValueKey= "EnemyChange.changeHealthValue";
    const string changeSinkSpeedValueKey = "EnemyChange.changeSinkSpeedValue";
    //被创建出来调用
    private void OnEnable()
    {
        //一开始调用参数
        changeHealthValue= EditorPrefs.GetInt(changeHealthValueKey, changeHealthValue);
        changeSinkSpeedValue = EditorPrefs.GetInt(changeSinkSpeedValueKey, changeSinkSpeedValue);
    }
    //按钮点击 之后触发的事件
    private void OnWizardCreate()
    {
        //objects 是场景中 这个包含预制体
        GameObject[] enemyP = Selection.gameObjects;
        //进度条
        EditorUtility.DisplayProgressBar("进度", "0/" + enemyP.Length + "完成修改值", 0);
        int count = 0;
        for (int i = 0; i < enemyP.Length; i++)
        {
            CompleteProject.EnemyHealth e = enemyP[i].GetComponent<CompleteProject.EnemyHealth>();
            //编辑器记录下可以撤回 放在改变之前
            Undo.RecordObject(e, "change health and speed");
            e.startingHealth += 10;
            e.sinkSpeed += 1;
            count++;
            EditorUtility.DisplayProgressBar("进度", "0/" + enemyP.Length + "完成修改值", (float)i/enemyP.Length);
        }
        //清空进度条
        //EditorUtility.ClearProgressBar();
        ShowNotification(new GUIContent($"{ Selection.gameObjects.Length}个游戏的值被修改了"));
    }

    private void OnWizardOtherButton()
    {
        OnWizardCreate();
    }

    //自带的Update 打开 改变值调用
    private void OnWizardUpdate()
    {
        if (Selection.gameObjects.Length>0)
        {
            helpString = $"您当前选择了{Selection.gameObjects.Length}个敌人";
        }
        else
        {
            //提示
            errorString = "请选择至少一个敌人";
        }

        //自动保存改变后的字段 下次还是改变的值
        EditorPrefs.SetInt(changeHealthValueKey, changeHealthValue);
        EditorPrefs.SetInt(changeSinkSpeedValueKey, changeSinkSpeedValue);
    }
    //选择物体发生改变
    private void OnSelectionChange()
    {
        OnWizardUpdate();
    }
}

