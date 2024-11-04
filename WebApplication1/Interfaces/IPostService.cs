using WebApplication1.DTO_S;

namespace WebApplication1.Interfaces
{
    public interface IPostService
    {
        public Task<IEnumerable<PlaceholderDto>> Get();
    }
}
