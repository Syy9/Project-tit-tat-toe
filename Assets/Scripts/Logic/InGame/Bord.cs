using System;

public class Bord
{
    public int BordId { get; private set; }
    public BordType BordType { get; private set; }
    public PlayerType Owner { get; private set; }
    public Action<BordType> OnChangeBordType;
    public Action<PlayerType> OnChangeOwner;
    private Bord()
    {

    }
    public static Bord Create(int bordId)
    {
        var instance = new Bord();
        instance.BordId = bordId;
        instance.BordType = BordType.None;
        return instance;
    }

    public void ChangeBordType(BordType newType)
    {
        BordType = newType;
        OnChangeBordType.Call(newType);
    }

    public void ChangeOwner(PlayerType owner)
    {
        Owner = owner;
        OnChangeOwner.Call(owner);
    }

    public bool HasOwner()
    {
        return BordType == BordType.Checked;
    }
}
