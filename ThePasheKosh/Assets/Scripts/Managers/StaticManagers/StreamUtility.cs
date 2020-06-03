using System.Collections.Generic;


public static class StreamUtility
{
    #region Fields
    static HelperStreamWriterReader Read_Writer;
    #endregion

    #region Properties
    // WriterReader Properties
    public static List<string[]> Linked_WS { get { return Read_Writer.Linked_WS; } set { Read_Writer.Linked_WS = value; } }

    #endregion


    #region Methods
    // for selecting records
    public static void CSVWriter(string pathFile, string dialogue, string[] linkedWords)
    {
        Read_Writer.CSVFileWriter(pathFile, dialogue, linkedWords);
    }
    // for selecting records
    public static void CSVUpdater(string pathFile, string newRecord, int lineToEdit)
    {
        Read_Writer.CSVFileUpdater(pathFile, newRecord, lineToEdit);
    }

    // for reading through dialogues and words
    public static void CSVReader(string pathFile)
    {
        Read_Writer.CSVFileReader(pathFile);
    }
    #endregion


    public static void InitWriterReader()
    {
        Read_Writer = new HelperStreamWriterReader();
    }
    

}//EndClasss/SadeQ
