using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChipDropController : ItemDropController {
    [SerializeField] private float speedMoveDown = 3f;
    [SerializeField] private int chipNumber;
    public override void AddToPlayer(PlayerBase player) {
        player.LevelerPlayer.AddExp(chipNumber);
        //player.AddChips(numberChip);
    }

    public override void Initalize() {
        base.Initalize();
        StartCoroutine(IMoveDown());
    }

    public void SetChipNumber(int number) {
        chipNumber = number;
    }

    public override void MoveToPlayer(PlayerBase player) {
        StopCoroutine(IMoveDown());
        base.MoveToPlayer(player);
    }

    private IEnumerator IMoveDown() {
        while(true) {
            transform.position += Vector3.down * speedMoveDown * Time.deltaTime;
            yield return new WaitForSeconds(Time.deltaTime);
        }
    }

    private void OnEnable() {
        Initalize();
    }
}
