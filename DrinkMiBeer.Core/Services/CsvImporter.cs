using System;
using System.Collections.Generic;
using System.Text;
using CsvHelper;
using DrinkMiBeer.Core.JTOs;
using System.IO;
using System.Threading.Tasks;
namespace DrinkMiBeer.Core.Services
{
    public class CsvImporter
    {

        public  IEnumerable<BeerApiCsvDTO> GetCsv()
        {
                    using (StreamReader reader = new StreamReader("import.txt"))
                    using (var csv = new CsvReader(reader))
                    {

                        return csv.GetRecords<BeerApiCsvDTO>();

                    }
        }
    }
}

