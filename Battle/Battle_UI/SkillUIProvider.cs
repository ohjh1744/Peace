using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillUIProvider : MonoBehaviour
{
    [Header("BulletUI")]
    public List<UICoolTimeControl> CoolTimeBulletList;
    [Header("Movement")]
    public UICoolTimeControl CoolTimeDash;
}
