using Volo.Abp.Application.Dtos;

namespace PersonelYonetim.Personels
{
    public class GetPersonelListDto : PagedAndSortedResultRequestDto
    {
        public string? FilterText { get; set; }
        public string? Department { get; set; }
        public string? Status { get; set; }
    }

}