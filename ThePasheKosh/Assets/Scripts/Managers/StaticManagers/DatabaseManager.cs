

public static class DatabaseManager 
{
    static HelperDatabaseLoader loader;

    public static TestArray TestArray { get { return loader.TestArray; } }

    public static TestArray LoadConversation(string databaseName)
    {
        return loader.ReturnDatabase(databaseName);
    }


    public static void Initialize()
    {
        loader = new HelperDatabaseLoader();
    }
}//EndClasss/SadeQ
