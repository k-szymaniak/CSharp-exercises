using System;


internal class Program
{
    static void Main(string[] args)
    {

        var money1 = Money.OfWithException(10, Currency.USD);
        var money2 = Money.OfWithException(15, Currency.USD);
        Console.WriteLine(money1);
        Console.WriteLine(money1 > money2);
        Console.WriteLine(money1 == money2);
        Console.WriteLine(money1 != money2);
        var money3 = money1.Percent(50);
        Console.WriteLine(money3);
        var money4 = money1.ToCurrency(4, Currency.PLN);
        Console.WriteLine(money4);
    }
}
public enum Currency
{
    PLN = 1,
    USD = 2,
    RUB = 3
}

public class Money : IEquatable<Money>
{
    private readonly decimal _value;
    private readonly Currency _currency;
    private Money(decimal value, Currency currency)
    {
        _value = value;
        _currency = currency;
    }
    public override string ToString()
    {
        return $"{_value} {_currency}";
    }

    public static Money OfWithException(decimal value, Currency currency)
    {
        if (value < 0)
        {
            throw new Exception("Error value<0");
        }

        return new Money(value, currency);
    }

    public static Money ParseValue(string stringValue, Currency currency)
    {
        decimal value = decimal.Parse(stringValue);
        return new Money(value, currency);
    }

    public bool Equals(Money? other)
    {
        if (other == null) return false;
        if (_currency != other.Currency) return false;
        return (_value == other.Value);
    }

    public Currency Currency
    {
        get { return _currency; }
    }
    public decimal Value
    {
        get { return _value; }
    }
    public static Money operator *(Money money, decimal factor)
    {
        return new Money(money.Value * factor, money.Currency);
    }
    public static Money operator +(Money moneya, Money moneyb)
    {
        if (moneya.Currency != moneyb.Currency) throw new Exception("Error Currencies not matching");
        return new Money(moneya.Value + moneyb.Value, moneya.Currency);
    }
    public static bool operator <(Money moneya, Money moneyb)
    {
        if (moneya.Currency != moneyb.Currency) throw new Exception("Error Currencies not matching");
        return (moneya.Value < moneyb.Value);
    }
    public static bool operator >(Money moneya, Money moneyb)
    {
        if (moneya.Currency != moneyb.Currency) throw new Exception("Error Currencies not matching");
        return (moneya.Value > moneyb.Value);
    }
    public static explicit operator float(Money money)
    {
        return (float)money.Value;
    }

}
public class Tank
{
    public readonly int Capacity;
    private int _level;
    public Tank(int capacity)
    {
        Capacity = capacity;
    }
    public int Level
    {
        get { return _level; }
        set
        {
            if (value < 0 || value > Capacity) throw new ArgumentOutOfRangeException();
            _level = value;
        }
    }
    public bool Consume(int w)
    {
        if (w > _level)
        {
            return false;
        }
        Level = _level - w;
        return true;
    }
    public void Refuel(int amount)
    {
        if (amount < 0)
        {
            throw new ArgumentException("Argument cant be non positive!");
        }
        if (_level + amount > Capacity)
        {
            throw new ArgumentException("Argument is to large!");
        }
        _level += amount;
    }
    public bool Refuel(Tank sourceTank, int amount)
    {
        if (this.Level + amount > Capacity)
        {
            return false;
        }
        if (sourceTank.Consume(amount))
        {
            this.Refuel(amount);
            return true;
        }

        return false;
    }

}
public static class MoneyExtension
{
    public static Money Percent(this Money money, decimal percent)
    {
        return Money.OfWithException((money.Value * percent) / 100m, money.Currency);
    }
    public static Money ToCurrency(this Money money, decimal factor, Currency curr)
    {
        return Money.OfWithException(money.Value * factor, curr);
    }
}



