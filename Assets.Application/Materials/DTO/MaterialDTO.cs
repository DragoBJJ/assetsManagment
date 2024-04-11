using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.Application.Assets.DTO;
using Assets.Domain;

namespace Assets.Application.Materials.DTO
{
    public class MaterialDTO
    {
        public int AssetId { get; set; }
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public string Description { get; set; } = default!;

        public string? Origin { get; set; }


        public static MaterialDTO? FromEntity(Material? m)
        {

            if (m == null)
            {
                return null;
            }

            return new MaterialDTO()
            {

                AssetId = m.AssetId,
                Id = m.Id,
                Name = m.Name,
                Description = m.Description,
                Origin = m.Origin
                
            };

        }
    }
        };
   
