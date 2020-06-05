using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Colors.Domain;

namespace Colors.Interface
{
    public interface IColorsRepository
    {
        List<Color> GetAllData();
        bool AddNewColor(Color colorToAdd);
        bool DeleteColor(string name);
    }
}
