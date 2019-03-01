using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace FirstApp.Services.Mapping
{

    public interface IHaveCustomMappings
    {
        void CreateMappings(IMapperConfigurationExpression configuration);
    }

}
