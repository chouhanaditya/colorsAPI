using System;
using System.Collections.Generic;
using Colors.Interface;
using Colors.Domain;
using System.Linq;

namespace Colors.Services
{
    public class ColorsServices : IColorsServices
    {
        private readonly IColorsRepository _colorsRepository;

        public ColorsServices(IColorsRepository colorsRepository)
        {
            _colorsRepository = colorsRepository;
        }

        public List<Color> GetAllData()
        {
            List<Color> colorsData = _colorsRepository.GetAllData();
            return colorsData;
        }
        public List<string> GetAllColorNames()
        {           
            List<string> listColorNames = null;
            try
            {
                List<Color> colorsData = _colorsRepository.GetAllData();
                listColorNames = colorsData.Select(x => x.Name).ToList();
            }
            catch (Exception ex)
            {
                throw;
            }
            return listColorNames;
        }
        public List<Color> GetColorByName(string name)
        {
            List<Color> colorData = null;
            try
            {
                List<Color> colorsData = _colorsRepository.GetAllData();
                colorData = colorsData.Where(x => x.Name == name).ToList();
            }
            catch (Exception ex)
            {
                throw;
            }
            return colorData;
        }
        public List<Color> GetColorByType(string type)
        {
            List<Color> colorData = null;
            try
            {
                List<Color> colorsData = _colorsRepository.GetAllData();
                colorData = colorsData.Where(x => x.Type == type).ToList();
            }
            catch (Exception ex)
            {
                throw;
            }
            return colorData;
        }
        public List<Color> GetColorByCategory(string category)
        {
            List<Color> colorData = null;
            try
            {
                List<Color> colorsData = _colorsRepository.GetAllData();
                colorData = colorsData.Where(x => x.Category == category).ToList();
            }
            catch (Exception ex)
            {
                throw;
            }
            return colorData;
        }
        public bool AddNewColor(Color colorToAdd)
        {
            var result = false;
            try
            {
                result = _colorsRepository.AddNewColor(colorToAdd);
            }
            catch (Exception ex)
            {
                throw;
                
            }
            return result;
        }
        public bool DeleteColor(string name)
        {
            var result = false;
            try
            {
                result = _colorsRepository.DeleteColor(name);
            }
            catch (Exception ex)
            {
                throw;

            }
            return result;
        }

    }
}
