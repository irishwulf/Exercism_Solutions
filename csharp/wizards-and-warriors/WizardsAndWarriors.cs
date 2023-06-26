using System;

abstract class Character
{
    private string _characterType;

    protected Character(string characterType) =>
        _characterType = characterType;

    public abstract int DamagePoints(Character target);

    public virtual bool Vulnerable() =>
        false;

    public override string ToString() =>
        $"Character is a {_characterType}";
}

class Warrior : Character
{
    private static readonly int _targetVulnerableDamage = 10;
    private static readonly int _noTargetVulnerableDamage = 6;

    public Warrior() : base("Warrior"){}

    public override int DamagePoints(Character target) =>
        target.Vulnerable() ? _targetVulnerableDamage : _noTargetVulnerableDamage;
}

class Wizard : Character
{
    protected bool _isSpellPrepared;
    private static readonly int _preparedSpellDamage = 12;
    private static readonly int _noPreparedSpellDamage = 3;

    public Wizard() : base("Wizard") =>
        _isSpellPrepared = false;

    public override int DamagePoints(Character target) =>
        _isSpellPrepared ? _preparedSpellDamage : _noPreparedSpellDamage;

    public void PrepareSpell() =>
        _isSpellPrepared = true;

    public override bool Vulnerable() =>
        ! _isSpellPrepared;
}
