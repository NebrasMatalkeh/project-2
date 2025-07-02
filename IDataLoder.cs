using System;

namespace project_2;

public interface IDataLoder
{
    void LoadData(string filePath);

    void SaveData(string filePath);
 
}
