using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using KensMort.Entities;
using KensMort.Models;
using KensMort.Repositories;
using Microsoft.AspNetCore.Http;
using OfficeOpenXml;

namespace KensMort.Services
{
    public class ScenarioService: IScenarioService
    {
        private IScenarioRepository _scenarioRepository;
        private IMapper _mapper;
        public ScenarioService(IScenarioRepository scenarioRepository,
            IMapper mapper)
        {
            _scenarioRepository = scenarioRepository;
            _mapper = mapper;
        }

        public async void UploadScenarios(IFormFile file)
        { 
            var list = new List<ScenarioModel>();  
  
            await using (var stream = new MemoryStream())  
            {  
                await file.CopyToAsync(stream);  
  
                using (var package = new ExcelPackage(stream))  
                {  
                    ExcelWorksheet worksheet = package.Workbook.Worksheets[0];  
                    var rowCount = worksheet.Dimension.Rows;  
  
                    for (int row = 2; row <= rowCount; row++)  
                    {  
                        list.Add(new ScenarioModel  
                        {  
                            Id = row - 1,
                            Month = Convert.ToInt32(worksheet.Cells[row, 1].Value),
                            Hpi =  Convert.ToDecimal(worksheet.Cells[row, 2].Value),
                            Rate =  Convert.ToDecimal(worksheet.Cells[row, 3].Value)
                        });  
                    }  
                }  
            }

            _scenarioRepository.Upload(_mapper.Map<IList<ScenarioEntity>>(list));
        }

        public async Task<IList<ScenarioModel>> GetAll()
        {
            return _mapper.Map<IList<ScenarioModel>>(await _scenarioRepository.GetAll());
        }
    }
}