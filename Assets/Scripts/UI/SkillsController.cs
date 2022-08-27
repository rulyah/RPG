using UnityEngine;

namespace UI
{
    public class SkillsController : WindowController
    {
        [SerializeField] private GameObject _cellPrefab;
        [SerializeField] private Transform parent;

        public override void Init()
        {
            base.Init();
        }
    }
}