using System.Collections;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController instance { get; private set; }
    public CameraController camera;
    public PlayerController player;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        camera.OnGoldClick += CameraOnGoldClick;
        camera.OnEnemyClick += CameraOnEnemyClick;
        camera.OnFirstSkillClick += CameraOnFirstSkillClick;
        camera.OnSecondSkillClick += CameraOnSecondSkillClick;
        camera.OnThirdSkillClick += CameraOnThirdSkillClick;
    }

    public IEnumerator Delay(Vector3 pos)
    {
        Debug.Log("Щяс пульну");

        yield return new WaitForSeconds(3);
        player.UseThirdSkill(pos);

    }
    private void CameraOnThirdSkillClick(Vector3 pos)
    {
        StartCoroutine(Delay(pos));
    }

    private void CameraOnSecondSkillClick(Vector3 pos)
    {
        player.UseSecondSkill(pos);
    }

    private void CameraOnFirstSkillClick(Vector3 pos)
    {
        player.UseFirstSkill(pos);
    }

    private void CameraOnEnemyClick(EnemyController obj)
    {
        player.MoveAndAttack(obj);
    }

    private void CameraOnGoldClick(GoldLoot obj)
    {
        player.PickUp(obj);
    }
}
