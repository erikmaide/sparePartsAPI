using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using Microsoft.VisualBasic.FileIO;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplicationVaruosad.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PartsController : ControllerBase
    {
        // GET: api/<PartsController>
        // /api/parts?page=2&pageSize=50
        [HttpGet]
        public IEnumerable<DTO.PartDTO> Get([FromQuery] SearchParams parameters)
        {
            List<DTO.PartDTO> rows = new List<DTO.PartDTO>();
            using (TextFieldParser parser = new TextFieldParser(@"C:\Users\nelmaid\Desktop\LE.txt"))
            {
                parser.TextFieldType = FieldType.Delimited;
                parser.SetDelimiters("\t");
                while (!parser.EndOfData)
                {
                    //Processing row
                    string[] columns = parser.ReadFields();
                    var part = new DTO.PartDTO();
                    part.Serial = columns[0];
                    part.Name = columns[1];
                    part.Price = double.Parse(columns[8]);
                    part.PriceVAT = columns[10];
                    part.CarModel = columns[9];

                    int stockCount = 0;
                    int.TryParse(columns[2], out stockCount);
                    part.Stock.Add("Tallinn", stockCount);
                    int.TryParse(columns[3], out stockCount);
                    part.Stock.Add("Tartu", stockCount);
                    int.TryParse(columns[4], out stockCount);
                    part.Stock.Add("Pärnu", stockCount);
                    int.TryParse(columns[5], out stockCount);
                    part.Stock.Add("Kohta-Järve", stockCount);
                    int.TryParse(columns[6], out stockCount);

                    rows.Add(part);
                }
            }
            var query = rows.AsQueryable();


            if (!string.IsNullOrEmpty(parameters.SearchByName))
                query = query.Where(d => d.Name.Contains(parameters.SearchByName));


            if (!string.IsNullOrEmpty(parameters.SortedBy))
            {
                if (parameters.SortedBy.ToLower() == "price")
                {
                    query = query.OrderBy(row => row.Price);
                }
                if (parameters.SortedBy.ToLower() == "-price")
                {
                    query = query.OrderByDescending(row => row.Price);
                }
            }
                





            return query.Skip((parameters.PageNumber - 1) * parameters.PageSize)
                .Take(parameters.PageSize).ToList();
               
        }

        // GET api/<PartsController>/5
        [HttpGet("{id}")]
        public string Get(int id)

        {
            return "value";
        }

        // POST api/<PartsController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<PartsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<PartsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
