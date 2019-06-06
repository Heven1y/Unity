using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoundMe : MonoBehaviour
{
    public static GameObject FindObject(string name, bool bOnlyRoot)
    {
        GameObject[] pAllObjects = (GameObject[])Resources.FindObjectsOfTypeAll(typeof(GameObject));

        foreach (GameObject pObject in pAllObjects)
        {
            if (bOnlyRoot)
            {
                if (pObject.transform.parent != null)
                {
                    continue;
                }
            }

            if (pObject.hideFlags == HideFlags.NotEditable || pObject.hideFlags == HideFlags.HideAndDontSave)
            {
                continue;
            }

#if UNITY_EDITOR
            if (Application.isEditor)
            {
                string sAssetPath = UnityEditor.AssetDatabase.GetAssetPath(pObject.transform.root.gameObject);
                if (!string.IsNullOrEmpty(sAssetPath))
                {
                    continue;
                }
            }
#endif

            if (pObject.name == name)
                return pObject;
        }

        return null;
    }
}
