using System;
using UnityEngine;
using System.Collections;
using Arrow;
using Effects;
using Enums;
using Equip;
using Inventory;
using Stats;
using Talents;
using UI;

public class PlayerController : MonoBehaviour
{
    
    [SerializeField] private InventoryController _inventory;
    [SerializeField] private SkillsController _skills;
    [SerializeField] private EquipmentController _equipment;
    [SerializeField] private Animator _animator;
    [SerializeField] private CharacterController _controller;
    [SerializeField] private TargetArrow _targetArrow;
    [SerializeField] private DirectionalArrow _directionalArrow;
    [SerializeField] private BallisticArrow _ballisticArrow;
    [SerializeField] private PowerArrow _powerArrow;

    public BattleController battleController;
    private UnitEffects _effects;
    public Equipment equipment;
    public Transform shootPoint;
    public UnitInventory unitInventory;
    public UnitStats _stats;
    public UnitTalents _talents;
    public HealthManaPanel healthManaPanel;
    
   
    public EquipmentState equipmentState;
    public WeaponsType currentWeapon;

    private bool _isShooting;
    private float moveSpeed = 1.0f;
    private float runSpeed = 2.5f;
    public float currentSpeed;
    public float attackRange = 100.0f;
    public int wallet;
    public int currentHealth;
    public int currentMana;
    
    

    public void PickUp(GoldLoot obj)
    {
        var distance = Vector3.Distance(transform.position, obj.transform.position);
        if (!(distance < 1.5f)) return;
        Debug.Log($"You pick up {obj.count.ToString()} gold!");
        Destroy(obj.gameObject);
        wallet += obj.count;
    }

    public void UseFirstSkill(Vector3 pos)
    {
        StartCoroutine(MakeFirstSkill());
    }

    public void Kick()
    {
        _animator.SetTrigger($"{currentWeapon.ToString()}KickTrigger");
    }
    
    public void UseSecondSkill(Vector3 pos)
    {
        for (var i = 0; i <= 9; i++)
        {
            var arr = Instantiate(_ballisticArrow);
            arr.transform.position = shootPoint.position;
            var direction = Vector3.Normalize(pos - arr.transform.position);
            arr.transform.rotation = Quaternion.LookRotation(transform.forward);
            arr.transform.Rotate(-45, 5*(i-4),0);
            arr.Fire();
        }
    }

    public void UseThirdSkill(Vector3 pos)
    {
        var arr = Instantiate(_powerArrow);
        arr.transform.position = shootPoint.position;
        var direction = Vector3.Normalize(pos - arr.transform.position);
        arr.transform.rotation = Quaternion.LookRotation(transform.forward);
    }
    public void MoveAndAttack(EnemyController obj)
    {
        _isShooting = true;
        StartCoroutine(MakeShoot());
    }

    public void Equip(Item item)
    {
        if (equipmentState == EquipmentState.ARMING) return;
        if (equipmentState == EquipmentState.UNARMING) return;
        unitInventory.FindSlot(item).Insert(null);
        var equipmentSlot = equipment.GetSlotByType(item.equipmentType);
        if (item.weaponsType == WeaponsType.GREAT_SWORD)
        {
            Disarm(EquipmentType.LEFT_HAND);
        }
        if (equipmentSlot.item != null)
        {
            Disarm(item.equipmentType);
        }
        StartCoroutine(Delay(1.5f, () =>
        {
            _animator.SetTrigger($"Equip{item.weaponsType.ToString()}Trigger");
            StartCoroutine(Delay(0.5f, () =>
            {
                equipment.Equip(item);
                equipmentState = EquipmentState.ARMED;
                currentWeapon = item.weaponsType;
            }));
        }));
    }

    public void Disarm(EquipmentType type)
    {
        var slot = equipment.GetSlotByType(type);
        if (slot == null) return;
        if (slot.item == null) return;
        var item = slot.item;
        equipmentState = EquipmentState.UNARMING;
        _animator.SetTrigger($"Disarm{currentWeapon.ToString()}Trigger");
        StartCoroutine(Delay(0.5f, () =>
        {
            equipment.DeEquip(type);
            equipmentState = EquipmentState.UNARMED;
        }));
        var emptySlot = unitInventory.FindSlot(null);
        emptySlot.Insert(item);
    }
    
    private IEnumerator Delay(float x, Action action)
    {
        yield return new WaitForSeconds(x);
        action?.Invoke();
    }
    
    private IEnumerator MakeShoot()
    {
        _animator.SetTrigger($"Shoot{currentWeapon.ToString()}Trigger");
        yield return new WaitForSeconds(0.8f);
        var arrow = Instantiate(_directionalArrow);
        arrow.transform.position = shootPoint.transform.position;
        arrow.transform.rotation = shootPoint.transform.rotation;
        //arrow.Shoot();
        yield return new WaitForSeconds(0.5f);
        _isShooting = false;
    }
    
    
    /*private IEnumerator MakeTargetShoot(EnemyController obj)
    {
        _animator.SetTrigger("ShootTriger");
        yield return new WaitForSeconds(0.3f);
        var arrow = Instantiate(targetArrow);
        arrow.transform.position = shootPoint.transform.position;
        arrow.transform.rotation = shootPoint.transform.rotation;
        arrow.Shoot(obj);
        yield return new WaitForSeconds(0.5f);
        _isShooting = false;
    }*/
    private IEnumerator MakeFirstSkill()
    {
        _animator.SetTrigger($"Shoot{currentWeapon.ToString()}Trigger");
        yield return new WaitForSeconds(0.8f);
        for (var i = 0; i <= 4; i++)
        {
            var arrow = Instantiate(_directionalArrow);
            arrow.transform.position = shootPoint.position;
            arrow.transform.rotation = Quaternion.LookRotation(transform.forward);
            arrow.transform.Rotate(0, 9*(i-2),0);
        }
        yield return new WaitForSeconds(0.5f);
        _isShooting = false;
        
    }

    //public int GetStatLvl(StatsType type)
    private void Start()
    {
        _stats = new UnitStats();
        _talents = new UnitTalents();
        battleController = new BattleController(this);
        healthManaPanel.Init();
        _inventory.Init();
        _skills.Init();
        _equipment.Init();
        _effects.Refresh();
    }
//setsiblingindex/transform
    private void Update()
    {
        if (_isShooting) return;
        if (equipmentState == EquipmentState.ARMING) return;
        if (equipmentState == EquipmentState.UNARMING) return;
        var moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical")).normalized;
        currentSpeed = moveSpeed;
        
        if (Input.GetKey(KeyCode.LeftShift))
        {
            currentSpeed = runSpeed;
            moveDirection *= 2;
        }
        
        _animator.SetFloat("Speed", moveDirection.magnitude);

        if (moveDirection == Vector3.zero) return;
        transform.forward = moveDirection.normalized;
        _controller.Move(moveDirection * (currentSpeed * Time.deltaTime));
    }
}
