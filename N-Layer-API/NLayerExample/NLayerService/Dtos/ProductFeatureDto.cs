using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace NLayerService.Dtos
{
    public class ProductFeatureDto
    {
        [JsonIgnore]
        public int Id { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
    }
}
