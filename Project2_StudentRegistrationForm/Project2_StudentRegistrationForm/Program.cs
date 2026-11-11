using System;
using System.Windows.Forms;

namespace Project2_StudentRegistrationForm;

internal static class Program
{
    [STAThread]
    static void Main()
    {
        ApplicationConfiguration.Initialize();
        Application.Run(new Form1());
    }
}
