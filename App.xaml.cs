using System;
using Grivinca_Curcean_Medii.Data;
using System.IO;

namespace Grivinca_Curcean_Medii;

public partial class App : Application
{
    static CarListDatabase database;
    public static CarListDatabase Database
    {
        get
        {
            if (database == null)
            {
                database = new CarListDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "ShoppingList.db3"));
            }
            return database;
        }
    }

    public App()
	{
		InitializeComponent();

		MainPage = new AppShell();
	}
}
