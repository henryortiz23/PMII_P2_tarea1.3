namespace Ejercicio_1._3;

public partial class App : Application
{
	private static Controllers.DBProc dbProc;

    public static Controllers.DBProc Instancia
    {
        get
        {
            if (dbProc == null)
            {
                string dbname = "PersonasDB.db3";
                string dbpath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                string dbfull = Path.Combine(dbpath, dbname);
                dbProc = new Controllers.DBProc(dbfull);
            }

            return dbProc;
        }
    }
    public App()
	{
		InitializeComponent();

        //MainPage = new AppShell();
        MainPage = new NavigationPage(new MainPage());
    }
}
