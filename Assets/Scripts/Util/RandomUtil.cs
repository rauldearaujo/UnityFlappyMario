using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomUtil
{
    private System.Random random;

    public RandomUtil() {
        this.random = new System.Random();
    }

    public float NextDoubleBetween(double max, double min) {
        return (float) (this.random.NextDouble() * (max - min) + min);
    }

}
