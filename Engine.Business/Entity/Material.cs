using Engine.Business.Dto;
using Engine.Business.Infrastructure;
using Engine.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Business.Entity
{
    public class Material : BusinessObject, IBusinessObject<MaterialDto, Data.Model.Material>
    {
        public Material(EngineContext context) : base(context) { }

        public MaterialDto Add(MaterialDto entity)
        {
            var dto = Map(Context.Materials.Add(Map(entity)));
            Context.SaveChanges();
            return dto;
        }

        public MaterialDto Delete(MaterialDto entity)
        {
            var dto = Map(Context.Materials.Remove(Map(entity)));
            Context.SaveChanges();
            return dto;
        }

        public IEnumerable<MaterialDto> Get()
        {
            return Map(Context.Materials);
        }

        public MaterialDto Get(int id)
        {
            return Map(Context.Materials.Find(id));
        }

        public MaterialDto Save(MaterialDto entity)
        {
            Context.Entry(Map(entity)).CurrentValues.SetValues(Map(entity));
            Context.SaveChanges();
            return entity;
        }

        public Data.Model.Material Map(MaterialDto dto)
        {
            return AutoMapper.Mapper.Map<Data.Model.Material>(dto);
        }

        public MaterialDto Map(Data.Model.Material entity)
        {
            return AutoMapper.Mapper.Map<MaterialDto>(entity);
        }

        public IEnumerable<Data.Model.Material> Map(IEnumerable<MaterialDto> dtos)
        {
            return AutoMapper.Mapper.Map<IEnumerable<Data.Model.Material>>(dtos);
        }

        public IEnumerable<MaterialDto> Map(IEnumerable<Data.Model.Material> entities)
        {
            return AutoMapper.Mapper.Map<IEnumerable<MaterialDto>>(entities);
        }
    }
}
