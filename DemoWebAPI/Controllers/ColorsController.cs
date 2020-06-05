using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using Newtonsoft.Json;
using Colors.Domain;
using Colors.Services;
using Colors.Interface;
using Microsoft.Extensions.Logging;

namespace ColorsWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ColorsController : ControllerBase
    {
       private readonly IColorsServices _colorsServices;
       private readonly ILogger<ColorsController> _logger;

        public ColorsController(IColorsServices colorsServices, ILogger<ColorsController> logger)
        {
            _colorsServices = colorsServices;
            _logger = logger;
        }

        [HttpGet("GetAllData")]
        public ActionResult<List<Color>> GetAllData()
        {
            List<Color> colorsData = null;
            try
            {
                _logger.LogInformation("ColorsController::GetAllData");
                colorsData = _colorsServices.GetAllData();               
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "ColorsController:GetAllData");
            }
            return colorsData;
        }

        [HttpGet("GetAllColorNames")]
        public ActionResult<IEnumerable<string>> GetAllColorNames()
        {
            List<string> listColorNames = null;
            try
            {
                _logger.LogInformation("ColorsController::GetAllColorNames");
                listColorNames = _colorsServices.GetAllColorNames();                
            }
            catch (Exception ex)
            {
                var logObject = new { response = listColorNames };
                _logger.LogError(ex, "ColorsController:GetAllColorNames {@logObject}", logObject);
            }
            return listColorNames;
        }

        /// <summary>
        /// This method will return  
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        [HttpGet("GetColorByName/{name}")]
        public ActionResult<List<Color>> GetColorByName(string name)
        {
            List<Color> colorData = null;
            try
            {
                _logger.LogInformation("ColorsController::GetColorByName");
                colorData = _colorsServices.GetColorByName(name);

            }
            catch (Exception ex)
            {
                var logObject = new { request = name, response = colorData };
                _logger.LogError(ex, "ColorsController:GetColorByName {@logObject}", logObject);
            }
            return colorData;
        }
              

        [HttpGet("GetColorByType/{type}")]
        public ActionResult<List<Color>> GetColorByType(string type)
        {
            List<Color> colorData = null;
            try
            {
                _logger.LogInformation("ColorsController::GetColorByType");
                colorData = _colorsServices.GetColorByType(type);
            }
            catch (Exception ex)
            {
                var logObject = new { request = type, response = colorData };
                _logger.LogError(ex, "ColorsController:GetColorByType {@logObject}", logObject);
            }
            return colorData;
        }

        [HttpGet("GetColorByCategory/{category}")]
        public ActionResult<List<Color>> GetColorByCategory(string category)
        {
            List<Color> colorData = null;
            try
            {
                _logger.LogInformation("ColorsController::GetColorByCategory");
                colorData = _colorsServices.GetColorByCategory(category);
            }
            catch (Exception ex)
            {
                var logObject = new { request = category, response = colorData };
                _logger.LogError(ex, "ColorsController:GetColorByCategory {@logObject}", logObject);
            }
            return colorData;
        }

        [HttpPost("AddNewColor")]
        public bool AddNewColor(Color colorToAdd)
        {
            var result = false;
            try
            {
                _logger.LogInformation("ColorsController::AddNewColor");
                result = _colorsServices.AddNewColor(colorToAdd);
            }
            catch (Exception ex)
            {
                var logObject = new { request = colorToAdd, response = result };
                _logger.LogError(ex, "ColorsController:AddNewColor {@logObject}", logObject);

            }
            return result;
        }

        [HttpPost("DeleteColor")]
        public bool DeleteColor(string name)
        {
            var result = false;
            try
            {
                _logger.LogInformation("ColorsController::DeleteColor");
                result = _colorsServices.DeleteColor(name);
            }
            catch (Exception ex)
            {
                var logObject = new { request = name, response = result };
                _logger.LogError(ex, "ColorsController:DeleteColor {@logObject}", logObject);
            }
            return result;
        }
    }
}
