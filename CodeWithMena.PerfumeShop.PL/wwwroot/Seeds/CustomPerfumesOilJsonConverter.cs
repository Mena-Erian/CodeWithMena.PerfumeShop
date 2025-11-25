using CodeWithMena.PerfumeShop.DAL.Common.Entities;
using CodeWithMena.PerfumeShop.DAL.Common.Enums;
using CodeWithMena.PerfumeShop.DAL.Entities;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace CodeWithMena.PerfumeShop.DAL.Persistence.Data.Seeds
{
    internal class PerfumeOilDto
    {
        public required string Name { get; set; }
        public string? Description { get; set; }
        public string FragranceType { get; set; }
        public string? FragranceFamily { get; set; }
        public int RatingOfSale { get; set; }
        public decimal? SupplierPrice { get; set; }
        public decimal? SalePrice { get; set; }


        public required string Id { get; set; } = string.Empty;
        public required string CreatedBy { get; set; } = string.Empty;
        public string? CreatedOn { get; set; }
        public required string LastModifiedBy { get; set; } = string.Empty;
        public string? LastModifiedOn { get; set; }
    }

    internal class CustomPerfumesOilJsonConverter : JsonConverter<List<PerfumeOil>>
    {
        public override List<PerfumeOil>? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {

            var perfumesDto = JsonSerializer.Deserialize<List<PerfumeOilDto>>(ref reader, options);

            if (perfumesDto is not null)
            {
                var perfumes = perfumesDto.Select(p => new PerfumeOil()
                {
                    Id = Guid.NewGuid(),
                    CreatedBy = p.CreatedBy,
                    LastModifiedBy = p.LastModifiedBy,
                    Name = GetUniquePerfumeName(p, perfumesDto),
                    Description = p.Description,
                    FragranceFamily = p.FragranceFamily is not null ? Enum.Parse<FragranceFamily>(p.FragranceFamily) : null,
                    FragranceType = GetFragranceType(p),
                    PerfumePrice = new()
                    { SupplierPrice = p.SupplierPrice, SalePrice = p.SalePrice },
                    RatingOfSale = p.RatingOfSale,
                });
                return perfumes.ToList();
            }
            return null;

            static FragranceType GetFragranceType(PerfumeOilDto p)
            {
                if (p.FragranceType == "Male and Female")
                {
                    return (FragranceType)3;
                }

                return Enum.Parse<FragranceType>(p.FragranceType);
            }

            static string GetUniquePerfumeName(PerfumeOilDto p, List<PerfumeOilDto> perfumesDto)
            {
                return perfumesDto.Select((perfume, index) => perfume.Name.Contains(p.Name) ? $"D_{index}_{p.Name}" : p.Name).FirstOrDefault(perfume => perfume.Contains(p.Name), p.Name);
            }
        }

        public override void Write(Utf8JsonWriter writer, List<PerfumeOil> value, JsonSerializerOptions options)
        {
            JsonSerializer.Serialize(writer, value, options);
        }
    }
}