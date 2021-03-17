using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/CreateSkillMaster")]
public class SkillMasterAsset : ScriptableObject
{
    public List<SKillMaster> SkillMasterList = new List<SKillMaster>();
}

[System.Serializable]
public class SKillMaster
{
    public int id = 0;
    public string SkillName = "がんせきおとし";

    [SerializeField]
    public int ratio = 100;
}