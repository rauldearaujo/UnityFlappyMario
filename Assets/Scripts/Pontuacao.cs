using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pontuacao {
    private int coins;

    public Pontuacao() {
        this.coins = 0;
    }

    public void AddCoins(int qntCoins = 1) {
        this.coins += qntCoins;
    }

    public void RemoveCoins(int qntCoins = 1) {
        this.coins -= qntCoins;
    }

    public int GetCoins() {
        return this.coins;
    }

}
