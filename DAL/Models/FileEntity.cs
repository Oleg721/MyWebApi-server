using Dal.Models;

namespace DAL.Models
{
    class FileEntity: BaseEntity<int>
    {
        public string Name { get; set; }
        public string Path { get; set; }
    }
}
