namespace QuanLySinhVien_ChuDe3
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new frmSinhVien());
        }
    }
}
