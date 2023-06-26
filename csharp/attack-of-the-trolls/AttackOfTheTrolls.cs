using System;
using System.Collections.Generic;

enum AccountType {
    Guest,
    User,
    Moderator
}

[Flags]
enum Permission : byte {
    Read   = 1 << 0,
    Write  = 1 << 1,
    Delete = 1 << 2,
    All    = Read | Write | Delete,
    None   = 0
}

static class Permissions
{
    public static Permission Default(AccountType accountType) =>
        _defaultPermissions.GetValueOrDefault(accountType);

    public static Permission Grant(Permission current, Permission grant) =>
        current | grant;

    public static Permission Revoke(Permission current, Permission revoke) =>
        current & ~revoke;

    public static bool Check(Permission current, Permission check) =>
        current.HasFlag(check);

    #region fixed values
        private static Dictionary<AccountType,Permission> _defaultPermissions = new() {
            [AccountType.Guest] = Permission.Read,
            [AccountType.User] = Permission.Read | Permission.Write,
            [AccountType.Moderator] = Permission.All
        };
    #endregion
}
