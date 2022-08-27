using System;
using Enums;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Camera camera;
    public PlayerController player;


    public event Action<GoldLoot> OnGoldClick;
    public event Action<EnemyController> OnEnemyClick;
    public event Action<Vector3> OnFirstSkillClick;
    public event Action<Vector3> OnSecondSkillClick;
    public event Action<Vector3> OnThirdSkillClick;

    public Vector3 firstArrowPosition;


    public Vector3 GetMousePosition() ////////////
    {
        return camera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y,
            20));
    }

    
    void Start()
    {
        firstArrowPosition = player.shootPoint.transform.position;
    }

    void Update()
    {
        
        /*if (Input.GetMouseButtonDown(0))
        {
            var ray = camera.ScreenPointToRay(Input.mousePosition);
            if (!Physics.Raycast(ray, out var hit)) return;
            
            if (hit.transform.CompareTag("Loot"))
            {
                OnGoldClick?.Invoke(hit.transform.GetComponent<GoldLoot>());
            }
            OnEnemyClick?.Invoke(hit.transform.GetComponent<EnemyController>());
        }*/
        
        
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            OnFirstSkillClick?.Invoke(GetMousePosition());
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {

            OnSecondSkillClick?.Invoke(GetMousePosition());
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            OnThirdSkillClick?.Invoke(GetMousePosition());
        }
        
        // Анімації та їх перемикачі
        
        if (Input.GetKeyDown(KeyCode.K))
        {
            player.Kick();
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            player.Equip(player.unitInventory.inventorySlots[0].item);
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            player.Equip(player.unitInventory.inventorySlots[1].item);
        }
        if (Input.GetKeyDown(KeyCode.T))
        {
            player.Equip(player.unitInventory.inventorySlots[2].item);
        }
        if (Input.GetKeyDown(KeyCode.Y))
        {
            player.Equip(player.unitInventory.inventorySlots[3].item);
        }
        if (Input.GetKeyDown(KeyCode.Z))
        {
            player._talents.AddExperience(TalentType.VITALITY, 50);
            Debug.Log($"{player._talents.GetExperience(TalentType.VITALITY).ToString()} exp in vitality");
            Debug.Log($"Vitality have {player._talents.GetTalentLevel(TalentType.VITALITY).ToString()} lvl now");
            Debug.Log($"Vitality need {player._talents.GetNeedExperience(TalentType.VITALITY).ToString()} exp for lvl up");
            Debug.Log(
                $"Now we have {player._stats.GetValue(StatsType.MAX_HEALTH, 2).ToString()} HP");
        }

        if (Input.GetKeyDown(KeyCode.X))
        {
            player.battleController.TakeDamage(10);
        }

        
        
        /////////////////
    }
}
