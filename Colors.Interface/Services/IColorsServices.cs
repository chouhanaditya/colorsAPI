using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Colors.Domain;

namespace Colors.Interface
{
    public interface IColorsServices
    {
        List<Color> GetAllData();
        List<string> GetAllColorNames();
        List<Color> GetColorByName(string name);
        List<Color> GetColorByType(string type);
        List<Color> GetColorByCategory(string catgory);
        bool AddNewColor(Color colortoAdd);
        bool DeleteColor(string name);
    }
}
