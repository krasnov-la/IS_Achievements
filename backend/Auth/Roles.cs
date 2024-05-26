namespace Auth;

public static class Roles
{
    public static string Default { get; } = "Default";
    public static string Admin { get; } = "Admin";
}

public static class PolicyData
{
    public static string AdminOnlyPolicyName = "admin";
    public static string AdminClaimName = "Admin";
}