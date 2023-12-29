using System;
using UnityEditor;
using UnityEngine;
using static ItemEffectProvider;

[Serializable]
public class EnhancedAttackInf
{
    public int bulletCount;
}

[Serializable]
public class InvulnerabilityInf
{
    public float InvulnerabilityTime;
    public GameObject InvulnerabilityEffectObj;
}

[CustomEditor(typeof(ItemEffectProvider))]
public class ItemEffectProviderEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        serializedObject.Update();

        var itemEffect = (ItemList)serializedObject.FindProperty("itemEffect").intValue;

        EditorGUILayout.Space();

        switch (itemEffect)
        {
            case ItemList.EnhancedAttack:
                EditorGUILayout.PropertyField(serializedObject.FindProperty("enhancedAttackInf"));
                EditorGUILayout.PropertyField(serializedObject.FindProperty("enhancedAttackInf.bulletCount"));
                break;
            case ItemList.invulnerability:
                EditorGUILayout.PropertyField(serializedObject.FindProperty("invulnerabilityInf"));
                EditorGUILayout.PropertyField(serializedObject.FindProperty("invulnerabilityInf.InvulnerabilityTime"));
                EditorGUILayout.PropertyField(serializedObject.FindProperty("invulnerabilityInf.InvulnerabilityEffectObj"));
                break;
        }    

        serializedObject.ApplyModifiedProperties(); //변경시킨 프로퍼티들 적용
    }
}
// 위의 클래스들은 Enum에 따라 추가 옵션 변수들을 선택할수 있도록 만들어주기 위해 사용됨


public class ItemEffectProvider : MonoBehaviour
{
    public enum ItemList
    {
        EnhancedAttack,
        invulnerability
    }
    public ItemList itemEffect;

    [HideInInspector] public EnhancedAttackInf enhancedAttackInf;
    [HideInInspector] public InvulnerabilityInf invulnerabilityInf;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            switch (itemEffect)
            {
                case ItemList.EnhancedAttack:
                    EnhancedAttackEffect(collision.gameObject);
                    break;
                case ItemList.invulnerability:
                    ImmunityEffect(collision.gameObject);
                    break;
            }

            this.gameObject.SetActive(false);
        }
    }

    public void EnhancedAttackEffect(GameObject player)
    {
        EnhancedAttack enhancedAttack;
        if (player.TryGetComponent<EnhancedAttack>(out enhancedAttack))
        {
            if (!enhancedAttack.enabled)
                enhancedAttack.enabled = true;
            enhancedAttack.CurBulletCnt += enhancedAttackInf.bulletCount;
            enhancedAttack.UpdateBulletState();
        }
        else
        {
            var e = player.AddComponent<EnhancedAttack>();
            e.CurBulletCnt = enhancedAttackInf.bulletCount;
            e.UpdateBulletState();
        }
    }

    public void ImmunityEffect(GameObject player)
    {
        Invulnerability invulnerability;
        if (player.TryGetComponent<Invulnerability>(out invulnerability))
        {
            if (!invulnerability.enabled)
                invulnerability.enabled = true;
            invulnerability.CurEffectTime += invulnerabilityInf.InvulnerabilityTime;
            invulnerability.UpdateImmunityState();
        }
        else
        {
            var e = player.AddComponent<Invulnerability>();
            e.CurEffectTime = invulnerabilityInf.InvulnerabilityTime;
            e.BuffEffect = Instantiate(invulnerabilityInf.InvulnerabilityEffectObj, player.transform);
            e.originColor = e.BuffEffect.GetComponent<SpriteRenderer>().color;
            e.UpdateImmunityState();
        }
    }
}
