﻿using Checkout.Interfaces;

namespace Checkout;

public class Checkout : ICheckout
{
    public void Scan(string item)
    {
        throw new NotImplementedException();
    }

    public int GetTotalPrice()
    {
        throw new NotImplementedException();
    }
}