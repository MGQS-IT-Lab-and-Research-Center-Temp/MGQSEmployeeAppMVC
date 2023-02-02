namespace MGQSEmployeeAppMVC.Shared
{
    public class Helper
    {
        public static string GenerateCode(int id)
        {
            return $"EMP-{id.ToString("0000")}";
        }
    }
}
