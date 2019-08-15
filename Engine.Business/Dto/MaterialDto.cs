using Engine.Business.Infrastructure;
using Engine.Data.Model;
using System.Runtime.Serialization;

namespace Engine.Business.Dto
{
    [DataContract]
    public class MaterialDto : IDto<Material>
    {
        protected Material Entity { get; set; }

        [DataMember]
        public int Id { get; set; }
    }
}
