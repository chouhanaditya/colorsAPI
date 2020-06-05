using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.IO;
using Microsoft.Extensions.Options;
using Colors.Interface;
using Colors.Domain;
using file = System.IO.File;


namespace Colors.Services
{
    public class ColorsRepository : IColorsRepository
    {
        private readonly IOptions<LocalJSONConfiguration> _appSettings;

        public ColorsRepository(IOptions<LocalJSONConfiguration> appSettings)
        {
            _appSettings = appSettings;
        }

        public List<Color> GetAllData()
        {
            List<Color> colorData = GetDataFromFile();    
            return colorData;
        }

        public bool AddNewColor(Color colorToAdd)
        {
            bool result = false;
            try
            {
                var colorOldData = GetDataFromFile();
                colorOldData.Add(colorToAdd);
                var colorNewData = JsonConvert.SerializeObject(colorOldData, Formatting.Indented);

                result = UpdateDataInFile(colorNewData);
            }
            catch(Exception ex)
            {
                throw ex;
            }

            return result;
        }

        public bool DeleteColor(string name)
        {
            bool result = false;
            try
            {
                var colorOldData = GetDataFromFile();
                colorOldData.RemoveAll(x => x.Name == name);
                var colorNewData = JsonConvert.SerializeObject(colorOldData, Formatting.Indented);

                result = UpdateDataInFile(colorNewData);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return result;
        }

        #region Private methods

        private bool UpdateDataInFile(string jsonData)
        {
            string jsonFilePath = _appSettings.Value.FilePath;
            if (File.Exists(jsonFilePath))
            {
                using (StreamWriter sw = File.CreateText(jsonFilePath))
                {
                    sw.WriteLine(jsonData);
                }
            }
            return true;
        }

        private List<Color> GetDataFromFile()
        {
            string jsonFilePath = _appSettings.Value.FilePath;
            List<Color> items = null;

            if (file.Exists(jsonFilePath))
            {
                using (StreamReader streamReader = file.OpenText(jsonFilePath))
                {
                    string jsonData = streamReader.ReadToEnd();
                    items = JsonConvert.DeserializeObject<List<Color>>(jsonData);
                }
            }
            return items;
        }
        #endregion

    }
}
