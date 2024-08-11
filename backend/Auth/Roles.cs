namespace Auth;

public static class Roles
{
    public static string User { get; } = "User";
    public static string Admin { get; } = "Admin";
}

public static class PolicyData
{
    public const string AdminOnlyPolicyName = "admin";
    public const string AdminClaimName = "Admin";
}