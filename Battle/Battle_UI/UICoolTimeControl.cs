using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class UICoolTimeControl : MonoBehaviour
{
    [Header("Skill Image")]
    public Image skill_img;

    public IEnumerator CoolTime (float time)
    {
        float curTime = time;
        while (curTime >= 0)
        {
            curTime -= Time.deltaTime;
            skill_img.fillAmount = curTime / time;
            yield return new WaitForFixedUpdate();
        }
        yield break;
    }    
}
